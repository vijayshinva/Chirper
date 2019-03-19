import React, { Component } from 'react';
import { Panel} from 'react-bootstrap';
import { TimeLine } from './TimeLine'
import { ChirpBox } from './ChirpBox'

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
    }
    
    render() {
        return (
            <div>
                <Panel>
                    <ChirpBox></ChirpBox>
                </Panel>
                <Panel>
                    <TimeLine></TimeLine>
                </Panel>
            </div>
        );
    }
}
