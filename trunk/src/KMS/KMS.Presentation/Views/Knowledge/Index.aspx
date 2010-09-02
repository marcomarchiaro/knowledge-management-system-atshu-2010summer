<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
KMS-知识库管理系统
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="index_logo">
    </div>
    <div id="fm" class="grid_5, prefix_5">
        <%
            using (Html.BeginForm("Search", "Knowledge", FormMethod.Post))
            {%>
        <input type="text" name="condition" class="search_index" maxlength="100" style="width:600px"/>
        &nbsp;&nbsp;
        <input type="submit" value="搜索" class="submit" />
        <br />
        <br />
        (如: "tags:计算机 软件 开发 dateRange:2009-1-1~2010-2-3")
        <% }%>
    </div>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#logo").css("background", "none");
        });
    </script>
</asp:Content>
