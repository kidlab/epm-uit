<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Controllers.TaskFormViewModel>"  %>

<asp:Content ID="titleContent" ContentPlaceHolderID="TitleContent" runat="server">
	<%= "Task [" + Model.Task.title + "]" %>
</asp:Content>

<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-task').addClass('active');
            $('.table-info tr:even > td').addClass('row-odd');
        });
	</script>
</asp:Content>

<asp:Content ID="bodyTab" ContentPlaceHolderID="BodyTab" runat="server">
    <% Html.RenderPartial("~/Views/Shared/ProjectManageTabs.ascx");%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("TaskForm");%>   
</asp:Content>
