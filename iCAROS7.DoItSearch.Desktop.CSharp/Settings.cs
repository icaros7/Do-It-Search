// From https://github.com/Funbit/ets2-telemetry-server/blob/master/source/Funbit.Ets.Telemetry.Server/Helpers/Settings.cs @Funbit

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public class Settings
    {
        #region Settings

        public string Keyword { get; set; }
        public int Max_Cnt { get; set; }
        public bool LoadAtStart { get; set; }
        public int SearchOption { get; set; }
        public string LastLang { get; set; }

        #endregion

        const string ApplicationName = "Do It Search";
        const string SettingsName = "Settings.json";

        public static readonly string SettingsDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationName);
        static readonly string SettingsFileName = Path.Combine(SettingsDirectory, SettingsName);

        public static void Clear()
        {
            if (File.Exists(SettingsFileName))
                File.Delete(SettingsFileName);
            if (Directory.Exists(SettingsDirectory))
                Directory.Delete(SettingsDirectory);
        }

        static Settings Load()
        {
            if (!File.Exists(SettingsFileName))
                return new Settings();
            return JsonConvert.DeserializeObject<Settings>(
                File.ReadAllText(SettingsFileName, Encoding.UTF8));
        }

        public void Save()
        {
            if (!Directory.Exists(SettingsDirectory))
                Directory.CreateDirectory(SettingsDirectory);
            File.WriteAllText(SettingsFileName,
                JsonConvert.SerializeObject(this, Formatting.Indented), Encoding.UTF8);
        }

        static readonly Lazy<Settings> LazyInstance = new Lazy<Settings>(Load);
        public static readonly Settings Instance = LazyInstance.Value;
    }
}