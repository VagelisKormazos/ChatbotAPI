import sys
from gpt4all import GPT4All

model_path = "C:/Users/v.kormazos/AI_Models/Hermes-2-Pro-Mistral-7B.Q4_0.gguf"

model = GPT4All(model_path, allow_download=False, device="cpu")

user_input = sys.argv[1]  # Παίρνει την ερώτηση από το .NET
response = model.generate(user_input)

print(response.encode('utf-8').decode('utf-8'))  # Επιστρέφει την απάντηση στο .NET API
