using OpenAI.Chat;
using Azure;
using Azure.AI.OpenAI;
using System.Text;

namespace BlazorIntApp1
{
    public class ChatService
    {
        private readonly ChatClient chatClient;
        public ChatService(string ApiUrl, string ApiKey)
        {
            string urlFromEnvironment = ApiUrl ?? Environment.GetEnvironmentVariable("AZURE_OPENAI_API_URL") ?? "";
            string keyFromEnvironment = ApiKey ?? Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? "";

            AzureOpenAIClient azureClient = new(new Uri(urlFromEnvironment),new AzureKeyCredential(keyFromEnvironment));

            chatClient = azureClient.GetChatClient("gpt-4o");
        }

        public string GetResponse(string query)
        {
            ChatCompletion completion = chatClient.CompleteChat(
                [
                 // System messages represent instructions or other guidance about how the assistant should behave
                 //new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
                 // User messages represent user input, whether historical or the most recen tinput
                 new UserChatMessage(query),
                 // Assistant messages in a request represent conversation history for responses
                 //new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
                 //new UserChatMessage("What's the best way to train a parrot?"),
                ]);

            return completion.Content[0].Text;

        }
    }
}