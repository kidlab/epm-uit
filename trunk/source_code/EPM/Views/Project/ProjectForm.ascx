<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.ProjectFormViewModel>"%>
<%--Changed on 2010-01-08
by; ManVHT
@desc:
    - Apply new style of ProjectForm.
--%>

<%  string contentTitle = "Add Project";
    string actionLink = "#";
    bool isOnEditing = false;
    bool isOnAdd = false;
    if (Model != null)
        if (Model.Project != null)
        {
            // Is on editing mode.{
            contentTitle = "Edit Milestone";
            isOnEditing = true;
            actionLink = "/Project/Edit";
        }
        else
        {
            isOnAdd = true;

            actionLink = "/Project/Create/";
        }
%>
<div class="table-content">
<h1> <%= contentTitle %></h1>
<div class="form-ajax" id="form-edit">
	<form action="<%= actionLink %>" method="post">
	<input type="hidden" name="id" value="<%if(isOnEditing) Writer.Write(Model.Project.id);%>" />
	<table cellpadding="1" cellspacing="5" border="0" width="100%">
		<tr>
			<td width="10%">
				Name:
			</td>
			<td width="90%">
				<input class="form-test" id="input-name" type="text" name="name" style="width: 70%" 
				value="<% if(isOnEditing) Writer.Write(Model.Project.name); %>" />
			</td>
		</tr>
		<tr>
			<td>
				Describe
			</td>
			<td>
				<textarea class="form-test" id="input-desc" name="desc" style="width: 100%" cols="20" rows="5">
				<%if(isOnEditing) Writer.Write(Model.Project.desc); %>
				</textarea>
			</td>
		</tr>
		<tr>
			<td>
				Due:
			</td>
			<td>
				<input class="form-test" id="input-due" type="text" name="end" style="width: 70%"
				value="<% if(isOnEditing) Writer.Write(Model.Project.end); %>"  />
			</td>
		</tr>
		<tr>
			<td>
				Budget
			</td>
			<td>
				<input class="form-test" id="input-budget" type="text" name="budget" style="width: 70%"
				value="<% if(isOnEditing) Writer.Write(Model.Project.budget); %>" />
			</td>
		</tr>
		<tr>
			<td colspan="2" align="center">
				<%--<input type="submit" name="submit" value="Save"/>--%>
				<button type="submit" value="">Save</button>
			</td>
		</tr>
	</table>
	</form>
</div>
</div>