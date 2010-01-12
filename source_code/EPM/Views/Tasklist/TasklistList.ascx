<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<EPM.Controllers.TasklistFormViewModel>>" %>

<%--Changed on 2010-01-12
    by: HaiLD
    @desc: update link         
    --%>


<div id="body-left">
				
		<h1 class="content-title"> Project / Tasklist </h1>
		
		<div class="page-buttons">
			<a class="page-button-add" id="pb-add" onclick="openTasklist(this.id,'form-add-tasklist')"><span>add</span></a>
		</div>
		<div class="clear"></div>
		<br/>
		<div class="form-ajax" id="form-add-tasklist" style="display: none;">
       <%
           EPM.Models.Tasklist taskList = new EPM.Models.Tasklist();
           if (Model.Count >0 )
           taskList.project_id = Model[0].Tasklist.project_id;
           Html.RenderPartial("~/Views/Tasklist/TasklistForm.ascx", new EPM.Controllers.TasklistFormViewModel(taskList));%>
       </div>
		
			
		<div >
			<div class="table-cover">
				<div class="cover-buttons-list">
					<a href="/" class="cover-btn tool-add" id="tool-add">
						<span>Add</span>
					</a>
					<a href="/" class="cover-btn tool-edit">
						<span>Edit</span>
					</a>
					<a href="/" class="cover-btn tool-del">
						<span>Del</span>
					</a>
					<a href="/" class="cover-btn tool-check">
						<span>Check</span>
					</a>
				</div>	
				Tasklist
			</div>
<!--				******************** FORM ADD ******************* 	-->
			<div class="form-ajax" id="form-add" style="display: none;">
			    <%
                     
                    Html.RenderPartial("~/Views/Task/TaskForm.ascx", new EPM.Controllers.TaskFormViewModel(null));%>
			</div>
		</div>
		<!-- ******************** END FORM ADD ******************* 	-->
		<div class="table-list-wrapper">
			<table class="table-list" width="100%" cellpadding="1" cellspacing="1">
				<tr>
					<th width="5%"></th>
					<th >Names</th>
					<th width="10%">Edit <%= Model.Count %></th>
				</tr>
				 <% if (Model != null && Model.Count > 0)
            for (int id = 0; id < Model.Count; id++)
            {

                var tasklist = Model[id].Tasklist;
                string lnkEdit = "/Tasklist/Edit/" + tasklist.project_id+ "/" + tasklist.id;
                //Html.ActionLink(project.name, "Edit", new { id = project.id });
                string lnkDelete =
                    Url.RouteUrl(this.ViewContext.RouteData.Values) + "/Tasklist/Delete/" + tasklist.id;

                // This makes the table more easily readable.
                if (id % 2 == 0)
                    this.Writer.Write("<tr>");
                else
                    this.Writer.Write("<tr class=\"odd\">");
                %>
				
					<td>
						<a class="button btn-check" href="/">
							<span>check</span>
						</a>
					</td>
					<td> <a href="<%= lnkEdit%>"><%= tasklist.name%></a></td>
					
					<td>
						<a class="button btn-edit" href="<%= lnkEdit%>">
							<span>edit</span>
						</a>								
						<a class="button btn-del" href="<%= lnkDelete%>">
							<span>delete</span>
						</a>						
					</td>
				</tr>	
							
				<% } %>
			</table>
			<!-- ******************** HIDDEN TABLE LIST ********** -->
			<div class="hidden-table-list" id="finish-milestone1" style="display: none">
				<table class="table-list" width="100%" cellpadding="1" cellspacing="1" >
					<tr>
						<th colspan="5"> Finished Taskslist</th>
					</tr>
					<tr>
						<td width="5%">
							<a class="button btn-check" href="#">
								<span>check</span>
							</a>
						</td>
						<td width="35%"> <a href="#">Tasklist </a></td>
						<td width="30%"> 50% </td>
						<td width="15%"> 50 days</td>
						<td width="10%">
							<a class="button btn-edit" href="#">
								<span>edit</span>
							</a>								
							<a class="button btn-del" href="#">
								<span>del</span>
							</a>						
						</td>
					</tr>								
					<tr>
						<td>
							<a class="button btn-check" href="/">
								<span>check</span>
							</a>
						</td>
						<td> <a href="/">Tasklist </a></td>
						<td> 50% </td>
						<td> 50 days</td>
						<td>
							<a class="button btn-edit" href="/">
								<span>edit</span>
							</a>								
							<a class="button btn-del" href="/">
								<span>del</span>
							</a>						
						</td>
					</tr>	
					<tr class="odd">
						<td>
							<a class="button btn-check" href="/">
								<span>check</span>
							</a>
						</td>
						<td> <a href="/">Tasklist </a></td>
						<td> 50% </td>
						<td> 50 days</td>
						<td>
							<a class="button btn-edit" href="/">
								<span>edit</span>
							</a>								
							<a class="button btn-del" href="/">
								<span>del</span>
							</a>						
						</td>
					</tr>		
				</table>
			</div>
		</div>
		<div class="table-bottom-tab">
			<a href="/" id="ft-toggle-1" onclick="toggleSlide(this.id,'finish-milestone1','activated','up')">Finished tasks</a>
		</div>		
	</div>
		
		
</div>
