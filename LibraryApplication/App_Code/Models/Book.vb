Imports System.Data
Imports System.Net
Imports System.Web.Helpers
Imports Microsoft.VisualBasic

Public Class Book
    Public Property Id As Integer
    Public Property UserId As Integer
    Public Property Title As String
    Public Property Description As String
    Public Property Gender As String
    Public Property ReleaseDate As Date

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
        SQL.Append(" FROM Books")
        SQL.Append(" WHERE Id = " & Id)

        dataTable = connection.EditDataTable(SQL.ToString())

        If dataTable.Rows.Count = 0 Then
            dataRow = dataTable.NewRow
        Else
            dataRow = dataTable.Rows(0)
        End If

        dataRow("Id") = ObtainLastId() + 1
        dataRow("UserId") = UserId
        dataRow("Title") = Title
        dataRow("Description") = Description
        dataRow("Gender") = Gender

        connection.SaveDataTable(dataRow)

        dataTable.Dispose()
    End Sub

    Public Sub Obtain(ByVal code As Integer)
        Dim connection As New Connection
        Dim dataTable As DataTable
        Dim dataRow As DataRow
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Books")
        SQL.Append(" WHERE Id = " & code)

        dataTable = connection.OpenDataTable(SQL.ToString())

        If dataTable.Rows.Count > 0 Then
            dataRow = dataTable.Rows(0)

            Id = dataRow("Id")
            UserId = dataRow("UserId")
            Title = dataRow("Title")
            Description = dataRow("Description")
            Gender = dataRow("Gender")
            ReleaseDate = dataRow("ReleaseDate")
        End If
    End Sub

    Public Function Search(Optional ByVal sort As String = "",
                           Optional ByVal userId As Integer = 0,
                           Optional ByVal title As String = "") As DataTable
        Dim connection As New Connection
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Books")
        SQL.Append(" Where Id IS NOT NULL")

        If userId > 0 Then
            SQL.Append(" AND UPPER(UserId) = " & userId)
        End If

        If title <> "" Then
            SQL.Append(" AND UPPER(Title) LIKE '%" & title.ToUpper() & "%'")
        End If

        SQL.Append(" ORDER BY " & IIf(sort = "", "Title", sort))

        Return connection.OpenDataTable(SQL.ToString())
    End Function

    Public Function ObtainLastId() As Integer
        Dim connection As New Connection
        Dim SQL As New StringBuilder
        Dim lastCode As Integer

        SQL.Append(" SELECT MAX(Id) FROM Books")

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
