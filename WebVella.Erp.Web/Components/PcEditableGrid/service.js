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
	let shiftDown = false;

	// !!!!!!!! must be VAR otherwhise gets initialized for every editable grid
	var editableGridsInitialized;
	var editableGridSelectSources;

	if (editableGridsInitialized !== true) {

		var EditableGrid = {
			updateFieldNames: function (body) { updateFieldNames(body) },
			handleSelect2Elements: function (node) { handleSelect2Elements(node) },
			performClone: function (row) { return performClone(row); },
			getValue: function (cell) { return getValue(cell); },
			setValue: function (cell, value) { return setValue(cell, value); },
			updateSelectSource: function (tableId, selectName, data) { updateSelectSource(tableId, selectName, data) },
		};

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

					let container = select.parentElement.parentElement;

					// delete scripts to reduce node sice
					for (let j = container.children.length - 1; j >= 0; j--) {
						if (container.children[j].tagName === 'SCRIPT')
							container.removeChild(container.children[j]);
					}

					i++;
				}

				editableGridSelectSources.set(table.id, selectOptionSet);

				for (let i = 1; i < body.children.length; i++) { // first is dummy -> skip

					for (let select of body.children[i].getElementsByTagName('select')) {
						let container = select.parentElement.parentElement;

						// delete scripts to reduce node sice
						for (let j = container.children.length - 1; j >= 0; j--) {
							if (container.children[j].tagName === 'SCRIPT')
								container.removeChild(container.children[j]);
						}
					}

					initRowElements(body.children[i]);
				}

				updateNoRecordsMessage(body);
			}

			// initialize add entry buttons
			for (let addBtn of document.getElementsByClassName('editable-grid-add-entry-button')) {
				addAddCallback(addBtn);
			}

			document.addEventListener('keydown', async e => {

				if (e.key == 'Control') ctrlDown = true;

				if (e.key == 'Shift' && document.activeElement.tagName !== 'input') {

					for (let table of getEditableGridTables())
						table.classList.add('user-select-none');

					if (!shiftAnchor) {
						let elem = getActiveElement();
						if (elem && getParentTable(elem)?.classList.contains('editable-grid')) {
							shiftAnchor = getParentTableRow(elem);
						}
					}
				}

				if (e.key == 'Escape') {
					clearAllSelections();

					if (document.getElementsByClassName('select2-container--open').length == 0)
						document.activeElement.blur();
				}
				else if (e.key == 'Insert') {
					let body = getTargetBody();

					if (body && body.getAttribute('add') === 'true') {
						addNew(body);
					}
				}
				else if (e.key == 'Delete') {
					let body = getTargetBody();
					if (body && body.getAttribute('delete') === 'true') {

						let prevIdx = 0;
						let nextIdx = 0;

						// get prev row
						for (let i = body.children.length - 1; i > 0; i--) {
							let row = body.children[i];

							if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
								prevIdx = i - 1;
						}

						// get next row
						for (let i = 1; i < body.children.length; i++) {
							let row = body.children[i];

							if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
								nextIdx = i + 1;
						}

						let selected;
						if (nextIdx > 0 && nextIdx < body.children.length)
							selected = body.children[nextIdx];

						else if (prevIdx > 0)
							selected = body.children[prevIdx];
	
						let control = document.activeElement;
						if (control)
							control.blur();

						// delete rows
						for (let i = body.children.length - 1; i > 0; i--) {
							let row = body.children[i];
							if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
								body.removeChild(row);
						}

						if (selected) {
							markAsSelected(selected);
							setFocusAtControlInSameColumn(control, selected, body);
						}

						updateFieldNames(body);
						updateNoRecordsMessage(body);
					}
				}
				else if (e.key == 'c' || e.key == 'C') {
					if (e.ctrlKey && !cDown && !hasSomethingElseSelected()) {
						let body = getTargetBody();
						if (body && body.getAttribute('copy') === 'true')
							await putDataToClipboard(body);
					}
					cDown = true;
				}
				else if (e.key == 'a' || e.key == 'A') {
					if (e.ctrlKey && !aDown && !hasSomethingElseSelected()) {

						let body = getTargetBody();
						if (body) {
							selectAll(body);
							if (body.children.length > 1 && body.children[1].getElementsByClassName('alert').length === 0) {
								document.activeElement.blur();

								let control = getFirstControl(body.children[1]);
								setFocus(control);
							}

							e.preventDefault();
						}
					}				

					aDown = true;
				}
				else if (e.key == 'x' || e.key == 'X') {
					if (e.ctrlKey && !xDown && !hasSomethingElseSelected()) {
						let body = getTargetBody();
						if (body && body.getAttribute('delete') === 'true') {

							await putDataToClipboard(body);

							for (let i = body.children.length - 1; i > 0; i--) {

								let row = body.children[i];
								if (row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
									body.removeChild(row);
							}

							updateFieldNames(body);
							updateNoRecordsMessage(body);
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
								const tableId = getParentTable(body).id;

								const text = await navigator.clipboard.readText();
								try {
									let obj = JSON.parse(text);

									if (isCompatible(body, obj.compatibility)) {

										const selectOptionSet = editableGridSelectSources.get(tableId);
										const newNodes = obj.data.map(_ => performClone(body.children[0]));

										let n = row;
										for (let node of newNodes) {
											n.after(node);
											n = node;
										}

										const selectCellOffsets = [];
										let cnt = 0;

										for (let i = 0; i < body.children[0].children.length; i++) {

											selectCellOffsets[i] = cnt;
											cnt += body.children[0].children[i].getElementsByTagName('select').length;
										}

										for (let i = 0; i < obj.data.length; i++) {

											const rowNode = newNodes[i];
											const rowData = obj.data[i];

											let cellIdx = 0;

											for (const cell of rowNode.children) {

												const selects = cell.getElementsByTagName('select');

												for (let j = 0; j < selects.length; j++) {

													const select = selects[j];
													if (select.hasAttribute('name')) {

														const valueLookup = new Map(Object.entries(rowData));
														const value = valueLookup.get(select.getAttribute('name'));

														const emptyOption = document.createElement('option');
														select.appendChild(emptyOption);

														const textLookup = selectOptionSet[selectCellOffsets[cellIdx] + j].textLookup;
														const text = textLookup.get(value);

														if (text) {
															const selectedOption = document.createElement('option');
															selectedOption.value = value;
															selectedOption.text = text;
															select.appendChild(selectedOption);
														}
													}
												}

												cellIdx++;
											}

											setValue(rowNode, rowData);
											handleSelect2Elements(rowNode);
										}

										updateFieldNames(body);
										updateNoRecordsMessage(body);

										if (newNodes.length > 0) {

											clearAllSelections();
											for (let node of newNodes)
												node.classList.add('row-selected');

											let control = document.activeElement;

											if (control)
												control.blur();

											setFocusAtControlInSameColumn(control, newNodes[0], body);
										}
									}
								}
								catch (e) {
									updateFieldNames(body);
									updateNoRecordsMessage(body);
								}
								loader.classList.add('d-none');
							}
						}
					}
					vDown = true;
				}
				else if (e.key == 'Shift') {
					shiftDown = true;
				}
				else if (e.key == 'Tab') {


					if (document.activeElement) {

						let control;

						if (!shiftDown && document.activeElement.classList.contains('editable-grid-add-entry-button')) {

							let row = getParentTable(document.activeElement)?.getElementsByTagName('TBODY')[0]?.children[1];
							if (row) {
								control = getFirstControl(row);
							}
						}

						else {

							let cell = getParentByTagName(document.activeElement, 'TD');

							if (cell) {
								if (shiftDown)
									control = getPrevControl(cell);
								else
									control = getNextControl(cell);
							}
						}

						if (control) {

							let row = getParentTableRow(control);

							if (row) {
								clearAllSelections();
								markAsSelected(row);
							}

							if (control.classList.contains('select2-selection')) {

								let select = getParentByTagName(control, 'DIV')?.getElementsByTagName('select')[0];

								if (select) {
									document.activeElement.blur();

									$(select).select2('focus');

									e.preventDefault();
									e.stopPropagation();
								}
							}
						}
					}
				}
				else if (e.key == 'Enter') {

					let elem = document.activeElement;

					if (elem && getParentTable(elem) && elem.classList.contains('select2-selection') && document.getElementsByClassName('select2-container--open').length == 0) {

						let select = getParentByTagName(elem, 'DIV')?.getElementsByTagName('select')[0];

						if (select) {

							$(select).select2('focus');

							e.preventDefault();
							e.stopPropagation();
						}
					}
				}
				else if (e.key == 'ArrowDown' && document.getElementsByClassName('select2-container--open').length == 0) {

					let body = getTargetBody();
					if (body) {

						if (shiftDown && shiftAnchor) {

							let row;

							if (document.activeElement) {

								let parentRow = getParentTableRow(document.activeElement);
								if (parentRow && parentRow.parentElement === body)
									row = getNextRow(parentRow);
							}

							if (row) {
								let control = document.activeElement;
								control.blur();
								setFocusAtControlInSameColumn(control, row, body);
								selectBetween(shiftAnchor, row);
							}
						}
						else {

							let row;
							let elem = getActiveElement();

							if (!elem) {
								row = getFirstRow(body);
								if (shiftDown)
									shiftAnchor = row;
							}
							else {
								let parentRow = getParentTableRow(elem);

								if (parentRow?.parentElement === body)
									row = getNextRow(parentRow);
								else {
									row = getFirstRow(body);
									if (shiftDown)
										shiftAnchor = row;
								}
							}

							if (row) {

								if (!shiftDown) {
									clearAllSelections();
									markAsSelected(row);
								}
								else {

									if (!shiftAnchor)
										shiftAnchor = getPrevRow(row);

									selectBetween(shiftAnchor, row);
								}

								let control = document.activeElement;
								document.activeElement.blur();
								setFocusAtControlInSameColumn(control, row, body);
							}
						}

						e.preventDefault();
						e.stopPropagation();
					}
				}
				else if (e.key == 'ArrowUp' && document.getElementsByClassName('select2-container--open').length == 0) {

					let body = getTargetBody();
					if (body) {
						if (document.activeElement) {

							let parentRow = getParentTableRow(document.activeElement);

							if (parentRow && parentRow.parentElement === body) {

								let row = getPrevRow(parentRow);

								if (row) {

									if (shiftDown && shiftAnchor) {
										let control = document.activeElement;
										control.blur();
										setFocusAtControlInSameColumn(control, row, body);
										selectBetween(shiftAnchor, row);
									}
									else {

										if (!shiftDown) {
											clearAllSelections();
											markAsSelected(row);
										}
										else {

											if (!shiftAnchor)
												shiftAnchor = getNextRow(row);

											selectBetween(shiftAnchor, row);
										}

										let control = document.activeElement;
										document.activeElement.blur();
										setFocusAtControlInSameColumn(control, row, body);
									}
								}
							}
						}

						e.preventDefault();
						e.stopPropagation();
					}
				}

				else if (e.key == 'ArrowLeft' && document.getElementsByClassName('select2-container--open').length == 0) {

					if (document.activeElement) {

						let body = getTargetBody();
						let cell = getParentByTagName(document.activeElement, 'TD');

						if (body && cell && cell.parentElement?.parentElement === body) {

							let control = getPrevControl(cell);

							if (control && getParentTableRow(control)?.parentElement === body) {

								document.activeElement.blur();
								setFocus(control);

								let row = getParentTableRow(control);

								if (!shiftDown) {
									clearAllSelections();
									markAsSelected(row);
								}
								else {
									if (!shiftAnchor)
										shiftAnchor = getParentTableRow(control);
									selectBetween(row, shiftAnchor);
								}
							}
						}
					}
				}

				else if (e.key == 'ArrowRight' && document.getElementsByClassName('select2-container--open').length == 0) {

					if (getActiveElement()) {

						let body = getTargetBody();
						let cell = getParentByTagName(document.activeElement, 'TD');

						if (body && cell && cell.parentElement?.parentElement === body) {

							let control = getNextControl(cell);

							if (control && getParentTableRow(control)?.parentElement === body) {
								document.activeElement.blur();
								setFocus(control);

								let row = getParentTableRow(control);

								if (!shiftDown) {
									clearAllSelections();
									markAsSelected(row);
								}
								else {
									if (!shiftAnchor)
										shiftAnchor = getParentTableRow(control);
									selectBetween(row, shiftAnchor);
								}
							}
						}
					}
					else {
						let body = getTargetBody();

						if (body) {

							let row = getFirstRow(body);

							if (row) {
								let control = getFirstControl(row);

								if (control) {
									clearAllSelections();
									setFocus(control);
									row.classList.add('row-selected');

									if (!shiftAnchor && shiftDown)
										shiftAnchor = row;
								}
							}
						}
					}
				}
			});

			document.addEventListener('keyup', e => {

				if (e.key == 'c' || e.key == 'C') cDown = false;
				if (e.key == 'v' || e.key == 'V') vDown = false;
				if (e.key == 'x' || e.key == 'X') xDown = false;
				if (e.key == 'a' || e.key == 'A') aDown = false;
				if (e.key == 'Control') ctrlDown = false;
				if (e.key == 'Shift') {

					shiftDown = false;
					shiftAnchor = null;

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

					let setFirstFocused = true;

					if (document.activeElement) {

						if (getParentTableRow(document.activeElement) === mouseOverRow)
							setFirstFocused = false;
						else
							document.activeElement.blur();
					}

					if (setFirstFocused) {
						let control = getFirstControl(mouseOverRow);

						setFocus(control);
					}
				}
			}, true);

			loader.classList.add('d-none');
		});

		function getPrevRow(row) {

			row = row.previousElementSibling;

			while (row && row.classList.contains('d-none'))
				row = row.previousElementSibling;

			if (row && row.getElementsByClassName('alert').length > 0)
				row = null;

			return row;
		}

		function getNextRow(row) {

			row = row.nextElementSibling;

			while (row && row.classList.contains('d-none'))
				row = row.nextElementSibling;

			if (row && row.getElementsByClassName('alert').length > 0)
				row = null;

			return row;
		}

		function selectBetween(rowA, rowB) {
			if (!rowA || !rowB || getParentTable(rowA) !== getParentTable(rowB))
				return;

			let body = rowA.parentElement;
			if (body) {

				let mode = 'unmark';
				let switchCount = 0;

				if (rowA === rowB) {

					for (let elem of body.children)
						unmarkAsSelected(elem);

					if (!rowA.classList.contains('d-none'))
						markAsSelected(rowA);
				}
				else {
					for (let elem of body.children) {
						if (elem === rowA || elem === rowB) {

							if (mode === 'unmark')
								mode = 'mark';
							else
								mode = 'unmark';

							switchCount++;
						}

						if (mode === 'unmark' && switchCount !== 1)
							unmarkAsSelected(elem);
						else {
							if (switchCount === 1)
								switchCount = 0;

							if (!elem.classList.contains('d-none') && elem.getElementsByClassName('alert').length === 0)
								markAsSelected(elem);
						}
					}
				}
			}
		}

		function getFirstRow(body) {

			let row;

			if (body.children.length > 2 || body.children.length === 2 && body.children[1].getElementsByClassName('alert').length === 0)
				row = body.children[1];

			while (row && row.classList.contains('d-none'))
				row = row.nextElementSibling;

			return row;
		}

		function setFocusAtControlInSameColumn(control, row, body) {
			if (!control)
				setFocus(getFirstControl(row));


			let controlParentRow = getParentTableRow(control);

			if (!controlParentRow || controlParentRow.parentElement !== body)
				setFocus(getFirstControl(row));

			else {
				let colIdx = -1;

				for (let i = 0; i < controlParentRow.children.length; i++) {

					let controls = getControlsInCell(controlParentRow.children[i]);
					if (controls.indexOf(control) >= 0) {
						colIdx = i;
						break;
					}
				}

				if (colIdx < 0 || row.children.length <= colIdx)
					setFocus(getFirstControl(row));
				else {

					let controls = getControlsInCell(row.children[colIdx]);

					if (controls.length > 0)
						setFocus(controls[0]);
					else
						setFocus(getFirstControl(row));
				}
			}
		}

		function setFocus(control) {
			if (control) {

				if (control.classList.contains('select2-selection')) {

					let select = getParentByTagName(control, 'DIV')?.getElementsByTagName('select')[0];
					if (select) {
						$(select).select2('focus');
					}
				}
				else {
					control.focus();
				}
			}
		}

		function getControlColumnIndex(control) {

			if (!control)
				return -1;

			let row = getParentTableRow(control);

			if (!row)
				return -1;

			for (let i = 0; i < row.children.length; i++) {

				let controlsInCell = getControlsInCell(row.children[i]);

				if (controlsInCell.indexOf(control) >= 0)
					return i;
			}

			return -1;
		}

		function getPrevControl(cell) {

			let controlsInCell = getControlsInCell(cell);

			if (controlsInCell.length > 1) {

				if (!document.activeElement)
					return null;

				let index = controlsInCell.indexOf(document.activeElement);

				if (index < 0)
					return null;

				if (index > 0)
					return controlsInCell[index - 1];
			}

			cell = getPrevCell(cell);
			if (!cell)
				return null;

			controlsInCell = getControlsInCell(cell);

			if (controlsInCell.length === 0)
				return getPrevControl(cell);
			else
				return controlsInCell[controlsInCell.length - 1];
		}

		function getNextControl(cell) {	

			let controlsInCell = getControlsInCell(cell);

			if (controlsInCell.length > 1) {

				if (!document.activeElement)
					return null;

				let index = controlsInCell.indexOf(document.activeElement);

				if (index < 0)
					return null;

				if (index < controlsInCell.length - 1)
					return controlsInCell[index + 1];
			}

			cell = getNextCell(cell);
			if (!cell)
				return null;

			controlsInCell = getControlsInCell(cell);

			if (controlsInCell.length === 0)
				return getNextControl(cell);
			else
				return controlsInCell[0];
		}

		function getActiveElement() {

			if (!document.activeElement || document.activeElement.tagName === 'BODY')
				return null;

			return document.activeElement;
		}

		function getNextCell(cell) {

			let next = cell.nextElementSibling;
			if (next)
				return next;

			let row = getParentTableRow(cell)?.nextElementSibling;

			while (row && row.classList.contains('d-none')) {
				row = row.nextElementSibling;
			}

			return row?.firstElementChild ?? null;
		}

		function getPrevCell(cell) {

			let prev = cell.previousElementSibling;
			if (prev)
				return prev;

			let row = getParentTableRow(cell)?.previousElementSibling;

			while (row && row.classList.contains('d-none')) {
				row = row.previousElementSibling;
			}

			return row?.lastElementChild ?? null;
		}

		function getFirstControl(row) {

			for (let col of row.children) {

				let controls = getControlsInCell(col);
				if (controls.length > 0)
					return controls[0];
			}
			return null;
		}

		function getControlsInCell(cell) {

			if (cell.classList.contains('d-none') || cell.style.display === 'none')
				return [];

			const result = [];

			if (cell.tagName === 'INPUT' || cell.tagName === 'select')
				result[result.length] = cell;

			else if (cell.classList.contains('wv-field-select')) {

				let control = cell.getElementsByClassName('select2-selection')[0];
				if(control)
					result[result.length] = control;
			}

			else {
				for (let child of cell.children) {
					for (let elem of getControlsInCell(child))
						result[result.length] = elem;
				}
			}

			return result;
		}

		function updateSelectSource(tableId, selectName, data) {

			const table = document.getElementById(tableId);

			if (!table)
				throw new Error('Table with id \'' + tableId + '\' does not exist.');

			const selectOptionSet = editableGridSelectSources.get(tableId);

			if (!selectOptionSet)
				throw new Error('Table has no select sources.');

			const selects = table.getElementsByTagName('TBODY')[0].children[0].getElementsByTagName('select');
			let idx = -1;

			for (let i = 0; i < selects.length; i++) {

				if (selects[i].name === selectName) {
					idx = i;
					break;
				}
			}

			if (idx < 0)
				throw new Error('Select source with name \'' + selectName + '\' does not exist.');

			let textLookup = new Map();
			let valueLookup = new Map();

			for (let elem of data) {
				textLookup.set(elem.text, elem.id);
				valueLookup.set(elem.id, elem.text);
			}

			selectOptionSet[idx] = {
				textLookup: textLookup,
				data: data
			};

			for (let select of table.getElementsByTagName('select')) {
				if (select.name.includes(selectName + '[')) {

					let options = select.getElementsByTagName('option');

					for (var i = options.length - 1; i >= 0; i--) {

						const option = options[i];

						if (option.value && option.value !== select.value)
							option.parentElement.removeChild(option);
					}

					for (let option of select.getElementsByTagName('option')) {

						if (option.value && option.value === select.value) {

							const text = valueLookup.get(option.value);

							if (!text) {
								option.parentElement.removeChild(option);
								select.value = '';
							}
							else {
								option.text = text;

								var rendered = select.parentElement?.getElementsByClassName('select2-selection__rendered')[0];

								if (rendered)
									rendered.innerHTML = text;
							}
							break;
						}
					}
				}
			}
		}




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

		function setValue(col, value) {
			setValueOn(col, value, 'wv-field-number', setNumber);
			setValueOn(col, value, 'wv-field-text', setText);
			setValueOn(col, value, 'wv-field-checkbox', setBool);
			setValueOn(col, value, 'wv-field-select', setSelectId);
		}

		function setValueOn(col, value, className, setFunction) {

			for (const elem of col.getElementsByClassName(className)) {
				if (!elem.classList.contains('editable-grid-ignore')) {
					setFunction(elem, value);
				}
			}
		}

		function setNumber(numberField, value) {
			let input = numberField.getElementsByTagName('input')[0];
			if (input && input.hasAttribute('name')) {

				const name = valueName(input.getAttribute('name'));
				const v = value[name];

				if(v)
					input.value = v;
			}
		}

		function setText(textField, value) {
			let input = textField.getElementsByTagName('input')[0];
			if (input && input.hasAttribute('name')) {

				const name = valueName(input.getAttribute('name'));
				const v = value[name];

				if (v)
					input.value = v;
			}
		}

		function setBool(checkBoxField, value) {
			const inputs = checkBoxField.getElementsByTagName('input');
			const hidden = inputs[0];
			const visible = inputs[1];

			const name = valueName(hidden.getAttribute('name') ?? visible.getAttribute('name'));
			const v = value[name];

			if (v) {
				hidden.value = v;
				const b = v === 'true';
				visible.checked = b;
			}
		}

		function setSelectId(selectField, value) {
			const input = selectField.getElementsByTagName('select')[0];
			if (input && input.hasAttribute('name')) {

				const name = valueName(input.getAttribute('name'));
				const v = value[name];

				if (v)
					input.value = v;
			}
		}

		async function putDataToClipboard(body) {
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
						compatibility: body.getAttribute('compatibility'),
						data: data
					};

					await navigator.clipboard.writeText(JSON.stringify(obj));
				}
			}
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

			let idx = 0;

			for (let i = 1; i < body.children.length; i++) {

				if (body.children[i].classList.contains('row-selected'))
					idx = i;
			}

			if (idx > 0)
				return body.children[idx];

			if (mouseOverRow && mouseOverRow.parentElement === body)
				return mouseOverRow;

			return body.children[body.children.length - 1];
		}

		function getTargetBody() {
			let tables = getEditableGridTables();

			if (tables.length == 1)
				return tables[0].getElementsByTagName('tbody')[0];

			else if (document.activeElement && getParentTableRow(document.activeElement))
				return getParentTableRow(document.activeElement).parentElement;

			var rows = document.getElementsByClassName('row-selected');
			if (rows && rows.length > 0 && rows.every(r => r.parentElement === rows[0].parentElement)) {
				return rows[0].parentElement;
			}

			if (mouseOverRow)
				return mouseOverRow.parentElement;

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

			for (let i = 1; i < tbody.children.length; i++) { // element 0 is dummy!!!

				if (i !== 1 || tbody.children[i].getElementsByClassName('alert').length === 0)
					mayAddClass(tbody.children[i], 'row-selected');
			}
		}

		function clearAllSelections() {
			let bodies = document.getElementsByTagName('TBODY');

			for (let body of bodies)
				clearSelection(body);

			shiftAnchor = null;
		}

		function markAsSelected(row) {

			if (!row)
				return;

			let body = row.parentElement;

			if (body && (body.getAttribute('delete') === 'true' || body.getAttribute('copy') === 'true' || body.getAttribute('paste') === 'true')) {

				if (!row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
					row.classList.add('row-selected');
			}
		}

		function unmarkAsSelected(row) {
			if (!row)
				return;

			if (row.classList.contains('row-selected'))
				row.classList.remove('row-selected');
		}

		function toggleSelection(row) {

			if (!row)
				return;

			if (!row.classList.contains('row-selected') && !row.getElementsByClassName('alert-info')[0])
				markAsSelected(row);
			else
				row.classList.remove('row-selected');
		}

		function addAddCallback(btn) {

			if (!btn)
				return;

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

				markAsSelected(node);

				handleSelect2Elements(node);
				updateFieldNames(body);
				updateNoRecordsMessage(body);

				let control = getFirstControl(node);
				if (control)
					setFocus(control);
			}
		}

		function performClone(row) {

			let node = row.cloneNode(true);

			node.classList.remove("d-none");
			resetDisabled(node);

			addRowEvents(node);
			replaceIds(node);

			for (let btn of node.getElementsByClassName('editable-grid-delete-button'))
				btn.tabIndex = -1;

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

			for (let wrapper of row.getElementsByClassName('wv-field-select')) {

				if (wrapper.getElementsByClassName('invalid-feedback').length > 0) {

					let span = wrapper.getElementsByClassName('select2-container')[0];
					if (span)
						span.classList.add('is-invalid');
				}
			}
		}

		function handleSelect2Elements(node) {

			let i = 0;
			const tableId = getParentTable(node).id;
			const selectOptionSet = editableGridSelectSources.get(tableId);

			for (let n of node.getElementsByTagName('select')) {

				n.removeAttribute('data-select2-id');

				if (n.parentElement) {

					for (let j = n.parentElement.children.length - 1; j >= 0; j--) {

						let elem = n.parentElement.children[0];
						if (elem.classList.contains('select2'))
							elem.parentElement.removeChild(elem);

					}						
				}

				const idx = i;

				$(n).select2({
					ajax: {
						transport: function (params, onSuccessHandler) {

							if (params.data?.term) {

								const filteredData = [];
								const searchText = params.data.term.toUpperCase();

								for (const elem of selectOptionSet[idx].data) {

									if (!elem.text || elem.text.toUpperCase().includes(searchText))
										filteredData[filteredData.length] = elem;
								}

								onSuccessHandler({ results: filteredData });
							}
							else {
								onSuccessHandler({ results: selectOptionSet[idx].data });
							}
						},
					}
				});

				$(n).on('select2:close', function (e) {
					const select = getParentByTagName(this, 'DIV')?.getElementsByTagName('select')[0];
					if (select) {

						$(n).select2('focus');
						if (select.nextElementSibling)
							select.nextElementSibling.classList.remove('fake-focus');
					}
				});

				$(n).on('select2:opening', function (e) {
					const select = getParentByTagName(this, 'DIV')?.getElementsByTagName('select')[0];

					if (select && select.nextElementSibling)
						select.nextElementSibling.classList.add('fake-focus');
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

						let prev = row.previousElementSibling;
						let next = row.nextElementSibling;
						let body = row.parentElement;

						body.removeChild(row);
						updateFieldNames(body);
						updateNoRecordsMessage(body);

						if (next) {

							markAsSelected(next);

							let control = getFirstControl(next);
							setFocus(control);
						}

						else if (prev && !prev.classList.contains('d-none')) {

							markAsSelected(prev);

							let control = getFirstControl(prev);
							setFocus(control);
						}
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
	