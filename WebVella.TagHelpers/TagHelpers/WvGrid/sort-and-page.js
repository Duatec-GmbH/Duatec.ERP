function ErpListChangePage(queryName, queryValue) {
	var currentUrl = getUrl();
	var uri = new URI(currentUrl).setSearch(queryName, queryValue);
	window.location = uri;
}

function getUrl() {
	let url = window.location.href;

	const scrollPosIdx = url.indexOf('scrollPos=');
	const returnUrlIdx = url.indexOf('returnUrl=');

	if (scrollPosIdx >= 0 && (scrollPosIdx < returnUrlIdx || returnUrlIdx < 0)) {

		const nextArgIdx = url.indexOf('&', scrollPosIdx);
		if (nextArgIdx < 0)
			url = url.substring(0, scrollPosIdx - 1);
		else
			url = url.substring(0, scrollPosIdx) + url.substring(nextArgIdx + 1)
	}

	return url;
}

function ErpListPagerInputSubmit(elementId, queryName) {
	$("#" + elementId).keypress(function (e) {
		if (e.which === 13) {
			var queryValue = $(this).val();
			ErpListChangePage(queryName, queryValue);
		}
	});
}

var sortOrder = [null, "asc", "desc"];

function getNextSort(currentOrder) {
	switch (currentOrder) {
		case "asc":
			return sortOrder[2];
		case "desc":
			return sortOrder[0];
		default:
			return sortOrder[1];
	}
}

function ErpListSortInit(listId, sortByQueryName, sortOrderQueryName) {
	$("#"+listId + " a.sort-link").on("click", function ($event) {
		$event.preventDefault();
		$event.stopPropagation();
		//Init
		var currentUrl = window.location.href;
		var uri = new URI(currentUrl);
		var q = uri.search(true);
		var currentSortByValue = q[sortByQueryName];
		if (Array.isArray(currentSortByValue)) { return currentSortByValue = currentSortByValue[0]; }
		var currentSortOrderValue = q[sortOrderQueryName];
		if (Array.isArray(currentSortOrderValue)) { return currentSortOrderValue = currentSortOrderValue[0]; }
		var newSortByValue = null;
		var newSortOrderValue = null;
		var clickedDataName = $(this).attr("data-dataname");

		//Logic
		//New field clicked
		if (currentSortByValue !== clickedDataName) {
			newSortByValue = clickedDataName;
			newSortOrderValue = getNextSort("");
		}
		//Old field clicked
		else {
			newSortByValue = clickedDataName;
			newSortOrderValue = getNextSort(currentSortOrderValue);
		}

		if (newSortByValue === null) {
			uri = uri.removeSearch(sortByQueryName);
		}
		else {
			uri = uri.setSearch(sortByQueryName, newSortByValue);
		}

		if (newSortOrderValue === null) {
			uri = uri.removeSearch(sortOrderQueryName).removeSearch(sortByQueryName); // both sort queries should be removed
		}
		else {
			uri = uri.setSearch(sortOrderQueryName, newSortOrderValue);
		}

		window.location = uri;
	});
}
