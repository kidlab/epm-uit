<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    int projectId = 0;
    if (ViewData["project_id"] != null)
    {
        projectId = (int)ViewData["project_id"];
    } 
 %>
<ul id="body-tab">
	<li class="tab" id="tab-project"> <a href="/Project/ManageProject/<%= projectId %>">Project </a> </li>
	<li class="tab" id="tab-milestone"> <a href="/Milestone/Index/<%= projectId %>"> Milestone </a> </li>
	<li class="tab" id="tab-task"> <a href="/TaskList/Index/<%= projectId %>"> Taskslist</a> </li>
	<li class="tab" id="tab-user"> <a href="/Project/User/<%=projectId %>"> User</a> </li>
</ul>
