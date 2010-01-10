<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.UserProfileViewModel>" %>

<% 
    var user = Model.user;
%>

<div class="table-content" style="border-top: 1px solid #5376A2; border-bottom: 1px solid #5376A2;">
	<table class="table-info" width="100%">
		<tr>
			<td width="30%" rowspan="5" style="text-align: center;">	
				<img src="/Content/images/no-avatar-male.jpg" alt="avatar" style="border: 1px solid #B0C0DF"/>
			</td>
			<td width="20%" class="title-cell">
				Company:
			</td>
			<td width="50%">
			 	<%= user.company%>
			</td>
		</tr>
		<tr>
			<td class="title-cell">
				Email:
			</td>
			<td>
			    <%= user.email%>
			</td>
		</tr>
		<tr>
			<td>
				URL:
			</td>
			<td>
			    
			</td>
		</tr>
		<tr>
			<td>
				Phone:
			</td>
			<td>
			    <%= user.phone%>
			</td>
		</tr>
		<tr>
			<td>
				Address:
			</td>
			<td>
			    <%= user.address%>
			</td>
		</tr>
	</table>					
</div>