VERSION 5.00
Begin VB.Form Form1 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Bertie Barnard Screensaver"
   ClientHeight    =   3810
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   6555
   Icon            =   "Bertie_Installer.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3810
   ScaleWidth      =   6555
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox Picture4 
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   720
      Picture         =   "Bertie_Installer.frx":548A
      ScaleHeight     =   255
      ScaleWidth      =   255
      TabIndex        =   5
      Top             =   1800
      Width           =   255
   End
   Begin VB.PictureBox Picture3 
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   720
      Picture         =   "Bertie_Installer.frx":78A3
      ScaleHeight     =   255
      ScaleWidth      =   255
      TabIndex        =   4
      Top             =   1440
      Width           =   255
   End
   Begin VB.PictureBox Picture2 
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   720
      Picture         =   "Bertie_Installer.frx":9CBC
      ScaleHeight     =   255
      ScaleWidth      =   255
      TabIndex        =   3
      Top             =   1080
      Width           =   255
   End
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   3840
      Picture         =   "Bertie_Installer.frx":C0D5
      ScaleHeight     =   255
      ScaleWidth      =   2535
      TabIndex        =   0
      Top             =   3360
      Width           =   2535
   End
   Begin VB.Label Label5 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Install Install Flash Player 6.0 ActiveX Control"
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   1080
      TabIndex        =   8
      Top             =   1845
      Width           =   3375
   End
   Begin VB.Label Label4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Install .NET Framework 1.1"
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   1080
      TabIndex        =   7
      Top             =   1485
      Width           =   2655
   End
   Begin VB.Label Label3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Install Bertie Barnard Screensaver"
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   1080
      TabIndex        =   6
      Top             =   1125
      Width           =   2655
   End
   Begin VB.Label Label2 
      BackColor       =   &H00FFFFFF&
      Caption         =   $"Bertie_Installer.frx":10287
      ForeColor       =   &H00C00000&
      Height          =   615
      Left            =   480
      TabIndex        =   2
      Top             =   2640
      Width           =   5655
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Bertie Barnard Screensaver 1.0"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   240
      Width           =   5055
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
 Private Type STARTUPINFO
      cb As Long
      lpReserved As String
      lpDesktop As String
      lpTitle As String
      dwX As Long
      dwY As Long
      dwXSize As Long
      dwYSize As Long
      dwXCountChars As Long
      dwYCountChars As Long
      dwFillAttribute As Long
      dwFlags As Long
      wShowWindow As Integer
      cbReserved2 As Integer
      lpReserved2 As Long
      hStdInput As Long
      hStdOutput As Long
      hStdError As Long
   End Type

   Private Type PROCESS_INFORMATION
      hProcess As Long
      hThread As Long
      dwProcessID As Long
      dwThreadID As Long
   End Type

   Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal _
      hHandle As Long, ByVal dwMilliseconds As Long) As Long

   Private Declare Function CreateProcessA Lib "kernel32" (ByVal _
      lpApplicationName As String, ByVal lpCommandLine As String, ByVal _
      lpProcessAttributes As Long, ByVal lpThreadAttributes As Long, _
      ByVal bInheritHandles As Long, ByVal dwCreationFlags As Long, _
      ByVal lpEnvironment As Long, ByVal lpCurrentDirectory As String, _
      lpStartupInfo As STARTUPINFO, lpProcessInformation As _
      PROCESS_INFORMATION) As Long

   Private Declare Function CloseHandle Lib "kernel32" _
      (ByVal hObject As Long) As Long

   Private Declare Function GetExitCodeProcess Lib "kernel32" _
      (ByVal hProcess As Long, lpExitCode As Long) As Long

   Private Const NORMAL_PRIORITY_CLASS = &H20&
   Private Const INFINITE = -1&

   Public Function ExecCmd(cmdline$)
      Dim proc As PROCESS_INFORMATION
      Dim start As STARTUPINFO

      ' Initialize the STARTUPINFO structure:
      start.cb = Len(start)

      ' Start the shelled application:
      ret& = CreateProcessA(vbNullString, cmdline$, 0&, 0&, 1&, _
         NORMAL_PRIORITY_CLASS, 0&, vbNullString, start, proc)

      ' Wait for the shelled application to finish:
         ret& = WaitForSingleObject(proc.hProcess, INFINITE)
         Call GetExitCodeProcess(proc.hProcess, ret&)
         Call CloseHandle(proc.hThread)
         Call CloseHandle(proc.hProcess)
         ExecCmd = ret&
   End Function






Private Sub Label3_Click()
Me.Hide
Dim retval As Long
retval = -1
retval = ExecCmd(App.Path & "\Distribute\Simple Screensaver Installer.exe")

If retval = 0 Then
    Me.Show
Else
 Me.Show
End If

End Sub

Private Sub Label4_Click()
Me.Hide
Dim retval As Long
retval = -1
retval = ExecCmd(App.Path & "\Distribute\dotnetfx.exe")

If retval = 0 Then
Me.Show
Else
Me.Show
End If

End Sub

Private Sub Label5_Click()
Me.Hide
Dim retval As Long
retval = -1
retval = ExecCmd(App.Path & "\Distribute\Install Flash Player 6 AX.exe")

If retval = 0 Then
Me.Show
Else
Me.Show
End If

End Sub

