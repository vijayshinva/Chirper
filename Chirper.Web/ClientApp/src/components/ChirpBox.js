import React, { Component } from 'react';
import { Glyphicon, Panel, FormControl, FormGroup, ControlLabel, HelpBlock } from 'react-bootstrap';

export class ChirpBox extends Component {
    displayName = ChirpBox.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.postTweet = this.postTweet.bind(this);

        this.state = {
            value: ''
        };
    }

    validateTweet() {
        const length = this.state.value.length;
        if (length > 10 && length <= 256) return 'success';
        else if (length < 10) return 'warning';
        else if (length > 256) return 'error';
        return null;
    }

    handleChange(e) {
        this.setState({ value: e.target.value });
    }

    postTweet() {
        fetch('http://localhost:55993/api/messages/1', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state.value)
        })
            .then(function (result) {
                console.log(result);
            })
            .catch(function (result) {
                console.log(result);
            })
    }

    render() {
        return (
            <div>
                <form>
                    <FormGroup controlId="frmTweet" validationState={this.validateTweet()}>
                        <FormControl type="textarea" value={this.state.value} placeholder="What's happening?" onChange={this.handleChange}>
                        </FormControl>
                        <FormControl.Feedback />
                    </FormGroup>
                    <button onClick={this.postTweet}>Post</button>
                </form>
            </div>
        );
    }
}