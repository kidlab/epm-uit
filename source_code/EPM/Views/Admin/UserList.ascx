<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Helpers.PaginatedList<EPM.Models.User>>" %>

<% 
    if ( Model.Count > 0)
    {
        var users = Model.ToArray();
%>

<script type="text/javascript">
    // ToanNM
    // show add new user 
    $(document).ready(function() {
    });
</script>

<div class="table-content">
		<div class="table-cover">
            <div class="cover-buttons-list">
		        <a href="/Admin/UserAdd/" class="cover-btn tool-add" id="tool-add">
			        <span>Add</span>
		        </a>
	        </div>	
			User Administration
		</div>
<!--				******************** FORM ADD ******************* 	-->
		<div class="form-ajax" id="form-add" style="display: none;">
		    <% 
		        //Html.RenderPartial("UserForm"); 
		    %>
	    </div>
	<!-- ******************** END FORM ADD ******************* 	-->
	<div class="table-grip-wrapper">
		<div class="grid-content">
			<div class="grid-items-wrapper">
			    <%
                    foreach (var item in users)
                    {
                        string linkView = "/Admin/UserView/id/" + item.id;
                        string linkEdit = "/Admin/UserEdit/id/" + item.id;
                        string linkDel  = "/Admin/UserDel/id/" + item.id;
                        %>
                        <div class="gi-wrapper" style="position: relative;">
					        <a class="grid-item" href="<%= linkView%>">
						        <img alt="" src="/Content/images/user-icon-male.png"/>
						        <p><%= item.name %></p>
					        </a>
					        <a href="<%= linkDel%>" class="grid-item-icon grid-del"><span>del</span></a>
					        <a href="<%= linkEdit%>" class="grid-item-icon grid-edit"><span>edit</span></a>
				        </div>
				        <% } %>
				<%--<div class="gi-wrapper" style="position: relative;">
					<a class="grid-item" href="#">
						<img alt="" src="img/user-icon-male.png"/>
						<p>User 1</p>
					</a>
					<a href="#" class="grid-item-icon grid-del"><span>del</span></a>
					<a href="#" class="grid-item-icon grid-edit"><span>edit</span></a>
				</div>
				
				<div class="gi-wrapper" style="position: relative;">
					<a class="grid-item" href="#">
						<img alt="" src="img/user-icon-male.png"/>
						<p>User 1</p>
					</a>
					<a href="#" class="grid-item-icon grid-del"><span>del</span></a>
					<a href="#" class="grid-item-icon grid-edit"><span>edit</span></a>
				</div>--%>
			</div>
		</div>
		<div class="clear"></div>
	</div>
</div>
<% } %>