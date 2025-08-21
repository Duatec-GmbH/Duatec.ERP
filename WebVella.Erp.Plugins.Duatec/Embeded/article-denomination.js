let loader = document.body.getElementsByClassName('loader')[0];
if (!loader) {
    loader = document.createElement('div');
    loader.classList.add('loader');

    if (document.body.children.length === 0)
        document.body.appendChild(loader);
    else
        document.body.children[0].prepend(loader);
}

loader.classList.remove('d-none');

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

                    if (rows[i].children.length > amountColumn && rows[i].children.length > articleColumn) {

                        const amountCell = rows[i].children[amountColumn];
                        hideDenominationElements(amountCell);
                    }
                }
            }
        }
    }
}

if (tableInfos.length > 0) {

    document.addEventListener('DOMContentLoaded', () => {

        loader.classList.remove('d-none');

        $.ajax({
            type: 'GET',
            url: '/api/v3.0/a/articles/denomination-lookup',
            dataType: 'json',
            success: function (response) {

                try {

                    const articleLookup = new Map();

                    for (const [key, value] of Object.entries(response)) {
                        articleLookup.set(key, value);
                    }

                    for (const tableInfo of tableInfos) {

                        addTableObserver(tableInfo, articleLookup);

                        const body = tableInfo.table.getElementsByTagName('TBODY')[0];
                        const rows = body.children;

                        for (let i = 1; i < rows.length; i++) { // first is always dummy, we don't modify this

                            var colLen = rows[i].children.length;

                            if (tableInfo.articleColumn < colLen && tableInfo.amountColumn < colLen) {

                                const articleCell = rows[i].children[tableInfo.articleColumn];
                                const amountCell = rows[i].children[tableInfo.amountColumn];

                                const articleId = EditableGrid.getValue(articleCell);
                                const articleInfo = articleLookup.get(articleId);

                                if (articleInfo) {

                                    if (articleInfo.isDivisible)
                                        showDenominationElements(amountCell);

                                    addArticleObserver(articleCell, amountCell, articleLookup);
                                }
                            }
                        }
                    }
                }
                finally {
                    loader.classList.add('d-none');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                try {
                    toastr.error(textStatus, 'Error!', { closeButton: false, tapToDismiss: true });
                }
                finally {
                    loader.classList.add('d-none');
                }
            }
        });
    }, true);
}

function hideDenominationElements(elem) {

    for (const e of elem.getElementsByClassName('visible-when-divisible')) {
        e.style.setProperty('display', 'none', 'important');
    }
}

function showDenominationElements(elem) {

    for (const e of elem.getElementsByClassName('visible-when-divisible')) {
        e.style.removeProperty('display');
    }
}

function addArticleObserver(articleCell, amountCell, articleLookup) {

    const container = articleCell.getElementsByClassName('select2-container')[0];

    if (!container)
        return null;

    const observer = new MutationObserver((mutationList) => {
        mutationList
            .filter((m) => m.type === 'childList')
            .forEach((mutation) => {
                mutation.addedNodes.forEach((node) => {
                    updateAmountCell(articleCell, amountCell, articleLookup);
                });
            });
    });

    observer.observe(container, { childList: true, subtree: true });

    return observer;
}

function addTableObserver(tableInfo, articleLookup) {

    const body = tableInfo.table.getElementsByTagName('TBODY')[0];

    const observer = new MutationObserver((mutationList) => {
        mutationList
            .filter((m) => m.type === 'childList')
            .forEach((mutation) => {
                mutation.addedNodes.forEach((row) => {

                    if (tableInfo.articleColumn < row.children.length && tableInfo.amountColumn < row.children.length) {

                        const articleCell = row.children[tableInfo.articleColumn];
                        const amountCell = row.children[tableInfo.amountColumn];

                        updateAmountCell(articleCell, amountCell, articleLookup);
                        addArticleObserver(articleCell, amountCell, articleLookup);
                    }
                });
            });
    });

    observer.observe(body, { childList: true, subtree: false });

    return observer;
}

function updateAmountCell(articleCell, amountCell, articleLookup) {

    const articleInfo = articleLookup.get(EditableGrid.getValue(articleCell));

    if (articleInfo) {

        if (articleInfo.isDivisible)
            showDenominationElements(amountCell);
        else
            hideDenominationElements(amountCell);

        var unitElement = amountCell.getElementsByClassName('article-unit')[0];
        if (unitElement)
            unitElement.textContent = articleInfo.unit;
    }
}