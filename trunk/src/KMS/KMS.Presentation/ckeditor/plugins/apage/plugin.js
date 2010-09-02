CKEDITOR.plugins.add('apage',
    {
        init: function (editor) {
            // Add the link and unlink buttons.
            editor.addCommand('apage', new CKEDITOR.dialogCommand('apage'));
            editor.ui.addButton('Page',
    {
        //label : editor.lang.link.toolbar,
        label: "Page",

        icon: 'images/anchor.jpg',
        command: 'apage'
    });
            //CKEDITOR.dialog.add( ��link��, this.path + ��dialogs/link.js�� );
            CKEDITOR.dialog.add('apage', function (editor) {
                return {
                    title: '���·�ҳ',
                    minWidth: 350,
                    minHeight: 100,
                    contents: [
    {
        id: 'tab1',
        label: 'First Tab',
        title: 'First Tab',
        elements:
    [
    {
        id: 'pagetitle',
        type: 'text',
        label: '��������һҳ���±���<br />(������Ĭ��ʹ�õ�ǰ����+������ʽ)'
    }
    ]
    }
    ],
                    onOk: function () {
                        editor.insertHtml("[page=" + this.getValueOf('tab1', 'pagetitle') + "]");
                    }
                };
            });
        },

        requires: ['fakeobjects']
    });
