import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
    
      </div>
          <h1>SignalR Chat Client</h1>
      <div className="card">
              <div id="loginArea">
                  User: <input type="text" id="userInput" />
              </div>
              <div id="messageArea">
                  Message: <input type="text" id="messageInput" /> 
                  <input type="button" id="sendButton" value="Send Message" />
              </div>

              <hr />
          
              <ul id="messagesList">
                
              </ul>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
