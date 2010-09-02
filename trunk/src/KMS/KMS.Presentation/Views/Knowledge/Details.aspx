<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	知识阅览
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>知识阅览</h2>

    <fieldset>
        <legend>Fields</legend>
        <div>相关分类：</div>
        <br />
        <%foreach (var p in Model.KnowledgeKnowledgeClassAssociationInfos)
          { %>
          <div style="float:left;margin-left:8px;border:1px solid">
            <div>分类ID：<%=p.KnowledgeClassInfo.KnowledgeClassId %></div>
            <div>名称：<%=Html.ActionLink(p.KnowledgeClassInfo.Name, "Details", "KnowledgeClass", new { id = p.KnowledgeClassInfo.KnowledgeClassId }, null) %></div>
          </div>
        <%} %>
        <div style="clear:both"></div>
        <br />
        <div class="display-label">知识ID：<%: Model.KnowledgeId %></div>
        
        <div class="display-label">名称：<%: Model.Name %></div>

        <div class="display-label">描述：<%: Model.Description %></div>
        
        <div class="display-label">内容：</div>
        <div><%=Model.Content %></div>

        <div class="display-label">最后修改时间：<%: String.Format("{0:g}", Model.TimeStamp) %></div>
    </fieldset>

</asp:Content>

