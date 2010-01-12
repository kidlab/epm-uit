<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Models.User>" %>
<% 
    EPM.Models.User user = null;
                    user = Model;
    var action           = "/Admin/UserEdit/id/" + user.id;
    List<EPM.Models.Role> roles = null;
    
    //
    // get role list
    if (ViewData["roles"] != null){
        roles = (List<EPM.Models.Role>)ViewData["roles"];
    }
    
    //
    // check if there were errors
    if (ViewData["errors"] != null)
    {
        List<String> errors = (List<String>)ViewData["errors"];
%>
<div class="error-message">
    Please correct the errors and try again
    <ul>
        <% foreach (var err in errors)
           {
               this.Writer.Write("<li>" + err + "</li>");
           } %>
    </ul>
</div>
<% } %>
<div class="table-content tb-boder" >
	<div class="form-normal" id="form-edit">
	<div class="add-poject-form">
		<form action="<%= action%>" method="POST">
		<table class="table-form" cellpadding="1" cellspacing="1" border="0" width="100%">
			<tr>
				<td width="20%" class="title-cell">
					User:
				</td>
				<td width="80%">
					<input class="form-test" id="input-name" type="text" name="username" value="<%= user.name ?? "" %>" style="width: 70%">
				</td>
			</tr>
			<tr><td><br/></td></tr>
			<tr>
				<td class="title-cell">
					Company:
				</td>
				<td>
					<input class="form-test" id="input-due" type="text" name="company"  value="<%= user.company ?? "" %>" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					Email:
				</td>
				<td>
					<input class="form-test" id="input-due" type="text" name="email" value="<%= user.email ?? "" %>" style="width: 70%">
				</td>
			</tr>	
			<tr>
				<td class="title-cell">
					Phone:
				</td>
				<td>
					<input class="form-test" id="input-due" type="text" name="phone" value="<%= user.phone ?? "" %>" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td colspan="2"><br/></td>
			</tr>
			<tr>
				<td class="title-cell">
					Address:
				</td>
				<td>
					<input class="form-test" id="input-due" type="text" name="address"  value="<%= user.address ?? "" %>" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					Country:
				</td>
				<td>
					<input class="form-test" id="input-due" type="text" name="country" value="<%= user.country ?? "" %>" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					Gender:
				</td>
				<td>					
					<select name="gender">
					    <% if (user.gender == 1)
                        {%>
					        <option value="0">Nam</option>
					        <option value="1">Nữ</option>
					    <% }
                        else
                        {%>
                            <option value="0">Nam</option>
					        <option value="1" selected="selected">Nữ</option>
					    <% } %>
					</select>
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					Role:
				</td>
				<td>
				    <% 
                        if (roles != null)
                        {
                            foreach (var item in roles)
                            {
                                if (user.IsAssignedRole(item)){ %>
                                    <input type="radio" checked=checked value="<%= item.id%>" name="role"/> <%= item.name %> <br />
                                <% } else {
                                %>
                                    <input type="radio" value="<%= item.id%>" name="role"/> <%= item.name %> <br />
                                <%
                                }
                            }
                        }
				    %>
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					password:
				</td>
				<td>
					<input class="form-test" id="Password1" type="password" name="oldpassword" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					New password:
				</td>
				<td>
					<input class="form-test" id="input-due" type="password" name="password" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td class="title-cell">
					Repeat password:
				</td>
				<td>
					<input class="form-test" id="input-due" type="password" name="repeatpassword" style="width: 70%">
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center">
				    <input class="form-test" type="hidden" name="id" value="<%= user.id%>" />
					<input type="submit" name="submit" value="Save">
				</td>
			</tr>
		</table>
		</form>
	</div>
</div>

</div>
