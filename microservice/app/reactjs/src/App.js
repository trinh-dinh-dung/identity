import { Skeleton } from "antd";
import React, { lazy, Suspense } from "react";
import { withTranslation } from "react-i18next";
import { connect } from "react-redux";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { bindActionCreators } from "redux";
import DefaultRoute from "../src/components/layout/routes/default-route";
import PrivateRoute from "../src/components/layout/routes/private-route";
import PublicRoute from "../src/components/layout/routes/public-route";
import CommonBase from "../src/shared/common/base";
import StringUtils from "../src/shared/common/StringUtils";
import { compData } from './AppData';
import Layout from "./components/layout/layout-main";
import OidcProvider from "./components/layout/OidcProvider";
import loginAction from "./redux-saga/action/Login/loginAction";
import userManager, { loadUserFromStorage, signinRedirect } from "./shared/oidc-client-base/userService";
import "./shared/scss/App.scss";
import Chat from "./shared/signalr/Chat";
import { mgCookiesHelper } from "./shared/utils/MESCookiesHelper";
const Login = lazy(() => import("./components/page/Login/login"));
const SigninOidc = lazy(() => import("./components/page/Login/signin-oidc"));
const SignoutOidc = lazy(() => import("./components/page/Login/signout-oidc"));
const NotFoundPage = lazy(() => import("./components/page/NotFound/Index"));

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = { isLoading: false, authenticated: false, listNotificaltion: [], pathName: "" };
    window.mesGetNewAccessToken = this.mesGetNewAccessToken.bind(this);
  }

  async componentDidMount() {
    if (window.location.pathname != "/signin-oidc") {
      let user = await loadUserFromStorage();

      if (!user) {
        this.props.loginAction.unauthUser();
        signinRedirect();
      } else {
        this.props.loginAction.authUser(user);
      }
    }
    this.setLanguaue();
  }

  shouldComponentUpdate(nextProps, nextState) {
    let { authenticated } = nextProps.redecersLogin;
    if (authenticated != this.state.authenticated) {
      this.setState({ authenticated });
      return true;
    }
    return false;
  }

  setLanguaue() {
    let lang = mgCookiesHelper.get("language");
    if (StringUtils.isNullOrEmpty(lang)) {
      lang = "vi";
    }

    CommonBase.setLanguaueHeader(localStorage.getItem('lag') ?? 'vi');
  }

  async mesGetNewAccessToken() {
    let user = await userManager.signinSilent();
    if (!user) {
      this.props.loginAction.unauthUser();
      signinRedirect();
    } else {
      this.props.loginAction.authUser(user);
    }
  }
  render() {
    let { authenticated } = this.state;

    return this.state.isLoading ? (
      null
    ) : (
      <BrowserRouter>
        <OidcProvider userManager={userManager} />
        <Chat />
        <Switch>
          <DefaultRoute exact path="/" authenticated={authenticated} />
          <PublicRoute exact path="/login" RouteComp={Login} authenticated={authenticated} />
          <Route exact path="/signout-oidc" RouteComp={SignoutOidc} />
          <Route path="/signin-oidc" component={SigninOidc} />
          <Layout exact >
            <Suspense
              fallback={<Skeleton active />}
            >
              <Switch>
                {compData.map((comp, index) => {
                  return (<PrivateRoute key={index} exact path={comp.path} RouteComp={comp.compPath} authenticated={authenticated} />)
                })}
                <PrivateRoute exact RouteComp={NotFoundPage} authenticated={authenticated} />
              </Switch>
            </Suspense>
          </Layout>
        </Switch>

      </BrowserRouter>
    )
  }
}
const mapDispatchToProps = (dispatch) => ({
  loginAction: bindActionCreators(loginAction, dispatch),
});

const mapStateToProps = (state) => {
  return {
    redecersLogin: {
      authenticated: state.loginReducer.authenticated,
      userInfo: state.loginReducer.userInfo,
    },
  };
};
export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withTranslation()(App));

