<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EPM.Controllers.ProjectFormViewModel>" %>
<%@ Import Namespace="EPM.Helpers" %> 
<asp:Content ID="titleContent" ContentPlaceHolderID="TitleContent" runat="server">
	<%= "Project [" + Model.Project.name + "]" %>
</asp:Content>

<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.tab').removeClass('active');
            $('#tab-project').addClass('active');
            $('.table-info tr:even > td').addClass('row-odd');
        });
	</script>
</asp:Content>

<asp:Content ID="bodyTab" ContentPlaceHolderID="BodyTab" runat="server">
    <% Html.RenderPartial("~/Views/Shared/ProjectManageTabs.ascx");%>
</asp:Content>

<asp:Content ID="itemTitle" ContentPlaceHolderID="ItemTitle" runat="server">
    <%= Model.Project.name%>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-content">
		<table class="table-info" width="100%">
			<tr>
				<td width="30%">
					Action:
				</td>
				<td width="70%">
				    <a class="button btn-check" href="#">
						<span>check</span>
					</a>
					<a class="button btn-edit" href="<%= "/Project/Edit/" + Model.Project.id %>">
						<span>edit</span>
					</a>	
				</td>
			</tr>
			<tr>
				<td width="30%">
					Done:
				</td>
				<td width="70%">
				    50%
				</td>
			</tr>
			<tr>
				<td>
					Budget:
				</td>
				<td>
				    <%= "$" + Model.Project.budget %>
				</td>
			</tr>
			<tr>
				<td>
					Days left:
				</td>
				<td>
				    <%= Model.Project.GetDayLeft() %>
				</td>
			</tr>
			<tr>
				<td>
					Describe:
				</td>
				<td>
				    <%= Model.Project.desc %>
				</td>
			</tr>
		</table>					
	</div>
	<%= Html.calendar(1, (int)ViewData["user_id"], (int)ViewData["project_id"])%>
	<div class="table-content">
		<div class="table-cover">
			<div class="cover-buttons-list">
				<a href="#" class="cover-btn tool-add" id="tool-add">
					<span>Add</span>
				</a>
				<a href="#" class="cover-btn tool-edit">
					<span>Edit</span>
				</a>
				<a href="#" class="cover-btn tool-del">
					<span>Del</span>
				</a>
				<a href="#" class="cover-btn tool-check">
					<span>Check</span>
				</a>
			</div>	
			Timetracker
		</div>
		<div class="form-ajax" id="form-timetracker">
			<form action="" method="post">
				<table width="100%">
					<tr>
						<td width="15%">
							Day
						</td>
						<td width="85%">
							<input id="tt_day" name="day" type="text" style="width: 20%"/>
						</td>
					</tr>
					<tr>
						<td>
							Start:
						</td>
						<td>
							<input id="tt_start" name="start" type="text" style="width: 20%">
						</td>
					</tr>
					<tr>
						<td>
							End:
						</td>
						<td>
							<input id="tt_end" name="end"  type="text" style="width: 20%">
						</td>
					</tr>
					<tr>
						<td>
							Comment:
						</td>
						<td>
							<textarea class="form-test" id="input-desc" name="comment" style="width: 100%" cols="20" rows="5"></textarea>
						</td>
					</tr>
					<tr>
			            <td colspan="2" align="center">
				            <input type="button" name="submit" value="Add"/>
				        </td>
		            </tr>
				</table>
			</form>
		</div>
	</div>
</asp:Content>