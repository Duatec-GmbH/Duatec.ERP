"use strict";

/// Your code goes below
///////////////////////////////////////////////////////////////////////////////////

const button = document.getElementById('_grid_add_entry_button');
const grid = document.getElementById('_editable_grid');

if (button && grid) {
	button.addEventListener('click', () => {
		console.log('add clicked');

		const body = grid.getElementsByTagName('tbody')[0]

		// dummy node which is not visible
		var node = body.children[0].cloneNode(true);
		node.classList.remove("d-none");

		body.appendChild(node);
	});
}


//////////////////////////////////////////////////////////////////////////////////
/// You code is above
	