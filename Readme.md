<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128549100/22.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4383)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Combo Box for ASP.NET MVC - How to filter a large data source and automatically select the first item

This example demonstrates how to use the combo box editor's [BindList](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.ComboBoxExtension.BindList.overloads) method to bind the editor to a large filtered data source.

![Bind a combo box editor to a large data source](BindEditorToLargeDataSource.png)

## Overview

Use the editor's [BindList](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.ComboBoxExtension.BindList.overloads) method and pass the following methods as parameters:

* A delegate method of the [ItemsRequestedByFilterConditionMethod](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.ItemsRequestedByFilterConditionMethod) type. This method allows you to implement custom item selection based on filter conditions.

* A delegate method of the [ItemRequestedByValueMethod](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.ItemRequestedByValueMethod) type. This method allows you to implement custom item selection based on items' values.

```cshtml
var comboBox = Html.DevExpress().ComboBox(settings => {
    settings.Name = "comboBox";
    <!-- ... -->
}).BindList(ComboBoxLargeDataBase.Model.DataHelper.GetPersonsRange, ComboBoxLargeDataBase.Model.DataHelper.GetPersonByID);
```

```cs
public static object GetPersonsRange(ListEditItemsRequestedByFilterConditionEventArgs args) {
    var skip = args.BeginIndex;
    var take = args.EndIndex - args.BeginIndex + 1;
    return (from person in DataHelper.Persons
            where (person.FirstName + " " + person.MiddleName + " " + person.LastName).ToLower().Contains(args.Filter.ToLower())
            orderby person.LastName
            select person
        )
        .Skip(skip)
        .Take(take);
}
public static object GetPersonByID(ListEditItemRequestedByValueEventArgs args) {
    if(args.Value != null)
        return GetPersonByID((int)args.Value);
    return null;
}
```

When a single item remains available after filter operations, the editor's [SetSelectedIndex](https://docs.devexpress.com/AspNet/js-ASPxClientComboBox.SetSelectedIndex(index)) method automatically selects it in the editor's client-side [EndCallback](https://docs.devexpress.com/AspNet/js-ASPxClientComboBox.EndCallback) event handler.

## Files to Review

* [HomeController.cs](./CS/ComboBoxLargeDataBase/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/ComboBoxLargeDataBase/Controllers/HomeController.vb))
* [MyModel.cs](./CS/ComboBoxLargeDataBase/Model/MyModel.cs) (VB: [MyModel.vb](./VB/ComboBoxLargeDataBase/Model/MyModel.vb))
* [ComboBoxPartial.cshtml](./CS/ComboBoxLargeDataBase/Views/Home/ComboBoxPartial.cshtml)
* [Index.cshtml](./CS/ComboBoxLargeDataBase/Views/Home/Index.cshtml)

## More Examples

* [Combo Box - Custom Binding](https://demos.devexpress.com/MVCxDataEditorsDemos/Editors/LargeDataComboBox)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-combobox-bind-to-large-filtered-data-source&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-combobox-bind-to-large-filtered-data-source&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
