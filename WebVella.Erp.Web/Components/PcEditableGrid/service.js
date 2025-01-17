"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////
{
	// TODO: find a way to load all scripts at once after page is load + ugglify scripts

	let usedIds = new Set();
	let select2IdCounter = 0;

	let mouseOverRow = null;
	let shiftAnchor = null;

	let cDown = false;
	let vDown = false;
	let xDown = false;

	let documentProcessed;

	let allElements = document.getElementsByTagName('*');
	for (const elem of allElements) {

		if (elem.hasAttribute('id'))
			usedIds.add(elem.getAttribute('id'));

		let select2Id = elem.getAttribute('data-select2-id');
		if (select2Id && select2Id > select2IdCounter) {
			select2IdCounter = select2Id;
		}
	}

	let allSelectfields = document.getElementsByClassName('wv-field-select');

	for (const elem of allSelectfields) {

		if (elem.parentElement.parentElement?.tagName === 'TR') {

			const row = elem.parentElement.parentElement;

			if (!row.classList.contains('d-none')) {
				const body = row.parentElement;

				deleteScripts(row);

				let node = performClone(row);
				if (node) {
					body.removeChild(row);
					body.appendChild(node);
				}
			}
		}
	}


	if (documentProcessed !== true) {

		documentProcessed = true;

		document.addEventListener('keydown', e => {

			if (e.key == 'Escape') {
				clearAllSelections();
			}
			else if (e.key == 'Insert' || e.key == '+') {
				clearAllSelections();
				let body = getTargetBody();
				if (body)
					addNew(body);
			}
			else if (e.key == 'Delete') {
				let rows = document.getElementsByClassName('row-selected');
				for (let row of rows)
					row.parentElement.removeChild(row);
			}
			else if (e.key == 'c') {
				if (e.ctrlKey && !cDown) {
					let body = getTargetBody();
					if (body)
						putDataToClipboard(body);
				}
				cDown = true;
			}
			else if (e.key == 'x') {
				if (e.ctrlKey && !xDown) {
					let body = getTargetBody();
					if (body) {
						putDataToClipboard(body)?.then(() => {
							let rows = body.getElementsByClassName('row-selected');
							for (let row of rows)
								body.removeChild(row);
						});
					}
				}
			}
			else if (e.key == 'v') {
				if (e.ctrlKey && !vDown) {
					// perform insert
				}
				vDown = true;
			} 
		});

		document.addEventListener('keyup', e => {

			if (e.key == 'c') cDown = false;
			if (e.key == 'v') vDown = false;
		});

		document.addEventListener('click', e => {

			if (!mouseOverRow) {
				clearAllSelections();
			}
			else {

				if (shiftAnchor && shiftAnchor.parentElement !== mouseOverRow.parentElement) {
					clearAllSelections();
				}

				if (e.ctrlKey) {
					toggleSelection(mouseOverRow);
					shiftAnchor = mouseOverRow;
				}
				else if (e.shiftKey && shiftAnchor) {

					if (shiftAnchor === mouseOverRow) {
						markAsSelected(mouseOverRow)
					}
					else {
						let state = 0;

						for (const row of mouseOverRow.parentElement.children) {

							if (state === 0) {
								if (row !== shiftAnchor && row !== mouseOverRow)
									unmarkAsSelected(row);
								else {
									markAsSelected(row);
									state = 1;
								}
							} else if (state === 1) {

								markAsSelected(row);
								if (row === shiftAnchor || row === mouseOverRow)
									state = 2;

							} else {
								unmarkAsSelected(row);
							}
						}	
					}				
				}
				else {
					clearAllSelections();
					markAsSelected(mouseOverRow);
					shiftAnchor = mouseOverRow;
				}
			}
		}, true);
	}

	const addBtns = document.getElementsByClassName('editable-grid-add-entry-button');

	for (const addBtn of addBtns) {
		addAddCallback(addBtn);
	}

	const deleteBtns = document.getElementsByClassName('editable-grid-delete-button');

	for (let deleteBtn of deleteBtns) {
		addDeleteCallback(deleteBtn);
		let row = getParentTableRow(deleteBtn);
		if (row)
			addRowEvents(row);
	}

	function putDataToClipboard(body) {
		let rows = body.getElementsByClassName('row-selected');
		if (rows.length > 0)
		{
			let headers = getHeaders(body);
			let map = new Map();
			let skip = [];

			for (let i = 0; i < headers.length; i++) {
				if (headers[i] == '' || map.has(headers[i])) {
					skip[i] = true;
				}
				else {
					map.set(headers[i], []);
					skip[i] = false;
				}
			}

			if (map.size > 0) {

				for (let row of rows) {

					for (let i = 0; i < headers.length; i++) {
						if (!skip[i]) {

							let values = map.get(headers[i]);
							values[values.length] = getValue(row.children[i]);
						}
					}
				}

				let json = JSON.stringify(Array.from(map.entries()));
				return navigator.clipboard.writeText(json);
			}
		}
		return null;
	}

	function getValue(col) {

		for (let i = 0; i < col.children.length; i++) {
			let elem = col.children[i];

			if (elem.classList.contains('wv-field-number'))
				return getNumber(elem);
			if (elem.classList.contains('wv-field-text'))
				return getText(elem);
			if (elem.classList.contains('wv-field-checkbox'))
				return getBool(elem);
			if (elem.classList.contains('wv-field-select'))
				return getSelectId(elem);
		}

		return null;
	}

	function getNumber(numberField) {
		let input = numberField.getElementsByTagName('input')[0];
		return input.value;
	}

	function getText(textField) {
		let input = textField.getElementsByTagName('input')[0];
		return input.value;
	}

	function getBool(checkBoxField) {
		let inputs = checkBoxField.getElementsByTagName('input');
		for (let input of inputs) {
			if (input.classList.contains('form-check-input'))
				return input.value;
		}
	}

	function getSelectId(selectField) {
		let displayVal = selectField.getElementsByClassName('select2-selection__rendered')[0]?.innerText;
		if (displayVal && displayVal !== null && displayVal !== '') {
			let options = selectField.getElementsByTagName('option');
			for (let option of options) {
				if (option.innerText === displayVal)
					return option.value;
			}
		}
		return null;
	}

	function getHeaders(body) {

		let headers = body.parentElement.getElementsByTagName('th');
		let result = [];

		for (let h of headers) {
			let val = h.innerText?.trim();

			if (val === null || val === '')
				result[result.length] = '';
			else
				result[result.length] = val;
		}
		return result;
	}

	function getTargetBody() {
		let tables = getEditableGridTables();
		if (tables.length == 1) {
			return tables[0].getElementsByTagName('tbody')[0];
		}
		else if (mouseOverRow) {
			return mouseOverRow.parentElement;
		}
		return null;
	}

	function getEditableGridTables() {
		const allTables = document.getElementsByTagName('table');
		let tables = [];

		for (let table of allTables) {
			if (table.classList.contains('editable-grid')) {
				tables[tables.length] = table;
			}
		}
		return tables
	}

	function clearSelection(tbody) {
		for (const row of tbody.children)
			row.classList.remove('row-selected');
	}

	function clearAllSelections() {
		let bodies = document.getElementsByTagName('TBODY');

		for (const body of bodies)
			clearSelection(body);

		shiftAnchor = null;
	}

	function markAsSelected(row) {
		if (!row.classList.contains('row-selected'))
			row.classList.add('row-selected');
	}

	function unmarkAsSelected(row) {
		if (row.classList.contains('row-selected'))
			row.classList.remove('row-selected');
	}

	function toggleSelection(row) {
		if (!row.classList.contains('row-selected'))
			row.classList.add('row-selected');
		else
			row.classList.remove('row-selected');
	}

	function addAddCallback(btn) {

		// TODO remove this after refactoring page scripts
		if (btn.getAttribute('listener') !== 'true') {

			// TODO remove this after refactoring page scripts
			btn.setAttribute('listener', 'true');

			btn.addEventListener('click', () => {
				const body = btn.parentElement.getElementsByTagName('TBODY')[0];
				if(body)
					addNew(body);
			});
		}
	}

	function addNew(body) {

		// TODO check if body even supports insert a new item

		clearAllSelections();
		const node = performClone(body.children[0]);

		if(node)
			body.appendChild(node);
	}

	function performClone(row) {

		if (!(row instanceof HTMLElement)) return null;

		deleteScripts(row);

		const node = row.cloneNode(true);
		node.classList.remove("d-none");

		addRowEvents(node);
		replaceIds(node);

		addDeleteButtonEvets(node);
		handleSelect2Elements(node);

		return node;
	}

	function handleSelect2Elements(node) {

		const selects = node.getElementsByTagName('select');
		for (let n of selects) {
			$(n).select2();
		}

		const select2Containers = node.getElementsByClassName('select2');
		for (let n of select2Containers)
			n.setAttribute('style', null);

		const toDelete = node.getElementsByClassName('select2-container--bootstrap4');
		for (let n of toDelete)
			n.parentElement.removeChild(n);

		for (let n of select2Containers)
			n.classList.add('select2-container--bootstrap4');
	}

	function deleteScripts(node) {

		if (!(node instanceof HTMLElement)) return;

		for (let script of node.getElementsByTagName('script')) {
			script.parentElement.removeChild(script);
		}
	}

	function addDeleteButtonEvets(node) {
		for (const delBtn of node.getElementsByClassName('editable-grid-delete-button')) {
			addDeleteCallback(delBtn);
		}
	}

	function addRowEvents(row) {
		// TODO remove this after refactoring page scripts

		if (row.getAttribute('mouse-events') !== true && !row.classList.contains('d-none')) {

			row.setAttribute('mouse-events', 'true');

			row.addEventListener('mouseenter', _ => {
				if (mouseOverRow !== row) {
					mouseOverRow = row;
				}
			});

			row.addEventListener('mouseleave', _ => {
				if (mouseOverRow === row) {
					mouseOverRow = null;
				}
			});
		}
	}

	function addDeleteCallback(btn) {

		const row = getParentTableRow(btn);

		// TODO remove this after refactoring page scripts
		if (row && !row.classList.contains('d-none') && btn.getAttribute('listener') !== 'true') {

			btn.setAttribute('listener', 'true');

			btn.addEventListener('click', () => {

				clearAllSelections();
				const row = getParentTableRow(btn);
				if (row) {
					row.parentElement.removeChild(row);
				}
			});
		}
	}

	function getParentTableRow(elem) {

		let it = elem;
		while (it && it.tagName !== 'TR') {
			it = it.parentElement;
		}
		return it;
	}

	function replaceIds(elem) {

		const labels = elem.getElementsByTagName('label');

		let labelForIds = new Map();

		for (let label of labels) {

			if (label.id) {
				const newId = makeNewId(label.id);
				if (newId)
					label.id = newId;
			}

			if (label.htmlFor) {

				const newId = makeNewId(label.htmlFor);
				if (newId) {
					labelForIds.set(label.htmlFor, newId);
					labelForIds.htmlFor = newId;
				}
			}
		}

		const all = elem.getElementsByTagName('*');

		for (let e of all) {

			if (e.id && e.tagName !== 'label') {

				let newId = labelForIds.get(e.id);
				if (newId)
					e.id = newId;
				else {
					newId = makeNewId(e.id);
					if (newId)
						e.id = newId;
				}
			}
		}
	}

	function makeNewId(id) {
		const uuidRegex = /[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}/;
		const match = uuidRegex.exec(id);

		if (usedIds.has(id))
			usedIds.delete(id);

		if (!match) {
			do {
				id = id.generateUUID();
			} while (usedIds.has(id));

			return id;
		}

		do {
			id = id.replace(match[0], generateUUID());
		} while (usedIds.has(id));

		usedIds.add(id);
		return id;
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
	