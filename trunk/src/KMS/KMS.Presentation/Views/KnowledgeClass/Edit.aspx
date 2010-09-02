<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeClassInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(false) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            分类ID: <%: Model.KnowledgeClassId.ToString() %>
        </div>
        <div class="editor-label">
            <%: Html.TextBox("KnowledgeClassId", Model.KnowledgeClassId.ToString(), new { type = "hidden" })%>
        </div>
        <div>
            父分类ID：<%: Model.FatherKnowledgeClassInfo.KnowledgeClassId.ToString() %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div>
            最后修改时间：<%: String.Format("{0:g}", Model.TimeStamp)%>
        </div>
        <p>
            <input type="submit" value="保存" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
