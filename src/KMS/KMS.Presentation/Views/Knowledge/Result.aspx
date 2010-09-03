<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<KMS.Model.KnowledgeInfo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	搜索结果
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>搜索结果</h2>
    <p>
        搜索词：<%=ViewData["input"].ToString() %>
    </p>
    <table width="100%">
        <tr>
            <th width="8%">
                知识点ID
            </th>
            <th width="10%">
                名称
            </th>
            <th>
                描述
            </th>
            <th width="15%">
                最后修改
            </th>
            <th width="8%"></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.KnowledgeId %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.TimeStamp) %>
            </td>
            <td>
                <%: Html.ActionLink("查看", "Details", new { id = item.KnowledgeId })%> |
                <%: Html.ActionLink("删除", "Delete", new { id = item.KnowledgeId })%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

