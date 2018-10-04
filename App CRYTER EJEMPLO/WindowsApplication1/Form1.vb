Public Class Form1
    Dim testArrayString() As String = {".", "?", "ç", "!", "&", "{", "*", "@", "#", "/", "%", "$", "]", ")", "}", "+", ";", "¿", "¡", "¶", "¢", "<", ">", "(", "·", "=", "£", "®", "_", "-", "ө", "Ҳ", "┼", "∑", "¬", "Ø", "¥", "‡", "▲", "▀", "◄", "♂"}
    Dim alfabetonumerico(65) As String

    Dim indice As Integer = 0
    Public Function coding() As String
        Dim validString As String
        Dim randomIndex As Integer
        Dim length As Integer
        Dim randomClass As New Random
        Dim codigo As String = ""
        While (codigo.Length < 50)
            length = testArrayString.Length - 1
            randomIndex = randomClass.Next(0, length)
            validString = testArrayString(randomIndex)
            codigo += validString
        End While
        Return codigo
    End Function

    Public Sub agregar(ByVal code As String)
        alfabetonumerico(indice) = code
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        agregar(coding())
        indice = indice + 1
        If indice = 65 Then
            MsgBox("ultimo")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        listar()
    End Sub
    Public Sub listar()
        Dim cadena As String = "Mis codigos: " + vbCr
        For index As Integer = 0 To 65
            cadena += String.Concat(index, " ", alfabetonumerico(index), vbCr)
        Next
        MsgBox(cadena)
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Label1.Text = coding()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        RichTextBox1.Text = RichTextBox1.Text.Replace("A", alfabetonumerico(1))
        RichTextBox1.Text = RichTextBox1.Text.Replace("B", alfabetonumerico(2))
        RichTextBox1.Text = RichTextBox1.Text.Replace("C", alfabetonumerico(3))
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RichTextBox1.Text = RichTextBox1.Text.Replace(alfabetonumerico(1), "A")
        RichTextBox1.Text = RichTextBox1.Text.Replace(alfabetonumerico(2), "B")
        RichTextBox1.Text = RichTextBox1.Text.Replace(alfabetonumerico(3), "C")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer2.Enabled = True
        Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (indice < 66) Then
            agregar(coding())
            indice += 1
            Timer1.Enabled = True
            Timer2.Enabled = False
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
            MsgBox("Base de datos Actualizada con exito")
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form2.Show()
    End Sub
End Class
