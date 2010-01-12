<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<EPM.Models.User>>" %>
<% 
    bool canAdd     = (bool)ViewData["canAdd"];
    int project_id  = (int)ViewData["projectId"];
    List<EPM.Models.User> users = new List<EPM.Models.User>();
    if (Model != null && Model.Count > 0)
    {
        users = Model;
    }
    
    // create action link
    string linkEdit = "/Admin/UserEdit/";
    string linkView = "/Admin/UserView/";
    string linkDel = "/Project/UserRemove/" + project_id + "/";
%>
<div class="table-content">
	<div class="table-cover">
		<div class="cover-buttons-list">
			<a href="#" class="cover-btn tool-add" id="tool-add" onclick="slide(this.id, 'form-add');">
				<span>Add</span>
			</a>
		</div>
		People
	</div>
<!--				******************** FORM ADD ******************* 	-->
	<% Html.RenderPartial("UserAssignForm"); %>
	<!-- ******************** END FORM ADD ******************* 	-->
	<div class="table-grip-wrapper">
		<div class="grid-content">
			<div class="grid-items-wrapper">
			    <% 
                    foreach (var item in users)
                    {%>
                        <div class="gi-wrapper" style="position: relative;">
					        <a class="grid-item" href="<%= linkView + item.id %>">
						        <img alt="" src="/Content/images/user-icon-male.png"/>
						        <p><%= item.name%></p>
					        </a>
					        <a href="<%= linkDel + item.id %>" class="grid-item-icon grid-del"><span>del</span></a>
					        <a href="<%= linkEdit + item.id %>" class="grid-item-icon grid-edit"><span>edit</span></a>
				        </div>
                    <%} 
			    %>
			</div>
		</div>
		<div class="clear"></div>
	</div>
</div>