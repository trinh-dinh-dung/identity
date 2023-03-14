import Cookies from 'js-cookie'
export const mgCookiesHelper = {

    set: function (key, value, expiresTime) {
        //Default: Cookie is removed when the user closes the browser.
        var endcodeValue = window.btoa(unescape(encodeURIComponent(value)));
        //expires in day
        Cookies.set(key, endcodeValue, { expires: expiresTime });
    },
    get: function (key) {
        var value = Cookies.get(key);
        try {
            value = decodeURIComponent(escape(window.atob(value)));
        } catch (err) {
        }
        return value;
    },
    remove: function (key) {
        Cookies.remove(key);
    },
    keys: {
        MG_ACCESS_TOKEN_PW_APP: "____mg_access_token_pw_app",
        PB_AMPLIFY_CONFIG_APP: "____pb_amplify_config_app",
        TRACKING_CONFIG_APP: "__tracking_config_app"
    },
    //https://developer.mozilla.org/en-US/docs/Web/API/Window/sessionStorage
    setSessionStorage: function (key, value) {
        if (typeof window.sessionStorage != 'undefined') {
            var endcodeValue = window.btoa(unescape(encodeURIComponent(value)));
            window.sessionStorage.setItem(key, endcodeValue);
        }
    },
    getSessionStorage: function (key) {
        if (typeof window.sessionStorage != 'undefined') {
            var value = window.sessionStorage.getItem(key);
            try {
                value = decodeURIComponent(escape(window.atob(value)));
            } catch (err) {
            }
            return value;
        }
        return null;
    },
    removeSessionStorage: function (key) {
        if (typeof window.sessionStorage != 'undefined') {
            window.sessionStorage.removeItem(key);
        }
    },
}