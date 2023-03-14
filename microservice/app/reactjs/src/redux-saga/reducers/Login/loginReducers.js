import * as types from "../../utils/enum/ActionTypeEnums";
import { StatusLogin } from "../../../shared/constants/enum/constants";
import CommonBase from "../../../shared/common/base";


const loginReducer = (state = {
    isFetching: false,
    isFetchingMore: false,

    userInfo: null,
    authenticated: true,
    isCallApiLogin: false,
    sitePage: "",

}, action) => {
    state.isFetching = false;
    state.isFetchingMore = false;
    state.isCallApiLogin = false;


    switch (action.type) {
        case types.LOGIN_REDUCER:
            state.isCallApiLogin = true;
            switch (action.response.Status) {
                case StatusLogin.USER_LOGIN_SUCCESS:
                    state.userInfo = action.response.Data;
                    break;
                case StatusLogin.USER_LOGIN_NOT_EXITS:
                    break;
                default:
                    break;
            }
            return {
                ...state
            }

        case types.DELETE_USER_REDUCER:
            return {
                ...state
            }
        case types.SET_USER_INFO:
            return {
                ...state,
            }
        case types.AUTH_USER:
            state.userInfo = action.request;
            state.authenticated = true;
            CommonBase.setAuthHeader(action.request.access_token);
            return {
                ...state,
            }

        case types.UN_AUTH_USER:
            state.userInfo = null;
            state.authenticated = false;
            CommonBase.setAuthHeader(null);
            return {
                ...state,
            }
        case types.UPDATE_MENU_PAGES:
            state.sitePage = action.site;
            return {
                ...state,
            }

        case types.UPDATE_DEFAULT_API:
            return {
                ...state,
            }
        default:
            return state;
    }
}



export default loginReducer;