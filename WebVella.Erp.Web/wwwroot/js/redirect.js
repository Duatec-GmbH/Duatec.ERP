"use strict"

ExecuteRedirect(false);

window.addEventListener('load', () => {
	if (sessionStorage.getItem('redirect-script-executed') !== 'true')
		ExecuteRedirect(false);
});

window.addEventListener('pageshow', () => {
	if (sessionStorage.getItem('redirect-script-executed') !== 'true')
		ExecuteRedirect(true);
});

window.addEventListener('beforeunload', () => {

	sessionStorage.removeItem('initialized');
	sessionStorage.removeItem('redirect-script-executed');
});

function ExecuteRedirect(fromBfCache) {

	let isDuplicated = sessionStorage.getItem('initialized') === 'true';

	if (!isDuplicated) {

		let entry = performance.getEntriesByType("navigation").find(en => en.type === 'back_forward');

		if (fromBfCache || entry) {

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

			else if (fromBfCache || entry && entry.deliveryType === 'cache') {

				sessionStorage.removeItem('initialized');
				location.reload();
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
	sessionStorage.setItem('redirect-script-executed', 'true');
}