Imports System.IO
Public Class frmDelete
    Dim dsData As New DataSet
    Dim strFolderPath As String
    Dim blnRestart As Boolean = False

    Private Sub frmDelete_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If blnRestart = False Then
            '-- You must tell the data set to Accept Changes or the data will not update to the file
            dsData.AcceptChanges()
            '-- I use the WriteSchema flag to ensure the xml file has a Schema 
            dsData.WriteXml(strFolderPath & "\Data.xml", XmlWriteMode.WriteSchema)
        End If
    End Sub
    Private Sub frmDelete_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitializeData()
    End Sub

    Private Sub InitializeData()
        '-- locating a specific special folder
        strFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        strFolderPath = strFolderPath & "\LINQ Delete Example"
        '-- Check to see if folder LINQ Delete Example exist in the user folder.
        If Directory.Exists(strFolderPath) = False Then
            '-- Create the LINQ Delete Example Directory
            Directory.CreateDirectory(strFolderPath)
        End If

        '-- First the Data files the user needs
        If My.Computer.FileSystem.FileExists(strFolderPath & "\Data.xml") = False Then
            Data(strFolderPath & "\Data.xml")
        End If

        If My.Computer.FileSystem.FileExists(strFolderPath & "\Data.xml") = True Then
            '-- The file does exists so let load it 
            dsData.ReadXml(strFolderPath & "\Data.xml")
        End If
        '-- Connect the grid to the dataSource
        gvXML.DataSource = dsData
        gvXML.DataMember = dsData.Tables(0).TableName


        '-- Get list of make from data set using LINQ
        Dim query = (From p In dsData.Tables(0)
                   Select p.Field(Of String)("Make")).Distinct

        '-- Fill up the list box
        For Each make In query
            lstMake.Items.Add(make.ToString())
        Next


    End Sub

    Private Sub lstMake_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstMake.SelectedIndexChanged
        If lstMake.SelectedIndex <> -1 Then
            btnDelete.Enabled = True
        Else
            btnDelete.Enabled = False
        End If

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

        '-- Get the text from the list box
        Dim strValue As String = lstMake.SelectedItem.ToString
        Dim rows As DataRow()

        '-- Using LINQ to select the rows from the table using the where clause.

        rows = (From myRow In dsData.Tables("Auto")
         Where myRow.Field(Of String)("Make") = strValue).ToArray


        For Each row As DataRow In rows
            dsData.Tables(0).Rows.Remove(row)
        Next

        '-- Last remove it from the list box 
        lstMake.Items.RemoveAt(lstMake.SelectedIndex)

    End Sub

    Private Sub bntKillFile_Click(sender As System.Object, e As System.EventArgs) Handles bntKillFile.Click
        If System.IO.File.Exists(strFolderPath & "\Data.xml") = True Then
            System.IO.File.Delete(strFolderPath & "\Data.xml")
            MsgBox("File Deleted, Restarting the program for fresh data", MsgBoxStyle.Information, "Refreshing Data")
            blnRestart = True
            End
        End If
    End Sub
    Private Function Data(strFilePath As String) As XDocument
        '-- Give us a XML file to work with as a database.
        '-- This will only be done once to give the file a start point and default data.

        Data = <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
               <Autos>
                   <Auto>
                       <Make>Chevrolet</Make>
                       <Model>Avalanche</Model>
                   </Auto>
                   <Auto>
                       <Make>Chevrolet</Make>
                       <Model>Camaro</Model>
                   </Auto>
                   <Auto>
                       <Make>Chevrolet</Make>
                       <Model>Impala</Model>
                   </Auto>
                   <Auto>
                       <Make>Chevrolet</Make>
                       <Model>Malibu</Model>
                   </Auto>
                   <Auto>
                       <Make>Ford</Make>
                       <Model>Focus</Model>
                   </Auto>
                   <Auto>
                       <Make>Ford</Make>
                       <Model>Mustang</Model>
                   </Auto>
                   <Auto>
                       <Make>Ford</Make>
                       <Model>Taurus</Model>
                   </Auto>
                   <Auto>
                       <Make>Ford</Make>
                       <Model>Shelby GT500</Model>
                   </Auto>
                   <Auto>
                       <Make>Honda</Make>
                       <Model>Accord</Model>
                   </Auto>
                   <Auto>
                       <Make>Honda</Make>
                       <Model>Civic</Model>
                   </Auto>
                   <Auto>
                       <Make>Honda</Make>
                       <Model>Fit</Model>
                   </Auto>
                   <Auto>
                       <Make>Honda</Make>
                       <Model>Insight</Model>
                   </Auto>
                   <Auto>
                       <Make>Toyota</Make>
                       <Model>Avalon</Model>
                   </Auto>
                   <Auto>
                       <Make>Toyota</Make>
                       <Model>Camry</Model>
                   </Auto>
                   <Auto>
                       <Make>Toyota</Make>
                       <Model>Corolla</Model>
                   </Auto>
                   <Auto>
                       <Make>Toyota</Make>
                       <Model>Prius</Model>
                   </Auto>
               </Autos>
        '-- Create the file
        Data.Save(strFilePath)

    End Function
End Class
