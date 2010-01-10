<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<h1>Add User</h1>
		<div class="add-project-form">
			<form action="" method="POST">
			<table cellpadding="1" cellspacing="5" border="0" width="100%">
				<tr>
					<td width="15%">
						<label>Name:</label>
					</td>
					<td width="85%">
						<input name="form-user" id="user-name" class="" style="width: 70%"/>
					</td>
				</tr>
				<tr>
					<td>
						<label>E-mail:</label>
					</td>
					<td>
						<input name="form-user" id="user-name" class="" style="width: 70%"/>
					</td>
				</tr>
				<tr>
					<td>
						<label>Password:</label>
					</td>
					<td>
						<input name="form-user" id="user-name" class="" style="width: 70%"/>
					</td>
				</tr>
				<tr>
					<td>
						<label>Hourly rate:</label>
					</td>
					<td>
						<input name="form-user" type="checkbox"  id="user-name" class="" />
						<label>Project 1</label>
						<br/>
						<input name="form-user" type="checkbox" id="user-name" class="" />
						<label>Project 2</label>
						<br/>
					</td>
				</tr>
				<tr>
					<td>
						<label>Role:</label>
					</td>
					<td>
						<input name="user-role" value="1" type="radio" id="user-name" class="" />
						<label>Admin</label>
						<br/>
						<input name="user-role" value="2" type="radio" id="user-name" class="" />
						<label>User</label>
						<br/>
						<input name="user-role" value="3" type="radio" id="user-name" class="" />
						<label>Client</label>
						<br/>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<input type="button" name="submit" value="Save">
						<input type="button" name="submit" value="Cancel">
					</td>
				</tr>
			</table>
			</form>
		</div>