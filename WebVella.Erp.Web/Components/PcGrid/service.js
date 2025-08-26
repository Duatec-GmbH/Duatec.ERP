"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////

{
	let mouseOverRow = null;
	let shiftAnchor = null;
	let cDown = false;
	let ctrlDown = false;
	let aDown = false;

	let grids = getGrids();

	// !!!!!!! must be VAR otherwhise script runs more often
	var gridsInitialized;

	if (gridsInitialized !== true && grids.length > 0) {
		gridsInitialized = true;

		for (let grid of grids) {

			for (let row of grid.getElementsByTagName('TR')) {

				if (row.parentElement.tagName === 'TBODY') {
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
		}

		document.addEventListener('DOMContentLoaded', () => {

			document.addEventListener('keyup', async e => {

				if (e.key == 'c' || e.key == 'C') cDown = false;
				if (e.key == 'a' || e.key == 'A') aDown = false;
				if (e.key == 'Control') ctrlDown = false;

				if (e.key == 'Shift') {

					if (!ctrlDown) {
						for (let table of getGrids())
							table.classList.remove('user-select-none');

						if(mouseOverRow)
							document.getSelection().empty();
					}
				}
			});

			document.addEventListener('keydown', e => {

				if (e.key == 'Control')
					ctrlDown = true;

				if (e.key == 'Shift') {

					for (let table of getGrids())
						table.classList.add('user-select-none');
				}

				if (e.key == 'Escape') {
					clearAllSelections();
				}
				else if (e.key == 'c' || e.key == 'C') {
					if (e.ctrlKey && !cDown && !hasSomethingSelected()) {
						let body = getTargetBody();

						if (body)
							putDataToClipboard(body);
					}
					cDown = true;
				}
				else if (e.key == 'a' || e.key == 'A') {
					if (e.ctrlKey && !aDown && !hasSomethingSelected()) {
						let body = getTargetBody();

						if (body) {
							for (let row of body.children) {
								if (!row.classList.contains('row-selected'))
									row.classList.add('row-selected');
							}
							e.preventDefault();
						}
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

				if (e.ctrlKey || e.shiftKey)
					e.stopPropagation();


			}, true);
		});

	}

	function hasSomethingSelected() {
		return document.getSelection().toString().trim().length > 0;
	}

	function getValue(col) {

		const resultArr = [];

		appendValuesOf(resultArr, col, 'wv-field-number', getNumber);
		appendValuesOf(resultArr, col, 'wv-field-text', getText);
		appendValuesOf(resultArr, col, 'wv-field-checkbox', getBool);
		appendValuesOf(resultArr, col, 'wv-field-select', getSelectId);

		if (resultArr.length === 0)
			return null;

		return Object.fromEntries(resultArr.map(v => [v.name, v.value]));
	}

	function appendValuesOf(resultArr, col, className, getFunction) {

		for (const elem of col.getElementsByClassName(className)) {
			if (!elem.classList.contains('editable-grid-ignore')) {

				const val = getFunction(elem);
				if (val)
					resultArr[resultArr.length] = val;
			}
		}
	}

	function valueName(name) {
		if (!name)
			return '';

		const brackIdx = name.indexOf('[');
		if (brackIdx < 0)
			return name;

		return name.substring(0, brackIdx);
	}

	function getNumber(numberField) {
		let input = numberField.getElementsByTagName('input')[0];

		if (input && input.getAttribute('name'))
			return {
				name: valueName(input.getAttribute('name')),
				value: input.value
			};
	}

	function getText(textField) {
		let input = textField.getElementsByTagName('input')[0];
		if (input && input.getAttribute('name'))
			return {
				name: valueName(input.getAttribute('name')),
				value: input.value
			};
	}

	function getBool(checkBoxField) {
		let inputs = checkBoxField.getElementsByTagName('input');
		for (let input of inputs) {
			if (input.hasAttribute('data-source-id') && input.getAttribute('name'))
				return {
					name: valueName(input.getAttribute('name')),
					value: input.value
				};
		}
	}

	function getSelectId(selectField) {
		let select = selectField.getElementsByTagName('select')[0];
		if (select && select.getAttribute('name'))
			return {
				name: valueName(select.getAttribute('name')),
				value: select.value
			};
	}

	function getHeaders(body) {

		let headers = body.parentElement.getElementsByTagName('th');
		let result = [];

		for (let h of headers) {
			let val;

			// this should be name not data filter name....
			let name = h.getAttribute('data-filter-name');

			if (name && name.trim() != '')
				val = name.trim();

			if (val === undefined || val === null || val === '')
				result[result.length] = '';
			else
				result[result.length] = val;
		}
		return result;
	}

	function putDataToClipboard(body) {
		let rows = body.getElementsByClassName('row-selected');
		if (rows.length > 0) {

			const headers = getHeaders(body);

			if (headers.some(h => h)) {

				const skip = headers.map(h => h ? false : true);
				const data = [];

				for (let row of rows) {

					const rowData = [];

					for (let i = 0; i < headers.length; i++) {
						if (!skip[i]) {
							var cellData = getValue(row.children[i]);

							if (cellData) {
								for (let kp of Object.entries(cellData)) {
									rowData[rowData.length] = kp;
								}
							}
						}
					}

					data[data.length] = Object.fromEntries(rowData);
				}

				let obj = {
					compatibility: body.parentElement.getAttribute('compatibility'),
					data: data
				};

				navigator.clipboard.writeText(JSON.stringify(obj));
			}
		}
	}

	function getTargetBody() {
		let tables = getGrids();
		if (tables.length == 1) {
			return tables[0].getElementsByTagName('tbody')[0];
		}
		else if (mouseOverRow) {
			return mouseOverRow.parentElement;
		}

		let rows = document.getElementsByClassName('row-selected');
		if (rows && rows.length > 0 && rows.every(r => r.parentElement === rows[0].parentElement)) {
			return rows[0].parentElement;
		}
		return null;
	}

	function getGrids() {
		let allTables = document.getElementsByTagName('table');
		let tables = [];

		for (let table of allTables) {
			if (!table.classList.contains('editable-grid')
				&& table.parentElement.classList.contains('erp-list')
				&& table.getAttribute('copy') === 'true') {

				tables[tables.length] = table;
			}
		}
		return tables
	}

	function clearSelection(tbody) {
		for (let row of tbody.children)
			row.classList.remove('row-selected');
	}

	function clearAllSelections() {
		let bodies = document.getElementsByTagName('TBODY');

		for (let body of bodies)
			clearSelection(body);

		shiftAnchor = null;
	}

	function markAsSelected(row) {

		if (row.parentElement.tagName === 'TBODY') {
			if (!row.classList.contains('row-selected'))
				row.classList.add('row-selected');
		} 
	}

	function unmarkAsSelected(row) {
		if (row.classList.contains('row-selected'))
			row.classList.remove('row-selected');
	}

	function toggleSelection(row) {
		if (!row.classList.contains('row-selected'))
			markAsSelected(row);
		else
			row.classList.remove('row-selected');
	}
}


	//////////////////////////////////////////////////////////////////////////////////
	/// You code is above
	