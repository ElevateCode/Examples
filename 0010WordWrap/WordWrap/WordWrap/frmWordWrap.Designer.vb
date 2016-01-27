<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBoxWrap = New System.Windows.Forms.TextBox()
        Me.btnStringFormatPage = New System.Windows.Forms.Button()
        Me.btnClientRectangle = New System.Windows.Forms.Button()
        Me.btnLinesCount = New System.Windows.Forms.Button()
        Me.btnMeasureRectangle = New System.Windows.Forms.Button()
        Me.btnDrawLines = New System.Windows.Forms.Button()
        Me.lblTextBoxWrap = New System.Windows.Forms.Label()
        Me.lblLinesPrinting = New System.Windows.Forms.Label()
        Me.btnStringFormatLine = New System.Windows.Forms.Button()
        Me.btnVerticalText = New System.Windows.Forms.Button()
        Me.btnTabStop = New System.Windows.Forms.Button()
        Me.btnFontInfo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBoxWrap
        '
        Me.txtBoxWrap.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxWrap.Location = New System.Drawing.Point(12, 30)
        Me.txtBoxWrap.Multiline = True
        Me.txtBoxWrap.Name = "txtBoxWrap"
        Me.txtBoxWrap.Size = New System.Drawing.Size(251, 204)
        Me.txtBoxWrap.TabIndex = 0
        '
        'btnStringFormatPage
        '
        Me.btnStringFormatPage.Location = New System.Drawing.Point(246, 289)
        Me.btnStringFormatPage.Name = "btnStringFormatPage"
        Me.btnStringFormatPage.Size = New System.Drawing.Size(135, 23)
        Me.btnStringFormatPage.TabIndex = 2
        Me.btnStringFormatPage.Text = "String Page Format Near"
        Me.btnStringFormatPage.UseVisualStyleBackColor = True
        '
        'btnClientRectangle
        '
        Me.btnClientRectangle.Location = New System.Drawing.Point(105, 289)
        Me.btnClientRectangle.Name = "btnClientRectangle"
        Me.btnClientRectangle.Size = New System.Drawing.Size(135, 23)
        Me.btnClientRectangle.TabIndex = 3
        Me.btnClientRectangle.Text = "Client Rectangle"
        Me.btnClientRectangle.UseVisualStyleBackColor = True
        '
        'btnLinesCount
        '
        Me.btnLinesCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLinesCount.Location = New System.Drawing.Point(397, 318)
        Me.btnLinesCount.Name = "btnLinesCount"
        Me.btnLinesCount.Size = New System.Drawing.Size(135, 23)
        Me.btnLinesCount.TabIndex = 6
        Me.btnLinesCount.Text = "Characters-Lines Count "
        Me.btnLinesCount.UseVisualStyleBackColor = True
        '
        'btnMeasureRectangle
        '
        Me.btnMeasureRectangle.Location = New System.Drawing.Point(105, 318)
        Me.btnMeasureRectangle.Name = "btnMeasureRectangle"
        Me.btnMeasureRectangle.Size = New System.Drawing.Size(135, 23)
        Me.btnMeasureRectangle.TabIndex = 7
        Me.btnMeasureRectangle.Text = "Measure Rectangle"
        Me.btnMeasureRectangle.UseVisualStyleBackColor = True
        '
        'btnDrawLines
        '
        Me.btnDrawLines.Location = New System.Drawing.Point(105, 347)
        Me.btnDrawLines.Name = "btnDrawLines"
        Me.btnDrawLines.Size = New System.Drawing.Size(135, 23)
        Me.btnDrawLines.TabIndex = 8
        Me.btnDrawLines.Text = "Draw Lines"
        Me.btnDrawLines.UseVisualStyleBackColor = True
        '
        'lblTextBoxWrap
        '
        Me.lblTextBoxWrap.AutoSize = True
        Me.lblTextBoxWrap.Location = New System.Drawing.Point(9, 9)
        Me.lblTextBoxWrap.Name = "lblTextBoxWrap"
        Me.lblTextBoxWrap.Size = New System.Drawing.Size(0, 13)
        Me.lblTextBoxWrap.TabIndex = 10
        '
        'lblLinesPrinting
        '
        Me.lblLinesPrinting.AutoSize = True
        Me.lblLinesPrinting.Location = New System.Drawing.Point(360, 9)
        Me.lblLinesPrinting.Name = "lblLinesPrinting"
        Me.lblLinesPrinting.Size = New System.Drawing.Size(0, 13)
        Me.lblLinesPrinting.TabIndex = 11
        '
        'btnStringFormatLine
        '
        Me.btnStringFormatLine.Location = New System.Drawing.Point(246, 318)
        Me.btnStringFormatLine.Name = "btnStringFormatLine"
        Me.btnStringFormatLine.Size = New System.Drawing.Size(135, 23)
        Me.btnStringFormatLine.TabIndex = 12
        Me.btnStringFormatLine.Text = "String Line Format Near"
        Me.btnStringFormatLine.UseVisualStyleBackColor = True
        '
        'btnVerticalText
        '
        Me.btnVerticalText.Location = New System.Drawing.Point(246, 347)
        Me.btnVerticalText.Name = "btnVerticalText"
        Me.btnVerticalText.Size = New System.Drawing.Size(135, 23)
        Me.btnVerticalText.TabIndex = 13
        Me.btnVerticalText.Text = "Vertical Text Near"
        Me.btnVerticalText.UseVisualStyleBackColor = True
        '
        'btnTabStop
        '
        Me.btnTabStop.Location = New System.Drawing.Point(397, 289)
        Me.btnTabStop.Name = "btnTabStop"
        Me.btnTabStop.Size = New System.Drawing.Size(135, 23)
        Me.btnTabStop.TabIndex = 14
        Me.btnTabStop.Text = "Tab Stops"
        Me.btnTabStop.UseVisualStyleBackColor = True
        '
        'btnFontInfo
        '
        Me.btnFontInfo.Location = New System.Drawing.Point(397, 347)
        Me.btnFontInfo.Name = "btnFontInfo"
        Me.btnFontInfo.Size = New System.Drawing.Size(135, 23)
        Me.btnFontInfo.TabIndex = 15
        Me.btnFontInfo.Text = "Font Info"
        Me.btnFontInfo.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 428)
        Me.Controls.Add(Me.btnFontInfo)
        Me.Controls.Add(Me.btnTabStop)
        Me.Controls.Add(Me.btnVerticalText)
        Me.Controls.Add(Me.btnStringFormatLine)
        Me.Controls.Add(Me.lblLinesPrinting)
        Me.Controls.Add(Me.lblTextBoxWrap)
        Me.Controls.Add(Me.btnDrawLines)
        Me.Controls.Add(Me.btnMeasureRectangle)
        Me.Controls.Add(Me.btnLinesCount)
        Me.Controls.Add(Me.btnClientRectangle)
        Me.Controls.Add(Me.btnStringFormatPage)
        Me.Controls.Add(Me.txtBoxWrap)
        Me.Name = "Form1"
        Me.Text = "Word Wrap Printing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxWrap As System.Windows.Forms.TextBox
    Friend WithEvents btnStringFormatPage As System.Windows.Forms.Button
    Friend WithEvents btnClientRectangle As System.Windows.Forms.Button
    Friend WithEvents btnLinesCount As System.Windows.Forms.Button
    Friend WithEvents btnMeasureRectangle As System.Windows.Forms.Button
    Friend WithEvents btnDrawLines As System.Windows.Forms.Button
    Friend WithEvents lblTextBoxWrap As System.Windows.Forms.Label
    Friend WithEvents lblLinesPrinting As System.Windows.Forms.Label
    Friend WithEvents btnStringFormatLine As System.Windows.Forms.Button
    Friend WithEvents btnVerticalText As System.Windows.Forms.Button
    Friend WithEvents btnTabStop As System.Windows.Forms.Button
    Friend WithEvents btnFontInfo As System.Windows.Forms.Button

End Class
