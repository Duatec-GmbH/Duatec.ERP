const tableInfos = [];

for (const table of document.getElementsByClassName('editable-grid')) {
    const body = table.getElementsByTagName('TBODY')[0];

    if (body && body.getAttribute('compatibility') === 'article-amount') {

        const head = table.getElementsByTagName('THEAD')[0];

        if (head) {
            let articleColumn = -1;
            let amountColumn = -1;
            let i = 0;

            for (const col of head.getElementsByTagName('TH')) {

                if (articleColumn < 0 && col.getAttribute('name') === 'article') {
                    articleColumn = i;
                    if (amountColumn >= 0)
                        break;
                }

                else if (amountColumn < 0 && col.getAttribute('name') === 'amount') {
                    amountColumn = i;
                    if (articleColumn >= 0)
                        break;
                }

                i++;
            }

            if (articleColumn >= 0 && amountColumn >= 0) {
                tableInfos[tableInfos.length] = { table: table, articleColumn: articleColumn, amountColumn: amountColumn };

                const rows = table.getElementsByTagName('TBODY')[0].children;

                for (let i = 1; i < rows.length; i++) { // first is always dummy, we don't modify this

                    const amountCell = rows[i].children[amountColumn];

                    for (const elem of amountCell.getElementsByClassName('visible-when-divisible')) {
                        elem.style.setProperty('display', 'none', 'important');
                    }
                }
            }
        }
    }
}

if (tableInfos.length > 0) {

    document.addEventListener('DOMContentLoaded', () => {
        $.ajax({
            type: 'GET',
            url: '/api/v3.0/a/articles/denomination-lookup',
            dataType: 'json',
            success: function (response) {

                const articleLookup = new Map();
                let showError = false;

                for (const [key, value] of Object.entries(response)) {
                    articleLookup.set(key, value);
                }

                for (const tableInfo of tableInfos) {

                    const rows = tableInfo.table.getElementsByTagName('TBODY')[0].children;

                    for (let i = 1; i < rows.length; i++) { // first is always dummy, we don't modify this

                        const articleCell = rows[i].children[tableInfo.articleColumn];
                        const amountCell = rows[i].children[tableInfo.amountColumn];

                        const article = EditableGrid.getValue(articleCell);

                        const articleInfo = articleLookup.get(article);

                        if (articleInfo?.isDivisible) {
                            for (const elem of amountCell.getElementsByClassName('visible-when-divisible')) {
                                elem.style.removeProperty('display');
                            }
                        }
                    }
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr.error(textStatus, 'Error!', { closeButton: false, tapToDismiss: true });
            }
        });
    }, true);
}