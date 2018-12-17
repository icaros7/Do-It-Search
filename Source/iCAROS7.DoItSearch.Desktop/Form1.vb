Public Class Form1
    Private Sub SetIntervalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetIntervalToolStripMenuItem.Click
        Dim Interval As Integer
        Try
            Interval = InputBox("반복 딜레이를 ms 단위로 설정해주세요." + vbCrLf + "1000ms = 1초", "간격 설정", "2000")
        Catch ex As Exception
            MessageBox.Show("정상적인 값이 아닙니다!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Timer1.Interval = Interval
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width / 2
        Me.Height = Screen.PrimaryScreen.Bounds.Height / 2
        Dim x As Int32
        Dim y As Int32
        x = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        y = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
        Me.Location = New Point(x, y)
        LoadatStartToolStripMenuItem.Checked = My.Settings.LoadAtStart
        If (LoadatStartToolStripMenuItem.CheckState = CheckState.Checked) Then
            Timer1.Interval = My.Settings.Interval
            TextBox1.Text = My.Settings.Keyword
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SetKeywordToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Key As String
        Key = InputBox("추가할 키워드를 입력 해 주세요." + vbCrLf + "현재 키워드 : " + TextBox1.Text, "키워드 설정")
        TextBox1.Text = Key
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        WebBrowser1.Url = New Uri("https://twitter.com/search?q=" + TextBox1.Text)
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        WebBrowser1.Url = New Uri("https://twitter.com/search?q=" + TextBox1.Text)
        Timer1.Enabled = True
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        Timer1.Enabled = False
        MessageBox.Show("중지 완료했습니다.", "중지", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SetSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetSaveToolStripMenuItem.Click
        My.Settings.Interval = Timer1.Interval
        My.Settings.Keyword = TextBox1.Text
    End Sub

    Private Sub SetLoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetLoadToolStripMenuItem.Click
        Timer1.Interval = My.Settings.Interval
        TextBox1.Text = My.Settings.Keyword
    End Sub

    Private Sub LoadatStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadatStartToolStripMenuItem.Click
        If LoadatStartToolStripMenuItem.CheckState = CheckState.Checked Then
            My.Settings.LoadAtStart = False
            LoadatStartToolStripMenuItem.Checked = False
        Else
            My.Settings.LoadAtStart = True
            LoadatStartToolStripMenuItem.Checked = True
        End If
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            StartToolStripMenuItem_Click(sender, New System.EventArgs())
        End If
    End Sub
End Class
