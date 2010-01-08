<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<EPM.Models.Project>>" %>
<div class="table-content">
	<div class="table-cover">
	    <% if (ViewData["ShowToolButtons"] != null
                && (bool)ViewData["ShowToolButtons"] == true)
        {// Show toolstrip buttons.%>
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
        <%}%>
		Projects
	</div>
    <div class="form-ajax" id="form-add" style="display: none;">
        <%Html.RenderPartial("~/Views/Project/ProjectForm.ascx", new EPM.Controllers.ProjectFormViewModel(null));%>
    </div>
	<div class="table-list-wrapper">
	    <table class="table-list" width="100%" cellpadding="1" cellspacing="1">
		    <tr>
			    <th width="5%"></th>
			    <th width="35%">Names</th>
			    <th width="30%">Done</th>
			    <th width="15%">Day left</th>
			    <th width="10%">Edit</th>
		    </tr>
    		
        <% if (Model != null && Model.Count > 0)
               for(int id = 0; id < Model.Count; id++) {
                   var project = Model[id];
                   string lnkEdit = "/Project/Edit/" + project.id;
                   string lnkInfo = "/Project/ManageProject/" + project.id;
                   //Html.ActionLink(project.name, "Edit", new { id = project.id });
                   string lnkDelete = 
                       Url.RouteUrl(this.ViewContext.RouteData.Values) + "/Delete/" + project.id;     
                  
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
			    <td> <a href="<%= lnkInfo%>"><%= project.name%></a> </td>
			    <td> <%= project.status%> </td>
			    <td> <%= project.start.Value.ToShortDateString()%></td>
			    <td>
				    <a class="button btn-edit" href="<%= lnkEdit%>">
					    <span>edit</span>
				    </a>								
				    <a class="button btn-del" href="<%= lnkDelete %>">
					    <span>del</span>
				    </a>						
			    </td>
		    </tr>
        <% } %>
    						
	    </table>
	</div>
</div>