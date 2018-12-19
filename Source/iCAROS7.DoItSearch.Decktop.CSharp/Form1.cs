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
using Microsoft.VisualBasic;
using System.Reflection;
using System.IO;
using log4net.Config;


namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public partial class Form1 : Form
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        Random rand = new Random();
        public int Cnt = 0;
        public int Max_Cnt = 10;
        public string[] keywords;
        private DateTime startTime;
        public Form1()
        {
            InitializeComponent();
            if (Settings.Instance.LoadAtStart == true)
            {
                Keyword.Text = Settings.Instance.Keyword;
                Max_Cnt = Settings.Instance.Max_Cnt;
                loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
            }
            this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            this.Height = Screen.PrimaryScreen.Bounds.Height / 2;
        }

        private void Keyword_Click(object sender, EventArgs e)
        {
            // TO DO: later
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.InfoFormat(@"프로그램 실행");
            int x = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);
        }
        private void OnTick(object sender, EventArgs eventArgs)
        {
            timer1.Interval = rand.Next(5000, Max_Cnt * 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Url = new Uri(@"https://twitter.com/search?q=" + HttpUtility.UrlEncode(keywords[Cnt]));
                if (Cnt == keywords.Length - 1)
                {
                    Cnt = 0;
                }
                else
                {
                    Cnt++;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(@"" + ex);
            }
            //webBrowser1.Url = new Uri(@"https://twitter.com/search?q=" + HttpUtility.UrlEncode(keywords[Cnt]));
            //if (Cnt == keywords.Length - 1)
            //{
            //    Cnt = 0;
            //}
            //else
            //{
            //    Cnt++;
            //}
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Keyword.Text != "")
            {
                keywords = Keyword.Text.Split(',');
                startTime = DateTime.Now;
                label1.Text = @"검색 시간 : 00:00:00";
                Log.InfoFormat(@"검색 시작 : {0}", Keyword.Text);
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"검색 키워드를 입력해 주세요.", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Cnt = 0;
            Log.InfoFormat(@"검색 중지");
            MessageBox.Show(@"중지 되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maxIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maxIntv = Microsoft.VisualBasic.Interaction.InputBox("검색을 할 사이에 잠깐 기다릴 최대 시간 초를 설정 합니다." + "\n" + "30을 입력하는 경우 5~30초 사이를 무작위로 기다립니다.", "검색 최대 간격 설정");

            Log.InfoFormat(@"최대 검색 시간 변경 : {0}", maxIntv);
            try
            {
                Max_Cnt = Int32.Parse(maxIntv);
                if (Max_Cnt < 5)
                {
                    Log.ErrorFormat(@"최대 검색 시간 설정 오류 {0}초", maxIntv);
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(@"5 이상의 숫자로 적어주세요!", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Instance.Max_Cnt = Max_Cnt;
            Settings.Instance.Keyword = Keyword.Text;
            Settings.Instance.LoadAtStart = loadAtStartToolStripMenuItem.Checked;
            Settings.Instance.Save();
            Log.InfoFormat(@"설정 저장 완료");
            MessageBox.Show(@"저장되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keyword.Text = Settings.Instance.Keyword;
            Max_Cnt = Settings.Instance.Max_Cnt;
            loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
            Log.InfoFormat(@"설정 불러오기 완료");
            MessageBox.Show(@"불러왔습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            label1.Text = @"검색 시간 : " + span.ToString(@"hh\:mm\:ss");
        }

        private void 사용법ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"가장 앞쪽 하얀 박스에 검색할 텍스트를 입력합니다." + "\n" + 
                @"','(반점, 콤마) 기호를 이력하여 검색어를 구분합니다." + "\n" +
                @"예시 : 트위터,#트위터" + "\n" +"\n" +
                @"검색 최대 간격 버튼을 눌러 검색 최대간격을 설정합니다. 기본적으로 10초입니다." + "\n" + 
                @"시작을 눌러 검색을 시작합니다." + "\n" + "\n" + 
                @"제작 : hominlab@minnote.net", @"도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startToolStripMenuItem.PerformClick();
                e.Handled = true;
            }
            else
            {
                return;
            }
        }
    }
}
