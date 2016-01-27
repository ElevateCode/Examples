<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDelete
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
        Me.gvXML = New System.Windows.Forms.DataGridView()
        Me.lstMake = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.bntKillFile = New System.Windows.Forms.Button()
        CType(Me.gvXML, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvXML
        '
        Me.gvXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvXML.Location = New System.Drawing.Point(12, 51)
        Me.gvXML.Name = "gvXML"
        Me.gvXML.Size = New System.Drawing.Size(278, 267)
        Me.gvXML.TabIndex = 0
        '
        'lstMake
        '
        Me.lstMake.FormattingEnabled = True
        Me.lstMake.Location = New System.Drawing.Point(377, 51)
        Me.lstMake.Name = "lstMake"
        Me.lstMake.Size = New System.Drawing.Size(121, 186)
        Me.lstMake.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(377, 254)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(121, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete Make"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'bntKillFile
        '
        Me.bntKillFile.Location = New System.Drawing.Point(21, 12)
        Me.bntKillFile.Name = "bntKillFile"
        Me.bntKillFile.Size = New System.Drawing.Size(102, 23)
        Me.bntKillFile.TabIndex = 3
        Me.bntKillFile.Text = "Kill Data File"
        Me.bntKillFile.UseVisualStyleBackColor = True
        '
        'frmDelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 362)
        Me.Controls.Add(Me.bntKillFile)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstMake)
        Me.Controls.Add(Me.gvXML)
        Me.Name = "frmDelete"
        Me.Text = "LINQ Delete Example using XML dataset"
        CType(Me.gvXML, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvXML As System.Windows.Forms.DataGridView
    Friend WithEvents lstMake As System.Windows.Forms.ListBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents bntKillFile As System.Windows.Forms.Button

End Class
