namespace AzureTimeTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            bntStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            lbTasks = new ListBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            btnSave = new Button();
            txtDescription = new RichTextBox();
            label4 = new Label();
            lblTotalTime = new Label();
            label3 = new Label();
            lblItemId = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Maiandra GD", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(387, 19);
            label1.Name = "label1";
            label1.Size = new Size(309, 77);
            label1.TabIndex = 0;
            label1.Text = "00:00:00";
            // 
            // bntStart
            // 
            bntStart.BackColor = Color.FromArgb(0, 251, 151);
            bntStart.FlatStyle = FlatStyle.Popup;
            bntStart.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bntStart.ForeColor = Color.White;
            bntStart.Location = new Point(354, 121);
            bntStart.Name = "bntStart";
            bntStart.Size = new Size(102, 39);
            bntStart.TabIndex = 1;
            bntStart.Text = "Start";
            bntStart.UseVisualStyleBackColor = false;
            bntStart.Click += bntStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(247, 86, 91);
            btnStop.FlatStyle = FlatStyle.Popup;
            btnStop.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(494, 121);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(102, 39);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(25, 130, 196);
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(622, 121);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(102, 39);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lbTasks
            // 
            lbTasks.FormattingEnabled = true;
            lbTasks.ItemHeight = 15;
            lbTasks.Location = new Point(12, 19);
            lbTasks.Name = "lbTasks";
            lbTasks.Size = new Size(272, 139);
            lbTasks.TabIndex = 4;
            lbTasks.SelectedIndexChanged += lbTasks_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.SkyBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 173);
            button1.Name = "button1";
            button1.Size = new Size(272, 49);
            button1.TabIndex = 5;
            button1.Text = "Fetch Tasks";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblTotalTime);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblItemId);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(358, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 280);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "DATA TO SAVE:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 251, 151);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(17, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(321, 39);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(17, 112);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(321, 96);
            txtDescription.TabIndex = 5;
            txtDescription.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 94);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 4;
            label4.Text = "Description:";
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTime.Location = new Point(79, 56);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(19, 21);
            lblTotalTime.TabIndex = 3;
            lblTotalTime.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 61);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Total time:";
            // 
            // lblItemId
            // 
            lblItemId.AutoSize = true;
            lblItemId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemId.Location = new Point(59, 22);
            lblItemId.Name = "lblItemId";
            lblItemId.Size = new Size(41, 21);
            lblItemId.TabIndex = 1;
            lblItemId.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 27);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Item Id:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 38, 48);
            ClientSize = new Size(760, 489);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(lbTasks);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(bntStart);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Azure Time Tracker";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button bntStart;
        private Button btnStop;
        private Button btnReset;
        private ListBox lbTasks;
        private Button button1;
        private GroupBox groupBox1;
        private Label lblItemId;
        private Label label2;
        private Label label3;
        private Label lblTotalTime;
        private Button btnSave;
        private RichTextBox txtDescription;
        private Label label4;
    }
}
