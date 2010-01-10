<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Helpers.PaginatedList<EPM.Models.Project>>" %>
<% 
    if (Model != null && Model.Count > 0)
    {
        var projects = Model.ToArray();
        String linkView = "/Project/View/";
        String linkEdit = "/Project/Edit/";
        String linkDel = "/Project/Delete/";
%>
<script type="text/javascript">
    $(document).ready(function() {
        $('.table-list tr:even > td').addClass('row-odd');
    });
</script>
<div class="table-content">
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
		Projects
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
		
		    <% foreach (var project in projects){ %>
                <tr>
			        <td>
				       <%-- <a class="button btn-check" href="/">
					        <span>check</span>
				        </a>--%>
			        </td>
			        <td> <a href="<%= linkView + project.id%>"> <%= project.name%>  </a></td>
			        <td> <%= project.status%> </td>
			        <td> <%= project.GetDayLeft()%></td>
			        <td>
				        <a class="button btn-edit" href="<%= linkEdit + project.id%>">
					        <span>edit</span>
				        </a>								
				        <a class="button btn-del" href="<%= linkDel + project.id%>">
					        <span>del</span>
				        </a>						
			        </td>
		        </tr>
            <% } %>					
	</table>
</div>
</div>	
<% } %>