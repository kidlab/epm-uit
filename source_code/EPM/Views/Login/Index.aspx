<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" href="/Content/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/Content/images/favicon.ico"  type="image/x-icon" />
    <link href="/Content/style.css" type="text/css" rel="stylesheet" />
</head>

<body>
<% string actionLink = "/Login/index"; %>
    <div id="header-wrapper"> 
		<div id="header">
            <div id="header-left">					
				<a class="logo" href="/"> <img src="/Content/images/logo-b.png" alt="EPM logo"/></a>
				<h2 class="header-title">EPM - Easy Project Management</h2>
			</div>
		
			<div class="clear"></div>
		</div>
	</div>
    <div id="body-wrapper">    
		<div id="body">
			<div id="login-wrapper">
				<form action="<%= actionLink %>" method="post">
					<label>Username</label>
					<input name="username" style="padding: 3px; width: 95%;" type="text">
					<label>Password</label>
					<input name="password" style="padding: 3px; width: 95%;" type="password">
					<center>
						<input value="OK" type="submit">
					</center>
				</form>
			</div>
		</div>	
    </div>
    <div class="clear"></div>
	<div id="footer-wrapper">
		<div id="footer">
			<p>Copyright(c) EPM 2009</p>
		</div>
	</div>
</body>
</html>