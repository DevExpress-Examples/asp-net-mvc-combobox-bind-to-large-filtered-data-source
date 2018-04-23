@Code
    Dim comboBox As ComboBoxExtension = Html.DevExpress().ComboBox( _
        Sub(settings)
                settings.Name = "comboBox"
                settings.Width = 230
                settings.Properties.DropDownWidth = 350
                settings.Properties.DropDownStyle = DropDownStyle.DropDown
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "ComboBoxPartial"}
                settings.Properties.EnableCallbackMode = True
                settings.Properties.CallbackPageSize = 5
                settings.Properties.DropDownRows = 4
                settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                settings.Properties.TextField = "FirstName"
                settings.Properties.TextFormatString = "{0} {1} {2}"
                settings.Properties.ValueField = "PersonID"
                settings.Properties.ValueType = GetType(System.Int32)

                settings.Properties.Columns.Add("FirstName", "FirstName", 90)
                settings.Properties.Columns.Add("MiddleName", "MiddleName", System.Web.UI.WebControls.Unit.Percentage(100))
                settings.Properties.Columns.Add("LastName", "LastName", 90)

                settings.Properties.ClientSideEvents.EndCallback = "OnEndCallback"
        End Sub).BindList(AddressOf ComboBoxLargeDataBase.Model.DataHelper.GetPersonsRange, AddressOf ComboBoxLargeDataBase.Model.DataHelper.GetPersonByID)
End Code
@comboBox.GetHtml()