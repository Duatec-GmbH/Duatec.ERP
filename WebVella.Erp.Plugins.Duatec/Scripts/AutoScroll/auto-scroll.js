// Scroll window to position
const scrollArgPos = window.location.href.indexOf('scrollPos=');
if (scrollArgPos >= 0) {

    const returnUrlArgPos = window.location.href.indexOf('returnUrl=');
    if (scrollArgPos < returnUrlArgPos || returnUrlArgPos < 0) {

        let pos;
        var nextArgIndex = window.location.href.indexOf('&', scrollArgPos);
        if (nextArgIndex < 0)
            pos = Number(window.location.href.substring(scrollArgPos + 'scrollPos='.length));
        else
            pos = Number(window.location.href.substring(scrollArgPos + 'scrollPos='.length, nextArgIndex));

        window.scrollTo(0, pos);
    }
}

// get base url (relative page url without parameters)
let baseUrl = window.location.href.substring(window.location.origin.length);
const queryStartIdx = baseUrl.indexOf('?');
if (queryStartIdx >= 0)
    baseUrl = baseUrl.substring(0, queryStartIdx);

const anchorTags = [];

// get anchor tags which return again to this page
for (let anchorTag of document.getElementsByTagName('a')) {

    if (anchorTag.href && anchorTag.href.startsWith(window.location.origin) && !anchorTag.classList.contains('btn-back')) {

        const relativePath = anchorTag.href.substring(window.location.origin.length);
        const appName = relativePath.substring(1, relativePath.indexOf('/', 1));

        if (appName && appName.length && appName !== '/' && appName !== 'sdk') {

            var returnUrlIdx = anchorTag.href.indexOf('returnUrl=');
            if (returnUrlIdx >= 0 && anchorTag.href.indexOf(baseUrl, returnUrlIdx) >= 0) {
                anchorTags[anchorTags.length] = anchorTag;
            }
        }
    }
}

if (anchorTags.length) {

    // add listener to update the url at each anchor tag
    document.addEventListener('scroll', (e) => {

        const pos = document.documentElement.scrollTop;

        for (let anchorTag of anchorTags) {
            const returnUrlString = 'returnUrl=';
            let idx = anchorTag.href.indexOf(returnUrlString);

            if (idx > 0) {

                idx += returnUrlString.length;
                let returnUrl = anchorTag.href.substring(idx);

                if (returnUrl) {

                    const start = anchorTag.href.substring(0, idx);
                    const queryStartIdx = returnUrl.indexOf('?');

                    if (queryStartIdx < 0) {
                        returnUrl += '?scrollPos=' + pos;
                    }
                    else {
                        let argIdx = returnUrl.indexOf('scrollPos=');
                        const returnUrlIdx = returnUrl.indexOf('returnUrl=');

                        if (argIdx < 0 || returnUrlIdx >= 0 && argIdx >= returnUrlIdx) {

                            idx = returnUrl.indexOf('?');
                            returnUrl = returnUrl.substring(0, idx + 1) + 'scrollPos=' + pos + '&' + returnUrl.substring(idx + 1);
                        }
                        else {

                            const nextArgIdx = returnUrl.indexOf('&', argIdx);

                            if (nextArgIdx < 0) {
                                returnUrl = returnUrl.substring(0, argIdx) + 'scrollPos=' + pos;
                            }
                            else {
                                returnUrl = returnUrl.substring(0, argIdx) + 'scrollPos=' + pos + returnUrl.substring(nextArgIdx);
                            }
                        }
                    }
                    anchorTag.href = start + returnUrl;
                }
            }
        }
    });
}