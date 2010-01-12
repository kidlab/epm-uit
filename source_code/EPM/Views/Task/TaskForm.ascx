<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.TaskFormViewModel>"%>
<%--Changed on 2010-01-08
by; ManVHT
@desc:
    - Apply new style of TaskForm.
--%>

<%  string contentTitle = "Add TaskList";
    string actionLink = "#";
    bool isOnEditing = false;
    if (Model != null && Model.Task != null)
    {
        // Is on editing mode.{
        contentTitle = "Edit Task";
        isOnEditing = true;
        actionLink = "/Task/Edit";
    }
%>
<div class="table-content">
	<div class="form-ajax" id="Div1">
	<h1>Task</h1>
	<div class="add-poject-form">
		<form action="<%= actionLink %>" method="POST">
		<input type="hidden" name="id" value="<%if(isOnEditing) Writer.Write(Model.Task.id);%>" />
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
					<select  class="form-text" id="input-tasklist" name="tasklist" style="width: 70%">
						<option value="1"> Tasklist 1</option>
					</select>
				</td>
			</tr>	
			<tr>
				<td>
					Assign:
				</td>
				<td>
					<select  class="form-text" id="input-assign" name="assign" style="width: 70%">
						<option value="1"> All</option>
						<option value="2"> admin</option>
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
