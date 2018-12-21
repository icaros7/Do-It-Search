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


namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public partial class MainForm : Form
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int Cnt = 0;
        private string[] keywords;
        private DateTime startTime;
        protected int Max_Cnt = 5;
        public MainForm()
        {
            InitializeComponent();

            // Load Settings
            if (Settings.Instance.LoadAtStart == true)
            {
                loadSettings();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.InfoFormat(@"프로그램 실행");
            MainBtn.Text = @"시작 (&E)";
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
                    Status.Text = keywords[Cnt] + @" 검색 중";
                }
                else
                {
                    Status.Text = keywords[Cnt].Substring(0, 9) + @"... 검색 중";
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

                wb.Dispose();
                if (radioButton1.Checked == true)
                {
                    // set interval to rand
                    Random rand = new Random();
                    timer1.Interval = rand.Next(1000, Max_Cnt * 1000);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(@"프로세스 오류 : ");
                Log.Error(ex);
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = @"검색 오류 (로그 참조)";
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
                Log.InfoFormat(@"설정 저장 완료");
                MessageBox.Show(@"저장되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(@"설정 저장 오류 : ");
                Log.Error(ex);
                MessageBox.Show(@"설정 저장 오류. 로그를 확인하세요.", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSettings();
            MessageBox.Show(@"불러왔습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadSettings()
        {
            try
            {
                Keyword.Text = Settings.Instance.Keyword;
                Max_Cnt = Settings.Instance.Max_Cnt;
                loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
                if (Settings.Instance.SearchOption == 0)
                {
                    radioButton0.Checked = true;
                }
                else if (Settings.Instance.SearchOption == 1)
                {
                    radioButton1.Checked = true;
                }
                Log.InfoFormat(@"설정 불러오기 완료");
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(@"설정 불러오기 오류 : ");
                Log.Error(ex);
                MessageBox.Show(@"설정 불러오기 오류. 로그를 확인하세요.", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Log.InfoFormat(@"시작시 설정 불러오기 상태 전환");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
            label1.Text = span.ToString(@"hh\:mm\:ss");
        }

        private void HelpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"가장 앞쪽 하얀 박스에 검색할 텍스트를 입력합니다." + "\n" +
                @"','(반점, 콤마) 기호를 이력하여 검색어를 구분합니다." + "\n" +
                @"예시 : 트위터,#트위터" + "\n" + "\n" +
                @"검색 최대 간격 버튼을 눌러 검색 최대간격을 설정합니다. 기본적으로 3초입니다." + "\n" +
                @"시작을 눌러 검색을 시작합니다." + "\n" + "\n" +
                @"제작 : hominlab@minnote.net", @"도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            if (MainBtn.Text == @"시작 (&E)")
            {
                if (Keyword.Text != "")
                {
                    keywords = Keyword.Text.Split(',');
                    startTime = DateTime.Now;
                    label1.Text = @"00:00:00";
                    Log.InfoFormat(@"검색 시작 : {0}", Keyword.Text);
                    MainBtn.Text = @"중지 (&E)";
                    timer1.Interval = Max_Cnt * 1000;
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    Status.ForeColor = System.Drawing.Color.Black;
                    Status.Text = @"검색 시작";
                }
                else
                {
                    MessageBox.Show(@"검색 키워드를 입력해 주세요.", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (MainBtn.Text == @"중지 (&E)")
            {
                MainBtn.Text = @"시작 (&E)";
                timer1.Enabled = false;
                timer2.Enabled = false;
                Cnt = 0;
                Log.InfoFormat(@"검색 중지");
                Status.ForeColor = System.Drawing.Color.Black;
                Status.Text = @"검색 중지";
                MessageBox.Show(@"중지 되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Status.Text = @"작업을 기다리는 중...";
            }
            else
            {
                MessageBox.Show(@"프로그램이 정상적으로 실행되지 않았습니다!" + "\n" +
                    @"재시작을 위해 종료 합니다!", @"비정상 실행 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.ErrorFormat(@"Form Initialize 혹은 Load 실패");
                Application.Exit();
            }
        }
    }
}
