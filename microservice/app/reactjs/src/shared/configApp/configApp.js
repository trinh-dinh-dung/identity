let ENV_APP = process.env;
var configApp = {
    apiGateWay: '',
    apiUpload: '',
    apiSso: '',
    apiMaintainance: '',
    apiMaterial: '',
    apiSop: '',

    urlCdn: '',
    apiSocket: '',

    authority: "",
    client_id: "",
    client_secret: "",
    response_type: "",
    scope: "openid profile offline_access api_service",
    redirect_uri: "",
    post_logout_redirect_uri: "",
}
 

if (ENV_APP.REACT_APP_ENV == "localdev") {
    configApp.apiGateWay = 'https://localhost:44388';
    configApp.apiUpload = 'http://192.168.2.103:8082';
    configApp.apiSso = 'https://localhost:6789';
    configApp.apiMaintainance = 'https://localhost:44359';
    configApp.apiMaterial = 'https://localhost:44357';
    configApp.apiSop = 'https://localhost:44358';

    configApp.urlCdn = 'http://localhost:3000';
    configApp.apiSocket = 'http://192.168.2.103:8086';

    configApp.authority = "https://localhost:6789";
    configApp.client_id = "ReactApp";
    configApp.client_secret = "secret";
    configApp.response_type = "code";
    configApp.scope = "openid profile offline_access api_service";
    configApp.redirect_uri = "http://localhost:3000/signin-oidc";
    configApp.post_logout_redirect_uri = "http://localhost:3000/signout-oidc";
}

 
export default configApp;