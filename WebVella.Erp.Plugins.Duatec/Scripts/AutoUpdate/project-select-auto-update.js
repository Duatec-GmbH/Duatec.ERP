const projectSelect = document.getElementsByName('project_id')[0];
let lastProjectUpdateTime = new Date();

if (projectSelect) {
    document.addEventListener("mouseenter", async (e) => {
        await update();
    });
    window.setInterval(update, 5000);

    async function update() {

        await $.ajax({
            type: 'GET',
            url: '/api/v3.0/p/projects/select-update-info?dateTimeUtc=' + lastProjectUpdateTime.toISOString(),
            dataType: 'json',
            success: async function (response) {

                if (response.hasChanged === true) {

                    await updateSelect(response.data);
                    lastProjectUpdateTime = new Date();
                }
            }
        });
    }

    async function updateSelect(data) {

        const hasEmptyOption = projectSelect.children[0]?.text === '';
        const value = projectSelect.value;

        projectSelect.innerText = '';

        if (hasEmptyOption) {

            const emptyOption = document.createElement('option');
            projectSelect.appendChild(emptyOption);
        }

        for (let obj of data) {

            const option = document.createElement('option');
            option.value = obj.id;
            option.text = obj.text;
            projectSelect.appendChild(option);
        }

        projectSelect.value = value;
    }
}