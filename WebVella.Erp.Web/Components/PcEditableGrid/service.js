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

	if (documentProcessed !== true) {

		documentProcessed = true;

		document.addEventListener('keydown', e => {

			if (e.key == 'c') {
				if (e.ctrlKey && !cDown) {
					// perform copy
				}
				cDown = true;
			}
			if (e.key == 'v') {
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

				clearAllSelections();

				const body = btn.parentElement.getElementsByTagName('TBODY')[0];

				deleteScripts(body);

				// dummy node which is not visible
				const node = body.children[0].cloneNode(true);

				node.classList.remove("d-none");
				body.appendChild(node);
				addRowEvents(node);
				replaceIds(node);

				addDeleteButtonEvets(node);
				handleSelect2Elements(node);

			});
		}
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

	function getParentTableRow(btn) {

		let it = btn;
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
	