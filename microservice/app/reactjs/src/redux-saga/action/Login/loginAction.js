import * as types from "../../utils/enum/ActionTypeEnums";

const loginAction = {
    login_saga: request => {
        return {
            type: types.LOGIN_SAGA,
            request: request
        }
    },
    login_reducer: response => {
        return {
            type: types.LOGIN_REDUCER,
            response: response
        }
    },
    authUser: request => {
        return {
            type: types.AUTH_USER,
            request: request
        }
    },
    unauthUser: () => {
        return {
            type: types.UN_AUTH_USER,
        }
    },
    updateDefaultData: () => {
        return {
            type: types.UPDATE_DEFAULT_API
        }
    },
    updateSitePage: (site) => {
        return {
            type: types.UPDATE_MENU_PAGES,
            site
        }
    }

}

export default loginAction;