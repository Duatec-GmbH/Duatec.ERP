"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////
{
	// TODO: find a way to load all scripts at once after page is load + ugglify scripts

	const deleteBtns = document.getElementsByClassName('editable-grid-delete-button');

	for (let deleteBtn of deleteBtns) {
		addDeleteCallback(deleteBtn);
	}

	const addBtns = document.getElementsByClassName('editable-grid-add-entry-button');

	for (const addBtn of addBtns) {
		addAddCallback(addBtn);
	}

	function addAddCallback(btn) {

		// TODO remove this after refactoring page scripts
		if (btn.getAttribute('listener') !== 'true') {

			// TODO remove this after refactoring page scripts
			btn.setAttribute('listener', 'true');

			btn.addEventListener('click', () => {

				// dummy node which is not visible
				const body = btn.parentElement.getElementsByTagName('TBODY')[0];
				const node = body.children[0].cloneNode(true);

				body.appendChild(node);
				node.classList.remove("d-none");

				const fields = node.getElementsByClassName('wv-field');

				for (const field of fields) {
					replaceIds(field);
				}

				const delBtns = node.getElementsByClassName('editable-grid-delete-button');

				for (let delBtn of delBtns) {
					addDeleteCallback(delBtn);
				}
			});
		}
	}

	function addDeleteCallback(btn) {

		// TODO remove this after refactoring page scripts
		if (btn.getAttribute('listener') !== 'true' && !btn.classList.contains('d-none')) {

			btn.addEventListener('click', () => {

				const row = getParentTableRow(btn);
				if (row) {
					row.parentElement.removeChild(row);
				}
			});
		}
	}

	function getParentTableRow(btn) {

		let it = btn;
		while (it && it.tagName !== 'TR') {
			it = it.parentElement;
		}
		return it;
	}

	function replaceIds(field) {

		const inputs = field.getElementsByTagName('input');
		const labels = field.getElementsByTagName('label');

		for (let input of inputs) {

			if (input.id && input.id.startsWith('input-')) {

				const oldId = input.id;
				input.id = 'input-'.concat(generateUUID());

				for (let label of labels) {

					if (label.htmlFor && label.htmlFor === oldId) {

						label.htmlFor = input.id;
					}
				}
			}
		}
	}

	// https://stackoverflow.com/questions/105034/how-do-i-create-a-guid-uuid
	function generateUUID() { // Public Domain/MIT
		let d = new Date().getTime();//Timestamp
		let d2 = ((typeof performance !== 'undefined') && performance.now && (performance.now() * 1000)) || 0;
		//Time in microseconds since page-load or 0 if unsupported
		return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
			let r = Math.random() * 16;//random number between 0 and 16
			if (d > 0) {//Use timestamp until depleted
				r = (d + r) % 16 | 0;
				d = Math.floor(d / 16);
			} else {//Use microseconds since page-load if supported
				r = (d2 + r) % 16 | 0;
				d2 = Math.floor(d2 / 16);
			}
			return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
		});
	}
}

//////////////////////////////////////////////////////////////////////////////////
/// You code is above
	