<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserDel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        EPM.Models.User user = null;
        if (Model != null) {
            user = Model;   
        }    
    %>
    <h1 class="content-title"> Delete User "<%= user.name %>" </h1>	
    <p> Do you really want to delete user <%= user.name %> ?</p>
    <form method="post" action="/Admin/UserDel/">
        <input type="hidden" name="id" value="<%= user.id%>"/>
        <input type="submit" value="Yes" />
        <input type="button" onclick="cancel()" value="No" />
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-user').addClass('active');
        });
        function cancel() {
            window.location = "/Admin/UserAdmin";
        }
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyTab" runat="server">
    <ul id="body-tab">
		<li class="tab" id="tab-user"> <a href="userinfo.html"> User </a> </li>
		<li class="tab" id="tab-edit"> <a href="edituser.html"> Edit </a> </li>					
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ItemTitle" runat="server">
</asp:Content>
