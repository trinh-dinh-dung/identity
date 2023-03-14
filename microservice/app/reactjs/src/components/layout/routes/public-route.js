import React from 'react';
import { Route, Redirect } from 'react-router-dom';

// eslint-disable-next-line react/prefer-stateless-function
class PublicRoute extends React.Component {

    render() {
        const { RouteComp, authenticated, path, ...rest } = this.props;
        const previousLocation = this.props.locatison;
        return (
            <Route
                {...rest}

                render={props =>
                    typeof authenticated === "undefined" || authenticated === false
                        ? <RouteComp {...props} />
                        : <Redirect to={previousLocation ? previousLocation : '/home'} />
                }
            />
        )
    }
}



export default PublicRoute