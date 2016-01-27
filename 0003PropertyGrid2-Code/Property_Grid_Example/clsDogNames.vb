Public Class clsDogNames
    Inherits System.ComponentModel.StringConverter

    Public Overrides Function GetStandardValues(context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        '-- Set to True if they must choose from the list or false if they can type into the list box.
        Return True
    End Function

    Private Function myList() As Collections.IList
        Dim colDogNameList As New Collection

        With colDogNameList
            .Add("Benji")
            .Add("Bolt")
            .Add("Lucky")
            .Add("Old Yellow")

        End With
        Return colDogNameList

    End Function
End Class
