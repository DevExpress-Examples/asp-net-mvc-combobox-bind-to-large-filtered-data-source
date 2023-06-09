Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.ASPxEditors

Namespace ComboBoxLargeDataBase.Model

    Public Module DataHelper

        Public ReadOnly Property Persons As IQueryable(Of Person)
            Get
                If HttpContext.Current.Session("Persons") Is Nothing Then
                    Dim list As List(Of Person) = New List(Of Person)()
                    list.Add(New Person(1, "David", "Jordan", "Adler"))
                    list.Add(New Person(2, "Michael", "Christopher", "Alcamo"))
                    list.Add(New Person(3, "Amy", "Gabrielle", "Altmann"))
                    list.Add(New Person(4, "Meredith", "", "Berman"))
                    list.Add(New Person(5, "Margot", "Sydney", "Atlas"))
                    list.Add(New Person(6, "Eric", "Zachary", "Berkowitz"))
                    list.Add(New Person(7, "Kyle", "", "Bernardo"))
                    list.Add(New Person(8, "Liz", "", "Bice"))
                    HttpContext.Current.Session("Persons") = list.AsQueryable(Of Person)()
                End If

                Return CType(HttpContext.Current.Session("Persons"), IQueryable(Of Person))
            End Get
        End Property

        Public Function GetPersonsRange(ByVal args As ListEditItemsRequestedByFilterConditionEventArgs) As Object
            Dim skip = args.BeginIndex
            Dim take = args.EndIndex - args.BeginIndex + 1
            Return(From person In Persons Where(person.FirstName & " " & person.MiddleName & " " & person.LastName).ToLower().Contains(args.Filter.ToLower()) Order By person.LastName Select person).Skip(skip).Take(take)
        End Function

        Public Function GetPersonByID(ByVal args As ListEditItemRequestedByValueEventArgs) As Object
            If args.Value IsNot Nothing Then Return GetPersonByID(CInt(args.Value))
            Return Nothing
        End Function

        Public Function GetPersonByID(ByVal personID As Integer) As Object
            Return(From person In Persons Where person.PersonID = personID Select person).Take(1)
        End Function
    End Module

    Public Class Person

        Public Sub New()
            PersonID = 0
            FirstName = String.Empty
            MiddleName = String.Empty
            LastName = String.Empty
        End Sub

        Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal middleName As String, ByVal lastName As String)
            PersonID = id
            Me.FirstName = firstName
            Me.MiddleName = middleName
            Me.LastName = lastName
        End Sub

        Public Property PersonID As Integer

        Public Property FirstName As String

        Public Property MiddleName As String

        Public Property LastName As String
    End Class
End Namespace
