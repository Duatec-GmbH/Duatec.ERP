
document.addEventListener('DOMContentLoaded', () => {

    function getFormValues()
    {
        let result = [];

        for (let form of document.getElementsByTagName('form')) {

            let formObj = getFormValue(form);
            if (formObj)
                result[result.length] = formObj;
        }

        return result;
    }

    function getFormValue(form) {
        let inputs = form.getElementsByTagName('input');
        let selects = form.getElementsByTagName('select');

        if (inputs.length > 0 || selects.length > 0) {

            let formObj = {};
            let values = [];

            for (let input of inputs) {

                if (input.name)
                    values[values.length] = { name: input.name, value: input.value };
            }

            for (let select of selects) {

                if (select.name)
                    values[values.length] = { name: select.name, value: select.value };
            }

            values.sort((a, b) => a.name.localeCompare(b.name));

            for (let kp of values)
                formObj[kp.name] = kp.value;

            return formObj;
        }
        return null;
    }

    let initial = getFormValues();
    let submited = false;

    for (let form of document.getElementsByTagName('form')) {

        form.addEventListener('submit', () => {
            submited = true;
        });
    }


    if (initial.length > 0) {

        window.addEventListener('beforeunload', e => {

            if (submited)
                submited = false;

            else {
                let current = getFormValues();

                if (initial.length === current.length) {

                    for (let i = 0; i < initial.length; i++) {

                        let initVal = initial[i];
                        let curVal = current[i];

                        if (JSON.stringify(initVal) !== JSON.stringify(curVal)) {
                            e.preventDefault();
                            return true;
                        }
                        else {

                            for (let form of document.getElementsByTagName('form')) {

                                let invalidFeedbacks = form.getElementsByClassName('invalid-feedback');

                                if (invalidFeedbacks.length > 0) {
                                    e.preventDefault();
                                    return true;
                                }
                            }
                        }
                    }
                }
                else {
                    e.preventDefault();
                    return true;
                }
            }
        });
    }
});

