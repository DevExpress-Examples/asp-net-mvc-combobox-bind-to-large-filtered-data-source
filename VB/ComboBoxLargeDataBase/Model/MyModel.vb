Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web

Namespace ComboBoxLargeDataBase.Model
	Public NotInheritable Class DataHelper
		Private Sub New()
		End Sub
		Public Shared ReadOnly Property Persons() As IQueryable(Of Person)
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

					Dim query As IQueryable(Of Person) = list.AsQueryable()
                    			HttpContext.Current.Session("Persons") = query
				End If
				Return CType(HttpContext.Current.Session("Persons"), IQueryable(Of Person))
			End Get
		End Property

		Public Shared Function GetPersonsRange(ByVal args As ListEditItemsRequestedByFilterConditionEventArgs) As Object
			Dim skip = args.BeginIndex
			Dim take = args.EndIndex - args.BeginIndex + 1
			Return (From person In DataHelper.Persons _
			        Where (person.FirstName & " " & person.MiddleName & " " & person.LastName).ToLower().Contains(args.Filter.ToLower()) _
			        Order By person.LastName _
			        Select person).Skip(skip).Take(take)
		End Function
		Public Shared Function GetPersonByID(ByVal args As ListEditItemRequestedByValueEventArgs) As Object
			If args.Value IsNot Nothing Then
				Return GetPersonByID(CInt(Fix(args.Value)))
			End If
			Return Nothing
		End Function
		Public Shared Function GetPersonByID(ByVal personID As Integer) As Object
			Return (From person In DataHelper.Persons _
			        Where person.PersonID = personID _
			        Select person).Take(1)
		End Function
	End Class

	Public Class Person
		Public Sub New()
			PersonID = 0
			FirstName = String.Empty
			MiddleName = String.Empty
			LastName = String.Empty
		End Sub

		Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal middleName As String, ByVal lastName As String)
			Me.PersonID = id
			Me.FirstName = firstName
			Me.MiddleName = middleName
			Me.LastName = lastName
		End Sub

		Private privatePersonID As Integer
		Public Property PersonID() As Integer
			Get
				Return privatePersonID
			End Get
			Set(ByVal value As Integer)
				privatePersonID = value
			End Set
		End Property
		Private privateFirstName As String
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateMiddleName As String
		Public Property MiddleName() As String
			Get
				Return privateMiddleName
			End Get
			Set(ByVal value As String)
				privateMiddleName = value
			End Set
		End Property
		Private privateLastName As String
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property
	End Class
End Namespace
