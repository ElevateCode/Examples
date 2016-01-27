Public Class PersonalCommands

    Private Shared m_cmdExit As New RoutedUICommand("Exit", "Exit", GetType(PersonalCommands))
    Private Shared m_cmdZoom As New RoutedUICommand("Zoom", "Zoom", GetType(PersonalCommands))

    Public Shared ReadOnly Property ExitProgram() As RoutedUICommand
        Get
            Return m_cmdExit
        End Get
    End Property
    Public Shared ReadOnly Property ZoomWindow() As RoutedUICommand
        Get
            Return m_cmdZoom
        End Get
    End Property


End Class
