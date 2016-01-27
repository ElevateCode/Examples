Public Class clsImgFileName
    Inherits System.Drawing.Design.UITypeEditor

    Private OpenFileDialog As New OpenFileDialog

    Public Overrides Function EditValue(context As System.ComponentModel.ITypeDescriptorContext, provider As System.IServiceProvider, value As Object) As Object
        If (Not (context Is Nothing) And Not (context.Instance Is Nothing) And Not (provider Is Nothing)) Then
            If CType(value, String) <> "" Then OpenFileDialog.FileName = CType(value, String)
            With OpenFileDialog
                .ShowReadOnly = False
                .Title = "Select the image file"
                .ValidateNames = True
                .CheckFileExists = True
                .Filter = "Pictures (*.bmp; *.jpg;*) |*.bmp; *.jpg;"
                .ShowDialog()
                value = .FileName
            End With
        End If
        Return CType(value, String)
    End Function

    Public Overrides Function GetEditStyle(context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        If (Not (context Is Nothing) And Not (context.Instance Is Nothing)) Then
            Return System.Drawing.Design.UITypeEditorEditStyle.Modal
        End If
        Return MyBase.GetEditStyle(context)
    End Function
End Class
