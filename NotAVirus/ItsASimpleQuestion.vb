Public Class ItsASimpleQuestion
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
    Dim ConfigFile As String = DIRCommons & "\ItsASimpleQuestion.ini"
    Dim userCanExit As Boolean = False
    Dim IAmLoaded As Boolean = False

    Dim rand As New Random
    Dim stupidMeter As Integer = 0

    Private Sub ItsASimpleQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IAmLoaded Then
            'Solo es usado cuando este formulario es el inicio del proyecto
            ReadParameters(Command())
            ReadValues()
        End If
    End Sub
    Private Sub ItsASimpleQuestion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub
    Private Sub ItsASimpleQuestion_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        If MessageBox.Show("'ItsASimpleQuestion' es parte de 'Not-A-Virus' y este fue creado y desarrollado por Zhenboro." & vbCrLf & "¿Desea visitar el sitio oficial?", "Not-A-Virus Series", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Process.Start("https://github.com/Zhenboro/Not-A-Virus")
            Threading.Thread.Sleep(500)
            Process.Start("https://github.com/Zhenboro")
        End If
    End Sub

    Sub ReadParameters(ByVal parametros As String)
        Try
            IAmLoaded = True
            If parametros <> Nothing Then
                Dim parameter As String = parametros
                Dim args() As String = parameter.Split(" ")

                If args(0).ToLower = "--localconfig" Then
                    ConfigFile = args(1)

                ElseIf args(0).ToLower = "--remoteconfig" Then
                    GetValues(args(1))

                Else
                    ConfigFile = args(0)
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

            GameMode_ADMIN(Boolean.Parse(GetIniValue("SET", "GameMode", ConfigFile, "False")))

        Catch ex As Exception
            Console.WriteLine("[ReadValues@ItsASimpleQuestion]Error: " & ex.Message)
            End
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_No.Click
        btn_Yes.Focus()
        If stupidMeter = GetIniValue("SET", "MaxPressNo", ConfigFile, "420") Then
            MsgBox(GetIniValue("ACTION", "MaxPressMessage", ConfigFile, "Understandable"), MsgBoxStyle.ApplicationModal, Me.Text)
            End
        End If
        ManageScore()
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
                MsgBox(GetIniValue("ACTION", "PressYes", ConfigFile, "I knew it :3"), MsgBoxStyle.ApplicationModal, Me.Text)
                Try
                    Process.Start(GetIniValue("ACTION", "Start", ConfigFile))
                Catch
                End Try
            End If
        Catch ex As Exception
            Console.WriteLine("[Button1_Click@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
        End
    End Sub

    Private Sub lbl_Question_Click(sender As Object, e As EventArgs) Handles lbl_Question.Click
        counterClicks += 1
    End Sub
    Private Sub ItsASimpleQuestion_Click(sender As Object, e As EventArgs) Handles Me.Click
        counterClicks += 1
    End Sub
End Class
Module GameMode
    Public isGameModeActive As Boolean = False
    Dim stopWatcher As New System.Diagnostics.Stopwatch
    Public counterClicks As Integer = 0
    Dim score As Integer = 0
    Dim maxScore As Integer = 0
    Dim minTR As String = Nothing
    Dim maxTR As String = Nothing

    Sub GameMode_ADMIN(ByVal mode As Boolean)
        Try
            isGameModeActive = mode
            If mode Then
                'ACTIVADO
                stopWatcher.Start()
            End If
        Catch ex As Exception
            Console.WriteLine("[GameMode_ADMIN@GameMode@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub

    Sub ResetScore()
        Try
            ItsASimpleQuestion.Label1.BackColor = Color.Orange
            ItsASimpleQuestion.Enabled = False
            ItsASimpleQuestion.Update()
            EndMessage()
            Threading.Thread.Sleep(1000)
            stopWatcher.Reset()
            ItsASimpleQuestion.Label1.Text = Nothing
            counterClicks = 0
            score = 0
            minTRi = 0
            maxTRi = 0
            ItsASimpleQuestion.Label1.BackColor = ItsASimpleQuestion.DefaultBackColor
            ItsASimpleQuestion.Enabled = True
        Catch ex As Exception
            Console.WriteLine("[ResetScore@GameMode@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub
    Sub EndMessage()
        Try
            Dim preMessage As String = Nothing

            If score = 0 Then
                preMessage = "You are cringe. How can u get 0 points?!?"
            ElseIf score <= 10 Then
                preMessage = "Well, " & score & " isn't that bad."
            ElseIf score >= maxScore Then
                preMessage = "Congratulations! " & score & "/" & maxScore & " is amazing!"
            Else
                preMessage = "Good job!"
            End If
            If maxScore = 0 Then
                preMessage = "We start with something!"
            End If
            If score > maxScore Then
                maxScore = score
            End If
            MsgBox(preMessage &
                   vbCrLf & "Thanks for playing!" &
                   vbCrLf &
                   vbCrLf & "Your score: " & score & " (" & maxScore & " is the best)" &
                   vbCrLf & "Your min RT: " & minTR &
                   vbCrLf & "Your max RT: " & maxTR, MsgBoxStyle.OkOnly, ItsASimpleQuestion.Text)

        Catch ex As Exception
            Console.WriteLine("[EndMessage@GameMode@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub
    Sub ManageScore()
        Try
            If isGameModeActive Then
                If counterClicks = 1 Then
                    'REINICIAR PUNTUACION
                    ResetScore()
                Else
                    'SUMAR PUNTUACION
                    counterClicks = 0
                    MoreScore()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[ManageScore@GameMode@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub

    Sub MoreScore()
        Try
            score += 1
            Dim contenido As String = "Score: " & score & " | RT: " & getReactionTime(stopWatcher)

            stopWatcher.Restart()
            ItsASimpleQuestion.Label1.Text = contenido
        Catch ex As Exception
            Console.WriteLine("[ModeScore@GameMode@ItsASimpleQuestion]Error: " & ex.Message)
        End Try
    End Sub

    Dim minTRi As Integer = 0
    Dim maxTRi As Integer = 0
    Function getReactionTime(ByVal reaction As System.Diagnostics.Stopwatch) As String
        Dim rtthing = Val(reaction.Elapsed.Seconds & reaction.Elapsed.Milliseconds)
        Dim rtShot = reaction.Elapsed.Seconds & "s:" & reaction.Elapsed.Milliseconds & "ms"
        If minTRi = 0 Then
            minTRi = rtthing
        End If
        If rtthing > maxTRi Then
            maxTR = rtShot
            maxTRi = rtthing
        End If
        If rtthing < minTRi Then
            minTR = rtShot
            minTRi = rtthing
        End If
        Return reaction.Elapsed.Minutes & ":" & reaction.Elapsed.Seconds & ":" & reaction.Elapsed.Milliseconds & "ms"
    End Function
End Module