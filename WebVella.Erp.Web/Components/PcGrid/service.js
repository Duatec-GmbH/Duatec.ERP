"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////

//function ColumnCountChange(e) {
//	var oldValue = e.target.getAttribute("data-old-value");
//	var value = e.target.value;
//	if (value.toString() !== oldValue.toString()) {
//		e.target.setAttribute("data-old-value",value);
//		$('#modal-component-options div[id^="section-column"]').addClass("d-none");
//		for (var i = 1; i <= value; i++) {
//			$('#modal-component-options #section-column'+ i).removeClass("d-none");
//		}	
//	}
//}

//	document.addEventListener("WvPbManager_Design_Loaded", function (event) {
//		if (event && event.payload && event.payload.component_name === "WebVella.Erp.Web.Components.PcGrid"){
//			console.log("WebVella.Erp.Web.Components.PcRecordList Design loaded");
//		}
//	});

//	document.addEventListener("WvPbManager_Design_Unloaded", function (event) {
//		if (event && event.payload && event.payload.component_name === "WebVella.Erp.Web.Components.PcGrid"){
//			console.log("WebVella.Erp.Web.Components.PcRecordList Design unloaded");
//		}
//	});
//document.addEventListener("WvPbManager_Options_Loaded", function (event) {
//	if (event && event.payload && event.payload.component_name === "WebVella.Erp.Web.Components.PcGrid"){
//		window.setTimeout(function () {
//			var visibleColumnsCount = document.querySelector('#modal-component-options .modal-body input[name="visible_columns"]');
//			visibleColumnsCount.setAttribute("data-old-value",visibleColumnsCount.value);
//			visibleColumnsCount.addEventListener("blur", ColumnCountChange);
//		},500);
//	}
//});

//document.addEventListener("WvPbManager_Options_Unloaded", function (event) {
//	if (event && event.payload && event.payload.component_name === "WebVella.Erp.Web.Components.PcGrid"){
//	console.log("WebVella.Erp.Web.Components.PcGrid UnLoad");
//		var visibleColumnsCount = document.querySelector('#modal-component-options .modal-body input[name="visible_columns"]');
//		visibleColumnsCount.removeEventListener("blur", ColumnCountChange);
//	}
//});

{
	let mouseOverRow = null;
	let shiftAnchor = null;
	let cDown = false;

	let documentProcessed;
	let grids = getGrids();

	if (documentProcessed !== true && grids.some()) {

		documentProcessed = true;

		for (let grid of grids) {

			for (let row of grid.getElementsByTagName('TR')) {

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

		document.addEventListener('DOMContentLoaded', () => {

			document.addEventListener('keyup', e => {
				if (e.key == 'c') cDown = false;
			});

			document.addEventListener('keydown', e => {

				if (e.key == 'Escape') {
					clearAllSelections();
				}
				else if (e.key == 'c') {
					if (e.ctrlKey && !cDown) {
						let body = getTargetBody();
						if (body && body.getAttribute('copy') === 'true')
							putDataToClipboard(body);
					}
					cDown = true;
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

	function getBool(checkBoxField) {
		let inputs = checkBoxField.getElementsByTagName('input');
		for (let input of inputs) {
			if (input.hasAttribute('data-source-id'))
				return input.value;
		}
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

	function getNumber(numberField) {
		let input = numberField.getElementsByTagName('input')[0];
		return input.value;
	}

	function getSelectId(selectField) {
		return selectField.getElementsByTagName('select')[0].value;
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
					data: Array.from(map.entries())
				};

				return navigator.clipboard.writeText(JSON.stringify(obj));
			}
		}
		return null;
	}

	function getTargetBody() {
		let tables = getGrids();
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

	function getGrids() {
		let allTables = document.getElementsByTagName('table');
		let tables = [];

		for (let table of allTables) {
			if (!table.classList.contains('editable-grid')
				&& table.parentElement.classList.contains('erp-list')
				&& table.parentElement.getAttribute('copy') === 'true') {

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
}


	//////////////////////////////////////////////////////////////////////////////////
	/// You code is above
	