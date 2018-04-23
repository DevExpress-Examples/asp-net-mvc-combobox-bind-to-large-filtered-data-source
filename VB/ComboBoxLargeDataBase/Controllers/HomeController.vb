Imports Microsoft.VisualBasic
Imports System.Web.Mvc
Imports ComboBoxLargeDataBase.Model

Namespace ComboBoxLargeDataBase.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View(DataHelper.Persons)
		End Function
		Public Function ComboBoxPartial() As ActionResult
			Return PartialView("ComboBoxPartial", DataHelper.Persons)
		End Function
	End Class
End Namespace
