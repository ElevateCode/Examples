Class MainWindow

#Region "Menu Items"
    Private Sub mnuFile_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuFile.Click
        MsgBox("File Menu was clicked")
        e.Handled = True
    End Sub

    Private Sub mnuNew_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuNew.Click
        MsgBox("New Menu was clicked")
        e.Handled = True
    End Sub

    Private Sub mnuOpen_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuOpen.Click
        MsgBox("Open Menu was clicked")
        e.Handled = True
    End Sub

    Private Sub mnuPDF_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuPDF.Click
        MsgBox("PDF Sub Menu of Open was clicked")
        e.Handled = True
    End Sub

    Private Sub mnuDoc_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuDoc.Click
        MsgBox("Doc Sub Menu of Open was clicked")
        e.Handled = True
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuSave.Click
        MsgBox("Save Menu was clicked")
        e.Handled = True
    End Sub
    Private Sub mnuExit_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuExit.Click
        MsgBox("Exit Menu was clicked")
        e.Handled = True
    End Sub
    Private Sub mnuZoom_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles mnuZoom.Click
        MsgBox("Zoom Menu was Clicked")
    End Sub

    Public Sub SetUpShortCutKeys()

        Dim NewCmdGester As New KeyGesture(Key.N, ModifierKeys.Control)
        Dim SaveCmdGester As New KeyGesture(Key.S, ModifierKeys.Control)
        Dim ExitCmdGester As New KeyGesture(Key.E, ModifierKeys.Control)
        Dim ZoomCmdGester As New KeyGesture(Key.Z, ModifierKeys.Control)

        mnuNew.InputGestureText = "Ctrl + N"
        mnuSave.InputGestureText = "Ctrl + S"
        mnuExit.InputGestureText = "Ctrl + E"
        mnuZoom.InputGestureText = "Ctrl + Z"

        mnuNew.Command = ApplicationCommands.[New]
        mnuSave.Command = ApplicationCommands.Save
        mnuExit.Command = PersonalCommands.ExitProgram
        mnuZoom.Command = PersonalCommands.ZoomWindow

        ApplicationCommands.[New].InputGestures.Add(NewCmdGester)
        ApplicationCommands.Save.InputGestures.Add(SaveCmdGester)
        PersonalCommands.ExitProgram.InputGestures.Add(ExitCmdGester)
        PersonalCommands.ZoomWindow.InputGestures.Add(ZoomCmdGester)


        Dim NewCmdBinding As New CommandBinding(ApplicationCommands.[New], AddressOf mnuNew_Click)
        Dim SaveCmdBinding As New CommandBinding(ApplicationCommands.Save, AddressOf mnuSave_Click)
        Dim CloseCmdBinding As New CommandBinding(PersonalCommands.ExitProgram, AddressOf mnuExit_Click)
        Dim ZoomCmdBinding As New CommandBinding(PersonalCommands.ZoomWindow, AddressOf mnuZoom_Click)


        CommandBindings.Add(NewCmdBinding)
        CommandBindings.Add(SaveCmdBinding)
        CommandBindings.Add(CloseCmdBinding)
        CommandBindings.Add(ZoomCmdBinding)



    End Sub
#End Region

  

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
       
        ' Add any initialization after the InitializeComponent() call.
        SetUpShortCutKeys()

  
    End Sub

  
  
    
End Class
