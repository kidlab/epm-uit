
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Helpers.PaginatedList<EPM.Models.Project>>"  %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function() {
            $("#statuswrapper .edit").toggle(function() {
                $("#formedit").slideDown("normal");
            },
		function() {
		    $("#formedit").slideUp("normal");
		});
            $("#statuswrapper .desc").toggle(function() {
                $("#statuswrapper .desc").addClass("desc-active");
                $("#project-desc").slideDown("normal");
            },
	function() {
	    $("#statuswrapper .desc").removeClass("desc-active");
	    $("#project-desc").slideUp("normal");
	});
        });
    </script>
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
				<h2 id="body-title">My Projects</h2>
				<div id="headline">
					<img src="../../Content/images/projects.png" alt="projects" class="list-icon" />	
					<span>Open Project</span>
				</div>
				<div id="project-list" class="table-list-1">
					<table width="100%" border="0" cellpadding="0" cellspacing="0">
						<tr id="list-title">
							<th width="6%"></th>
							<th width="30%">Project</th>
							<th width="26%">Done</th>
							<th width="26%">Days left</th>
							<th width="12%" class="last">Days left</th>
						</tr>
						
						
                        <% foreach (var project in Model) { %>
                        <tr>
                            <td></td>
							<td>
							<div class="toggle-in">
								<span class="view-toggle"></span>
								 <%= Html.ActionLink(project.name, "Edit", new { id = project.id })%>
							</div>
								
							</td>
                           <td>
								<div id="status-bar">
									<div id="status-bar-complete" style="width: 50%" ></div>
								</div>
								<span><%= project.status %></span>
							</td>
							<td>
								<%= project.start %>
							</td>
							<td>
								<a class="project-edit icon" id="<%= project.id %>"> <span>Edit</span> </a>
								<a class="project-del icon" id="<%= project.id %>"> <span>Delete</span> </a>
							</td>
                        </tr>
                        <% } %>
						<tr>
							<td colspan="5">
								<div class="table-project-info">
									<p>aaaaa</p>
									<p class="info-title">
										Users:
									</p>
									<ul class="table-project-users">
										<li> <a href="/">Admin</a> </li>
										<li> <a href="/">Vice Admin</a> </li>
										<li> <a href="/">Mod</a> </li>
									</ul>
									<div class="clear"></div>
								</div>
							</td>
						</tr>
					</table>
				</div>
			
</asp:Content>

