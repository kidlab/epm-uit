<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.MilestoneFormViewModel>"%>
<%--Changed on 2010-01-08
by; ManVHT
@desc:
    - Apply new style of MilestoneForm.
--%>

<%  string contentTitle = "Add Milestone";
    string actionLink = "#";
    bool isOnEditing = false;
    if (Model != null && Model.Milestone != null)
    {
        // Is on editing mode.{
        contentTitle = "Edit Milestone";
        isOnEditing = true;
        actionLink = "/Milestone/Edit";
    }
%>
<div class="table-content">
<h1> <%= contentTitle %></h1>
<div class="form-ajax" id="form-edit">
	<form action="<%= actionLink %>" method="post">
	<input type="hidden" name="id" value="<%if(isOnEditing) Writer.Write(Model.Milestone.id);%>" />
	<table cellpadding="1" cellspacing="5" border="0" width="100%">
		<tr>
			<td width="10%">
				Name:
			</td>
			<td width="90%">
				<input class="form-test" id="input-name" type="text" name="name" style="width: 70%" 
				value="<% if(isOnEditing) Writer.Write(Model.Milestone.name); %>" />
			</td>
		</tr>
		<tr>
			<td>
				Describe
			</td>
			<td>
				<textarea class="form-test" id="input-desc" name="desc" style="width: 100%" cols="20" rows="5">
				<%if(isOnEditing) Writer.Write(Model.Milestone.desc); %>
				</textarea>
			</td>
		</tr>
		<tr>
			<td>
				Due:
			</td>
			<td>
				<input class="form-test" id="input-due" type="text" name="end" style="width: 70%" />
			</td>
		</tr>
		
		<tr>
			<td>
				People
			</td>
			<td>
				
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