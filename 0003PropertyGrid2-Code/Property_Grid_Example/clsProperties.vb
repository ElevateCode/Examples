Imports System.ComponentModel
Public Class clsProperties

    Private m_Male As String
    Private m_Female As String
    Private m_Dog As String
    Private m_Cat As String
    Private m_DogColor As String
    Private m_DogName As String
    Private m_DogImage As String

    Public Sub New()
        m_DogColor = "Black"
    End Sub

    <Category("People"), Description("Males are adult boys")>
    Public Property Male() As String
        Get
            Return m_Male
        End Get
        Set(ByVal value As String)
            m_Male = value
        End Set
    End Property
    <Category("People"), Description("Female are adult girls")>
    Public Property Female() As String
        Get
            Return m_Female
        End Get
        Set(ByVal value As String)
            m_Female = value
        End Set
    End Property
    <Category("Pets"), Description("Dogs Bark")>
    Public Property Dog() As String
        Get
            Return m_Dog
        End Get
        Set(ByVal value As String)
            m_Dog = value
        End Set
    End Property
    <Category("Pets"), Description("Cats Meow")>
    Public Property Cat() As String
        Get
            Return m_Cat
        End Get
        Set(ByVal value As String)
            m_Cat = value
        End Set
    End Property

    <[ReadOnly](True), Category("Pets"), Description("The Dogs color is read only"), DisplayName("Dog Color")>
    Public ReadOnly Property DogColor() As String
        Get
            Return m_DogColor
        End Get

    End Property

    <TypeConverter(GetType(clsDogNames)), Category("Pets"), Description("Select Your Dogs Name from the list"), DisplayName("Dog Name")>
    Public Property DogName() As String
        Get
            Return m_DogName
        End Get
        Set(ByVal value As String)
            m_DogName = value
        End Set
    End Property

    <Editor(GetType(clsImgFileName), GetType(System.Drawing.Design.UITypeEditor)), DefaultValue(""), Category("Pets"), Description("Select the image for your Dog"), DisplayName("Dog Image")>
    Public Property DogImage() As String
        Get
            Return m_DogImage
        End Get
        Set(ByVal value As String)
            m_DogImage = value
        End Set
    End Property


   


   


    




   
    












End Class
