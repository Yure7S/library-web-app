Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class EmailSender
    Public Sub Send(ByVal subject As String, ByVal user As User, Optional templatePath As String = "")
        Try
            Dim smtp As New SmtpClient()
            Dim email As New MailMessage()
            Dim mailAccount As String = ConfigurationManager.AppSettings("mailAccount")
            Dim mailPassword As String = ConfigurationManager.AppSettings("mailPassword")

            ' SMTP Settings
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New NetworkCredential(mailAccount, mailPassword)
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Host = "smtp.gmail.com"

            ' Email content Settings
            email.From = New MailAddress(mailAccount)
            email.To.Add(user.Email)
            email.Subject = subject
            email.IsBodyHtml = True

            ' Email template Reader
            Dim reader As New StreamReader(templatePath)
            Dim mailBody As String = reader.ReadToEnd()
            reader.Close()

            mailBody = mailBody.Replace("[[user.Username]]", user.Username)
            email.Body = mailBody

            ThreadPool.QueueUserWorkItem(Sub(x) smtp.Send(email))

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub
End Class