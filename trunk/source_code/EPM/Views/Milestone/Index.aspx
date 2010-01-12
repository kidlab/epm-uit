<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<EPM.Models.Milestone>>"  %>
<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function(){
	        $('.tab').removeClass('active');
	        $('#tab-milestone').addClass('active');

	        $('#tool-add').toggle(function(){
		        $('#form-add').slideDown('slow');
	        }, function(){
		        $('#form-add').slideUp('slow');
	        });
        });
    </script>
</asp:Content>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    My Projects
</asp:Content>

<asp:Content ID="bodyTab" ContentPlaceHolderID="BodyTab" runat="server">
    <% Html.RenderPartial("~/Views/Shared/ProjectManageTabs.ascx");%>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--Changed on 2010-01-07
    by: ManVHT
    @desc:
        - List all project by ProjectList.ascx
    --%>
    <% 
        ViewData["ShowToolButtons"] = true;
        Html.RenderPartial("MilestoneList"); 
    %>
    
    <%-- End changes  --%>
</asp:Content>

