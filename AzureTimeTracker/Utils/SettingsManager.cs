using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace AzureTimeTracker.Utils;

public static class SettingsManager
{
    private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

    public static void SaveSettings(Settings settings)
    {
        string settingsJson = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
        string encryptedSettings = EncryptSettings(settingsJson);

        Directory.CreateDirectory(Path.GetDirectoryName(SettingsFilePath));
        File.WriteAllText(SettingsFilePath, encryptedSettings);
    }

    public static Settings LoadSettings()
    {
        if (!File.Exists(SettingsFilePath))
            return new Settings();
        string fileContent = File.ReadAllText(SettingsFilePath);

        try
        {
            // Attempt to decrypt assuming the file content is encrypted
            string decryptedSettings = DecryptSettings(fileContent);
            return JsonConvert.DeserializeObject<Settings>(decryptedSettings);
        }
        catch (FormatException)
        {
            // If decryption fails, assume file content is plaintext JSON
            var settings = JsonConvert.DeserializeObject<Settings>(fileContent);

            // Save the settings as encrypted for future reads
            SaveSettings(settings);

            return settings;
        }
    }

    private static string EncryptSettings(string plainText)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encryptedBytes);
    }

    private static string DecryptSettings(string encryptedText)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] plainBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(plainBytes);
    }
}