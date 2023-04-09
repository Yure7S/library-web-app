Imports System.Data
Imports System.Web.Helpers
Imports System.Web.Services.Description

Public Class User

    Public Property Id As Integer
    Public Property Username As String
    Public Property Email As String
    Public Property Password As String
    Public Property IsAdmin As Boolean
    Public Property CreatedAt As Date

    Public Sub New(Optional id As Integer = 0)
        If id > 0 Then
            Obtain(id)
        End If
    End Sub

    Public Sub Save()
        Dim connection As New Connection
        Dim dataTable As DataTable
        Dim dataRow As DataRow
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Users")
        SQL.Append(" WHERE Id = " & Id)

        dataTable = connection.EditDataTable(SQL.ToString())

        If dataTable.Rows.Count = 0 Then
            dataRow = dataTable.NewRow
        Else
            dataRow = dataTable.Rows(0)
        End If

        Password = Crypto.HashPassword(Password)

        dataRow("Id") = ObtainLastId() + 1
        dataRow("Username") = Username
        dataRow("Email") = Email
        dataRow("Password") = Password
        dataRow("IsAdmin") = False

        connection.SaveDataTable(dataRow)

        dataTable.Dispose()
    End Sub

    Public Sub Obtain(ByVal code As Integer)
        Dim connection As New Connection
        Dim dataTable As DataTable
        Dim dataRow As DataRow
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Users")
        SQL.Append(" WHERE Id = " & code)

        dataTable = connection.OpenDataTable(SQL.ToString())

        If dataTable.Rows.Count > 0 Then
            dataRow = dataTable.Rows(0)

            Id = dataRow("Id")
            Username = dataRow("Username")
            Email = dataRow("Email")
            Password = dataRow("Password")
            IsAdmin = dataRow("IsAdmin")
            CreatedAt = dataRow("CreatedAt")
        End If
    End Sub

    Public Function Search(Optional ByVal sort As String = "",
                           Optional ByVal username As String = "",
                           Optional ByVal email As String = "") As DataTable
        Dim connection As New Connection
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Users")
        SQL.Append(" Where Id IS NOT NULL")

        If username <> "" Then
            SQL.Append(" AND UPPER(Username) = '" & username.ToUpper() & "'")
        End If

        If email <> "" Then
            SQL.Append(" AND UPPER(Email) = '" & email.ToUpper() & "'")
        End If

        SQL.Append(" ORDER BY " & IIf(sort = "", "Username", sort))

        Return connection.OpenDataTable(SQL.ToString())
    End Function

    Public Function ObtainLastId() As Integer
        Dim connection As New Connection
        Dim SQL As New StringBuilder
        Dim lastCode As Integer

        SQL.Append(" SELECT MAX(Id) FROM Users")

        With connection.OpenDataTable(SQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                lastCode = .Rows(0)(0)
            Else
                lastCode = 0
            End If
        End With

        connection = Nothing
        Return lastCode
    End Function

End Class