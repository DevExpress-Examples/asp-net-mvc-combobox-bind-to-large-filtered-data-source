Imports System.Web.Mvc
Imports ComboBoxLargeDataBase.Model

Namespace ComboBoxLargeDataBase.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View(Persons)
        End Function

        Public Function ComboBoxPartial() As ActionResult
            Return PartialView("ComboBoxPartial", Persons)
        End Function
    End Class
End Namespace
