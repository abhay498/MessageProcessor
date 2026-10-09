import { useState } from "react";
import "./App.css";

function App() {
    const [message, setMessage] = useState("");
    const [result, setResult] = useState("");

    const processMessage = async () => {
        try {
            const response = await fetch(
                "http://localhost:5010/api/message/process",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify({
                        message: message
                    })
                }
            );

            const data = await response.json();

            setResult(data.result);
        } catch (error) {
            console.error(error);
            setResult("Something went wrong.");
        }
    };

    return (
        <div className="container">
            <h1>Message Processor</h1>

            <input
                type="text"
                placeholder="Enter a message"
                value={message}
                onChange={(e) => setMessage(e.target.value)}
            />

            <button onClick={processMessage}>
                Process
            </button>

            <h2>Result</h2>

            <p>{result}</p>
        </div>
    );
}

export default App;