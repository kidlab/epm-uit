<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Controllers.HomeViewModel>" %>
<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-desktop').addClass('active');
        });       
    </script>
</asp:Content>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="itemTitle" ContentPlaceHolderID="ItemTitle" runat="server" >
    Desktop
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">    
    <%--Changed on 2010-01-08
    by: ManVHT
    @desc:
        - Render partial projectz and tasks.
    --%>
    <% 
        if (Model.Projects != null)
            Html.RenderPartial("../Project/ProjectList", Model.Projects);

        if (Model.Tasks != null)
            Html.RenderPartial("../Task/TasksList", Model.Tasks);
    %>	
</asp:Content>
