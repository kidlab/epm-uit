<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.TasklistFormViewModel>"%>
<%--Changed on 2010-01-08
by; ManVHT
@desc:
    - Apply new style of TasklistForm.
--%>

<%  
    
    string contentTitle = "Add TaskList";
    string actionLink = "#";
    bool isOnEditing = false;
    bool isOnAdd = false;
    int projectId   ;
    int project_id = (int)HttpContext.Current.Session["project_id"];
    if (Model != null)
        if (Model.Tasklist.id > 0)
        {
            // Is on editing mode.{
            contentTitle = "Edit Tasklist";
            isOnEditing = true;
            actionLink = "/Tasklist/Edit";
        }
        else
        {
            isOnAdd = true;
           
            actionLink = "/Tasklist/Create/" + (int)HttpContext.Current.Session["project_id"];
        }
   
%>
<div class="table-content">
	
	<h1>Tasklist </h1>
	<div class="add-poject-form">
		<form action="<%= actionLink %>" method="POST">
		<input type="hidden" name="id" value="<%if(isOnEditing) Writer.Write(Model.Tasklist.id);%>" />
		<input type="hidden" name="project_id" value="<%= project_id%>" />
		<table cellpadding="1" cellspacing="5" border="0" width="100%">
			<tr>
				<td width="10%">
					Name:
				</td>
				<td width="90%">
					<input class="form-test" id="Text1" type="text" name="name" style="width: 70%" 
				    value="<% if(isOnEditing) Writer.Write(Model.Tasklist.name); %>" />
				</td>
			</tr>
			<tr>
				<td>
					Text:
				</td>
				<td>
					<textarea class="form-test" id="Textarea1" name="desc" style="width: 100%" cols="20" rows="5">
				    <%if(isOnEditing) Writer.Write(Model.Tasklist.desc); %>
				</textarea>
				</td>
			</tr>
			
			<tr>
				<td>
					Milestone:
				</td>
				<td>
					<select  class="form-text" id="input-tasklist" name="miletone_id" style="width: 70%">
					<%
			           List<EPM.Models.Milestone> milestones ;
                       EPM.Models.MilestoneRepository milestoneRepo = new EPM.Models.MilestoneRepository();

                       milestones = milestoneRepo.GetMilestonesByProjectId(project_id).ToList<EPM.Models.Milestone>();

                       for (int i=0; i < milestones.Count; i++ )
                       {
                          
					  %>
						<option value="<%= milestones[i].id %>"
						    <% 
						       if (Model.Tasklist.miletone_id == milestones[i].id)
                               Writer.Write(" selected='selected'"); 
                               %>
						    ><%= milestones[i].name%></option>
						
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

