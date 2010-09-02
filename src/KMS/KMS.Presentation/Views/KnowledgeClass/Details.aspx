<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeClassInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    知识分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h5>
        当前分类信息</h5>
    <p>
        <%if (Model.FatherKnowledgeClassInfo != null)
          {
              Response.Write("父分类ID：" + Model.FatherKnowledgeClassInfo.KnowledgeClassId);
              Response.Write("&nbsp;&nbsp;");
              Response.Write(Html.ActionLink("查看", "Details/" + Model.FatherKnowledgeClassInfo.KnowledgeClassId));
          }
          else
              Response.Write("当前为根分类");
        %>
    </p>
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
                最后修改
            </th>
            <th width="12%">
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
            <td>
                <%: Html.ActionLink("编辑", "Edit", new { id = Model.KnowledgeClassId }, new { target = "_blank" }) %>
                |
                <%: Html.ActionLink("删除", "Delete", new { id = Model.KnowledgeClassId })%>
            </td>
        </tr>
    </table>
    <h5>
        子分类信息</h5>
    <p>
        <%: Html.ActionLink("添加新分类", "Create/" + Model.KnowledgeClassId, null, new { target = "_blank" })%>
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
                最后修改
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
        当前分类下的知识
    </h5>
    <p>
        <%: Html.ActionLink("添加新知识", "Create/" + Model.KnowledgeClassId, "Knowledge", null, new { target = "_blank" }) %>
    </p>
    <table width="100%">
        <tr>
            <th width="8%">
                知识ID
            </th>
            <th width="10%">
                名称
            </th>
            <th width="30%">
                描述
            </th>
            <th>
                标签
            </th>
            <th width="15%">
                最后修改
            </th>
            <th width="12%">
            </th>
        </tr>
        <% foreach (var item in Model.KnowledgeKnowledgeClassAssociationInfos)
           { %>
        <tr>
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
            <td>
                <%: Html.ActionLink("查看", "Details", "Knowledge", new { id = item.KnowledgeInfo.KnowledgeId }, new { target = "_blank" })%>
                |
                <%: Html.ActionLink("删除", "Delete", "Knowledge", new { id = item.KnowledgeInfo.KnowledgeId }, null) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
