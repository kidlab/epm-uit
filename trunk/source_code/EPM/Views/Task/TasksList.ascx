<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<EPM.Controllers.TaskViewModel>>" %>
<div class="table-content">
	<div class="table-cover">			
		My Tasks
	</div>
	<table class="table-list" width="100%" cellpadding="1" cellspacing="1">
		<tr>
			<th width="5%"></th>
			<th width="35%">Tasks</th>
			<th width="30%">Project</th>
			<th width="15%">Days left</th>
			<th width="10%">Edit</th>
		</tr>
		<% for (int id = 0; id < Model.Count; id++) {
                 var taskVM = Model[id];
                 string lnkEdit = "#";//"Task/Edit/" + task.id;
                 // This makes the table more easily readable.
                 if (id % 2 == 0)
                     this.Writer.Write("<tr>");
                 else
                     this.Writer.Write("<tr class=\"odd\">");
        %>
			    <td>
				    <a class="button btn-check" href="#">
					    <span>check</span>
				    </a>
			    </td>
			    <td> <a href="<%= lnkEdit %>"> <%= taskVM.Task.title%></a></td>
			    <td> <%= taskVM.GetProjectName()%></td>
			    <td> <%= taskVM.Task.start.ToShortDateString()%></td>
			    <td>
				    <a class="button btn-edit" href="<%= lnkEdit%>">
					    <span>edit</span>
				    </a>								
				    <a class="button btn-del" href="#">
					    <span>del</span>
				    </a>						
			    </td>
		    </tr>		   
		<% } %>
	</table>	
</div>