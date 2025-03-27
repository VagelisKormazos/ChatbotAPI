<script>
    import { onMount } from "svelte";

    let message = "";
    let chatHistory = [];
    let isLoading = false;

    async function sendMessage() {
        if (!message.trim()) return;

        const userMessage = { role: "user", content: message };
        chatHistory = [...chatHistory, userMessage];

        message = ""; // Καθαρίζει την ερώτηση

        isLoading = true;

        const response = await fetch("http://localhost:5126/api/chatbot/ask", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ question: userMessage.content }),
        });

        const data = await response.json();
        isLoading = false;

        chatHistory = [...chatHistory, { role: "bot", content: data.answer }];
    }

    function handleKeyDown(event) {
        if (event.key === "Enter") {
            event.preventDefault(); // Αποτρέπει το default submit behavior
            sendMessage();
        }
    }
</script>

<main class="chat-container">
    <h2>Chatbot Assistant 🤖</h2>

    <div class="messages">
        {#each chatHistory as msg}
            <div class={msg.role}>
                {msg.content}
            </div>
        {/each}

        {#if isLoading}
            <div class="bot thinking">🤔 The chatbot thinking...</div>
        {/if}
    </div>

    <div class="input-area">
        <input bind:value={message} placeholder="Type here..." on:keydown={handleKeyDown} />
        <button on:click={sendMessage}>➤</button>
    </div>
</main>

<style>
    * {
        font-family: Arial, sans-serif;
    }
    .chat-container {
        max-width: 500px;
        margin: auto;
        display: flex;
        flex-direction: column;
        height: 600px;
        border-radius: 12px;
        border: 1px solid #ddd;
        padding: 15px;
        background: #f9f9f9;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }
    h2 {
        text-align: center;
        margin-bottom: 10px;
        color: #333;
    }
    .messages {
        flex: 1;
        overflow-y: auto;
        display: flex;
        flex-direction: column;
        gap: 8px;
        padding-bottom: 10px;
    }
    .user {
        align-self: flex-end;
        background: #007bff;
        color: white;
        padding: 12px;
        border-radius: 15px;
        max-width: 75%;
    }
    .bot {
        align-self: flex-start;
        background: #e0e0e0;
        padding: 12px;
        border-radius: 15px;
        max-width: 75%;
    }
    .thinking {
        font-style: italic;
        opacity: 0.7;
    }
    .input-area {
        display: flex;
        gap: 5px;
    }
    input {
        flex: 1;
        padding: 12px;
        border-radius: 5px;
        border: 1px solid #ccc;
        font-size: 16px;
    }
    button {
        background: #007bff;
        color: white;
        border: none;
        padding: 12px;
        border-radius: 5px;
        cursor: pointer;
        font-size: 18px;
    }
    button:hover {
        background: #0056b3;
    }
</style>
