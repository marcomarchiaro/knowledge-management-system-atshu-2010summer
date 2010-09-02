<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    新建知识
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../../ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        var editor1;
        $(function () {
            CKEDITOR.replace('Content',
								 {
								     toolbar: 'MyToolbar',
								     language: 'zh-cn',
								     width: 600,
								     height: 300,
								     resize_dir: 'vertical',
								     resize_maxHeight: 600
								 });
            editor1 = CKEDITOR.instances.Content;
        });

    </script>
    <h2>
        Create</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(false) %>
    <fieldset>
        <legend>Fields</legend>
        <p>
            当前知识分类ID：<%//string knowledgeClassId = ViewData["knowledgeClassId"].ToString(); %>
        </p>
        <div>
            <textarea id="Content" name="Content" ></textarea>
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
        <div class="editor-label">
            <%: Html.LabelFor(model => model.TimeStamp) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.TimeStamp) %>
            <%: Html.ValidationMessageFor(model => model.TimeStamp) %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
