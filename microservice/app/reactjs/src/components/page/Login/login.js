/* eslint-disable jsx-a11y/img-redundant-alt */
import React from 'react';
import { connect } from 'react-redux';
import loginAction from '../../../redux-saga/action/Login/loginAction'
import { bindActionCreators } from 'redux';
import { withTranslation } from 'react-i18next';

import { mgCookiesHelper } from '../../../shared/utils/MESCookiesHelper';
import { CookiesType } from "../../../shared/constants/enum/constants";
import "../../../shared/scss/page/login/login.scss";

class Login extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      userLogin: {
        username: '',
        password: ''
      }
    };
  }


  static getDerivedStateFromProps(nextProps, prevState) {
    // 123
    let { redecersLogin } = nextProps;
    if (redecersLogin.isCallApiLogin == true && redecersLogin.userInfo != null) {
      mgCookiesHelper.set(CookiesType.mes_login_app, JSON.stringify(redecersLogin.userInfo), 30);
      window.location.href = "/";
      // nextProps.history.push('/');
      // nextProps.loginAction.updateDefaultData();
    }
    return null;
  }


  handleInputChange(e) {
    let { userLogin } = this.state;
    let value = e.target.value;
    let name = e.target.name;

    userLogin[name] = value;
    this.setState({ userLogin });
  }

  handleSubmit() {
    let { userLogin } = this.state;
    this.props.loginAction.login_saga(userLogin);
  }

  render() {
    let { userLogin } = this.state;
    return (
      <div className="login-main">
        <section className="vh-100">
          <div className="container-fluid h-custom">
            <div className="row d-flex justify-content-center align-items-center h-100">
              <div className="col-md-9 col-lg-6 col-xl-5">
                <img
                  src="https://mdbootstrap.com/img/Photos/new-templates/bootstrap-login-form/draw2.png" className="img-fluid"
                  alt="Sample image" />
              </div>
              <div className="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                <form>
                  <div className="form-outline mb-4">
                    <input
                      autoComplete="off" type="email" name="username"
                      onChange={this.handleInputChange.bind(this)}
                      value={userLogin.username}
                      id="form3Example3" className="form-control form-control-lg"
                      placeholder="Enter a valid email address" />
                    <label className="form-label" htmlFor="form3Example3">Email address</label>
                  </div>

                  <div className="form-outline mb-3">
                    <input
                      name="password"
                      onChange={this.handleInputChange.bind(this)}
                      value={userLogin.password}
                      type="password" id="form3Example4" className="form-control form-control-lg"
                      placeholder="Enter password" />
                    <label className="form-label" htmlFor="form3Example4">Password</label>
                  </div>

                  <div className="d-flex justify-content-between align-items-center">
                    <div className="form-check mb-0">
                      <input className="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
                      <label className="form-check-label" htmlFor="form2Example3">
                        Remember me
                      </label>
                    </div>
                    <a href="#!" className="text-body">Forgot password?</a>
                  </div>

                  <div className="text-center text-lg-start mt-4 pt-2">
                    <button
                      onClick={this.handleSubmit.bind(this)}
                      type="button" className="btn btn-primary btn-lg"
                      style={{ paddingLeft: '2.5rem', paddingRight: "2.5rem" }}
                    >Login</button>
                    <p className="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a
                      href="#!"
                      className="link-danger">Register</a></p>
                  </div>

                </form>
              </div>
            </div>
          </div>
          <div className="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">
            <div className="text-white mb-3 mb-md-0">
              Copyright © 2020. All rights reserved.
            </div>

            <div>
              <a href="#!" className="text-white me-4">
                <i className="fab fa-facebook-f" />
              </a>
              <a href="#!" className="text-white me-4">
                <i className="fab fa-twitter" />
              </a>
              <a href="#!" className="text-white me-4">
                <i className="fab fa-google" />
              </a>
              <a href="#!" className="text-white">
                <i className="fab fa-linkedin-in" />
              </a>
            </div>
          </div>
        </section>

      </div>

    );
  }
}

const mapDispatchToProps = dispatch => ({
  loginAction: bindActionCreators(loginAction, dispatch)
})

const mapStateToProps = state => {
  return {
    redecersLogin: {
      authenticated: state.loginReducer.authenticated,
      userInfo: state.loginReducer.userInfo,
      isCallApiLogin: state.loginReducer.isCallApiLogin
    }
  }
};
export default connect(mapStateToProps, mapDispatchToProps)(withTranslation()(Login));
