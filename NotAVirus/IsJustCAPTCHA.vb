Imports System.IO
Public Class IsJustCAPTCHA
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
    Dim ConfigFile As String = DIRCommons & "\IsJustCAPTCHA.ini"
    Dim userCanExit As Boolean = False

    Dim CheckedBase64 As String = "/9j/4AAQSkZJRgABAQEAjwCPAAD/4QAiRXhpZgAATU0AKgAAAAgAAQESAAMAAAABAAEAAAAAAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCABqAGoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9lP21v2z/AAr+xR8Mj4h8Q7ry8vXaDS9LgcLcajKFBYA4IVFBBZyCFBHBJVT+SPx2/wCCuvxw+NWuXEkPiu48G6bvbyNP0H/RPJGeMzD987Acbi4BOSEXsn/BXX473nxq/bd8VWslwz6X4Pm/4R+wi3HbD5PEx29NzTGQlvTaO1fMRr+5/CbwlyrL8qo5hmNGNXEVYqbc0pKCkrqMU9E0nq7XvfWx/JPiN4jZhjMwq4LBVHTo05OPutpya0bbWrV1otkraX1PT/8Ahtj4zf8ARXPid6/8jRe//HaP+G2fjN/0Vz4nf+FTe/8Ax2vMKK/Zf9X8r/6Bqf8A4BH/ACPy/wDtnH/8/wCf/gUv8z0//htn4zf9Fc+J3/hU3v8A8do/4bZ+M3/RXPid/wCFTe//AB2vMKKP9X8r/wCgan/4BH/IP7Yx/wDz/n/4FL/M9P8A+G2fjN/0Vz4nf+FTe/8Ax2j/AIbZ+M3/AEVz4nf+FTe//Ha8woo/1fyv/oGp/wDgEf8AIP7Yx/8Az/n/AOBS/wAz0/8A4bZ+M3/RXPid/wCFTe//AB2j/htn4zf9Fc+J3/hU3v8A8drzDpRjmj/V/K/+gen/AOAR/wAg/tjMP+f8/wDwKX+Z6f8A8Ns/Gb/ornxO/wDCpvf/AI7XS/Dv/gpV8dPhpqkd1Z/EzxTqBRsmPWLs6pC/+yVuN+AfUEH0IPNeF54o6VjX4XyetB0quFpyi904Ra/I1o5/mdGXtKeImn3U5f5n7Xf8E3/+CqGl/tmTDwv4gs7bw/4+t4TKIYmP2TVkUZZ4MksrqBlo2JIALBmAYL9dbAescefduf5V/Nn8NfiDq3wn8f6P4m0O4a01bQ7uO8tZQSNrowYAgdVOMEdwSK/o4+G3jK3+JXw60DxHZ7ltPEGm2+pQDOcJNEsi/owr+KfG7w8wvDWOpYvLVy0K9/d19yUbNpf3WndLW1mtrH9T+FPGlfPcJPDY53q0re9b4ovZvzVrN9dHvc/n5/bZOf2zPi5/2Omsdf8Ar+mrzGvTv22P+TzPi5/2Oms/+l01eY1/bvD/APyK8N/17h/6Sj+U84/3+v8A45f+lMKKKK9c80KKKKACiijrQAoVmGF6tx7n3H61+tv/AATT/wCCTOg+Fvgfea58VvDdtrHiDxtZCMaZeoW/sezbDKvZkuWIDlxho+FG1t+fI/8AgjF/wTjbx9q9n8XvGunn+w9Pm3+G7KaP/j+uEP8Ax9sD/wAs42BCf3nBbgIN/wCr0DYhXd8px0Jr+RfHLxWmq0uHslqOPK/3s4uz5k9IRa2s1eTve6UejT/pLwl8PY+yWdZpBPmX7uMldWf2mnvdaRT6a9Vb8Uf+CiX/AASh8Rfsj3d14m8MreeJPh2z5M5Xfd6KCcBbgAcrzgTDAPRth27vj0nAHpjjnPFf0veLNQ03TNC1C51ia0h0q3tnlvXuiogSAKTIXLcbAoYtnjGc1/PX+114t8D+Nf2i/FGpfDjRv7D8Hz3Z+xW6swjlx96ZIz/q0dsssfG0MFwMYH3Hgj4kZnxDTqYHMaTlKil+9VknfRKS/n6prdJtpNXfyfitwPgMlnDF4GajGo3+7e67uP8Ad8ns3o2tvNT9059Mge9f0RfsVZP7G3wl6/8AImaP3/6cYa/ndHT8R+Nf0RfsUf8AJmnwk/7EvR//AEhhrw/pMv8A4TcF/wBfJf8ApJ63gN/v+K/wR/8ASj8K/wBtj/k8z4uf9jprP/pdNXmNenftsf8AJ5nxc/7HTWf/AEumrzGv6IyD/kV4b/r3D/0lH4rnH+/1/wDHL/0phRR2q3JoN9FosepNZXa6dNM1vHdGFhDJKqqzIHxtLBWUkA5AYHuK9SU4rdnnxi3sipRRtOM44oIwB/tdPequSFfUH/BMT9gG8/bR+K/2zVYprfwD4bkWTVrkMU+2Pwy2kTf33GCxH3E5yGZd3ln7Jf7LfiL9r34zab4P8PxtGZj5uoXzIWi021BHmTv64BwFyCzMqgjdkfvb8AfgL4d/Zu+FGk+D/DFkLXS9JiCgkZkuZDy8sjAfM7sSSffjAAA/B/GjxQWQYP8AszL5f7VVW6/5dxenN/ieqiv+3nsr/r3hbwC84xP1/GR/2em9n9uX8v8AhX2u+3V267w7oln4Z0Gz03TrW3sdP0+FLe2toEEcVvGgCqiqOFVQAABwAKnm4LfTHXFPRgic8Y9a+HP+Cv8A/wAFG1/Zx8HS/D/wbqC/8J54ggP2q5hfLaFaMOX9p5AcIOqg7+Pk3fxnwzw7js/zKnluBXNUm9W9orrKT7Ld99ldtJ/1BnueYTJsDPHYt2hBaLq30il3fT79keA/8Fnf+Cjf/CwNZvvhD4Lvj/YmmzbfEV7C2f7QuEJxaqRwYo2GX/vOAOAnz/nd/nk5oOdxznOe5yfxor/Rrg3hLBcOZZTy3BLRayl1lJ7yfm+nZWS0R/EPE3EeKzvHzx2Ker0S6Ritor0/F3fUO3/AhX9EX7FH/Jmnwk/7EvR//SGGv53e3/AhX9EX7FH/ACZp8JP+xL0f/wBIYa/C/pNf8i3Bf9fJf+kn654C/wC/4r/BH8z8K/22P+TzPi5/2Oms/wDpdNXmOK9O/bY/5PM+Ln/Y6az/AOl01eZD/Gv6GyF2yvDf9e4f+ko/Fc41zCv/AI5f+lM+hf8Agn1/wT98Qftw/Eby1FxpXgvSZFOsawEHyjr9nhLDBmcY9QqncwPyq37GeJf2Ivhv4p/ZtX4UzeGreHwjDAEtoYF2y2coyRcxyHJ87cSS53FskNuDMD5//wAEsf2iPhr8Y/2btL0fwFptr4ZuPDUCw6noPmbpraU5zNuPzSpI2T5p5JJBwwIH1Ajgj7wr+GfFjxAzzMM+dGqpYaOGl7kL2kpLabadnJ7pptJO0XZtv+tvDvg7KcHlCq03Gu68ffnumn9lJ7RWzTSbfxJWSX8+v7bv7Efij9iX4qNomsK17o98WbR9YSPbDqEIP47JlyN6EkjIIypBPl3gLwNq/wAT/GuneH/D+nXGpa1rU629paQAM8zuT8oJ6D1JwoAJJAya/of/AGif2ePC/wC1J8L9S8I+LdPW/wBKv1BR1wJrKYZ2TwsQdsi5PPIIypBUsp+fP+CdX/BLDTf2KfEWu+ItYvrXxP4oup5bbS71ISq2NjnAIVs4nkHLkEgD5VOCxb9WyP6Q2H/1fqVMxjfG00lGKT5ajeilp8Nt5rTvHey/O828F67zmEMFK2Fm7t31glq46/FfaL/8C2u/QP8Agn5+w7pX7Enwaj0mHyL7xNqwS513U0U/6TMAcRoTyIo9xCg4JJZjyxA9/jOyMbuMDnJojfCDd8p964j9oL47+Hv2bvhXrHjLxNeC10vSYt/y4MtxIeEijXI3O7YUD1OTgAkfyzjcZmGd5k8RWbq160vVuT0SS+5JLZaI/oHC4XB5VgVSpWp0aUeuyS1bb/Fvq9Xqecf8FCv24NI/Yk+Dk2rOYL3xRqwe30LTWb/j4mC8yOAQfJjBDMeOdq5BYGvwj8e+OtW+J3jXUvEWv30+p6zrE7XN3cytl5nY5PsFz0AwAMDArtP2tv2o/EX7Xfxq1Pxh4gk8sz/urCxVy0WmWyk+XAh9gcscDc5ZjjoPM6/vTwn8OKXC+XXrpPFVEnUlvbtCL7R6tfE9drJfyD4i8cVc/wAbak2qFN2gu/eT8307K3W9w9aKKK/Wj84Dt/wIV/RF+xR/yZp8JP8AsS9H/wDSGGv53e3/AAIV/RF+xR/yZp8JP+xL0f8A9IYa/mH6TX/ItwX/AF8l/wCkn754C/7/AIr/AAR/M/Cv9tj/AJPM+Ln/AGOms/8ApdNXmNenftsf8nmfFz/sdNZ/9Lpq8xr+iMg/5FeG/wCvcP8A0lH4rnH+/wBf/HL/ANKZ2HwL+Ovib9m/4l6f4u8JalJpusaa+VIJaO4jP3oZE6NG/RgfYgggEfuR+wj+3d4a/bf+GqX2nmPTfEumxous6M8m6Szc8b0PV4WI+V8exwwIr8B67D4G/HPxN+zn8StN8W+E9RfTdY0xiVOd0dyhxuikTo0bgYYH0BGCAR+eeKHhfhOKcJ7SFoYqC9yff+7LvF9HvFu60un9pwDx/ieH8RyTvPDyfvR7dOaN9n3W0lo7aNf0hRthKXep7j868C/YQ/bz8Mftv/Dv7Zp+zTfE2mxoNY0d5A0lo3TzEPWSFj0fHfacMCK926J+nXFfwJmuVYvLMXPA4+DhUg7NP+tU901o1qm0f2Ll2Y4bHYeGLwk1OnJXTX9aNdVunoVvEOu2fhvS7rUL+6t7OxsIHubi4mkCRwRopZnZjwAACSTwADX4ef8ABTj9v28/bR+K32HS5prfwB4dlaPSbYkr9tblXvJB13OMhVPKJxwWfPuH/BZ3/go5/wALA1i8+EXgm+P9h6bNt8RX0LZGoXKE4tVI4MUbDL/3nAHAT5/zvPX/ABOa/rrwL8LfqNJcQ5pH99Nfu4v7EX9pr+aS27R85O382eLfiB9bqSyXL5fu4v32vtSX2f8ADF7936anSiiiv6aPwcKKKKADt/wIV/RF+xR/yZp8JP8AsS9H/wDSGGv53e3/AAIV/RF+xR/yZp8JP+xL0f8A9IYa/mH6TX/ItwX/AF8l/wCkn754C/7/AIr/AAR/M/Cv9tj/AJPM+Ln/AGOmsf8ApdNXmNe6f8FLPhzd/DL9uv4m2d1FJH/aGuTavCxUhZI7xvtClfUfvCvHdSOoNeF1/QXDGIhWyfCVabvGVKDT8nFH4zn1GdLM8RSmrONSaf8A4Ewooor3DyTrPgn8bPEn7O/xH0/xb4T1KXTNa0t90bqdyTKfvRyJ0ZHHBB+vpX6A/tL/APBce38e/snWdh4MtbzQ/iH4iRrHViAdmhxgASSwSfxNJuxGRyg3E4ZVz+aVFfF8RcAZLneMoY/MaSlUou6fddIz/minqk+vk5J/U5LxlmuVYWtg8FU5YVVZ+T7x7NrS66eaTSu7SNuY5Y9ec/r3+tJRRX2i00PlgooooAKKKM/40AHb8Qa/oi/Yo/5M1+En/Yl6P/6Qw1/PHZ2U2oXUVvbxSXE8zhI4kUs8jkgBQByc5HFf0dfATwJcfC74F+C/DMzK03h3QbHTHOerQW8cR/Va/lr6TmIgsDgaN/ec5tLySSf5o/oDwHpS+tYutb3VGK+bbf6Hzf8A8FV/+CbzftneG7XxB4XS1t/H2gwmGHzjsj1e2yW+zu/RWViSjHj5mU4Dbl/Gv4g/DXxB8J/FNxonibR9S0PVrUkSWt7btDIMdwCBle4YZBGCCQQa/pWb+tc/46+G3h34j6f9l8RaBouvWq8iHUbGK6jB/wB2RSK/PPC3xizHJYQyevTVajf3by5ZQvq1e0rx7JrTvayPtvELwxwWaSlmlKbpVdOayupbK9rqz8769j+a0HIor+iFf2Kvg3Iu5vhL8MmY9SfC9jz/AOQqX/hif4M/9Ej+GP8A4S1j/wDGq/o7/iKX/UN/5P8A/aH4f/xD/wD6f/8Akn/2x/O7RX9EX/DE/wAGf+iR/DH/AMJax/8AjVH/AAxP8Gf+iR/DH/wlrH/41R/xFL/qG/8AJ/8A7QP+If8A/T//AMk/+2P53aK/oi/4Yn+DP/RI/hj/AOEtY/8Axqj/AIYn+DP/AESP4Y/+EtY//GqP+Ipf9Q3/AJP/APaB/wAQ/wD+n/8A5J/9sfzu0V/RF/wxP8Gf+iR/DH/wlrH/AONUf8MT/Bn/AKJH8Mf/AAlrH/41R/xFL/qG/wDJ/wD7QP8AiH//AE//APJP/tj+d2prGzm1O7it7eGa4mmcJHFGnmNIx7BepJ4wBX9Dn/DE/wAGf+iR/DH/AMJax/8AjVb/AIF+APgP4Y3hn8N+CfCPh6YdJNM0e3tGH4xoDXl514wvBYSeJWE5uXp7S3/th6WU+GX1vFRoPE2v15L/APtx+c//AASh/wCCUOu2PjbSvif8TdIk0230sreaFod4m24kuBylxOn/ACzCHDKp+YsASAoXf+om5l42t/3zUyjA/E0tfxrxlxlmPE2YPMMwfS0Yr4Yx3svzb3b8rJf05wvwvgsiwSweDXnKT3k+7/RbJfNv/9k="
    Dim unCheckedBase64 As String = "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"

    'Indica la combinacion seleccionada
    Dim Pic1 As Boolean = False
    Dim Pic2 As Boolean = False
    Dim Pic3 As Boolean = False
    Dim Pic4 As Boolean = False
    Dim Pic5 As Boolean = False
    Dim Pic6 As Boolean = False
    Dim Pic7 As Boolean = False
    Dim Pic8 As Boolean = False
    Dim Pic9 As Boolean = False
    'Indica las que deben estar en True
    Dim Com1 As Boolean = False
    Dim Com2 As Boolean = False
    Dim Com3 As Boolean = False
    Dim Com4 As Boolean = False
    Dim Com5 As Boolean = False
    Dim Com6 As Boolean = False
    Dim Com7 As Boolean = False
    Dim Com8 As Boolean = False
    Dim Com9 As Boolean = False

    Private Sub IsJustCAPTCHA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadParameters(Command())
        ReadValues()
        ResizeIt(My.Computer.Screen.Bounds.Width, 200) 'default
    End Sub
    Private Sub IsJustCAPTCHA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub IsJustCAPTCHA_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        If MessageBox.Show("'IsJustCAPTCHA' es parte de 'Not-A-Virus' y este fue creado y desarrollado por Zhenboro." & vbCrLf & "¿Desea visitar el sitio oficial?", "Not-A-Virus Series", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Process.Start("https://github.com/Zhenboro/Not-A-Virus")
            Threading.Thread.Sleep(500)
            Process.Start("https://github.com/Zhenboro")
        End If
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

                Else
                    ConfigFile = args(0)
                End If

            End If
        Catch ex As Exception
            Console.WriteLine("[GetValues@IsJustCAPTCHA]Error: " & ex.Message)
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
            Console.WriteLine("[GetValues@IsJustCAPTCHA]Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub ReadValues()
        Try

            Dim meText As String = GetIniValue("TEXT", "Text", ConfigFile, "IsJustCAPTCHA")
            meText = meText.Replace("%username%", Environment.UserName)
            meText = meText.Replace("%vbCrLf%", vbCrLf)
            Me.Text = meText

            Dim meInformation As String = GetIniValue("TEXT", "lbl_Information", ConfigFile, "This computer is locked.%vbCrLf%To unlock please click the button and complete the CAPTCHA.")
            meInformation = meInformation.Replace("%username%", Environment.UserName)
            meInformation = meInformation.Replace("%vbCrLf%", vbCrLf)
            Me.lbl_Information.Text = meInformation

            Me.lbl_IAmNotARobot.Text = GetIniValue("TEXT", "lbl_IAmNotARobot", ConfigFile, "I am not a robot.")
            Me.btn_Unlock.Text = GetIniValue("TEXT", "btn_Unlock", ConfigFile, "UNLOCK")
            Me.lbl_SelectTip.Text = GetIniValue("CAPTCHA", "lbl_SelectTip", ConfigFile, "¿Cual de las siguientes waifus no es una waifu?")
            Me.btn_Continue.Text = GetIniValue("CAPTCHA", "btn_Continue", ConfigFile, "> Continuar >")

            Com1 = GetIniValue("COMBINATION", "Com1", ConfigFile, False)
            Com2 = GetIniValue("COMBINATION", "Com2", ConfigFile, False)
            Com3 = GetIniValue("COMBINATION", "Com3", ConfigFile, False)
            Com4 = GetIniValue("COMBINATION", "Com4", ConfigFile, False)
            Com5 = GetIniValue("COMBINATION", "Com5", ConfigFile, False)
            Com6 = GetIniValue("COMBINATION", "Com6", ConfigFile, False)
            Com7 = GetIniValue("COMBINATION", "Com7", ConfigFile, False)
            Com8 = GetIniValue("COMBINATION", "Com8", ConfigFile, False)
            Com9 = GetIniValue("COMBINATION", "Com9", ConfigFile, False)

            Pic_1.ImageLocation = GetIniValue("IMAGES", "Pic_1", ConfigFile, "https://i.pinimg.com/originals/27/69/0c/27690ca6b8f4ca177efd3d59d1b64f83.jpg")
            Pic_2.ImageLocation = GetIniValue("IMAGES", "Pic_2", ConfigFile, "https://avatarfiles.alphacoders.com/169/169888.jpg")
            Pic_3.ImageLocation = GetIniValue("IMAGES", "Pic_3", ConfigFile, "https://lh6.googleusercontent.com/proxy/hsiurYYUw9PbqjDjOFQQ6EnVl1wJFpTxjrT2Bwbr4bZX3hnWShwiOmoRvhHGmDV3l6hoLVMSuGNMDv5gIw8VDSm-xZ6RoQ=w1200-h630-p-k-no-nu")
            Pic_4.ImageLocation = GetIniValue("IMAGES", "Pic_4", ConfigFile, "https://p7.hiclipart.com/preview/747/246/391/anime-girl-mangaka-comics-anime.jpg")
            Pic_5.ImageLocation = GetIniValue("IMAGES", "Pic_5", ConfigFile, "https://avatarfiles.alphacoders.com/164/thumb-1920-164226.jpg")
            Pic_6.ImageLocation = GetIniValue("IMAGES", "Pic_6", ConfigFile, "https://i.pinimg.com/originals/6e/5e/76/6e5e76c1f196c9d0429b2d4528d854bf.jpg")
            Pic_7.ImageLocation = GetIniValue("IMAGES", "Pic_7", ConfigFile, "https://i.pinimg.com/736x/47/19/74/471974bcfb4e8435444a84bda3160af9.jpg")
            Pic_8.ImageLocation = GetIniValue("IMAGES", "Pic_8", ConfigFile, "https://i.pinimg.com/originals/6d/9a/e3/6d9ae3b81c7f75eda568d4ef28fd6893.jpg")
            Pic_9.ImageLocation = GetIniValue("IMAGES", "Pic_9", ConfigFile, "https://pic4.zhimg.com/50/v2-67323f63e681e1f97828b1b5ccd7060c_xll.jpg")

        Catch ex As Exception
            Console.WriteLine("[ReadValues@IsJustCAPTCHA]Error: " & ex.Message)
            End
        End Try
    End Sub

    Sub ResizeIt(ByVal Width As Integer, ByVal Height As Integer)
        Me.Size = New Size(Width, Height)
        Me.CenterToScreen()
    End Sub

    Private Sub Btn_Unlock_Click(sender As Object, e As EventArgs) Handles btn_Unlock.Click
        ResizeIt(My.Computer.Screen.Bounds.Width, 700) 'reset
        PictureBox1.Image = ConvertByteToImage(ConvertBase64ToByteArray(unCheckedBase64)) 'default
        Panel1.Location = New Point(190, 309) 'reset
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        StartQuest()
    End Sub

    Sub StartQuest()
        Panel1.Location = New Point(Panel1.Location.X, Panel1.Location.Y - 150)
        Panel1.Enabled = False
        Panel2.Visible = True
        btn_Unlock.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Continue.Click
        Verification()
    End Sub
    Sub Verification()
        If Pic1 = Com1 Then
            If Pic2 = Com2 Then
                If Pic3 = Com3 Then
                    If Pic4 = Com4 Then
                        If Pic5 = Com5 Then
                            If Pic6 = Com6 Then
                                If Pic7 = Com7 Then
                                    If Pic8 = Com8 Then
                                        If Pic9 = Com9 Then
                                            FinishQuest() 'logrado!
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Sub FinishQuest()
        Panel1.Location = New Point(Panel1.Location.X, Panel1.Location.Y + 150)
        Panel1.Enabled = True
        PictureBox1.Enabled = False
        Panel2.Visible = False
        PictureBox1.Image = ConvertByteToImage(ConvertBase64ToByteArray(CheckedBase64))
        Me.Refresh()
        Me.Update()
        Threading.Thread.Sleep(1500)
        End
    End Sub

    Function ConvertBase64ToByteArray(base64 As String) As Byte()
        If base64 IsNot Nothing Then
            Return Convert.FromBase64String(base64) 'Convert the base64 back to byte array.
        End If
        Return Nothing
    End Function
    Function ConvertByteToImage(ByVal BA As Byte())
        If BA IsNot Nothing Then
            Dim ms As MemoryStream = New MemoryStream(BA)
            Dim image = System.Drawing.Image.FromStream(ms)
            Return image
        End If
        Return Nothing
    End Function
    Private Sub IsJustCAPTCHA_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        MsgBox(e.KeyCode.ToString & " is locked")
        If e.KeyCode = Keys.Menu Then
            MsgBox("MENU (Alt) is locked")
        End If
        If e.KeyCode = Keys.F4 Then
            MsgBox("F4 is locked")
        End If
    End Sub

#Region "Picture Combinations"
    Private Sub Pic_1_Click(sender As Object, e As EventArgs) Handles Pic_1.Click
        If Pic1 Then
            Pic1 = False
            Pic_1.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic1 = True
            Pic_1.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_2_Click(sender As Object, e As EventArgs) Handles Pic_2.Click
        If Pic2 Then
            Pic2 = False
            Pic_2.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic2 = True
            Pic_2.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_3_Click(sender As Object, e As EventArgs) Handles Pic_3.Click
        If Pic3 Then
            Pic3 = False
            Pic_3.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic3 = True
            Pic_3.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_4_Click(sender As Object, e As EventArgs) Handles Pic_4.Click
        If Pic4 Then
            Pic4 = False
            Pic_4.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic4 = True
            Pic_4.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_5_Click(sender As Object, e As EventArgs) Handles Pic_5.Click
        If Pic5 Then
            Pic5 = False
            Pic_5.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic5 = True
            Pic_5.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_6_Click(sender As Object, e As EventArgs) Handles Pic_6.Click
        If Pic6 Then
            Pic6 = False
            Pic_6.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic6 = True
            Pic_6.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_7_Click(sender As Object, e As EventArgs) Handles Pic_7.Click
        If Pic7 Then
            Pic7 = False
            Pic_7.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic7 = True
            Pic_7.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_8_Click(sender As Object, e As EventArgs) Handles Pic_8.Click
        If Pic8 Then
            Pic8 = False
            Pic_8.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic8 = True
            Pic_8.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub Pic_9_Click(sender As Object, e As EventArgs) Handles Pic_9.Click
        If Pic9 Then
            Pic9 = False
            Pic_9.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Pic9 = True
            Pic_9.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
#End Region
End Class