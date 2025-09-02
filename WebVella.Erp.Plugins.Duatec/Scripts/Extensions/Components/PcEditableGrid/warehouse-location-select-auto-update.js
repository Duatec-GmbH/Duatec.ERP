const warehouseLocationTableIds = [];
let lastWarehouseLocationGridsUpdateTime = new Date();

for (const table of document.getElementsByClassName('editable-grid')) {

    const body = table.getElementsByTagName('TBODY')[0];
    if (body) {
        for (const select of body.children[0].getElementsByTagName('select')) {

            if (select && select.name === 'warehouse_location_id')
                warehouseLocationTableIds[warehouseLocationTableIds.length] = table.id;
        }
    }
}

if (warehouseLocationTableIds.length > 0) {
    document.addEventListener("mouseenter", async (e) => {
        await updateWarehouseLocations();
    });

    window.setInterval(updateWarehouseLocations, 5000);
}

async function updateWarehouseLocations() {
    await $.ajax({
        type: 'GET',
        url: '/api/v3.0/w/warehouse-locations/select-update-info?dateTimeUtc=' + lastWarehouseLocationGridsUpdateTime.toISOString(),
        dataType: 'json',
        success: async function (response) {

            if (response.hasChanged === true) {

                for (const tableId of warehouseLocationTableIds)
                    EditableGrid.updateSelectSource(tableId, 'warehouse_location_id', response.data);

                lastWarehouseLocationGridsUpdateTime = new Date();
            }
        }
    });
}