Module Program_Launcher

    Private Sub Error_Handler(ByVal Message As String)
        Try
            MsgBox("Sorry, but the following error has been trapped by Simple Screensaver 1.0: " & vbCrLf & Message, MsgBoxStyle.Exclamation, "Simple Screensaver 1.0 Error")
        Catch ex As Exception
            MsgBox("Sorry, but the following error has been trapped by Simple Screensaver 1.0: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Simple Screensaver 1.0 Error")
        End Try
    End Sub

    Public Sub main()
        Try

            If CheckForExistingInstance() = False Then



                Dim arguments As String()
                arguments = GetCommandLineArgs()

                Dim displaysaver As Screensaver
                displaysaver = New Screensaver
                Dim displayoptions As Configuration
                displayoptions = New Configuration
                Dim displaypreview As Preview
                displaypreview = New Preview

                If arguments.Length > 0 Then
                    If arguments(0).ToLower.StartsWith("/c") = True Then
                        Application.Run(displayoptions)

                    End If
                    If arguments(0).ToLower.StartsWith("/p") = True Then
                        SetForm(displaypreview, arguments(1))
                        Application.Run(displaypreview)
                    End If
                    If arguments(0).ToLower.StartsWith("/s") = True Then
                        displaysaver.ShowDialog()
                    End If
                Else
                    displaysaver.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Function GetCommandLineArgs() As String()

        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)

        Return args

    End Function

    Public Function CheckForExistingInstance() As Boolean
        'Get number of processes of you program
        Dim result As Boolean

        If Process.GetProcessesByName _
          (Process.GetCurrentProcess.ProcessName).Length > 1 Then

            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Private Sub SetForm(ByRef frm As Form, ByRef arg As String)

        Dim style As Integer
        Dim previewHandle As Integer = Int32.Parse(CType(arg, String))
        Dim clsAPI As New clsWinAPI
        Dim R As New clsWinAPI.RECT

        'get dimensions of preview window
        clsAPI.GetClientRect(previewHandle, R)

        With frm
            .WindowState = FormWindowState.Normal
            .FormBorderStyle = FormBorderStyle.None
            .Width = R.right
            .Height = R.bottom
        End With

        'get and set new window style
        style = clsAPI.GetWindowLong(frm.Handle.ToInt32, clsAPI.GWL_STYLE)
        style = style Or clsAPI.WS_CHILD
        clsAPI.SetWindowLong(frm.Handle.ToInt32, clsAPI.GWL_STYLE, style)

        'set parent window (preview window)
        clsAPI.SetParent(frm.Handle.ToInt32, previewHandle)

        'save preview in forms window structure
        clsAPI.SetWindowLong(frm.Handle.ToInt32, clsAPI.GWL_HWNDPARENT, previewHandle)
        clsAPI.SetWindowPos(frm.Handle.ToInt32, 0, R.left, 0, R.right, R.bottom, clsAPI.SWP_NOACTIVATE Or clsAPI.SWP_NOZORDER Or clsAPI.SWP_SHOWWINDOW)

    End Sub
End Module
