<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    string actionLink = "/Admin/RoleAdd/";
 %>

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
						<form name="frmRole" action="<%= actionLink %>" method="POST" onsubmit="changeCheckboxValues()">
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
									<input type="checkbox" name="project_add" class="" value="0"> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="project_edit" class="" value="0"> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="project_del" class="" value="0"> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="project_close" class="" value="0"> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Milestone</h3><br/>
									<input type="checkbox" name="milestone_add" class="" value="0"> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="milestone_edit" class="" value="0"> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="milestone_del" class="" value="0"> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="milestone_close" class="" value="0"> 
									<label>Close</label>
									<br/>
									<br/>
									
									<h3>Tasks</h3><br/>
									<input type="checkbox" name="task_add" class="" value="0"> 
									<label>Add</label>
									<br/>
									<input type="checkbox" name="task_edit" class="" value="0"> 
									<label>Edit</label>
									<br/>
									<input type="checkbox" name="task_del" class="" value="0"> 
									<label>Delete</label>
									<br/>
									<input type="checkbox" name="task_close" class="" value="0"> 
									<label>Close</label>
									<br/>
									<br/>
								</td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<input type="submit" name="btnSave" value="Save">
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
							<td> <a href="">Admin </a></td>
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
							<td> <a href=">User</a></td>
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
							<td> <a href="">Client</a></td>
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
			
<script type="text/javascript">
function changeCheckboxValues() {
    if (document.frmRole.project_add.checked) {
        document.frmRole.project_add.value = 1;
    }

    if (document.frmRole.project_edit.checked) {
        document.frmRole.project_edit.value = 1;
    }

    if (document.frmRole.project_del.checked) {
        document.frmRole.project_del.value = 1;
    }

    if (document.frmRole.project_close.checked) {
        document.frmRole.project_close.value = 1;
    }
    
    // Milestone
    if (document.frmRole.milestone_add.checked) {
        document.frmRole.milestone_add.value = 1;
    }

    if (document.frmRole.milestone_edit.checked) {
        document.frmRole.milestone_edit.value = 1;
    }

    if (document.frmRole.milestone_del.checked) {
        document.frmRole.milestone_del.value = 1;
    }

    if (document.frmRole.milestone_close.checked) {
        document.frmRole.milestone_close.value = 1;
    }

    // Tasks
    if (document.frmRole.task_add.checked) {
        document.frmRole.task_add.value = 1;
    }

    if (document.frmRole.task_edit.checked) {
        document.frmRole.task_edit.value = 1;
    }

    if (document.frmRole.task_del.checked) {
        document.frmRole.task_del.value = 1;
    }

    if (document.frmRole.task_close.checked) {
        document.frmRole.task_close.value = 1;
    } 
}
</script>