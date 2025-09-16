"use strict"

window.addEventListener('beforeunload', () => {

	sessionStorage.removeItem('initialized');
});

let isDuplicated = sessionStorage.getItem('initialized') === 'true';

if (!isDuplicated) {

	let performanceEntries = performance.getEntriesByType("navigation");

	if (performanceEntries.length > 0) {

		for (let entry of performanceEntries) {

			if (entry.type === 'back_forward') {

				const returnUrl = sessionStorage.getItem('returnUrl');
				const lastPage = sessionStorage.getItem('lastPage');


				if (lastPage === window.location.origin || lastPage === window.location.origin + '/') {

					sessionStorage.removeItem('initialized');
					location.replace(window.location.origin);
				}

				else if (returnUrl && returnUrl !== window.location.href) {

					sessionStorage.removeItem('initialized');
					location.replace(returnUrl);
				}

				else if (entry.deliveryType === 'cache') {

					sessionStorage.removeItem('initialized');
					location.reload();
				}

				break;
			}
		}

		// this disables the forward button
		history.pushState(null, null, window.location.href);
	}
}

sessionStorage.setItem('lastPage', window.location.href);

if (window.location.href.includes('returnUrl=')) {

	let returnUrl = window.location.href.substring(window.location.href.indexOf('returnUrl=') + 'returnUrl='.length);
	returnUrl = window.location.origin + decodeURIComponent(returnUrl);

	sessionStorage.setItem('returnUrl', returnUrl);
}
else {
	sessionStorage.setItem('returnUrl', window.location.origin);
}

sessionStorage.setItem('initialized', 'true');