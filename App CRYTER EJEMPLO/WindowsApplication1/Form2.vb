Imports System.IO

Public Class Form2

    Private Function ConvertImageToBase64(ByVal ImageInput As Image) As String

        Dim Base64Op As String = String.Empty
        Try
            Dim ms As MemoryStream = New MemoryStream()

            ImageInput.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ''Saving Image to Memory stream

            Base64Op = Convert.ToBase64String(ms.ToArray()) ''Creating Base64 String from  memory stream

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

        Return Base64Op

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RichTextBox1.Text = ConvertImageToBase64(PictureBox1.Image)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RichTextBox1.SelectAll()
    End Sub
    Private Function GetImageFromBase64(ByVal Base64String) As Bitmap
        Dim fileBytes As Byte()
        Dim streamImage As Bitmap

        Try

            If String.Empty <> Base64String Then ''Checking The Base64 string validity

                fileBytes = Convert.FromBase64String(Base64String) ''Converting Base64 string to Byte Array

                Using ms As New MemoryStream(fileBytes) ''Copying Byte Array to Memory Stream

                    streamImage = Image.FromStream(ms) ''Constructing Image from Memory Stream

                    If Not IsNothing(streamImage) Then

                        If Not Directory.Exists("c:\Base64ImageViwer") Then
                            Directory.CreateDirectory("c:\Base64ImageViwer") ''Create a Temp Path for Saving 
                        End If
                    End If

                End Using

            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

        Return streamImage ''Returning Image 

    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.Image =GetImageFromBase64(RichTextBox1.Text)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim file As New OpenFileDialog()
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(file.FileName)
        End If
    End Sub
End Class
