<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EPM.Helpers" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>index TEST</h2>
   
    <!-- 
        Html.calendar(int type, int user_id, int project_id) 
        - type: loại calendar  (1:lớn  , 2:nhỏ (slidebar))
        - user_id : id của user đang đăng nhập
        - project_id : id của project user đó đang coi . id = -1 : mún coi calendar cho tất cả project (user đang ở màn hính Desktop) 
    -->
    <%= Html.calendar(1,1,-1)%>
    <p />
    <%= Html.calendar(2,1,-1)%>
 
</asp:Content>
