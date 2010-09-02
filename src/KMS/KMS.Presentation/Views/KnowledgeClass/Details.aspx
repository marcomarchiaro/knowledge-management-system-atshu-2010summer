<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeClassInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    知识分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h5>
        当前分类信息</h5>
    <table width="100%">
        <tr>
            <th width="8%">
                当前分类ID
            </th>
            <th width="10%">
                分类名
            </th>
            <th>
                描述
            </th>
            <th width="15%">
                最后修改时间
            </th>
        </tr>
        <tr>
            <td>
                <%: Model.KnowledgeClassId %>
            </td>
            <td>
                <%: Model.Name %>
            </td>
            <td>
                <%: Model.Description %>
            </td>
            <td>
                <%: String.Format("{0:g}", Model.TimeStamp) %>
            </td>
        </tr>
    </table>
    <h5>
        子分类信息</h5>
    <p>
        <%: Html.ActionLink("添加新分类", "Create") %>
    </p>
    <table width="100%">
        <tr>
            <th width="8%">
                子分类ID
            </th>
            <th width="10%">
                分类名
            </th>
            <th>
                描述
            </th>
            <th width="15%">
                最后修改时间
            </th>
            <th width="12%">
            </th>
        </tr>
        <% foreach (var item in Model.KnowledgeClassInfos)
           { %>
        <tr>
            <td>
                <%: item.KnowledgeClassId %>
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
                <%: Html.ActionLink("查看", "Details", new { id = item.KnowledgeClassId }, new { target = "_blank" })%>
                |
                <%: Html.ActionLink("编辑", "Edit", new { id = item.KnowledgeClassId }, new { target = "_blank" }) %>
                |
                <%: Html.ActionLink("删除", "Delete", new { id = item.KnowledgeClassId })%>
            </td>
        </tr>
        <% } %>
    </table>
    <h5>
        当前分类下的知识</h5>
    <table width="100%">
        <tr>
            <th>
            </th>
            <th>
                知识ID
            </th>
            <th>
                名称
            </th>
            <th>
                描述
            </th>
            <th>
                标签
            </th>
            <th>
                修改时间
            </th>
        </tr>
        <% foreach (var item in Model.KnowledgeKnowledgeClassAssociationInfos)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("查看", "Knowledge/Detail", new { id = item.KnowledgeInfo.KnowledgeId }) %>
                |
                <%: Html.ActionLink("删除", "Knowledge/Delete", new { id = item.KnowledgeInfo.KnowledgeId })%>
            </td>
            <td>
                <%: item.KnowledgeInfo.KnowledgeId %>
            </td>
            <td>
                <%: item.KnowledgeInfo.Name %>
            </td>
            <td>
                <%: item.KnowledgeInfo.Description %>
            </td>
            <td>
                <%foreach (var tag in item.KnowledgeInfo.KnowledgeTagAssociationInfos)
                  { %>
                <%: String.Format("{0} ", tag.TagInfo.Name) %>
                <%} %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.TimeStamp) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
