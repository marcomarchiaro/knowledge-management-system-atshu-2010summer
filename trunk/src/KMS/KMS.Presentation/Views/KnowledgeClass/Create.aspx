<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeClassInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加知识分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% //using (Ajax.BeginForm("Create", new AjaxOptions { }))
        using (Html.BeginForm(new { controller = "KnowledgeClass", action = "Create" }))
        {%>
    <%: Html.ValidationSummary(false)%>
    <fieldset>
        <legend>Fields</legend>
        <div>
            父分类ID：<%: Html.ViewData["fatherId"] %>
            <%: Html.TextBox("fatherId", null, new { type = "hidden" })%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Description)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Description)%>
            <%: Html.ValidationMessageFor(model => model.Description)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name)%>
            <%: Html.ValidationMessageFor(model => model.Name)%>
        </div>
        <p>
            <input type="submit" value="添加" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
