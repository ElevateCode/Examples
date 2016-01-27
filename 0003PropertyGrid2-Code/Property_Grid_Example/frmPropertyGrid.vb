Public Class frmPropertyGrid
    Dim myProperties As New clsProperties

    Private Sub frmPropertyGrid_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '-- Tie the Grid Control to the Object
        PropertyGridExample.SelectedObject = myProperties

    End Sub
End Class
