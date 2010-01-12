<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    List<EPM.Models.User> userAssign = new List<EPM.Models.User>();
    int project_id = (int)ViewData["projectId"];
    if (ViewData["usersNotAssign"] != null) {
        userAssign = (List<EPM.Models.User>)ViewData["usersNotAssign"];
    }
%>
<script type="text/javascript">
    function submitForm() {
        if ($('#user-choose').val() == "-1")
            alert("Please choose a user to assign");
        else
            $('#assign-user').submit();            
    }
</script>
<div class="form-ajax" id="form-add" style="display: none;">
		<h1>Add User</h1>
		<div class="add-project-form">
			<form id="assign-user" action="/Project/UserAdd/" method="POST">
			<% if (userAssign.Count > 0)
            { %>
			<table cellpadding="1" cellspacing="5" border="0" width="100%">
				<tr>
					<td width="10%">
						User:
					</td>
					<td width="90%">
						    <select name="user" id="user-choose" class="" style="width: 70%">
							    <option value="-1">Please Choose</option>
							    <% foreach (var item in userAssign)
              {
                                      %> <option value="<%= item.id%>"> <%= item.name%></option> <%
                } %>
						    </select>			
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
					    <input type="hidden" name="project" value="<%= project_id %>"/>
						<input type="button" value="Save" onclick="submitForm();">
						<input type="button" value="Cancel" onclick="slide(this.id, 'form-add');">
					</td>
				</tr>
			</table>
							
			<%}
            else
            {
                this.Writer.Write("<center><h3>No user!<h3></center>");
            }%>		
			</form>
		</div>
	</div>