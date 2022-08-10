Public Class IsJustBSOD
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
    Dim ConfigFile As String = DIRCommons & "\IsJustBSOD.ini"
    Dim userCanExit As Boolean = False
    Dim IAmLoaded As Boolean = False

    Dim MustIncrement As Boolean
    Dim MaxPercent As Integer
    Dim completed As String
    Dim AtCompleted As String
    Dim Repeat As Boolean
    Dim Freeze As Boolean

    Private Sub IsJustBSOD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If Not IAmLoaded Then
            'Solo es usado cuando este formulario es el inicio del proyecto
            ReadParameters(Command())
            ReadValues()
        End If
        Inicializar()
    End Sub
    Private Sub IsJustBSOD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShowCursor(True)
        End
    End Sub
    Private Sub IsJustBSOD_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        If MessageBox.Show("'IsJustBSOD' es parte de 'Not-A-Virus' y este fue creado y desarrollado por Zhenboro." & vbCrLf & "¿Desea visitar el sitio oficial?", "Not-A-Virus Series", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
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
            Console.WriteLine("[GetValues@IsJustBSOD]Error: " & ex.Message)
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
            Console.WriteLine("[GetValues@IsJustBSOD]Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub ReadValues()
        Try
            Dim meBackColor() As String = GetIniValue("OPTIONS", "BackgroundColor", ConfigFile, "0;120;215").Split(";")
            Me.BackColor = Color.FromArgb(255, meBackColor(0), meBackColor(1), meBackColor(2))

            Dim meBackColorQR() As String = GetIniValue("OPTIONS", "QRBackgroundColor", ConfigFile, "255;255;255").Split(";")
            Me.PictureBox1.BackColor = Color.FromArgb(0, meBackColorQR(0), meBackColorQR(1), meBackColorQR(2))

            Dim meText As String = GetIniValue("TEXT", "Text", ConfigFile, "IsJustBSOD")
            meText = meText.Replace("%username%", Environment.UserName)
            meText = meText.Replace("%vbCrLf%", vbCrLf)
            Me.Text = meText

            Dim meTitle As String = GetIniValue("TEXT", "lbl_Title", ConfigFile, "Your PC ran into a problem and needs to restart. We're just collecting some error info, and then we'll restart for you.")
            meTitle = meTitle.Replace("%username%", Environment.UserName)
            meTitle = meTitle.Replace("%vbCrLf%", vbCrLf)
            Me.lbl_Title.Text = meTitle

            Me.lbl_Icon.Text = GetIniValue("TEXT", "lbl_Icon", ConfigFile, ":(")

            Dim meInformation As String = GetIniValue("TEXT", "lbl_Information", ConfigFile, "For more information about this issue and possible fixes, visit https://www.windows.com/stopcode")
            meInformation = meInformation.Replace("%username%", Environment.UserName)
            meInformation = meInformation.Replace("%vbCrLf%", vbCrLf)
            Me.lbl_Information.Text = meInformation

            Dim meErrorInfo As String = GetIniValue("TEXT", "lbl_ErrorInfo", ConfigFile, "If you call a support person, give them this info:" & vbCrLf & "Stop code: PAGE_FAULT_IN_NONPAGED_AREA" & vbCrLf & "What failed: portcls.sys")
            meErrorInfo = meErrorInfo.Replace("%username%", Environment.UserName)
            meErrorInfo = meErrorInfo.Replace("%vbCrLf%", vbCrLf)
            Me.lbl_ErrorInfo.Text = meErrorInfo

            MustIncrement = Boolean.Parse(GetIniValue("SET", "MustIncrement", ConfigFile, True))
            MaxPercent = Integer.Parse(GetIniValue("SET", "MaxPercent", ConfigFile, 100))
            completed = GetIniValue("SET", "completed", ConfigFile, "completed")
            Repeat = GetIniValue("OPTIONS", "Repeat", ConfigFile, False)
            Freeze = GetIniValue("OPTIONS", "Freeze", ConfigFile, False)
            AtCompleted = GetIniValue("ACTION", "AtCompleted", ConfigFile, "NULL")

            Me.PictureBox1.ImageLocation = GetIniValue("IMAGE", "QR", ConfigFile, "https://i.pinimg.com/originals/60/c1/4a/60c14a43fb4745795b3b358868517e79.png")

            'Dim backgroundImageURL As String = GetIniValue("SET", "completed", ConfigFile, "completado")
            'If backgroundImageURL <> Nothing Then
            '    'descargar
            '    If My.Computer.FileSystem.FileExists(DIRCommons & "\BSOD_Background") Then

            '    End If
            '    'mostrar
            '    Dim img As Image = Image.FromFile("C:\Users\Zhenboro\Downloads\2020-04-23-image-9.jpg")
            '    Me.BackgroundImage = img
            'End If
            'End If
        Catch ex As Exception
            Console.WriteLine("[ReadValues@IsJustBSOD]Error: " & ex.Message)
            End
        End Try
    End Sub

    Private Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
    Sub Inicializar()
        ShowCursor(False)
        Dim threadControlPorcentaje As Threading.Thread = New Threading.Thread(AddressOf ControlPorcentaje)
        threadControlPorcentaje.Start()
    End Sub

    Sub ControlPorcentaje()
        Dim r As Random = New Random
        Dim porcentaje As Integer
        Dim Switch As Boolean = True

        While Switch
            porcentaje = 0
            If MustIncrement Then
                porcentaje = 0
                ' incrementar de 0 a MaxPercent (=100)
                While porcentaje < MaxPercent + 1

                    lbl_Status.Text = porcentaje & "% " & completed

                    porcentaje += 1
                    Threading.Thread.Sleep(r.Next(100, 1000))
                End While
            Else
                'decrementar de MaxPercent (=100) a 0
                porcentaje = MaxPercent
                While porcentaje > 0

                    lbl_Status.Text = porcentaje & "% " & completed

                    porcentaje -= 1
                    Threading.Thread.Sleep(r.Next(100, 1000))
                End While
            End If
            If Repeat Then
                MustIncrement = Not MustIncrement 'invierte el estado a su contraparte
            Else
                Switch = False
            End If
        End While

        If Not Freeze Then
            Try
                If AtCompleted <> "NULL" Then
                    Process.Start(AtCompleted)
                End If
            Catch
            End Try
            'al finalizar
            End
        End If
    End Sub
End Class