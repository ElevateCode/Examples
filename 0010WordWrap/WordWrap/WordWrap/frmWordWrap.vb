Imports System.Drawing

Public Class Form1
    Dim g As Graphics
    Dim ClientRecF As RectangleF
    Dim MeasureRecF As RectangleF

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtBoxWrap.Text = "Short Lines are easy." + ControlChars.CrLf
        txtBoxWrap.Text += "The lines in this text box do not have many hard returns they consist of mostly soft returns that are not catch able using vb.net control properties." + ControlChars.CrLf
        txtBoxWrap.Text += "We must use windows API calls or print methods, to figure out how many lines and character per word wrap line."
        g = Me.CreateGraphics
    End Sub

    Private Sub btnClientRectangle_Click(sender As System.Object, e As System.EventArgs) Handles btnClientRectangle.Click
        '-- Clear the print area
        DrawClientRecF()
    End Sub

    Private Sub btnMeasureRectangle_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasureRectangle.Click
        '-- Clear the print area
        DrawClientRecF()

        MeasureRecF = New RectangleF(360, 30, txtBoxWrap.Width, txtBoxWrap.Font.Height)
        '-- Show our measure rectangle
        g.DrawRectangle(Pens.Red, MeasureRecF.X, MeasureRecF.Y, MeasureRecF.Width, MeasureRecF.Height)
        '-- Draw text inside the rectangle.
        g.DrawString("This text is in the measure rectangle", txtBoxWrap.Font, Brushes.Black, MeasureRecF)
    End Sub

    Private Sub btnDrawLines_Click(sender As System.Object, e As System.EventArgs) Handles btnDrawLines.Click
        '-- Clear the print area
        DrawClientRecF()
        '-- Figure how many lines will fit in the print area.
        Dim LinesPerTexBox As Integer = CInt(Math.Round(txtBoxWrap.Height / (txtBoxWrap.Font.Height * 1.025)))

        Dim String_Format As New StringFormat
        String_Format.Alignment = StringAlignment.Far

        Dim DashPen As New Pen(Brushes.Gray)
        DashPen.DashStyle = Drawing2D.DashStyle.Dash

        Dim offset As Integer = 30
        Dim dashOffSet As Integer = txtBoxWrap.Font.Height / 2


        For intCounter = 1 To LinesPerTexBox
            '-- Our Numbers
            g.DrawString(intCounter.ToString, txtBoxWrap.Font, Brushes.Blue, 340, offset, String_Format)
            '-- Our Letters
            g.DrawString(Chr(64 + intCounter), txtBoxWrap.Font, Brushes.Black, 360, offset)
            '-- Move down one line
            offset += txtBoxWrap.Font.Height
            '-- Dash Line
            g.DrawLine(DashPen, 360, offset - dashOffSet, 360 + txtBoxWrap.Width, offset - dashOffSet)
            '-- Solid Line
            g.DrawLine(Pens.Gray, 360, offset, 360 + txtBoxWrap.Width, offset)

        Next

    End Sub

    Private Sub btnStringFormatPage_Click(sender As System.Object, e As System.EventArgs) Handles btnStringFormatPage.Click
        '-- Clear the print area
        DrawClientRecF()

        Dim String_Format As New StringFormat
        Dim strText As String = ""

        If btnStringFormatPage.Text = "String Page Format Near" Then
            '-- Change the flag to see what happen on far and center.
            String_Format.LineAlignment = StringAlignment.Near
            strText = "The String Alignement is Near"
            btnStringFormatPage.Text = "String Page Format Center"

        ElseIf btnStringFormatPage.Text = "String Page Format Center" Then
            String_Format.LineAlignment = StringAlignment.Center
            strText = "The String Alignement is Center"
            btnStringFormatPage.Text = "String Page Format Far"

        ElseIf btnStringFormatPage.Text = "String Page Format Far" Then
            String_Format.LineAlignment = StringAlignment.Far
            strText = "The String Alignement is Far"
            btnStringFormatPage.Text = "String Page Format Near"

        End If

        ClientRecF = New RectangleF(360, 30, txtBoxWrap.Width + 2, txtBoxWrap.Height)

        g.DrawString(strText, txtBoxWrap.Font, Brushes.Black, ClientRecF, String_Format)

    End Sub

    Private Sub btnStringFormatLine_Click(sender As System.Object, e As System.EventArgs) Handles btnStringFormatLine.Click
        '-- Clear the print area
        DrawClientRecF()

        Dim String_Format As New StringFormat
        Dim strText As String = ""

        If btnStringFormatLine.Text = "String Line Format Near" Then
            '-- Change the flag to see what happen on far and center.
            String_Format.Alignment = StringAlignment.Near
            strText = "Align Near"
            btnStringFormatLine.Text = "String Line Format Center"

        ElseIf btnStringFormatLine.Text = "String Line Format Center" Then
            String_Format.Alignment = StringAlignment.Center
            strText = "Align Center"
            btnStringFormatLine.Text = "String Line Format Far"

        ElseIf btnStringFormatLine.Text = "String Line Format Far" Then
            String_Format.Alignment = StringAlignment.Far
            strText = "Align Far"
            btnStringFormatLine.Text = "String Line Format Near"

        End If

        MeasureRecF = New RectangleF(360, 30, txtBoxWrap.Width, txtBoxWrap.Font.Height)

        g.DrawString(strText, txtBoxWrap.Font, Brushes.Black, MeasureRecF, String_Format)
    End Sub

    Private Sub btnVerticalText_Click(sender As System.Object, e As System.EventArgs) Handles btnVerticalText.Click
        '-- Clear the print area
        DrawClientRecF()

        Dim String_Format As New StringFormat
        Dim strText As String = "Vertical String"

        String_Format.FormatFlags = StringFormatFlags.DirectionVertical

        If btnVerticalText.Text = "Vertical Text Near" Then
            '-- Change the flag to see what happen on far and center.
            String_Format.Alignment = StringAlignment.Near
            btnVerticalText.Text = "Vertical Text Center"

        ElseIf btnVerticalText.Text = "Vertical Text Center" Then
            String_Format.Alignment = StringAlignment.Center
            btnVerticalText.Text = "Vertical Text Far"

        ElseIf btnVerticalText.Text = "Vertical Text Far" Then
            String_Format.Alignment = StringAlignment.Far
            btnVerticalText.Text = "Vertical Text Near"

        End If


        ClientRecF = New RectangleF(360, 30, txtBoxWrap.Width + 2, txtBoxWrap.Height)

        g.DrawString(strText, txtBoxWrap.Font, Brushes.Black, ClientRecF, String_Format)
    End Sub

    Private Sub btnTabStop_Click(sender As System.Object, e As System.EventArgs) Handles btnTabStop.Click
        '-- Clear the print area
        DrawClientRecF()

        Dim String_Format As New StringFormat
        Dim strText As String = "Tab Stops" + ControlChars.Tab + "1" + ControlChars.Tab + "2" + ControlChars.Tab + "3" + ControlChars.CrLf + _
                                "Cool Stuff" + ControlChars.Tab + "A" + ControlChars.Tab + "B" + ControlChars.Tab + "C"

        '-- Our Client Rec is 253 wide so our first tab is 100 over and second is 150 thrid is 230
        Dim tabs As Single() = {100, 50, 80}
        String_Format.SetTabStops(0, tabs)
        ClientRecF = New RectangleF(360, 30, txtBoxWrap.Width + 2, txtBoxWrap.Height)

        g.DrawString(strText, txtBoxWrap.Font, Brushes.Black, ClientRecF, String_Format)
    End Sub

    Private Sub btnLinesCount_Click(sender As System.Object, e As System.EventArgs) Handles btnLinesCount.Click
        '-- Clear the print area
        DrawClientRecF()
        lblLinesPrinting.Text = ""
        lblTextBoxWrap.Text = ""
        '-- Very Easy to get
        lblTextBoxWrap.Text = "Lines in the text box line count property " + txtBoxWrap.Lines.Count.ToString
        '-- Soft returns for printing not so easy
        Dim stringSize As SizeF
        Dim intSoftReturnLines As Integer = 0
        Dim offset As Integer = 30
        Dim string_format As New StringFormat
        string_format.Trimming = StringTrimming.Word
        Dim sfBuffer As SizeF = g.MeasureString("M", txtBoxWrap.Font)

        MeasureRecF = New RectangleF(360, 30, txtBoxWrap.Width + sfBuffer.Width, txtBoxWrap.Font.Height)

        For intCounter = 0 To txtBoxWrap.Lines.Count - 1

            stringSize = g.MeasureString(txtBoxWrap.Lines(intCounter), txtBoxWrap.Font)

            If stringSize.Width < txtBoxWrap.Width Then
                '-- The line fits do nothing 
                intSoftReturnLines += 1
                g.DrawString("Characters Fitted " + txtBoxWrap.Lines(intCounter).Count.ToString, txtBoxWrap.Font _
                                 , System.Drawing.Brushes.SeaGreen, 360, offset, string_format)
                offset += txtBoxWrap.Font.Height
            Else

                Dim CharactersFitted As Integer = 0
                Dim LinesFilled As Integer = 0 '-- Not using this for example but need to pass it into method

                For intFittedChar = 0 To txtBoxWrap.Lines(intCounter).Length - 1
                    '-- See how many characters will fit on one line
                    g.MeasureString(txtBoxWrap.Lines(intCounter).Substring(intFittedChar), txtBoxWrap.Font, _
                                    New SizeF(MeasureRecF.Width, MeasureRecF.Height) _
                                    , string_format, CharactersFitted, LinesFilled)

                    intSoftReturnLines += 1
                    g.DrawString("Characters Fitted " + CharactersFitted.ToString, txtBoxWrap.Font _
                                 , Brushes.SeaGreen, 360, offset, string_format)

                    offset += txtBoxWrap.Font.Height
                    intFittedChar += CharactersFitted - 1
                Next
            End If
        Next

        lblLinesPrinting.Text = "The number of soft + Hard return lines is " + intSoftReturnLines.ToString

    End Sub

    Private Sub btnFontInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnFontInfo.Click
        '-- Clear the print area
        DrawClientRecF()
        Dim offset As Integer = 30
        Dim String_Format As New StringFormat
        String_Format.LineAlignment = StringAlignment.Near

        g.DrawString("The Font size is " + txtBoxWrap.Font.Size.ToString, txtBoxWrap.Font, Brushes.Black, 360, offset, String_Format)

        offset += txtBoxWrap.Font.Height

        g.DrawString("The Font design unit EM is " + txtBoxWrap.Font.FontFamily.GetEmHeight(FontStyle.Regular).ToString, _
                     txtBoxWrap.Font, Brushes.Black, 360, offset, String_Format)
        offset += txtBoxWrap.Font.Height

        g.DrawString("The Font Name (" + txtBoxWrap.Font.FontFamily.Name + ")", txtBoxWrap.Font, Brushes.Black, 360, offset, String_Format)



    End Sub

    Private Sub DrawClientRecF()
        '-- Makes the print area
        ClientRecF = New RectangleF(360, 30, txtBoxWrap.Width + 2, txtBoxWrap.Height)
        g.FillRectangle(Brushes.White, ClientRecF)
    End Sub

   
End Class
