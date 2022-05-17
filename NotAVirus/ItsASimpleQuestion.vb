Public Class ItsASimpleQuestion
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
    Dim ConfigFile As String = DIRCommons & "\ItsASimpleQuestion.ini"
    Dim userCanExit As Boolean = False

    Dim rand As New Random
    Dim stupidMeter As Integer = 0

    Private Sub ItsASimpleQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadParameters(Command())
        ReadValues()
    End Sub
    Private Sub ItsASimpleQuestion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Sub ReadParameters(ByVal parametros As String)
        Try
            If parametros <> Nothing Then
                Dim parameter As String = parametros
                Dim args() As String = parameter.Split(" ")

                If args(0).ToLower = "--localconfig" Then
                    ConfigFile = args(1)

                ElseIf args(0).ToLower = "--remoteconfig" Then
                    GetValues(args(1))

                End If

            End If
        Catch ex As Exception
            Console.WriteLine("[GetValues@ItsASimpleQuestion]Error: " & ex.Message)
            End
        End Try
    End Sub

    Sub GetValues(ByVal fileURL As String)
        Try
            If My.Computer.FileSystem.FileExists(ConfigFile) Then
                My.Computer.FileSystem.DeleteFile(ConfigFile)
            End If
            My.Computer.Network.DownloadFile(fileURL, ConfigFile)
        Catch ex As Exception
            Console.WriteLine("[GetValues@ItsASimpleQuestion]Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub ReadValues()
        Try
            Me.Size = New Size(GetIniValue("OPTIONS", "Size", ConfigFile, "530;530").Split(";")(0), GetIniValue("OPTIONS", "Size", ConfigFile, "530;530").Split(";")(1))

            Dim meText As String = GetIniValue("TEXT", "Text", ConfigFile, "It's a simple question.")
            meText = meText.Replace("%username%", Environment.UserName)
            meText = meText.Replace("%vbCrLf%", vbCrLf)
            Me.Text = meText

            Me.lbl_Question.Text = GetIniValue("TEXT", "lbl_Question", ConfigFile, "Are you dumb?")

            Dim yesButton As String = GetIniValue("BUTTONS", "btn_Yes", ConfigFile, "Yes")
            yesButton = yesButton.Replace("%username%", Environment.UserName)
            yesButton = yesButton.Replace("%vbCrLf%", vbCrLf)
            Me.btn_Yes.Text = yesButton

            Dim noButton As String = GetIniValue("BUTTONS", "btn_No", ConfigFile, "No")
            noButton = noButton.Replace("%username%", Environment.UserName)
            noButton = noButton.Replace("%vbCrLf%", vbCrLf)
            Me.btn_No.Text = noButton
        Catch ex As Exception
            Console.WriteLine("[ReadValues@ItsASimpleQuestion]Error: " & ex.Message)
            End
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_No.Click
        btn_Yes.Focus()
        If stupidMeter = GetIniValue("SET", "MaxPressNo", ConfigFile, "420") Then
            End
        End If
        MoveTheButton()
    End Sub
    Sub MoveTheButton()
        Try
            Dim x As Integer = rand.Next(0, Me.ClientSize.Width - btn_No.Width)
            Dim y As Integer = rand.Next(0, Me.ClientSize.Height - btn_No.Height)
            btn_No.Location = New Point(x, y)
            stupidMeter += 1
        Catch ex As Exception
            Console.WriteLine("[MoveTheButton@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Yes.Click
        Try
            lbl_Question.Text = GetIniValue("ACTION", "PressYes", ConfigFile, "I knew it :3")
            If stupidMeter >= Val(GetIniValue("SET", "ShowMessageFor", ConfigFile, "10")) Then
                Dim messageText As String = GetIniValue("ACTION", "MoreThanMessage", ConfigFile, "Oh, it took you " & stupidMeter & " tries to finally admit it!")
                messageText = messageText.Replace("%username%", Environment.UserName)
                messageText = messageText.Replace("%vbCrLf%", vbCrLf)
                messageText = messageText.Replace("%stupidMeter%", stupidMeter)
                MsgBox(messageText)
            Else
                MsgBox(GetIniValue("ACTION", "PressYes", ConfigFile, "I knew it :3"))
            End If
        Catch ex As Exception
            Console.WriteLine("[Button1_Click@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
        End
    End Sub
End Class