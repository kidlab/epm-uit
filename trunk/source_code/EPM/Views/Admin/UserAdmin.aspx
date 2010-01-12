<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Helpers.PaginatedList<EPM.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserAdmin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="content-title"> System / User Administration </h1>	
    <% ViewData["ShowToolButtons"] = true;
       Html.RenderPartial("UserList");
    %>
    <% Html.RenderPartial("UserRole"); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-user-admin').addClass('active');
            /// ToanNM: Load user list ajax content
            $("#ajaxUserList").load('/Admin/AjaxUserList/');
        });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyTab" runat="server">
    <ul id="body-tab">
		<li class="tab" id="tab-project-admin"> <a href="myproject.html">Projects Administration</a> </li>
		<li class="tab" id="tab-user-admin"> <a href="user_administration.html">Users Administration</a> </li>
		<li class="tab" id="tab-system-admin"> <a href="system_admin.html">System Administration</a> </li>
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ItemTitle" runat="server">
</asp:Content>
