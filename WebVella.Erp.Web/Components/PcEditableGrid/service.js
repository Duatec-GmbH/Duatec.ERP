"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////

{
let usedIds = new Set();

	let mouseOverRow = null;
	let shiftAnchor = null;
	let cDown = false;
	let vDown = false;
	let xDown = false;
	let aDown = false;
	let ctrlDown = false;

	// !!!!!!!! must be VAR otherwhise gets initialized for every editable grid
	var editableGridsInitialized;
	var editableGridSelectSources;

	if (editableGridsInitialized !== true) {

		let loader = document.body.getElementsByClassName('loader')[0];
		if (!loader) {
			loader = document.createElement('div');
			loader.classList.add('loader');

			if (document.body.children.length === 0)
				document.body.appendChild(loader);
			else
				document.body.children[0].prepend(loader);
		}


		editableGridsInitialized = true;
		editableGridSelectSources = new Map();

		document.addEventListener("DOMContentLoaded", () => {

			// get all ids already used in document (I'm paranoid)
			for (let elem of document.getElementsByTagName('*')) {

				if (elem.hasAttribute('id'))
					usedIds.add(elem.getAttribute('id'));
			}

			// initialize grids
			for (let table of document.getElementsByClassName('editable-grid')) {

				let body = table.getElementsByTagName('TBODY')[0];

				const selectOptionSet = [];
				let i = 0;
				for (let select of body.children[0].getElementsByTagName('select')) {
					selectOptionSet[i] = { textLookup: new Map(), data: [] };

					for (let option of select.getElementsByTagName('option')) {

						selectOptionSet[i].data[selectOptionSet[i].data.length] = { id: option.value, text: option.text };
						selectOptionSet[i].textLookup.set(option.value, option.text);
					}
					select.innerHTML = '';
					i++;
				}

				editableGridSelectSources.set(table.id, selectOptionSet);

				for (let i = 1; i < body.children.length; i++) { // first is dummy -> skip
					initRowElements(body.children[i]);
				}

				updateNoRecordsMessage(body);
			}

			// initialize add entry buttons
			for (let addBtn of document.getElementsByClassName('editable-grid-add-entry-button')) {
				addAddCallback(addBtn);
			}

			document.addEventListener('keydown', e => {

				if (e.key == 'Control') ctrlDown = true;

				if (e.key == 'Shift' && mouseOverRow && document.activeElement.tagName !== 'input') {

					for (let table of getEditableGridTables())
						table.classList.add('user-select-none');
				}

				if (e.key == 'Escape') {
					clearAllSelections();
				}
				else if (e.key == 'Insert' || e.key == '+') {
					let body = getTargetBody();
					if (body && body.getAttribute('add') === 'true')
						addNew(body);
				}
				else if (e.key == 'Delete') {
					let body = getTargetBody();
					if (body && body.getAttribute('delete') === 'true') {

						for (let i = body.children.length - 1; i > 0; i--) {

							let row = body.children[i];
							if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
								body.removeChild(row);
						}

						updateFieldNames(body);
						updateNoRecordsMessage(body);
					}
				}
				else if (e.key == 'c' || e.key == 'C') {
					if (e.ctrlKey && !cDown && !hasSomethingElseSelected()) {
						let body = getTargetBody();
						if (body && body.getAttribute('copy') === 'true')
							putDataToClipboard(body);
					}
					cDown = true;
				}
				else if (e.key == 'a' || e.key == 'A') {
					if (e.ctrlKey && !aDown && !hasSomethingElseSelected()) {
						let body = getTargetBody();
						if (body) {
							selectAll(body);
							e.preventDefault();
						}
					}
					aDown = true;
				}
				else if (e.key == 'x' || e.key == 'X') {
					if (e.ctrlKey && !xDown && !hasSomethingElseSelected()) {
						let body = getTargetBody();
						if (body && body.getAttribute('delete') === 'true') {

							putDataToClipboard(body)?.then(() => {

								for (let i = body.children.length - 1; i > 0; i--) {

									let row = body.children[i];
									if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
										body.removeChild(row);
								}

								updateFieldNames(body);
								updateNoRecordsMessage(body);
							});
						}
					}
				}
				else if (e.key == 'v' || e.key == 'V') {
					if (e.ctrlKey && !vDown) {
						let body = getTargetBody();
						if (body && body.getAttribute('paste') === 'true') {

							let row = getTargetRow(body);
							if (row) {
								loader.classList.remove('d-none');
								let headers = getHeaders(body);
								let tableId = getParentTable(body).id;
								let selectOptionSet = editableGridSelectSources.get(tableId);

								navigator.clipboard.readText()
									.then(text => {
										try {
											let obj = JSON.parse(text);

											if (isCompatible(body, obj.compatibility)) {

												let newNodes = obj.data[0][1].map(_ => performClone(body.children[0]));

												let selectCellOffsets = [];
												let cnt = 0;

												for (let i = 0; i < body.children[0].children.length; i++) {

													selectCellOffsets[i] = cnt;
													cnt += body.children[0].children[i].getElementsByTagName('select').length;
												}

												for (let kp of obj.data) {

													let header = kp[0];
													let data = kp[1];
													let childIdx = headers.indexOf(header);

													if (childIdx >= 0) {
														for (let i = 0; i < newNodes.length; i++) {

															let value = data[i];
															let cell = newNodes[i].children[childIdx];

															let selects = cell.getElementsByTagName('select');

															for (let j = 0; j < selects.length; j++) {

																let select = selects[j];
																let emptyOption = document.createElement('option');
																select.appendChild(emptyOption);

																let textLookup = selectOptionSet[selectCellOffsets[childIdx] + j].textLookup;
																let text = textLookup.get(value);

																if (text) {
																	let selectedOption = document.createElement('option');
																	selectedOption.value = value;
																	selectedOption.text = text;
																	select.appendChild(selectedOption);
																}
															}

															setValue(cell, value);
														}
													}
												}

												e = row;
												for (let node of newNodes) {
													e.after(node);
													handleSelect2Elements(node);
													e = node;
												}
												updateFieldNames(body);
												updateNoRecordsMessage(body);
											}
											loader.classList.add('d-none');
										}
										catch (e) {
											updateFieldNames(body);
											updateNoRecordsMessage(body);
											loader.classList.add('d-none');
										}
									});
							}
						}
					}
					vDown = true;
				}
			});

			document.addEventListener('keyup', e => {

				if (e.key == 'c' || e.key == 'C') cDown = false;
				if (e.key == 'v' || e.key == 'V') vDown = false;
				if (e.key == 'x' || e.key == 'X') xDown = false;
				if (e.key == 'a' || e.key == 'A') aDown = false;
				if (e.key == 'Control') ctrlDown = false;

				if (e.key == 'Shift') {

					if (!ctrlDown) {
						for (let table of getEditableGridTables())
							table.classList.remove('user-select-none');
					}
				}
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

							for (let row of mouseOverRow.parentElement.children) {

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

			loader.classList.add('d-none');
		});


		function hasSomethingElseSelected() {
			return document.getSelection().toString().trim().length > 0;
		}

		function isCompatible(body, compatibility) {
			let bodyComp = body.getAttribute('compatibility');

			if (bodyComp === '' || bodyComp == '*')
				return true;

			let bodyEntries = bodyComp.split(',')
				.map(e => e.trim());
			let compEntries = compatibility.split(',')
				.map(e => e.trim());

			return compEntries.some(e => bodyEntries.some(be => be === e));
		}

		function updateFieldNames(body) {

			if (!body) return;

			let idx = 0;

			for (let elem of body.children) {
				if (!elem.classList.contains('d-none') && !elem.getElementsByClassName('alert-info')[0]) {

					updateRowFieldNames(elem, idx);
					idx++;
				}
			}
		}

		function updateRowFieldNames(row, idx) {

			if (!row) return;

			if (!row.classList.contains('d-none') && !row.getElementsByClassName('alert-info')[0]) {

				for (let select of row.getElementsByTagName('select')) {
					updateFieldName(select, idx);
				}

				for (let input of row.getElementsByTagName('input')) {
					updateFieldName(input, idx);
				}
				idx++;
			}
		}

		function updateNoRecordsMessage(body) {

			let cnt = 0;
			let containsAlert = false;

			for (let tr of body.children) {

				if (tr.getElementsByClassName('alert-info')[0])
					containsAlert = true;
				else if (!tr.classList.contains('d-none'))
					cnt++;
			}

			if (cnt == 0 && !containsAlert) {

				let tr = document.createElement('tr');
				let td = document.createElement('td');
				tr.appendChild(td);

				let span = getHeaders(body).length.toString();
				td.setAttribute('colspan', span);

				let div = document.createElement('div');
				td.appendChild(div);

				div.innerHTML = 'No Entries';
				div.classList.add('alert');
				div.classList.add('alert-info');
				div.classList.add('m-0');

				body.appendChild(tr);
			}
			else if (cnt > 0 && containsAlert)
			{
				let alert = body.getElementsByClassName('alert-info')[0];
				if (alert) {
					let row = alert.parentElement.parentElement;
					row.parentElement.removeChild(row);
				}
			}
		}

		function updateFieldName(elem, idx) {
			if (elem.hasAttribute('name'))
				setFieldName(elem, 'name', idx);

			if (elem.hasAttribute('data-field-name'))
				setFieldName(elem, 'data-field-name', idx);
		}

		function setFieldName(elem, attribute, idx) {
			var oldVal = elem.getAttribute(attribute);
			if (oldVal === undefined || oldVal === null || oldVal === '') return;

			let start = oldVal.lastIndexOf('[');
			if (start < 0)
				elem.setAttribute(attribute, oldVal.concat(`[${idx}]`));
			else if (oldVal.charAt(oldVal.length - 1) == ']') {

				let val = oldVal.substring(0, start).concat(`[${idx}]`);
				elem.setAttribute(attribute, val);
			}
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

		function setValue(col, value) {

			for (let i = 0; i < col.children.length; i++) {
				let elem = col.children[i];

				if (elem.classList.contains('wv-field-number'))
					return setNumber(elem, value);
				if (elem.classList.contains('wv-field-text'))
					return setText(elem, value);
				if (elem.classList.contains('wv-field-checkbox'))
					return setBool(elem, value);
				if (elem.classList.contains('wv-field-select'))
					return setSelectId(elem, value);

				throw new Error(`Could not insert value at ${elem.tagName}`);

			}

			return null;
		}

		function getNumber(numberField) {
			let input = numberField.getElementsByTagName('input')[0];
			return input.value;
		}

		function setNumber(numberField, value) {
			let input = numberField.getElementsByTagName('input')[0];
			input.value = value;
		}

		function getText(textField) {
			let input = textField.getElementsByTagName('input')[0];
			if (input)
				return input.value;

			let p = textField;

			while (p.children[0])
				p = p.children[0];
			return p?.innerText ?? null;
		}

		function setText(textField, value) {
			let input = textField.getElementsByTagName('input')[0];
			if (input) {
				input.value = value;
				return;
			}

			let p = textField;

			while (p.children[0])
				p = p.children[0];

			p.innerText = value;
		}

		function getBool(checkBoxField) {
			let inputs = checkBoxField.getElementsByTagName('input');
			for (let input of inputs) {
				if (input.hasAttribute('data-source-id'))
					return input.value;
			}
		}

		function setBool(checkBoxField, value) {
			let inputs = checkBoxField.getElementsByTagName('input');
			let hidden = inputs[0];
			let visible = inputs[1];

			hidden.value = value;
			let b = value === 'true';

			visible.checked = b;
		}

		function getSelectId(selectField) {
			return selectField.getElementsByTagName('select')[0].value;
		}

		function setSelectId(selectField, value) {
			selectField.getElementsByTagName('select')[0].value = value;
		}

		function putDataToClipboard(body) {
			let rows = body.getElementsByClassName('row-selected');
			if (rows.length > 0) {
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

					let obj = {
						compatibility: body.getAttribute('compatibility'),
						data: Array.from(map.entries().filter(kp => kp[1].some(v => v != null && v != undefined)))
					};

					return navigator.clipboard.writeText(JSON.stringify(obj));
				}
			}
			return null;
		}

		function getHeaders(body) {

			let headers = body.parentElement.getElementsByTagName('th');
			let result = [];

			for (let h of headers) {
				let val;

				var name = h.getAttribute('name');
				if (name && name.trim() != '')
					val = name.trim();
				else val = h.innerText?.trim();

				if (val === undefined || val === null || val === '')
					result[result.length] = '';
				else
					result[result.length] = val;
			}
			return result;
		}

		function getTargetRow(body) {
			if (mouseOverRow && mouseOverRow.parentElement === body)
				return mouseOverRow;

			return body.children[body.children.length - 1];
		}

		function getTargetBody() {
			let tables = getEditableGridTables();
			if (tables.length == 1) {
				return tables[0].getElementsByTagName('tbody')[0];
			}
			else if (mouseOverRow) {
				return mouseOverRow.parentElement;
			}

			var rows = document.getElementsByClassName('row-selected');
			if (rows && rows.length > 0 && rows.every(r => r.parentElement === rows[0].parentElement)) {
				return rows[0].parentElement;
			}
			return null;
		}

		function getEditableGridTables() {
			let allTables = document.getElementsByTagName('table');
			let tables = [];

			for (let table of allTables) {
				if (table.classList.contains('editable-grid')) {
					tables[tables.length] = table;
				}
			}
			return tables
		}

		function clearSelection(tbody) {
			for (let row of tbody.children)
				row.classList.remove('row-selected');
		}

		function selectAll(tbody) {

			for (let i = 1; i < tbody.children.length; i++) // element 0 is dummy!!!
				mayAddClass(tbody.children[i], 'row-selected');
		}

		function clearAllSelections() {
			let bodies = document.getElementsByTagName('TBODY');

			for (let body of bodies)
				clearSelection(body);

			shiftAnchor = null;
		}

		function markAsSelected(row) {

			let body = row.parentElement;

			if (body && (body.getAttribute('delete') === 'true' || body.getAttribute('copy') === 'true' || body.getAttribute('paste') === 'true')) {

				if (!row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
					row.classList.add('row-selected');
			}
		}

		function unmarkAsSelected(row) {
			if (row.classList.contains('row-selected'))
				row.classList.remove('row-selected');
		}

		function toggleSelection(row) {

			if (!row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
				markAsSelected(row);
			else
				row.classList.remove('row-selected');
		}

		function addAddCallback(btn) {

			btn.addEventListener('click', () => {
				let body;
				if (btn.parentElement.tagName === 'TH')
					body = btn.parentElement.parentElement.parentElement.parentElement.getElementsByTagName('TBODY')[0];
				else body = btn.parentElement.getElementsByTagName('TBODY')[0];
				if (body)
					addNew(body);
			});
		}

		function addNew(body) {

			let node = performClone(body.children[0]);

			if (node) {

				const selectedRows = body.getElementsByClassName('row-selected');
				const row = selectedRows && selectedRows.length > 0 ? selectedRows[selectedRows.length - 1] : null;

				clearAllSelections();

				if (!row)
					body.appendChild(node);
				else
					row.after(node);

				node.classList.add('row-selected');

				handleSelect2Elements(node);
				updateFieldNames(body);
				updateNoRecordsMessage(body);
			}
		}

		function performClone(row) {

			let node = row.cloneNode(true);

			node.classList.remove("d-none");
			resetDisabled(node);

			addRowEvents(node);
			replaceIds(node);

			addDeleteButtonEvents(node);
			addCheckBoxEvents(node);

			return node;
		}

		function initRowElements(row) {
			row.classList.remove("d-none");
			resetDisabled(row);

			addRowEvents(row);
			replaceIds(row);

			addDeleteButtonEvents(row);
			addCheckBoxEvents(row);
			handleSelect2Elements(row);
		}

		function handleSelect2Elements(node) {

			let i = 0;
			const tableId = getParentTable(node).id;
			const selectOptionSet = editableGridSelectSources.get(tableId);

			for (let n of node.getElementsByTagName('select')) {

				const data = selectOptionSet[i].data;

				$(n).select2({
					ajax: {
						transport: function (params, onSuccessHandler) {

							if (params.data?.term) {

								const filteredData = [];
								const searchText = params.data.term.toUpperCase();

								for (const elem of data) {

									if (!elem.text || elem.text.toUpperCase().includes(searchText))
										filteredData[filteredData.length] = elem;
								}

								onSuccessHandler({ results: filteredData });
							}
							else {
								onSuccessHandler({ results: data });
							}
						},
					}
				});
				i++;
			}

			let select2Containers = node.getElementsByClassName('select2');
			for (let n of select2Containers)
				n.setAttribute('style', null);

			let toDelete = node.getElementsByClassName('select2-container--bootstrap4');
			for (let n of toDelete)
				n.parentElement.removeChild(n);

			for (let n of select2Containers) {

				n.classList.remove('select2-container--below')
				n.classList.remove('select2-container--focus')
				n.setAttribute('style', null);

				mayAddClass(n, 'select2-container--bootstrap4');
				mayAddClass(n, 'select2-container--default');
			}
		}

		function mayAddClass(elem, cl) {
			if (!elem.classList.contains(cl))
				elem.classList.add(cl);
		}

		function addDeleteButtonEvents(node) {
			for (let delBtn of node.getElementsByClassName('editable-grid-delete-button')) {
				addDeleteCallback(delBtn);
			}
		}

		function resetDisabled(node) {

			for (let input of node.getElementsByTagName('input')) {
				input.removeAttribute('disabled');
			}

			for (let sel of node.getElementsByTagName('select')) {
				sel.removeAttribute('disabled');
			}
		}

		function addCheckBoxEvents(node) {
			let fields = node.getElementsByClassName('wv-field-checkbox');
			for (let field of fields) {
				let inputs = field.getElementsByTagName('input');
				let hidden = inputs[0];
				let visible = inputs[1];

				visible.addEventListener('change', () => {
					hidden.value = visible.checked.toString();
				});
			}
		}

		function addRowEvents(row) {

			if (!row.classList.contains('d-none') && !row.getElementsByClassName('alert-info')[0]) {

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

			let row = getParentTableRow(btn);

			if (row && !row.classList.contains('d-none')) {

				btn.addEventListener('click', () => {

					clearAllSelections();
					let row = getParentTableRow(btn);
					if (row?.parentElement) {

						let body = row.parentElement;
						body.removeChild(row);
						updateFieldNames(body);
						updateNoRecordsMessage(body);
					}
				});
			}
		}

		function getParentTableRow(elem) {
			return getParentByTagName(elem, 'TR');
		}

		function getParentTable(elem) {
			return getParentByTagName(elem, 'TABLE');
		}

		function getParentByTagName(elem, tagName) {
			let it = elem;
			while (it && it.tagName !== tagName) {
				it = it.parentElement;
			}
			return it;
		}

		function replaceIds(elem) {

			let labels = elem.getElementsByTagName('label');

			let labelForIds = new Map();

			for (let label of labels) {

				if (label.id) {
					let newId = makeNewId(label.id);
					if (newId)
						label.id = newId;
				}

				if (label.htmlFor) {

					let newId = makeNewId(label.htmlFor);
					if (newId) {
						labelForIds.set(label.htmlFor, newId);
						labelForIds.htmlFor = newId;
					}
				}
			}

			let all = elem.getElementsByTagName('*');
			let replacedIds = new Map();

			for (let e of all) {

				if (e.id && e.tagName !== 'label') {

					let newId = labelForIds.get(e.id);
					if (!newId)
						newId = replacedIds.get(e.id);

					if (newId)
						e.id = newId;
					else {
						newId = makeNewId(e.id);
						if (newId) {
							replacedIds.set(e.id, newId);
							e.id = newId;
						}
					}
				}
			}
		}

		function makeNewId(id) {
			let uuidRegex = /[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}/;
			let match = uuidRegex.exec(id);

			if (usedIds.has(id))
				usedIds.delete(id);

			if (!match) {
				do {
					id = generateUUID();
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


}

//////////////////////////////////////////////////////////////////////////////////
/// You code is above
	