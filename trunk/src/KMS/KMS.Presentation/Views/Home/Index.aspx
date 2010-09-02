<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
            http://asp.net/mvc</a>.
    </p>--%>
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
</asp:Content>
