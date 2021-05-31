Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter.Fill(Me.Database1DataSet.Table1)
        PictureBox1.Image = Image.FromFile("D:\All About Study Sem 4\GUI Application Development Using VB.Net\Telephone Diary\phone-book.jpg")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel1.Visible = False
        Panel2.Visible = True
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        Panel2.Visible = True
        Panel1.Visible = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel2.Visible = True
        Panel1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Table1BindingSource.AddNew()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Table1BindingSource.RemoveCurrent()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error GoTo saveError
        Table1BindingSource.EndEdit()
        Table1TableAdapter.Update(Database1DataSet.Table1)
        MsgBox("Data Has Been Saved")

saveError:
        Exit Sub
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Table1BindingSource.MovePrevious()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Table1BindingSource.MoveNext()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox5.Text = "" Then
            Call notFound()
            Exit Sub
        Else
            Table1BindingSource.Filter = "(Convert(TelephoneID, 'System.String') Like '" & TextBox5.Text & "')" &
                "OR (FirstName Like '" & TextBox5.Text & "') OR (LastName Like '" & TextBox5.Text & "') OR (PhoneNumber Like '" & TextBox5.Text & "')"
            If Table1BindingSource.Count <> 0 Then

                DataGridView1.DataSource = Table1BindingSource

            Else
                MsgBox("The search item was not found.")

                Table1BindingSource.Filter = Nothing

            End If

        End If
    End Sub
    Private Sub notFound()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox5.Text = ""
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Close()
    End Sub
End Class
