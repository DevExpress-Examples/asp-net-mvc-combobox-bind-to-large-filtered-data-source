﻿@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    function OnEndCallback(s, e) {
        window.setTimeout(function () {
            if (s.GetItemCount() == 1) {
                s.SetSelectedIndex(0);
                s.HideDropDown();
            }
        }, 0);
    }
</script>
@Html.Partial("ComboBoxPartial", Model)