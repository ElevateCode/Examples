Imports System.IO

Public Class Form1

    Dim blnOnce As Boolean = False
    Dim dsData As New DataSet
    Dim strFolderPath As String


#Region "Form Events"
    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- You must tell the dataset to accept the changes or the data will not update to the XML file.
        dsData.AcceptChanges()
        '-- I use the WriteSchema flag to ensure the xml file has a Schema.
        dsData.WriteXml(strFolderPath & "\Data.xml", XmlWriteMode.WriteSchema)

    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '-- VB.Net does not always destroy the form so to avoid errors I use a run once flag.
        '-- This flag makes sure that the data is only initialized once.
        If blnOnce = False Then
            InitializeData()
            blnOnce = True
        End If
    End Sub

#End Region



#Region "Helper Subs"

    Private Sub InitializeData()
        '-- Locating a specific special folder.
        strFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        strFolderPath = strFolderPath & "\BindingNavigator Example"
        '-- Check to see if folder BindingNavigator Example exists in the user folder.
        If Directory.Exists(strFolderPath) = False Then
            '-- Create the BindingNavigator Example Directory.
            Directory.CreateDirectory(strFolderPath)
        End If

        '-- First create the Data file the user needs.
        If My.Computer.FileSystem.FileExists(strFolderPath & "\Data.xml") = False Then
            Data(strFolderPath & "\Data.xml")
        End If


        If My.Computer.FileSystem.FileExists(strFolderPath & "\Data.xml") = True Then
            '-- The file does exist so load it.
            dsData.ReadXml(strFolderPath & "\Data.xml")
            ' Get a DataView of the table contained in the dataset.
            Dim tables As DataTableCollection = dsData.Tables
            Dim DetailsView As New DataView(tables(0))
            BindingSource1.DataSource = DetailsView
            '-- Just checking to avoid errors-- it should be zero by default.
            If txtName.DataBindings.Count = 0 Then
                txtName.DataBindings.Add("Text", BindingSource1, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
            End If
            '-- Just checking to avoid errors it should be zero by default.
            If txtProducer.DataBindings.Count = 0 Then
                txtProducer.DataBindings.Add("Text", BindingSource1, "Producer", True, DataSourceUpdateMode.OnPropertyChanged)
            End If
            '-- Now set the BindingNavigator Binding Source to make it all work..
            BindingNavigator1.BindingSource = BindingSource1
        End If

    End Sub

#End Region

   
    Private Function Data(strFilePath As String) As XDocument
        '-- This function creates an XML file to use as a data source. 
        '-- This will only be done once to give us some default data to work with.

        Data = <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
               <languages>
                   <language>
                       <Name>VB Dot Net</Name>
                       <Producer>Microsoft</Producer>
                   </language>
                   <language>
                       <Name>Java</Name>
                       <Producer>Oracle</Producer>
                   </language>
               </languages>
        '-- Create the file.
        Data.Save(strFilePath)

    End Function



End Class
