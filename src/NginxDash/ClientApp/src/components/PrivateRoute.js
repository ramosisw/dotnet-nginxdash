import { Redirect, Route } from "react-router-dom";
import React, { Component } from "react";
import { config } from '../config';
import queryString from 'query-string';

class PrivateRoute extends Component {
    /**
     *
     * @returns {*}
     */
    render() {
        const { component: Component, isAuthenticated, ...rest } = this.props;
        const queryValues = queryString.parse(this.props.location.search);
        return <Route {...rest} render={props => (
            /*isAuthenticated*/
            localStorage.getItem('user') && !queryValues.oauth ? (
                <Component {...rest} {...props} >
                    {props.children}
                </Component>
            ) : (
                    <Redirect to={config.homePath + '/login' + props.location.search} />
                )
        )
        } />;
    }
}

export default PrivateRoute;