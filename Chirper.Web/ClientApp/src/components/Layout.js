import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
    displayName = Layout.name

    render() {
        return (
            <Grid fluid>
                <NavMenu />
                <Row>
                    <Col sm={3}>
                    </Col>
                    <Col sm={9}>
                        {this.props.children}
                    </Col>
                </Row>
            </Grid>
        );
    }
}
