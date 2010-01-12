<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EPM.Helpers" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>index TEST</h2>
   
    <!-- 
        Html.calendar(int type, int user_id, int project_id) 
        - type: loại calendar  (1:lớn  , 2:nhỏ (slidebar))
        - user_id : id của user đang đăng nhập
        - project_id : id của project user đó đang coi . id = -1 : mún coi calendar cho tất cả project (user đang ở màn hính Desktop) 
        
        ++ dưới đây là 2 ví dụ : 
            - Cái thứ 1 cho calendar lớn nằm ngay bên trái , coi các event của project có id = 3 
            - cái thứ 2 cho calendar nhỏ nằm bên slidebar bên phải .
    -->
    <%= Html.calendar(1,1,3)%>
    <p />
    <%= Html.calendar(2,1,-1)%>
    
    
    <!-- 
    bool validAuth(int user_id, int project_id, string action, string module)
     - user_id : user'id đăng nhập
     - project_id : project của user đó đang coi
     - action : kiểu chuỗi , phải giống với dữ liệu trong bảng Action
     - module : tức tên controller kiểu chuỗi , phải giống với dữ liệu trong bảng Action
    + cách sửa dụng : dùng hàm này ở đầu mỗi action , sẽ trả về giá trị true nếu allow và ngươc lại , dựa vào giá trị đó dev tự xử lý tiếp (redirect hay lam ji đó tùy thích) 
    
    ++ dưới đây là 1 ví dụ
    -->
    <% EPM_Auth.validAuth(4,3,"view","Milestone";  %>
         
  
 
</asp:Content>
