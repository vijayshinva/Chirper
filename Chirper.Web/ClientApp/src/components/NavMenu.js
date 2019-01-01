import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem, FormGroup, FormControl, NavDropdown, MenuItem, Button } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/'}>Chirper.Web</Link>
                    </Navbar.Brand>
                </Navbar.Header>
                <Nav>
                    <LinkContainer to={'/counter'}>
                        <NavItem>
                            <Glyphicon glyph='education' /> Moments
                        </NavItem>
                    </LinkContainer>
                </Nav>
                <Nav pullRight>
                    <Navbar.Form pullLeft>
                        <FormGroup>
                            <FormControl type="text" placeholder="Search" />
                        </FormGroup>{' '}<Glyphicon glyph='search' />
                        <Button type="submit">Submit</Button>
                    </Navbar.Form>
                    <NavDropdown eventKey={3} title="Log in" id="basic-nav-dropdown">
                        <MenuItem eventKey={3.1}>Action</MenuItem>
                        <MenuItem eventKey={3.2}>Another action</MenuItem>
                        <MenuItem eventKey={3.3}>Something else here</MenuItem>
                        <MenuItem divider />
                        <MenuItem eventKey={3.4}>Separated link</MenuItem>
                    </NavDropdown>
                </Nav>
            </Navbar>
    );
    }
}
