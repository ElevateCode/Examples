Public Class PersonalCommands
    Private Shared m_cmdAddToDictionary As New RoutedUICommand("AddToDictionary", "AddToDictionary", GetType(PersonalCommands))

    Public Shared ReadOnly Property AddToCustDictionary() As RoutedUICommand
        Get
            Return m_cmdAddToDictionary
        End Get
    End Property
End Class
