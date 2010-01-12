<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserRemove
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        EPM.Models.User user = new EPM.Models.User();
        EPM.Models.Project project = new EPM.Models.Project();
        if (ViewData["user"] != null)
        {
            user = (EPM.Models.User)ViewData["user"];
        }
        if (ViewData["project"] != null)
        {
            project = (EPM.Models.Project)ViewData["project"];
        }
    %>
    <h1 class="content-title"> Project / Deassign <%= user.name %></h1>	
    <p> Are you really want to Deassign from <%= project.name%>, this will remove all task assign to this user</p>
    <form action="/Project/UserRemove/<%= project.id + "/" + user.id%>" method="post">
        <input name="project" type="hidden" value="<%= project.id %>"/>
        <input name="user" type="hidden" value="<%= user.id %>"/>
        <input type="submit" value="Yes"/> &nbsp;
        <input type="button" value="No" onclick="javascript: history.back(1)"/> 
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyTab" runat="server">
<% Html.RenderPartial("~/Views/Shared/ProjectManageTabs.ascx");%>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ItemTitle" runat="server">
</asp:Content>
