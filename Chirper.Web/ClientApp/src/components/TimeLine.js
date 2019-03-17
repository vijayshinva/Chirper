import React, { Component } from 'react';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';

export class TimeLine extends Component {
    constructor(props) {
        super(props);

        this.state = {
            value: ''
        };
    }

    componentDidMount = () => {
        const hubConnection = new HubConnectionBuilder()
            .withUrl("http://localhost:56008/wallhub")
            .configureLogging(LogLevel.Trace)
            .build();
        hubConnection.on("WallUpdate", (user, message) => {
            const encodedMsg = user + " says " + message;
            const li = document.createElement("li");
            li.textContent = encodedMsg;
            document.getElementById("messagesList").appendChild(li);
        });
        hubConnection.start()
            .catch(function (err) {
                return console.error(err.toString());
            })
            .then(() => hubConnection.invoke("RegisterForWallUpdate", '53C0FDDF-666A-4D52-BAF9-3D09147B2581').catch(err => console.error(err.toString())));
    }

    render() {
        return (
            <div id="messagesList">

            </div>
        );
    }
}
