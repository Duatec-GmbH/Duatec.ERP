const warehouseLocationSelect = document.getElementsByName('warehouse_location_id')[0];
let lastWarehouseLocationUpdateTime = new Date();

if (warehouseLocationSelect) {
    document.addEventListener("mouseenter", async (e) => {
        await update();
    });
    window.setInterval(update, 5000);

    async function update() {

        await $.ajax({
            type: 'GET',
            url: '/api/v3.0/w/warehouse-locations/select-update-info?dateTimeUtc=' + lastWarehouseLocationUpdateTime.toISOString(),
            dataType: 'json',
            success: async function (response) {

                if (response.hasChanged === true) {

                    await updateSelect(response.data);
                    lastWarehouseLocationUpdateTime = new Date();
                }
            }
        });
    }

    async function updateSelect(data) {

        const hasEmptyOption = warehouseLocationSelect.children[0]?.text === '';
        const value = warehouseLocationSelect.value;

        warehouseLocationSelect.innerText = '';

        if (hasEmptyOption) {

            const emptyOption = document.createElement('option');
            warehouseLocationSelect.appendChild(emptyOption);
        }

        for (let obj of data) {

            const option = document.createElement('option');
            option.value = obj.id;
            option.text = obj.text;
            warehouseLocationSelect.appendChild(option);
        }

        warehouseLocationSelect.value = value;
    }
}