<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KMS.Model.KnowledgeInfo>" %>
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
        新建知识</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(false) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            当前知识分类ID：<%: ViewData["knowledgeClassId"] %>
            <%: Html.TextBox("knowledgeClassId", null, new { type = "hidden" }) %>
        </div>

        <div class="editor-label">
            名称：
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            标签：
        </div>
        <div class="editor-field">
            <%: Html.TextBox("tags", null) %>(用空格分开，如"计算机 书籍")
        </div>

        <div class="editor-label">
            描述：
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>

        <div class="editor-label">
            内容：
        </div>
        <div>
            <%: Html.TextAreaFor(model => model.Content) %>
            <%: Html.ValidationMessageFor(model => model.Content) %>
        </div>
        <div class="editor-label">
            <input type="submit" value="添加" />
        </div>
    </fieldset>
    <% } %>
</asp:Content>
