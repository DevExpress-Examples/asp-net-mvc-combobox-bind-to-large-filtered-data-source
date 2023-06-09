<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4383)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/ComboBoxLargeDataBase/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/ComboBoxLargeDataBase/Controllers/HomeController.vb))
* [MyModel.cs](./CS/ComboBoxLargeDataBase/Model/MyModel.cs) (VB: [MyModel.vb](./VB/ComboBoxLargeDataBase/Model/MyModel.vb))
* [ComboBoxPartial.cshtml](./CS/ComboBoxLargeDataBase/Views/Home/ComboBoxPartial.cshtml)
* [Index.cshtml](./CS/ComboBoxLargeDataBase/Views/Home/Index.cshtml)
<!-- default file list end -->
# ComboBox - How to filter a large data source and automatically select the first item
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4383)**
<!-- run online end -->


<p>This example is a standalone illustration of the <a href="http://demos.devexpress.com/MVC/Editors/LargeDataComboBox"><u>Data Editors - Combo Box with Large Database</u></a> demo. It illustrates how to bind the MVC ComboBox Extension to a large datasource with the incremental filtering enabled.<br />
It is necessary to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcComboBoxExtension_BindListtopic1741"><u>ComboBoxExtension.BindList</u></a> method, which receives two arguments:<br />
- A delegate method of the ItemsRequestedByFilterConditionMethod type, which enables you to implement custom selection of the requested items by the filter conditions. <br />
- A delegate method of the ItemRequestedByValueMethod type, which enables you to implement custom selection of the requested item by the value. </p><p>Both the delegate methods are implemented in the /Model/Model module and return the requested range or a single value based on the typed filter string/substring.</p><p><strong>Additional/Custom Functionality:</strong><br />
If there is a single Item available after filtering, this Item is automatically selected via the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsScriptsASPxClientComboBox_SetSelectedIndextopic"><u>ASPxClientComboBox.SetSelectedIndex</u></a> method within the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsScriptsASPxClientComboBox_EndCallbacktopic"><u>ASPxClientComboBox.EndCallback</u></a> event handler.</p>

<br/>


