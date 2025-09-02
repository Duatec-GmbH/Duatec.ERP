const articleTableIds = [];
let lastArticleGridsUpdateTime = new Date();

for (const table of document.getElementsByClassName('editable-grid')) {

    const body = table.getElementsByTagName('TBODY')[0];
    if (body) {
        for (const select of body.children[0].getElementsByTagName('select')) {

            if (select && select.name === 'article_id')
                articleTableIds[articleTableIds.length] = table.id;
        }
    }
}

if (articleTableIds.length > 0) {
    document.addEventListener("mouseenter", async (e) => {
        await updateWarehouseLocations();
    });

    window.setInterval(updateWarehouseLocations, 5000);
}

async function updateWarehouseLocations() {
    await $.ajax({
        type: 'GET',
        url: '/api/v3.0/a/articles/select-update-info?dateTimeUtc=' + lastArticleGridsUpdateTime.toISOString(),
        dataType: 'json',
        success: async function (response) {

            if (response.hasChanged === true) {

                for (const tableId of articleTableIds)
                    EditableGrid.updateSelectSource(tableId, 'article_id', response.data);

                if (EditableGrid.updateSelectSource)
                    await EditableGrid.updateArticleDenominations(true);

                lastArticleGridsUpdateTime = new Date();
            }
        }
    });
}