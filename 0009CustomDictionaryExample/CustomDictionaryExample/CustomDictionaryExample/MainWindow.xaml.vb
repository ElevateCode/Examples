Imports System.IO
Class MainWindow
    Private strFolderPath As String
    Private ctmSpellCheck As ContextMenu
    Private strMisspelledWord As String
    Dim lstCustomDictionaries As IList
#Region "Events"
    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        '-- Set up our folder and files Needed for example.
        InitializeData()
        '-- Turn Spell Checking on for this text box.
        SpellCheck.SetIsEnabled(TextBox1, True)
        ctmSpellCheck = New ContextMenu()
        TextBox1.ContextMenu = ctmSpellCheck
        '-- lstCustomDictionaries is wired(encapsulated method) to spellcheck using the GetCustomDictionaries method
        '-- not only does it return the list of custom dictionaries it hooks to it return values and uses it as dictionary
        lstCustomDictionaries = SpellCheck.GetCustomDictionaries(TextBox1)
        lstCustomDictionaries.Add(New Uri(strFolderPath + "\CustomDictionary.lex"))
    End Sub
    Private Sub TextBox1_ContextMenuOpening(sender As System.Object, e As System.Windows.Controls.ContextMenuEventArgs) Handles TextBox1.ContextMenuOpening

        '-- Clear the context menu from its previous suggestions.
        ctmSpellCheck.Items.Clear()
        '-- Get the spelling error and add its suggestions to the context menu.
        Dim caretIndex As Integer = TextBox1.CaretIndex
        Dim cmdIndex As Integer = 0
        Dim spellingError As SpellingError = TextBox1.GetSpellingError(caretIndex)


        If spellingError IsNot Nothing Then
            '-- This is how we get the current missspell word.
            strMisspelledWord = TextBox1.Text.Substring(TextBox1.GetSpellingErrorStart(caretIndex), TextBox1.GetSpellingErrorLength(caretIndex))


            '-- Get the list of suggestions and add them to context menu.
            For Each str As String In spellingError.Suggestions
                Dim mi As New MenuItem()
                mi.Header = str
                mi.FontWeight = FontWeights.Bold
                mi.Command = EditingCommands.CorrectSpellingError
                mi.CommandParameter = str
                mi.CommandTarget = TextBox1
                TextBox1.ContextMenu.Items.Insert(cmdIndex, mi)
                cmdIndex += 1
            Next

            '-- Add (separator line) to the context menu
            Dim separatorMenuItem1 As New Separator()
            TextBox1.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem1)
            cmdIndex += 1

            '-- Add the (Ignore All) to the context menu
            Dim ignoreAllMI As New MenuItem()
            ignoreAllMI.Header = "Ignore All"
            ignoreAllMI.Command = EditingCommands.IgnoreSpellingError
            ignoreAllMI.CommandTarget = TextBox1
            TextBox1.ContextMenu.Items.Insert(cmdIndex, ignoreAllMI)
            cmdIndex += 1
            '-- Add (separator line) to the context menu
            Dim separatorMenuItem2 As New Separator()
            TextBox1.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem2)
            cmdIndex += 1

            '-- Add the (Add to Custom Dictionary) to the context menu 
            Dim addDicMI As New MenuItem
            addDicMI.Header = "Add To Custom Dictionary"
            addDicMI.Command = PersonalCommands.AddToCustDictionary
            addDicMI.CommandTarget = TextBox1
            TextBox1.ContextMenu.Items.Insert(cmdIndex, addDicMI)
            '-- now do the command binding.
            Dim NewCmdAddCustDic As New CommandBinding(PersonalCommands.AddToCustDictionary, AddressOf AddToCustDic)
            CommandBindings.Add(NewCmdAddCustDic)
        End If
    End Sub
#End Region
    Private Sub AddToCustDic()
        '-- Remove the Dictionary 
        lstCustomDictionaries.Remove(New Uri(strFolderPath + "\CustomDictionary.lex"))
        Dim objWriter As New System.IO.StreamWriter(strFolderPath + "\CustomDictionary.lex", True)
        '-- Write the word to the dictionary
        objWriter.WriteLine(strMisspelledWord)
        objWriter.Close()
        '-- Add the Dictionary back.
        lstCustomDictionaries.Add(New Uri(strFolderPath + "\CustomDictionary.lex"))
    End Sub
    Private Sub InitializeData()
        '-- Use this to set up Folders and Custom Dictionary file.
        '-- locating a specific special folder
        strFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        strFolderPath = strFolderPath & "\Custom Dictionary Example"
        '-- Check to see if folder Custom Dictionary Example exist in the user folder.
        If Directory.Exists(strFolderPath) = False Then
            '-- Create the Custom Dictionary Example Directory
            Directory.CreateDirectory(strFolderPath)
        End If
        '-- If the CustomDictionary.lex does not exist create it.
        If My.Computer.FileSystem.FileExists(strFolderPath & "\CustomDictionary.lex") = False Then
            Dim objWriter As New System.IO.StreamWriter(strFolderPath & "\CustomDictionary.lex", True)
            '#LID 4106 (Spanish - Guatemala)
            '#LID 1031 (German - Germany)
            '#LID 1036 (French - France)
            '#LID 1033 (English - United States)
            '#LID 2057 (English - United Kingdom)
            '#LID 1056 (Urdu) (Not supported by WPF Spell Check yet)
            objWriter.WriteLine("#LID 1033")
            objWriter.Close()
        End If
    End Sub

   
  
  
End Class
