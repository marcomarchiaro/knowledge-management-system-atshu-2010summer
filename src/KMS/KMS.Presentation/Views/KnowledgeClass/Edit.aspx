<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeClassInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑分类信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        编辑分类信息</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(false) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            分类ID:
            <%: Model.KnowledgeClassId.ToString() %>
        </div>
        <div class="editor-label">
            <%: Html.TextBox("KnowledgeClassId", Model.KnowledgeClassId.ToString(), new { type = "hidden" })%>
        </div>
        <div class="editor-label">
            <%if (Model.FatherKnowledgeClassInfo != null)
              {
                  Response.Write("父分类ID：" + Model.FatherKnowledgeClassInfo.KnowledgeClassId.ToString());
                  Response.Write("&nbsp;&nbsp;"); Response.Write(Html.ActionLink("查看", "Details/"
                  + Model.FatherKnowledgeClassInfo.KnowledgeClassId));
              }
              else Response.Write("当前为根分类");
            %>
        </div>
        <div class="editor-label">
            描述：
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div class="editor-label">
            名称
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            最后修改时间：<%: String.Format("{0:g}", Model.TimeStamp)%>
        </div>
        <div class="editor-field">
            <input type="submit" value="保存" />
        </div>
    </fieldset>
    <% } %>
</asp:Content>
