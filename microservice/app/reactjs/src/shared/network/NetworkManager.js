import StringUtils from "../common/StringUtils";

function handleErrors(response) {
    if (response.status != 200) {
        throw Error(response.statusText);
    }
    return response.json();
}

export function exeGet(urlApi, parrams, accessToken, callbackbeforeSend) {
    //parrams is array will contain key and value
    return new Promise((resolve, reject) => {
        if (parrams != null) {
            for (var i = 0; i < parrams.length; i++) {
                let parKey = parrams[i].Key
                let parValue = parrams[i].Value
                if (i === 0) {
                    urlApi = urlApi + "?" + parKey + "=" + parValue;
                } else {
                    urlApi = urlApi + "&" + parKey + "=" + parValue;
                }
            }
        }
        let headers = {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        };
        console.log("exeGet - urlApi:" + urlApi);
        if (StringUtils.isNullOrEmpty(accessToken)) {
            console.log('exePost-accessToken is null');
        } else {
            headers['Authorization'] = `Bearer ${accessToken}`;
        }

        if (callbackbeforeSend) {
            callbackbeforeSend();
        }

        fetch(urlApi, {
            method: 'GET',
            headers: headers
        }).then(handleErrors).then(
            (result) => {
                resolve(result);
                console.log(result);
            },
            (error) => {
                console.log("error");

                reject(error);
            }
        ).catch(function (error) {
            console.log("error");

            reject(error);
        });
    });
}

export function exeGetV2(urlApi, parrams, accessToken, callbackbeforeSend) {
    //parrams is array will contain key and value
    return new Promise((resolve, reject) => {
        if (parrams != null) {
            for (var i = 0; i < parrams.length; i++) {
                let parKey = parrams[i].Key
                let parValue = parrams[i].Value
                if (i === 0) {
                    urlApi = urlApi + "?" + parKey + "=" + parValue;
                } else {
                    urlApi = urlApi + "&" + parKey + "=" + parValue;
                }
            }
        }
        //sample 
        let headers = {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        }
        console.log("exeGet - urlApi:" + urlApi);
        if (StringUtils.isNullOrEmpty(accessToken)) {
            console.log('exePost-accessToken is null');
        } else {
            headers['Authorization'] = `Bearer ${accessToken}`;

        }

        if (callbackbeforeSend) {
            callbackbeforeSend();
        }

        fetch(urlApi, {
            mode: 'no-cors',
            method: 'GET',
            headers: headers
        }).then(handleErrors).then(
            (result) => {
                resolve(result);
            },
            (error) => {
                console.log("error");

                reject(error);
            }
        ).catch(function (error) {
            console.log("error");

            reject(error);
        });
    });
}

export function exePostFormData(urlApi, jsonBody, accessToken, callbackbeforeSend) {
    return new Promise((resolve, reject) => {
        console.log("exePost - urlApi:" + urlApi)
        console.log('jsonBody');
        console.log(new URLSearchParams(jsonBody).toString());
        console.log(jsonBody);
        console.log(JSON.stringify(jsonBody));

        let headers = {
            'Content-Type': 'application/x-www-form-urlencoded'
        };
        if (StringUtils.isNullOrEmpty(accessToken)) {
            console.log('exePost-accessToken is null');
        } else {
            headers['Authorization'] = `Bearer ${accessToken}`;
        }

        if (callbackbeforeSend) {
            callbackbeforeSend();
        }

        fetch(urlApi, {
            method: 'POST',
            headers: headers,
            body: jsonBody != null ? new URLSearchParams(jsonBody).toString() : "",
        }).then(handleErrors).then(
            (result) => {
                resolve(result);
            },
            (error) => {
                console.log("error");

                reject(error);
            }
        ).catch(function (error) {
            console.log("error");

            reject(error);
        });
    });
}

export function exePost(urlApi, jsonBody, accessToken, callbackbeforeSend) {
    return new Promise((resolve, reject) => {
        console.log("exePost - urlApi:" + urlApi)
        console.log('jsonBody');
        console.log(new URLSearchParams(jsonBody).toString());
        console.log(jsonBody);
        console.log(JSON.stringify(jsonBody));

        let headers = {
            'Content-Type': 'application/json'
        };
        if (StringUtils.isNullOrEmpty(accessToken)) {
            console.log('exePost-accessToken is null');
        } else {
            headers['Authorization'] = `Bearer ${accessToken}`;
        }

        if (callbackbeforeSend) {
            callbackbeforeSend();
        }

        fetch(urlApi, {
            method: 'POST',
            headers: headers,
            body: jsonBody != null ? JSON.stringify(jsonBody) : "",
        }).then(handleErrors).then(
            (result) => {
                resolve(result);
            },
            (error) => {
                console.log("error");

                reject(error);
            }
        ).catch(function (error) {
            console.log("error");

            reject(error);
        });
    });
}

export async function exePostGetAccessToken(urlApi, jsonBody, callbackbeforeSend) {
    console.log("exePost - urlApi:" + urlApi)
    console.log('jsonBody');
    console.log(jsonBody);

    if (callbackbeforeSend) {
        callbackbeforeSend();
    }
    try {
        let response = await fetch(urlApi, {
            method: 'POST',
            headers: new Headers({
                'Content-Type': 'application/x-www-form-urlencoded',
            }),
            body: jsonBody != null ? new URLSearchParams(jsonBody).toString() : "",
        });
        const json = await response.json();
        console.log(json);
        return Promise.resolve(json)
    } catch (error) {
        console.log("exePostAccessToken error");

        return Promise.reject(error)
    }
}