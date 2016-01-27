Imports System.Drawing.Printing
Public Class frmPrintTest
    Dim lstLinesToPrint As New List(Of String)


    Private Sub btnLoadFile_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadFile.Click
        '-- Get the Text from here and save it to txt file in bin folder http://www.archives.gov/exhibits/charters/bill_of_rights_transcript.html
        Dim objReader As New System.IO.StreamReader("BillofRights.txt")
        txtFile.Text = objReader.ReadToEnd
        objReader.Close()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click


        '-- Set the PrintDialog Printer settings to the Print Document Settings

        PrintDialog.PrinterSettings = PrintDoc.PrinterSettings

        If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '-- Now set the Print Document to what the dialog setting that were selected
            PrintDoc.PrinterSettings = PrintDialog.PrinterSettings

            '-- We can have a Page Settings dialog or we can hard code it for this example lets hard code it.
            Dim PageSetUp As New PageSettings
            '-- The default coordinate system of the page is 1/100 of an inch.
            With PageSetUp
                .Margins.Left = 50
                .Margins.Right = 50
                .Margins.Top = 50
                .Margins.Bottom = 50
                .Landscape = False
            End With
            PrintDoc.DefaultPageSettings = PageSetUp
        End If

        '-- Because it's a video we will print the preview window if we are printing for real we only have to call 
        '-- PrintDoc.Print method
        PrintPreviewDialog.Document = PrintDoc
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDoc_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        '-- Get our lines to print first
        Dim fntText As Font = txtFile.Font
        Dim txtWidth As Integer = PrintDoc.DefaultPageSettings.PaperSize.Width - PrintDoc.DefaultPageSettings.Margins.Left - PrintDoc.DefaultPageSettings.Margins.Right
        Dim stringSize As New SizeF
        Dim g = Me.CreateGraphics

        '-- Make sure we are starting with a new list
        lstLinesToPrint.Clear()

        '-- Loop thru the lines in the text box and break them down to fit in the printable area.
        For intCounter = 0 To txtFile.Lines.Count - 1
            '-- Get the width of the string
            stringSize = g.MeasureString(txtFile.Lines(intCounter), fntText)

            If stringSize.Width < txtWidth Then
                '-- This line will print nothing needs to be done
                lstLinesToPrint.Add(txtFile.Lines(intCounter))
            Else
                '-- This line is too long break it up
                Dim strWords() As String = txtFile.Lines(intCounter).Split(" ")
                Dim strMeasure As String = ""
                Dim intMaxWords As Integer = 0
                Dim intStartPoint As Integer = 0
                Dim sfBuffer As SizeF = g.MeasureString("MMMMMM", fntText)

                '-- Now see how many words we can put on this line.
                For count = 0 To strWords.Length - 1

                    strMeasure += strWords(count) + " "
                    stringSize = g.MeasureString(strMeasure, fntText)
                    '-- Keep adding words till they excedd the limit.
                    If stringSize.Width > txtWidth - sfBuffer.Width Then
                        '-- Now the line is one word to long so remove it. 
                        intMaxWords = count - 1
                        strMeasure = ""
                        For i = intStartPoint To intMaxWords
                            strMeasure += strWords(i) + " "
                        Next
                        '-- Do add here
                        lstLinesToPrint.Add(strMeasure)
                        strMeasure = ""
                        intStartPoint = intMaxWords + 1
                    End If

                    '-- Now  add the remain part of the line to the list
                    If count = strWords.Length - 1 Then
                        strMeasure = ""
                        For i = intMaxWords + 1 To strWords.Count - 1
                            strMeasure += strWords(i) + " "
                        Next
                        '-- Do add here
                        lstLinesToPrint.Add(strMeasure)
                        strMeasure = ""
                    End If

                Next
            End If

        Next

    End Sub


    Private Sub PrintDoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Static intStart As Integer

        Dim fntText As Font = txtFile.Font

        Dim txtHeight As Integer
        '-- Just short hand variables
        Dim LeftMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Left
        Dim TopMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Top
        '-- Get the printable area
        txtHeight = PrintDoc.DefaultPageSettings.PaperSize.Height - PrintDoc.DefaultPageSettings.Margins.Top - PrintDoc.DefaultPageSettings.Margins.Bottom

        '-- Calculate the number of lines per page .25 is just a buffer spacing need to remove the hard coding later and fix it to the font.
        Dim LinesPerPage As Integer = CInt(Math.Round(txtHeight / (fntText.Height + 0.25)))

        Dim intLineNumber As Integer = 0

        '-- Draw a border around the printable area.
        e.Graphics.DrawRectangle(Pens.Red, e.MarginBounds)

        '-- Loop thru the lines in the list and print them out
        For intCounter = intStart To lstLinesToPrint.Count - 1
            e.Graphics.DrawString(lstLinesToPrint(intCounter), fntText, Brushes.Black, LeftMargin, (fntText.Height * intLineNumber) + TopMargin)
            intLineNumber += 1

            If intLineNumber > LinesPerPage - 1 Then
                '-- Start where we left off.
                intStart = intCounter
                e.HasMorePages = True
                Exit For
            End If
        Next


    End Sub


End Class
