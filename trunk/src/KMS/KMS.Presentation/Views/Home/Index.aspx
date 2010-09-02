<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
KMS-知识库管理系统
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="index_logo">
    </div>
    <div id="fm" class="grid_5, prefix_5">
        <%
            using (Html.BeginForm("", "home", FormMethod.Post))
            {%>
        <input type="text" name="Keywords" class="search_index" maxlength="100" />
        <input type="submit" value="Search" class="submit" />
        <% }%>
    </div>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#logo").css("background", "none");
        });
    </script>
</asp:Content>
