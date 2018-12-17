<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RemoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetIntervalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetLoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadatStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 35)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(800, 415)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("https://twitter.com/", System.UriKind.Absolute)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextBox1, Me.RemoteToolStripMenuItem, Me.SetIntervalToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 35)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RemoteToolStripMenuItem
        '
        Me.RemoteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.RemoteToolStripMenuItem.Name = "RemoteToolStripMenuItem"
        Me.RemoteToolStripMenuItem.Size = New System.Drawing.Size(60, 31)
        Me.RemoteToolStripMenuItem.Text = "동작"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.StartToolStripMenuItem.Text = "시작"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.StopToolStripMenuItem.Text = "중지"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.ExitToolStripMenuItem.Text = "종료"
        '
        'SetIntervalToolStripMenuItem
        '
        Me.SetIntervalToolStripMenuItem.Name = "SetIntervalToolStripMenuItem"
        Me.SetIntervalToolStripMenuItem.Size = New System.Drawing.Size(102, 31)
        Me.SetIntervalToolStripMenuItem.Text = "간격 설정"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetSaveToolStripMenuItem, Me.SetLoadToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoadatStartToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(181, 31)
        Me.SettingsToolStripMenuItem.Text = "설정 저장/불러오기"
        '
        'SetSaveToolStripMenuItem
        '
        Me.SetSaveToolStripMenuItem.Name = "SetSaveToolStripMenuItem"
        Me.SetSaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SetSaveToolStripMenuItem.Size = New System.Drawing.Size(270, 30)
        Me.SetSaveToolStripMenuItem.Text = "저장하기"
        '
        'SetLoadToolStripMenuItem
        '
        Me.SetLoadToolStripMenuItem.Name = "SetLoadToolStripMenuItem"
        Me.SetLoadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.SetLoadToolStripMenuItem.Size = New System.Drawing.Size(270, 30)
        Me.SetLoadToolStripMenuItem.Text = "불러오기"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(267, 6)
        '
        'LoadatStartToolStripMenuItem
        '
        Me.LoadatStartToolStripMenuItem.Checked = True
        Me.LoadatStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LoadatStartToolStripMenuItem.Name = "LoadatStartToolStripMenuItem"
        Me.LoadatStartToolStripMenuItem.Size = New System.Drawing.Size(270, 30)
        Me.LoadatStartToolStripMenuItem.Text = "시작시 설정 불러오기"
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 31)
        Me.TextBox1.Text = "트위터"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Do It Search"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RemoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetIntervalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetSaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetLoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents LoadatStartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As ToolStripTextBox
End Class
