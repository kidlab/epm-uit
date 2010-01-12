<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Controllers.UserProfileViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        if (Model != null)
        {
            var user = Model.user;
        
    %>

    <h1 class="content-title"> User Profile: <%=  user.name%> </h1>	
    <%
        ViewData["ShowToolButtons"] = true;
        Html.RenderPartial("UserInfo");
    %>    
        
    <% 
        Html.RenderPartial("ProjectList");
        }
       else{
    %>
        <h1 class="content-title"> No user found! </h1>	
    <%
       }    
    %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-user').addClass('active');
            $('.table-info tr:even > td').addClass('row-odd');

            $('.grid-item').hover(function() {
                $(this).addClass('grip-content-hover');
            }, function() {
                $(this).removeClass('grip-content-hover');
            });

            var userId = $("#userId").html();
            $('#ajaxProjectList').load('/Admin/AjaxProjectsByUserView/id/' + userId);
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
    <%
        int id = Model.user.id;
    %>
     <ul id="body-tab">
		<li class="tab" id="tab-user"> <a href="/Admin/UserView/<%= id%>"> User </a> </li>
		<li class="tab" id="tab-edit"> <a href="/Admin/UserEdit/<%= id%>"> Edit </a> </li>						
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ItemTitle" runat="server">
</asp:Content>
