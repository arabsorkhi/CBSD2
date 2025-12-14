 
import React, { useEffect } from 'react';
//establish a connection to the SignalR hub:
import * as signalR from '@microsoft/signalr';
const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:5001/notificationHub')
    .withAutomaticReconnect()
    .build();

//connection.start().catch(err => console.error(err));
//export default connection;

// Define a method the server can call (RPC)
connection.on("ReceiveMessage", (user, message) => {
    console.log(`${user}: ${message}`);
    // Update your UI here
});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.error(err);
        setTimeout(start, 5000); // Retry connection
    }
};

// Call the start function to begin the connection
start();