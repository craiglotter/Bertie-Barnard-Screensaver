Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AxShockwaveFlash1 As AxShockwaveFlashObjects.AxShockwaveFlash
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button
        Me.AxShockwaveFlash1 = New AxShockwaveFlashObjects.AxShockwaveFlash
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(208, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'AxShockwaveFlash1
        '
        Me.AxShockwaveFlash1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxShockwaveFlash1.Enabled = True
        Me.AxShockwaveFlash1.Location = New System.Drawing.Point(0, 0)
        Me.AxShockwaveFlash1.Name = "AxShockwaveFlash1"
        Me.AxShockwaveFlash1.OcxState = CType(resources.GetObject("AxShockwaveFlash1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxShockwaveFlash1.Size = New System.Drawing.Size(292, 266)
        Me.AxShockwaveFlash1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.AxShockwaveFlash1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Error_Handler(ByVal Message As String)
        Try
            MsgBox("Sorry, but the following error has been trapped by Simple Screensaver 1.0: " & vbCrLf & Message, MsgBoxStyle.Exclamation, "Simple Screensaver 1.0 Error")
        Catch ex As Exception
            MsgBox("Sorry, but the following error has been trapped by Simple Screensaver 1.0: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Simple Screensaver 1.0 Error")
        End Try
    End Sub

    Private Sub Exit_Routine()
        Try
            Application.Exit()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Loader()
        Try
            AxShockwaveFlash1.Movie = Application.StartupPath & "\screensaver.swf"
            Dim point As New System.Drawing.Point(0, 0)
            Button1.Top = Screen.GetBounds(point).Height - (Button1.Height + 10)
            Button1.Left = Screen.GetBounds(point).Width - (Button1.Width + 10)
            Button1.Focus()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Exit_Routine()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Button_Lose_Focus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.Focus()
    End Sub

    Private Sub Mouse_Move(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        MsgBox("hello")
    End Sub

    Private Sub Capture_Keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, Button1.KeyPress
        Try
            If Not IsNothing(e.KeyChar) Then
                e.Handled = True
                Exit_Routine()
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            
            Loader()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub




End Class
