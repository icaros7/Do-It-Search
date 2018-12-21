/*
 * Do It Search: A Simple Twitter Searching Program
 * 2018.12.17 / Homin Rhee
 * 
 * Github Repo : https://github.com/icaros7/Do-It-Search
 * 
 * Powered by hominlab@minnote.net
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Reflection;
using System.IO;
using log4net.Config;
using System.Globalization;
using System.Threading;


namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public partial class MainForm : Form
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int Cnt = 0; // Keyword's count
        private string[] keywords; // Stroage for split keyword by ','
        private DateTime startTime; // Stroage for Running time
        protected int Max_Cnt = 5; // Max Interval time
        public MainForm()
        {
            InitializeComponent();

            // Load Settings
            if (Settings.Instance.LoadAtStart == true)
            {
                try
                {
                    loadSettings();
                    if (Settings.Instance.LastLang == null) // Prevent Crashing, if updating old version
                    {
                        Settings.Instance.LastLang = "ko";
                        Settings.Instance.Save();
                    }
                    ChangeLang(Settings.Instance.LastLang);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat(strLang.Log_Error_Load);
                    Log.Error(ex);
                    MessageBox.Show(strLang.Load_Loaded_Error, strLang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                applyLocale(CultureInfo.CurrentUICulture.Name.Substring(0, 2)); // This Application doesn't support region code.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.InfoFormat(strLang.Log_Form_Load);
            MainBtn.Text = strLang.MainBtn_Start;
            Status.Text = strLang.Status_Wait;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                WebBrowser wb = new WebBrowser();
                wb.Url = new Uri(@"https://twitter.com/search?q=" + HttpUtility.UrlEncode(keywords[Cnt]));

                // Status Labeling
                if (keywords[Cnt].Length < 10)
                {
                    Status.Text = keywords[Cnt] + strLang.Status_Searching;
                }
                else
                {
                    Status.Text = keywords[Cnt].Substring(0, 9) + strLang.Status_Searching_Long;
                }

                // Multi-Keyword Searching
                if (Cnt == keywords.Length - 1)
                {
                    // Goto 1st keyword
                    Cnt = 0;
                }
                else
                {
                    Cnt++;
                }

                wb.Dispose(); // Dispose oject for prevent RAM leak
                if (radioButton1.Checked == true)
                {
                    // set interval to rand
                    Random rand = new Random();
                    timer1.Interval = rand.Next(1000, Max_Cnt * 1000);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(strLang.Log_Error_Process);
                Log.Error(ex);
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = strLang.Status_Searching_Error;
            }
        }

        private void maxIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetIntervalForm settingForm = new SetIntervalForm(Max_Cnt);
            if (settingForm.ShowDialog() == DialogResult.OK)
            {
                Max_Cnt = Int32.Parse(settingForm.textBox1.Text);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Instance.Max_Cnt = Max_Cnt;
                Settings.Instance.Keyword = Keyword.Text;
                Settings.Instance.LoadAtStart = loadAtStartToolStripMenuItem.Checked;
                if (radioButton0.Checked == true)
                {
                    Settings.Instance.SearchOption = 0;
                }
                else if (radioButton1.Checked == true)
                {
                    Settings.Instance.SearchOption = 1;
                }
                Settings.Instance.Save();
                Log.InfoFormat(strLang.Log_Save);
                MessageBox.Show(strLang.Save_Saved, strLang.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(strLang.Log_Error_Save);
                Log.Error(ex);
                MessageBox.Show(strLang.Save_Saved_Error, strLang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSettings();
            MessageBox.Show(strLang.Load_Loaded, strLang.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadSettings()
        {
            try
            {
                Keyword.Text = Settings.Instance.Keyword;
                Max_Cnt = Settings.Instance.Max_Cnt;
                if (Max_Cnt < 1) // Prevent crash If settings value is 0
                {
                    Max_Cnt = 5;
                }
                loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
                if (Settings.Instance.SearchOption == 0)
                {
                    radioButton0.Checked = true;
                }
                else if (Settings.Instance.SearchOption == 1)
                {
                    radioButton1.Checked = true;
                }
                Log.InfoFormat(strLang.Log_Load);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(strLang.Log_Error_Load);
                Log.Error(ex);
                MessageBox.Show(strLang.Load_Loaded_Error, strLang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadAtStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadAtStartToolStripMenuItem.Checked == true)
            {
                Settings.Instance.LoadAtStart = true;
                saveToolStripMenuItem.PerformClick();
            }
            else
            {
                Settings.Instance.LoadAtStart = false;
                saveToolStripMenuItem.PerformClick();
            }
            Log.InfoFormat(strLang.Log_Changed_LoadAtStart);
        }

        private void timer2_Tick(object sender, EventArgs e) // Running Timer
        {
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
            label1.Text = span.ToString(@"hh\:mm\:ss");
        }

        private void HelpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(strLang.Help_1 + "\n" +
                strLang.Help_2 + "\n" + "\n" +
                strLang.Help_3 + "\n" +
                strLang.Help_4 + "\n" +
                strLang.Help_5 + "\n" +
                strLang.Help_6 + "\n" + "\n" +
                strLang.Help_7 + "\n" +
                strLang.Help_8 + "\n" + "\n" +
                strLang.Help_9,
                strLang.Help_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            if (MainBtn.Text == strLang.MainBtn_Start)
            {
                if (Keyword.Text != "")
                {
                    keywords = Keyword.Text.Split(',');
                    startTime = DateTime.Now;
                    label1.Text = @"00:00:00";
                    Log.InfoFormat(strLang.Status_Start + @" : {0}", Keyword.Text);
                    MainBtn.Text = strLang.MainBtn_Stop;
                    timer1.Interval = Max_Cnt * 1000;
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    Status.ForeColor = System.Drawing.Color.Black;
                    Status.Text = strLang.Status_Start;
                }
                else
                {
                    MessageBox.Show(strLang.Error_Type_Keyword, strLang.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.ErrorFormat(strLang.Log_Error_Blank_Keyword);
                }
            }
            else if (MainBtn.Text == strLang.MainBtn_Stop)
            {
                MainBtn.Text = strLang.MainBtn_Start;
                timer1.Enabled = false;
                timer2.Enabled = false;
                Cnt = 0;
                Log.InfoFormat(strLang.Status_Stop);
                Status.ForeColor = System.Drawing.Color.Black;
                Status.Text = strLang.Status_Stop;
                MessageBox.Show(strLang.Msg_Stop, strLang.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Status.Text = strLang.Status_Wait;
            }
            else
            {
                MessageBox.Show(strLang.Msg_abnormal_1 + "\n" +
                    strLang.Msg_abnormal_2, strLang.Msg_abnormal_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.ErrorFormat(strLang.Log_abnormal);
                Application.Exit();
            }
        }

        private void ChangeLang(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Settings.Instance.LastLang = lang;
            Settings.Instance.Save();
            applyLocale(lang);
        }

        private void langKOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strLang.Msg_Lang_Change_Log, strLang.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loggingLangChange("ko");
            ChangeLang("ko");
        }

        private void langENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strLang.Msg_Lang_Change_Log, strLang.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loggingLangChange("en");
            ChangeLang("en");
        }

        private void loggingLangChange(string lang)
        {
            Log.InfoFormat(strLang.Log_Lang_Change + @" : " + CultureInfo.CurrentUICulture.Name.Substring(0, 2) + @" -> " + lang);
        }

        private void applyLocale(string lang)
        {
            if (MainBtn.Text == "시작 (&E)" || MainBtn.Text == "Start (&E)" || MainBtn.Text == "MainBtn")
            {
                maxIntervalToolStripMenuItem.Text = strLang.maxIntervalToolStripMenuItem;
                Setup_ToolStripMenuItem.Text = strLang.Setup_ToolStripMenuItem;
                Status_Label.Text = strLang.Status_Label;
                Search_Keyword_Label.Text = strLang.Search_Keyword_Label;
                Running_Time.Text = strLang.Running_Time;
                Interval_Type.Text = strLang.Interval_Type;
                radioButton0.Text = strLang.radioButton0;
                radioButton1.Text = strLang.radioButton1;
                HelpLabel.Text = strLang.Help_Label;
                MainBtn.Text = strLang.MainBtn_Start;
                Status.Text = strLang.Status_Wait;
                saveToolStripMenuItem.Text = strLang.saveToolStripMenuItem;
                loadAtStartToolStripMenuItem.Text = strLang.loadAtStartToolStripMenuItem;
                loadToolStripMenuItem.Text = strLang.loadToolStripMenuItem;
                exitToolStripMenuItem.Text = strLang.exitToolStripMenuItem;
                if (lang != "ko") // Reconfig Some control location for Korean
                {
                    Status_Label.Location = new Point(52,36);
                    Search_Keyword_Label.Location = new Point(35, 66);
                    Running_Time.Location = new Point(60, 96);
                    Interval_Type.Location = new Point(43, 125);
                }
                else
                {
                    Status_Label.Location = new Point(65, 36);
                    Search_Keyword_Label.Location = new Point(15, 66);
                    Running_Time.Location = new Point(30, 96);
                    Interval_Type.Location = new Point(30, 125);
                }
            }
            else
            {
                MessageBox.Show(strLang.Msg_Change_HaveTo_Waiting, strLang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/icaros7/Do-It-Search");
        }
    }
}
