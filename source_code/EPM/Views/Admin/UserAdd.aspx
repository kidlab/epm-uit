<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserAdd
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1 class="content-title"> Add user </h1>		
    <% Html.RenderPartial("UserForm");%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
	    $(document).ready(function(){
		    $('.tab').removeClass('active');
		    $('#tab-user').addClass('active');
		    $('.table-form tr:even > td').addClass('row-odd');

	    });
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