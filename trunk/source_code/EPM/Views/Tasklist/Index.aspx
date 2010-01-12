<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<EPM.Controllers.TasklistFormViewModel>>"  %>
<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
       
	    $(document).ready(function() {
	        $('.tab').removeClass('active');
	        $('#tab-task').addClass('active');

	        $('#tool-add').toggle(function() {
	            $('#form-add').slideDown('fast');
	        }, function() {
	            $('#form-add').slideUp('fast');
	        });
	    });
	  
	    function openTasklist(id, controlId) {
	        slide(id, controlId);
	    }
	    openTasklist("pb-add", "form-add-tasklist");
    </script>
</asp:Content>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    My Tasks
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("TasklistList");%>
</asp:Content>

