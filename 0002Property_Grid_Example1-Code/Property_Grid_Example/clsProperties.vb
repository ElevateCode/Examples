Imports System.ComponentModel
Public Class clsProperties

    Private m_Men As String
    Private m_Women As String
    Private m_Dog As String
    Private m_Cat As String
    <Category("People"), Description("Men are adult boys")>
    Public Property Men() As String
        Get
            Return m_Men
        End Get
        Set(ByVal value As String)
            m_Men = value
        End Set
    End Property
    <Category("People"), Description("Women are adult girls")>
    Public Property Women() As String
        Get
            Return m_Women
        End Get
        Set(ByVal value As String)
            m_Women = value
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




    




   
    












End Class
