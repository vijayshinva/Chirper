import React, { Component } from 'react';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';

export class TimeLine extends Component {
    displayName = TimeLine.name

    constructor(props) {
        super(props);

        this.state = {
            value: ''
        };
    }

    componentDidMount = () => {
        const hubConnection = new HubConnectionBuilder()
            .withUrl("http://localhost:57579/chirphub")
            .configureLogging(LogLevel.Information)
            .build();
        hubConnection.on("ReceiveMessage", (user, message) => {
            const encodedMsg = user + " says " + message;
            const li = document.createElement("li");
            li.textContent = encodedMsg;
            document.getElementById("messagesList").appendChild(li);
        });
        hubConnection.start()
            .catch(function (err) {
                return console.error(err.toString());
            })
            .then(() => hubConnection.invoke("RegisterWebDevice", 'test@test.signalr').catch(err => console.error(err.toString())));
    }

    render() {
        return (
            <div id="messagesList">

            </div>
        );
    }
}
