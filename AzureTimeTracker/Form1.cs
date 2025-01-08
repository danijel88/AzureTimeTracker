


using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Timers;
using AzureTimeTracker.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace AzureTimeTracker
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer _timer;
        Stopwatch _stopwatch;
        private double h, m, s, ms;
        private readonly Settings _settings;
        private readonly Dictionary<string, string> _keyValuePair;
        public Form1()
        {
            InitializeComponent();
            _settings = SettingsManager.LoadSettings();
            _keyValuePair = new Dictionary<string, string>();
            lblItemId.Text = string.Empty;
            lblTotalTime.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _stopwatch = new Stopwatch();
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += OnElapsed;
        }

        private void OnElapsed(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ms += 1000;
                if (ms == 1000)
                {
                    ms = 0;
                    s += 1;
                }

                if (s == 60)
                {
                    m += 1;
                    s = 0;
                }

                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                label1.Text = ($"{h.ToString().PadLeft(2,'0')}:{m.ToString().PadLeft(2, '0')}:{s.ToString().PadLeft(2, '0')}");
            }));
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            _timer.Start();
            _stopwatch.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _stopwatch.Stop();
            decimal totalH = Convert.ToDecimal(h);
            decimal totalS = Convert.ToDecimal(s) / (60 * 60);
            decimal totalM = Convert.ToDecimal(m) / 60;
            decimal totalL = Convert.ToDecimal(ms) / (60 * 60 * 60);
            lblTotalTime.Text = (totalH + totalM + totalS + totalL).ToString("F");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _stopwatch.Stop();
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            label1.Text = "00:00:00";
            lblTotalTime.Text = string.Empty;
            lblItemId.Text = string.Empty;
        }
        private async Task FetchTasksAsync()
        {
            lbTasks.Items.Clear();
            _keyValuePair.Clear();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($":{_settings.PersonalAccessToken}")));

                // WIQL query to fetch tasks or user stories
                string url = $"{_settings.OrganizationUrl}/{_settings.DefaultProject}/_apis/wit/wiql?api-version=7.1";
                var wiqlQuery = new
                {
                    query = $"SELECT [System.Id], [System.Title] FROM WorkItems " +
                            $"WHERE [System.WorkItemType] IN ('Task')" +
                            $" AND [System.State] <> 'Closed' " +
                            $" AND [System.TeamProject] = '{_settings.DefaultProject}' " +
                            $" AND [System.AssignedTo] = '{_settings.AssignedTo}'"
                };

                var content = new StringContent(JsonConvert.SerializeObject(wiqlQuery), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    dynamic queryResult = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    if (queryResult.workItems.Count > 0)
                    {
                        string workItemsUrl = string.Empty;
                        JArray workItemsArray = queryResult.workItems as JArray;
                        // Fetch work item details using IDs
                        if (workItemsArray != null)
                        {
                            // Deserialize the JArray to a List<WorkItem>
                            List<AzureTask> workItems = workItemsArray.ToObject<List<AzureTask>>();

                            // Now you can use LINQ to process the workItems list
                            workItemsUrl = $"{_settings.OrganizationUrl}/{_settings.DefaultProject}/_apis/wit/workitems?ids={string.Join(",", workItems.Select(w => w.Id).ToArray())}&fields=System.Title&api-version=7.1";
                        }
                        else
                        {
                            // Handle case where workItemsArray is null or not a valid JArray
                        }

                        response = await client.GetAsync(workItemsUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            dynamic workItems = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                            foreach (var item in workItems.value)
                            {
                                var key = item["id"].ToString();
                                var value = item.fields["System.Title"].ToString();
                                _keyValuePair.Add(key, value);
                                lbTasks.Items.Add($"{key} - {value}");
                            }
                        }
                        else
                        {
                            string errorDetails = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Failed to retrieve work items: {errorDetails}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    string errorDetails = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to execute WIQL query: {errorDetails}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                label1.Text = "00:00:00";
                lblItemId.Text = string.Empty;
                lblTotalTime.Text = string.Empty;
            }
        }
        private async Task PushTimeToTaskAsync(string taskId, string elapsedTime)
        {
            using (var client = new HttpClient())
            {
                // Authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($":{_settings.PersonalAccessToken}")));
                
                // Create the content with the correct content type for PATCH
                var content = new StringContent(JsonConvert.SerializeObject(new object []
                {
                    new { op = "add", path = $"/fields/Completed Work", value = elapsedTime.Replace(',','.') }
                }), Encoding.UTF8, "application/json-patch+json");

                // Build the URL
                string url = $"{_settings.OrganizationUrl}/{_settings.DefaultProject}/_apis/wit/workitems/{taskId}?api-version=6.0";

                // Make the PATCH request
                HttpResponseMessage response = await client.PatchAsync(url, content);

                // Check for failure and show the error message
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to push time to Azure DevOps. Status: {response.StatusCode}. Error: {errorContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Time successfully pushed to Azure DevOps.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            await FetchTasksAsync();
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = lbTasks.SelectedItem;
            var splitSelectedItem = selectedItem.ToString()
                .Trim()
                .Trim('"')
                .Split('-');
            var key = splitSelectedItem[0];
            lblItemId.Text = key;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (lblItemId.Text == string.Empty || lblTotalTime.Text == string.Empty)
            {
                MessageBox.Show("Task must be selected, also time should be grater than 0.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            await PushTimeToTaskAsync(lblItemId.Text, lblTotalTime.Text);

        }
    }
}
