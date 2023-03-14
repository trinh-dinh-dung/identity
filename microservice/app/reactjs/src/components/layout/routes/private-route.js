import React from 'react';
import { connect } from "react-redux";
import { Route } from 'react-router-dom';
import { bindActionCreators } from "redux";
import loginAction from "src/redux-saga/action/Login/loginAction";
import { loadUserFromStorage, signinRedirect } from "src/shared/oidc-client-base/userService";


class PrivateRoute extends React.Component {
    async componentDidMount() {
        if (window.location.pathname != "/signin-oidc") {
            let user = await loadUserFromStorage();
            if (!user) {
                this.props.loginAction.unauthUser();
                signinRedirect();
            }
        }
        this.props.loginAction.updateSitePage(this.props.path);
    }

    render() {
        const { RouteComp, authenticated, ...rest } = this.props;
        return (
            <div id="container-app" className="container container-app">
                <div className="main-body">
                    <Route
                        {...rest}
                        render={props =>
                            typeof authenticated === "undefined" || authenticated === false
                                ? null
                                : <RouteComp {...props} />
                        }
                    />
                </div>
            </div>
        )
    }
}

const mapDispatchToProps = (dispatch) => ({
    loginAction: bindActionCreators(loginAction, dispatch),
});

export default connect(null, mapDispatchToProps)(PrivateRoute);

