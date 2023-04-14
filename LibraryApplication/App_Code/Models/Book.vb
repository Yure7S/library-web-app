Imports System.Data

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
            dataRow("Id") = ObtainLastId() + 1
        Else
            dataRow = dataTable.Rows(0)
        End If

        dataRow("UserId") = UserId
        dataRow("Title") = Title
        dataRow("Description") = Description
        dataRow("Gender") = Gender

        connection.SaveDataTable(dataRow)

        dataTable.Dispose()
    End Sub

    Public Function Obtain(ByVal code As Integer) As DataRow
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
            Return dataRow
        End If

        Return Nothing
    End Function

    Public Function Search(Optional ByVal sort As String = "",
                           Optional ByVal id As Integer = 0,
                           Optional ByVal userId As Integer = 0,
                           Optional ByVal title As String = "") As DataTable
        Dim connection As New Connection
        Dim SQL As New StringBuilder

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Books")
        SQL.Append(" Where Id IS NOT NULL")

        If id > 0 Then
            SQL.Append(" AND UPPER(Id) = " & id)
        End If

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

    Public Function Delete(ByVal id As Integer) As Integer
        Dim connection As New Connection
        Dim SQL As New StringBuilder

        SQL.Append(" DELETE")
        SQL.Append(" FROM Books")
        SQL.Append(" WHERE Id = " & id)

        Dim affectedRows As Integer = connection.ExecuteSQL(SQL.ToString())

        connection = Nothing

        Return affectedRows
    End Function

End Class
