using System.Globalization;

namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maxIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langKOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Setup_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAtStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Search_Keyword_Label = new System.Windows.Forms.Label();
            this.Keyword = new System.Windows.Forms.TextBox();
            this.Running_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Interval_Type = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.Status_Label = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.MainBtn = new System.Windows.Forms.Button();
            this.HelpLabel = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxIntervalToolStripMenuItem,
            this.langToolStripMenuItem,
            this.Setup_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(355, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maxIntervalToolStripMenuItem
            // 
            this.maxIntervalToolStripMenuItem.Name = "maxIntervalToolStripMenuItem";
            this.maxIntervalToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.maxIntervalToolStripMenuItem.Text = "검색 간격";
            this.maxIntervalToolStripMenuItem.Click += new System.EventHandler(this.maxIntervalToolStripMenuItem_Click);
            // 
            // langToolStripMenuItem
            // 
            this.langToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.langKOToolStripMenuItem,
            this.langENToolStripMenuItem});
            this.langToolStripMenuItem.Name = "langToolStripMenuItem";
            this.langToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.langToolStripMenuItem.Text = "언어 (Language)";
            // 
            // langKOToolStripMenuItem
            // 
            this.langKOToolStripMenuItem.Name = "langKOToolStripMenuItem";
            this.langKOToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.langKOToolStripMenuItem.Text = "한국어";
            this.langKOToolStripMenuItem.Click += new System.EventHandler(this.langKOToolStripMenuItem_Click);
            // 
            // langENToolStripMenuItem
            // 
            this.langENToolStripMenuItem.Name = "langENToolStripMenuItem";
            this.langENToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.langENToolStripMenuItem.Text = "English";
            this.langENToolStripMenuItem.Click += new System.EventHandler(this.langENToolStripMenuItem_Click);
            // 
            // Setup_ToolStripMenuItem
            // 
            this.Setup_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadAtStartToolStripMenuItem,
            this.toolStripMenuItem1,
            this.githubToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.Setup_ToolStripMenuItem.Name = "Setup_ToolStripMenuItem";
            this.Setup_ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.Setup_ToolStripMenuItem.Text = "설정";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "저장";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadToolStripMenuItem.Text = "불러오기";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadAtStartToolStripMenuItem
            // 
            this.loadAtStartToolStripMenuItem.CheckOnClick = true;
            this.loadAtStartToolStripMenuItem.Name = "loadAtStartToolStripMenuItem";
            this.loadAtStartToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadAtStartToolStripMenuItem.Text = "시작시 자동 불러오기";
            this.loadAtStartToolStripMenuItem.Click += new System.EventHandler(this.loadAtStartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.githubToolStripMenuItem.Text = "Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "종료";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Search_Keyword_Label
            // 
            this.Search_Keyword_Label.Location = new System.Drawing.Point(0, 66);
            this.Search_Keyword_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Search_Keyword_Label.Name = "Search_Keyword_Label";
            this.Search_Keyword_Label.Size = new System.Drawing.Size(112, 20);
            this.Search_Keyword_Label.TabIndex = 2;
            this.Search_Keyword_Label.Text = "검색 키워드 :";
            this.Search_Keyword_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Keyword
            // 
            this.Keyword.Location = new System.Drawing.Point(120, 63);
            this.Keyword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Keyword.Name = "Keyword";
            this.Keyword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Keyword.Size = new System.Drawing.Size(222, 27);
            this.Keyword.TabIndex = 3;
            // 
            // Running_Time
            // 
            this.Running_Time.Location = new System.Drawing.Point(0, 96);
            this.Running_Time.Name = "Running_Time";
            this.Running_Time.Size = new System.Drawing.Size(112, 20);
            this.Running_Time.TabIndex = 4;
            this.Running_Time.Text = "검색 시간 :";
            this.Running_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "00:00:00";
            // 
            // Interval_Type
            // 
            this.Interval_Type.BackColor = System.Drawing.SystemColors.Control;
            this.Interval_Type.Location = new System.Drawing.Point(0, 125);
            this.Interval_Type.Name = "Interval_Type";
            this.Interval_Type.Size = new System.Drawing.Size(112, 20);
            this.Interval_Type.TabIndex = 6;
            this.Interval_Type.Text = "검색 간격 :";
            this.Interval_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(198, 123);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 24);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "무작위";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Location = new System.Drawing.Point(120, 123);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(72, 24);
            this.radioButton0.TabIndex = 8;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "고정형";
            this.radioButton0.UseVisualStyleBackColor = true;
            // 
            // Status_Label
            // 
            this.Status_Label.Location = new System.Drawing.Point(0, 36);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(112, 20);
            this.Status_Label.TabIndex = 9;
            this.Status_Label.Text = "상태 :";
            this.Status_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.ForeColor = System.Drawing.Color.Black;
            this.Status.Location = new System.Drawing.Point(116, 36);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(148, 20);
            this.Status.TabIndex = 10;
            this.Status.Text = "작업을 기다리는 중...";
            // 
            // MainBtn
            // 
            this.MainBtn.Location = new System.Drawing.Point(231, 169);
            this.MainBtn.Name = "MainBtn";
            this.MainBtn.Size = new System.Drawing.Size(111, 38);
            this.MainBtn.TabIndex = 11;
            this.MainBtn.Text = "MainBtn";
            this.MainBtn.UseVisualStyleBackColor = true;
            this.MainBtn.Click += new System.EventHandler(this.MainBtn_Click);
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Location = new System.Drawing.Point(13, 178);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(80, 20);
            this.HelpLabel.TabIndex = 12;
            this.HelpLabel.TabStop = true;
            this.HelpLabel.Text = "도움말 (&H)";
            this.HelpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLabel_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 223);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.MainBtn);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.radioButton0);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Interval_Type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Running_Time);
            this.Controls.Add(this.Keyword);
            this.Controls.Add(this.Search_Keyword_Label);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Do It Search";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Setup_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAtStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem maxIntervalToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label Search_Keyword_Label;
        private System.Windows.Forms.TextBox Keyword;
        private System.Windows.Forms.Label Running_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Interval_Type;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button MainBtn;
        private System.Windows.Forms.LinkLabel HelpLabel;
        private System.Windows.Forms.ToolStripMenuItem langToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langKOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
    }
}

