Class MainWindow

#Region "Menu Items"
    Private Sub mnuFile_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuFile.Click
        MsgBox("File Menu was clicked")
    End Sub

    Private Sub mnuNew_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuNew.Click
        MsgBox("New Menu was clicked")
    End Sub

    Private Sub mnuOpen_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuOpen.Click
        MsgBox("Open Menu was clicked")
    End Sub

    Private Sub mnuPDF_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuPDF.Click
        MsgBox("PDF Sub Menu of Open was clicked")
    End Sub

    Private Sub mnuDoc_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuDoc.Click
        MsgBox("Doc Sub Menu of Open was clicked")
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuSave.Click
        MsgBox("Save Menu was clicked")
    End Sub
    Private Sub mnuExit_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuExit.Click
        MsgBox("Exit Menu was clicked")
    End Sub

#End Region








End Class
