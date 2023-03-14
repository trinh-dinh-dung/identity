import React from 'react';
import { Route, Redirect } from 'react-router-dom';

// eslint-disable-next-line react/prefer-stateless-function
class PrivateRoute extends React.Component {
    render() {
        const { authenticated, ...rest } = this.props
        return (
            <Route
                {...rest}
                render={({ location }) =>
                    typeof authenticated === "undefined" || authenticated === false
                        ?
                        null
                        :
                        <Redirect to={{ pathname: "/trang-chu", state: { from: location } }} />
                }
            />
        )
    }
}

export default (PrivateRoute)