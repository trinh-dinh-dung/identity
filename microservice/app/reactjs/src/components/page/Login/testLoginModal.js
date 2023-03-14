import React from 'react';

import "./../../scss/page/login/login.scss";

class LoginTest extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userLogin: {
                username: '',
                password: ''
            }
        };
    }


    render() {
        let _this = this;
        return (
            <div className='login-main'>
                test modal

            </div>

        );
    }
}


export default LoginTest;
