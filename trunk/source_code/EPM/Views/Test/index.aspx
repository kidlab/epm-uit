<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EPM.Helpers" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>index TEST</h2>
   
    <%= Html.calendar("First Name", "this is a calendar:")%>
 
</asp:Content>
