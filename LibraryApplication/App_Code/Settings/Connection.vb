Imports System.Data.SqlClient
Imports System.Data
Imports System.Diagnostics

Public Class Connection

    Private _connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ToString()
    Public ReadOnly Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
    End Property

    Private connection As SqlConnection
    Private command As SqlCommand
    Private dataAdapter As SqlDataAdapter
    Private transaction As SqlTransaction

    Public Sub StartTransaction()
        connection = New SqlConnection
        command = New SqlCommand

        connection.Open()
        command = connection.CreateCommand
        transaction = connection.BeginTransaction()

        command.Connection = connection
        command.Transaction = transaction
    End Sub

    Public Sub ConfirmTransaction()
        transaction.Commit()

        connection.Close()
        command.Dispose()
        connection.Dispose()
        transaction.Dispose()

        connection = Nothing
        command = Nothing
        transaction = Nothing
    End Sub

    Public Sub CancelTransaction()
        transaction.Rollback()

        connection.Close()
        command.Dispose()
        connection.Dispose()
        transaction.Dispose()

        command = Nothing
        connection = Nothing
        transaction = Nothing
    End Sub

    Public Function OpenDataTable(ByVal SQL As String) As DataTable
        Dim dataTable As New DataTable

        If transaction Is Nothing Then
            connection = New SqlConnection(ConnectionString())
            command = New SqlCommand()
            command.Connection = connection
        End If

        command.CommandType = CommandType.Text
        command.CommandText = SQL

        dataAdapter = New SqlDataAdapter(command)
        dataAdapter.Fill(dataTable)

        If transaction Is Nothing Then
            connection.Close()
            command.Dispose()
            connection.Dispose()

            command = Nothing
            connection = Nothing
        End If

        dataAdapter.Dispose()
        dataAdapter = Nothing

        Return dataTable
    End Function

    Public Function ExecuteSQL(ByVal SQL As String) As Integer
        Dim rowsAffected As Integer

        If transaction Is Nothing Then
            connection = New SqlConnection(ConnectionString())
            command = New SqlCommand(SQL, connection)
        End If

        command.CommandType = CommandType.Text
        command.CommandText = SQL

        Try
            rowsAffected = command.ExecuteNonQuery()
        Catch ex As Exception
            rowsAffected = -1
        End Try

        If transaction Is Nothing Then
            connection.Close()

            command.Dispose()
            connection.Dispose()

            connection = Nothing
            command = Nothing
        End If

        Return rowsAffected
    End Function

    Public Function EditDataTable(ByVal SQL As String) As DataTable
        Dim dataTable As New DataTable

        If transaction Is Nothing Then
            connection = New SqlConnection(ConnectionString())
            command = New SqlCommand
            command.Connection = connection
        End If

        command.CommandType = CommandType.Text
        command.CommandText = SQL

        dataAdapter = New SqlDataAdapter(command)
        dataAdapter.Fill(dataTable)

        If transaction Is Nothing Then
            command.Dispose()
            command = Nothing
        End If

        Return dataTable
    End Function

    Public Function SaveDataTable(ByVal dataRow As DataRow, Optional saveLog As Boolean = True, Optional returnField As String = "") As Boolean
        Dim objBuilder As New SqlCommandBuilder(dataAdapter)
        Dim dataTable As DataTable = dataRow.Table
        Dim blnReturn As Boolean = True

        If dataTable.Rows.Count = 0 Then
            dataTable.Rows.Add(dataRow)
            dataAdapter.InsertCommand = objBuilder.GetInsertCommand
        Else
            dataAdapter.UpdateCommand = objBuilder.GetUpdateCommand
        End If

        dataAdapter.Update(dataTable)

        If transaction Is Nothing Then
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End If

        dataAdapter.Dispose()
        dataAdapter = Nothing
        dataTable.Dispose()

        dataAdapter = Nothing
        objBuilder = Nothing
        dataTable = Nothing

        Return blnReturn
    End Function

    Public Sub CancelarDataTable()
        If Not transaction Is Nothing Then
            CancelTransaction()

            connection.Close()
            connection.Dispose()
            connection = Nothing

            transaction.Dispose()
            transaction = Nothing
        End If

        dataAdapter.Dispose()
        dataAdapter = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class