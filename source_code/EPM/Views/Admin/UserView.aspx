<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="content-title"> System / User Infomation </h1>	
    <%
        ViewData["ShowToolButtons"] = true;
        Html.RenderPartial("UserList");
    %>    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
	    $(document).ready(function(){
		    $('.tab').removeClass('active');
		    $('#tab-user').addClass('active');
		    $('.table-info tr:even > td').addClass('row-odd');

		    $('.grid-item').hover(function(){
				    $(this).addClass('grip-content-hover');
			    },function(){
				    $(this).removeClass('grip-content-hover');
			    });
	    });
    	
	    tinyMCE.init({
		    mode : "textareas",
		    theme : "advanced",
		    width : "100%",
		    theme_advanced_toolbar_location: 'top',
		    theme_advanced_toolbar_align: 'left',
		    theme_advanced_resizing : true
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
