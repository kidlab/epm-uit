<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<EPM.Controllers.TaskViewModel>>"  %>
<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function(){
	        $('.tab').removeClass('active');
	        $('#tab-tasks').addClass('active');

	        $('#tool-add').toggle(function(){
		        $('#form-add').slideDown('slow');
	        }, function(){
		        $('#form-add').slideUp('slow');
	        });
        });
    </script>
</asp:Content>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    My Tasks
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("TasksList");%>
</asp:Content>

