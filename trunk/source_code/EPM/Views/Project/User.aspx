<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<EPM.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="content-title"> Project / User </h1>				
	<% Html.RenderPartial("UserList"); %>
	
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        $('.tab').removeClass('active');
        $('#tab-user').addClass('active');

        $('#tool-add').toggle(function() {
            $('#form-add').slideDown('fast');
        }, function() {
            $('#form-add').slideUp('fast');
        });
    });
</script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyTab" runat="server">
<% int projectId = (int)ViewData["projectId"]; %>
<ul id="body-tab">
	<li class="tab" id="tab-project"> <a href="/Project/">Project </a> </li>
	<li class="tab" id="tab-milestone"> <a href="/Milestone/<%= projectId%>"> Milestone </a> </li>
	<li class="tab" id="tab-task"> <a href="/Task/<%= projectId%>"> Taskslist</a> </li>
	<li class="tab" id="tab-user"> <a href="/Project/User/<%= projectId%>"> User</a> </li>
</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ItemTitle" runat="server">
</asp:Content>
