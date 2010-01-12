<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.TaskFormViewModel>"%>
<%--Changed on 2010-01-08
by; ManVHT
@desc:
    - Apply new style of TaskForm.
--%>

<%  string contentTitle = "Add TaskList";
    string actionLink = "#";
    bool isOnEditing = false;
    bool isOnAdd = false;
    int projectId;
    if (Model.Task != null)
        if (Model.Task.id > 0)
        {
            // Is on editing mode.{
            contentTitle = "Edit Tasklist";
            isOnEditing = true;
            actionLink = "/Task/Edit";
        }
        else
        {
            // special solution for task
            isOnAdd = true;
            actionLink = "/Task/Create";
        }
%>
<script type="text/javascript">
    function addTask(taskListId) {
        $('#tasklist_id').val(taskListId);
    }
</script>
<div class="table-content">
	<div class="form-ajax" id="Div1">
	<h1>Task</h1>
	<div class="add-poject-form">
		<form id="formTask" action="<%= actionLink %>" method="POST">
		<input type="hidden" name="id" value="<%if(isOnEditing) Writer.Write(Model.Task.id);%>" />
		<input type="hidden" name="tasklist_id" id="tasklist_id" value="" />
		<table cellpadding="1" cellspacing="5" border="0" width="100%">
			<tr>
				<td width="10%">
					Title:
				</td>
				<td width="90%">
					<input class="form-test" id="Text1" type="text" name="name" style="width: 70%" 
				    value="<% if(isOnEditing) Writer.Write(Model.Task.title); %>" />
				</td>
			</tr>
			<tr>
				<td>
					Text:
				</td>
				<td>
					<textarea class="form-test" id="Textarea1" name="desc" style="width: 100%" cols="20" rows="5">
				<%if(isOnEditing) Writer.Write(Model.Task.desc); %>
				</textarea>
				</td>
			</tr>
			<tr>
				<td>
					End:
				</td>
				<td>
					<input class="form-test" id="Text2" type="text" name="end" style="width: 70%"
					value ="<%if(isOnEditing) Writer.Write(Model.Task.end); %>" />
				</td>
			</tr>	
			<tr>
				<td>
					Tasklist:
				</td>
				<td>
					<select  class="form-text" id="input-tasklist" name="tasklist_id" style="width: 70%">
						<%
			               List<EPM.Models.Tasklist> taskLists ;
                           EPM.Models.TasklistRepository taskListRepo = new EPM.Models.TasklistRepository();
                          
                           taskLists = taskListRepo.GetTasklistsByProject((int)ViewData["projectId"]).ToList<EPM.Models.Tasklist>();
                         		    
                           for (int i = 0; i < taskLists.Count; i++)
                           {
                          
					  %>
						    <option value="<%= taskLists[i].id %>"
						        <% 
						           if ( isOnEditing) 
						            if (Model.Task.tasklist_id == taskLists[i].id)
                                       Writer.Write(" selected='selected'"); 
                                   %>
						        ><%= taskLists[i].name%></option>
						
					    <% } %>
					</select>
				</td>
			</tr>	
			<tr>
				<td>
					Assign:
				</td>
				<td>
					<select  class="form-text" id="input-assign" name="assign_id" style="width: 70%" >
						<%
			               List<EPM.Models.User> users ;
                           EPM.Models.UserRepository userRepo = new EPM.Models.UserRepository();
                          
                           users = userRepo.GetUsersByProject((int)ViewData["projectId"]).ToList<EPM.Models.User>();
                         		    
                           for (int i = 0; i < users.Count; i++)
                           {
                          
					  %>
						    <option value="<%= users[i].id %>"
						        <% 
						           if ( (int)ViewData["userId"]== users[i].id)
                                   Writer.Write(" selected='selected'"); 
                                   %>
						        ><%= users[i].name%></option>
						
					    <% } %>
					</select>
					
				</td>
			</tr>							
			<tr>
				<td colspan="2" align="center">
					<input type="submit" name="submit" value="Save">
					<input type="button" name="cancel" value="Cancel" onclick="history.back(-1)">
				</td>
			</tr>
		</table>
		</form>
	</div>
</div>
				
</div>
