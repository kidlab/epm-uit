<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="table-content">
					<div class="table-cover">
						<div class="cover-buttons-list">
							<a href="#" class="cover-btn tool-add" id="tool-add" onclick="toggleSlide(this.id, 'form-add-role', 'open', 'up')">
								<span>Add</span>
							</a>
							<a href="#" class="cover-btn tool-edit">
								<span>Edit</span>
							</a>
							<a href="#" class="cover-btn tool-del">
								<span>Del</span>
							</a>
							<a href="#" class="cover-btn tool-check">
								<span>Check</span>
							</a>
						</div>	
						Roles
					</div>
<!--				******************** FORM ADD ******************* 	-->
					<div class="form-ajax" id="form-add-role" style="display: none;">
					<h1>Add Role</h1>
					<div class="add-project-form">
						<form action="" method="POST">
						<table cellpadding="1" cellspacing="5" border="0" width="100%">
							<tr>
								<td width="10%">
									<label>Name:</label>
								</td>
								<td width="90%">
									<input class="form-test" id="input-name" type="text" name="name" style="width: 70%">
								</td>
							</tr>
							<tr>
								<td valign="top">
									<label>Role:</label>
								</td>
								<td>
									<h3>Project</h3><br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Milestone</h3><br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Tasks</h3><br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Time Tracker</h3><br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Admin</h3><br/>
									<input type="checkbox" name="" class="" value=""> 
									<label>Administration</label>
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
				</div>
				<!-- ******************** END FORM ADD ******************* 	-->
				<div class="table-list-wrapper">
					<table class="table-list" width="100%" cellpadding="1" cellspacing="1">
						<tr>
							<th width="5%"></th>
							<th width="50%">Name</th>
							<th width="35%"></th>
							<th width="10%">Edit</th>
						</tr>
						<tr>
							<td>
							</td>
							<td> <a href="projectinfo.html">Admin </a></td>
							<td> </td>
							<td>							
								<a class="button btn-del" href="/">
									<span>del</span>
								</a>						
							</td>
						</tr>
						<tr>
							<td>
							</td>
							<td> <a href="projectinfo.html">User</a></td>
							<td> </td>
							<td>							
								<a class="button btn-del" href="/">
									<span>del</span>
								</a>						
							</td>
						</tr>
						<tr>
							<td>
							</td>
							<td> <a href="projectinfo.html">Client</a></td>
							<td> </td>
							<td>							
								<a class="button btn-del" href="/">
									<span>del</span>
								</a>						
							</td>
						</tr>
					</table>
					
				</div>
			</div>