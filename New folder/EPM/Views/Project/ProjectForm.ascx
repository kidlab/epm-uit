<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPM.Controllers.ProjectFormViewModel>"  %>

 <script type="text/javascript">
        $(document).ready(function(){
	        $("#statuswrapper .edit").toggle(function(){
			        $("#formedit").slideDown("normal");
		        }, 
		        function(){
			        $("#formedit").slideUp("normal");
		        });
	        $("#statuswrapper .desc").toggle(function(){
		        $("#statuswrapper .desc").addClass("desc-active");
		        $("#project-desc").slideDown("normal");
	        }, 
	        function(){
		        $("#statuswrapper .desc").removeClass("desc-active");
		        $("#project-desc").slideUp("normal");
	        });
        });
        </script>

    <h2 id="body-title">My Projects</h2>
    <div id="statuswrapper">
					<ul>
						<li class="link"><a class="close"></a></li>
						<li class="link"><a class="edit"></a></li>
						<li class="link"><a class="desc">Description</a></li>
						<li class="link"><a class="budget">Budget: $10000</a></li>
						<li class="link"><a class="timeleft">days left: 50 days</a></li>
					</ul>					
				</div>
				<div class="clear">
				</div>
				<div id="formedit" class="hidden" >
					<div>
						<h2 class="title">Edit Project</h2>
						<form action="/Project/edit" method="post">
						<input type="hidden" name="id" value="<%= Model.Project.id %>" />
							<table id="form" width="100%">
								<tr>
									<td width="20%">Name:</td>
									<td width="80%">
										<input type="text" name="name" value="<%= Model.Project.name %>">
									</td>
								</tr><tr>
									<td>Description:</td>
									<td>
										<textarea name="desc" cols="10" rows="5" style="width: 100%">
										<%= Model.Project.desc %>
										</textarea>
									</td>
								</tr><tr>
									<td>Date:</td>
									<td>
										<input type="text" name="start" value="<%= Model.Project.start %>" />
									</td>
								</tr>
								<tr>
									<td></td>
									<td>
										<input class="btn" type="submit" name="" value="Save">
										<input class="btn" type="button" name="" value="Cancel"
									</td>
								</tr>
							</table>
						</form>
					</div>
				</div>
				<div id="project-desc" class="hidden" >
					<p>
						bla bla bla
					</p>
				</div>