Imports System.Drawing.Printing

Public Class frmPrinting
    Dim lstLinesToPrint As New List(Of String)


    Private Sub tsOpenFile_Click(sender As System.Object, e As System.EventArgs) Handles tsOpenFile.Click
        Dim objReader As New System.IO.StreamReader("BillofRights.txt")
        txtFile.Text = objReader.ReadToEnd
        objReader.Close()
    End Sub

    Private Sub tsPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsPrint.Click
        PrintDialog.PrinterSettings = PrintDoc.PrinterSettings

        If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDoc.PrinterSettings = PrintDialog.PrinterSettings

            Dim PageSetup As New PageSettings
            With PageSetup
                .Margins.Left = 50
                .Margins.Right = 50
                .Margins.Top = 50
                .Margins.Bottom = 50
                .Landscape = False
            End With
            PrintDoc.DefaultPageSettings = PageSetup

        End If
        PrintPreviewDialog.Document = PrintDoc
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDoc_BeginPrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        Dim fntText As Font = txtFile.Font
        Dim txtWidth As Integer = PrintDoc.DefaultPageSettings.PaperSize.Width - PrintDoc.DefaultPageSettings.Margins.Left - PrintDoc.DefaultPageSettings.Margins.Right
        Dim stringSize As New SizeF
        

        Dim g = Me.CreateGraphics

        lstLinesToPrint.Clear()

        For intCounter = 0 To txtFile.Lines.Count - 1

            stringSize = g.MeasureString(txtFile.Lines(intCounter), fntText)

            If stringSize.Width < txtWidth Then
                '-- The line fits so just go ahead and add it to the list of things to print.
                lstLinesToPrint.Add(txtFile.Lines(intCounter))
            Else
                '-- Otherwise the line is too long so we need to break it up, and rebuild it to fit.
                Dim LeftMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Left
                Dim TopMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Top
                Dim sfBuffer As SizeF = g.MeasureString("M", fntText)
                Dim layOutRec As New RectangleF(LeftMargin, TopMargin, txtWidth - sfBuffer.Width, fntText.Height)
                Dim string_format As New StringFormat
                string_format.Trimming = StringTrimming.Word
                Dim CharactersFitted As Integer = 0
                Dim LinesFilled As Integer = 0 '-- Not using this for example but need to pass it into the method.

                For intFittedChar = 0 To txtFile.Lines(intCounter).Length - 1
                    '-- See how many characters will fit on one line in the page margins
                    g.MeasureString(txtFile.Lines(intCounter).Substring(intFittedChar), fntText, New SizeF(layOutRec.Width, layOutRec.Height) _
                                    , string_format, CharactersFitted, LinesFilled)

                    lstLinesToPrint.Add(txtFile.Lines(intCounter).Substring(intFittedChar, CharactersFitted))

                    intFittedChar += CharactersFitted - 1
                Next
            End If
        Next



        

    End Sub

    Private Sub PrintDoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Static intStart As Integer
        Dim fntText As Font = txtFile.Font
        Dim txtHeight As Integer
        Dim LeftMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Left
        Dim TopMargin As Integer = PrintDoc.DefaultPageSettings.Margins.Top
        txtHeight = PrintDoc.DefaultPageSettings.PaperSize.Height - PrintDoc.DefaultPageSettings.Margins.Top - PrintDoc.DefaultPageSettings.Margins.Bottom

        Dim LinesPerPage As Integer = CInt(Math.Round(txtHeight / (fntText.Height + 0.025)))

        e.Graphics.DrawRectangle(Pens.Red, e.MarginBounds)
        Dim intLineNumber As Integer

        For intCounter = intStart To lstLinesToPrint.Count - 1
            e.Graphics.DrawString(lstLinesToPrint(intCounter), fntText, Brushes.Black, LeftMargin, fntText.Height * intLineNumber + TopMargin)
            intLineNumber += 1
            If intLineNumber > LinesPerPage - 1 Then
                intStart = intCounter
                e.HasMorePages = True '-- This is recursive. It will call the Print Page Sub again when it's set to true.
                Exit For
            End If

        Next

    End Sub


End Class
