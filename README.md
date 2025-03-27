# ChatbotAPI

This project is a chatbot API designed to run locally, utilizing .NET for the backend, Svelte for the frontend, and a Python-based AI model executed on the host's CPU.

![Chat Bot Image](https://github.com/user-attachments/assets/a426ebbf-0646-4417-8aed-13c40d1c763d)


## Backend

The backend is built using **.NET** and provides API endpoints for handling chatbot interactions. It connects to a database for storing user interactions and configurations.

### Technologies Used:
- **.NET Core** (Latest Version)
- **Entity Framework** for database interaction
- **Microsoft SQL** 

### How to Run the Backend:
1. Clone the repository:
   ```sh
   git clone https://github.com/VagelisKormazosMellonGroup/ChatbotAPI.git
   cd ChatbotAPI
   ```
2. Install the required dependencies.
3. Set up the database and configure the connection string in `appsettings.json`.
4. Run the application:
   ```sh
   dotnet run
   ```

## Frontend

The frontend is built using **Svelte**, providing a dynamic and responsive UI for interacting with the chatbot.

### How to Run the Frontend:
1. Navigate to the frontend directory:
   ```sh
   cd frontend
   ```
2. Install dependencies:
   ```sh
   npm install
   ```
3. Start the development server:
   ```sh
   npm run dev
   ```

## AI Model & Python Integration

The chatbot runs AI-powered natural language processing using a locally hosted model. The Python script loads and executes the model on the host's CPU.

### Model Details:
- **Model Used:** Hermes-2-Pro-Mistral-7B
- **Framework:** `llama.cpp` (or another compatible inference framework)
- **Execution:** Runs locally on the CPU, ensuring privacy and offline availability

### Running the Python Model:
1. Install required dependencies:
   ```sh
   pip install -r requirements.txt
   ```
2. Run the Python script that loads the model:
   ```sh
   python run_model.py
   ```

## Additional Notes
- Ensure that your environment is properly set up with the correct dependencies.
- The backend, frontend, and Python model should run concurrently for full functionality.
- If needed, configure environment variables for API keys, database connections, etc.

### Contribution
Feel free to submit pull requests or report issues. 🚀

### License
This project is licensed under the MIT License.

