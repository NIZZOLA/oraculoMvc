using System.Text.Json.Serialization;

namespace OraculoApi.Model.OpenAI;

public class OpenAIRequest
{
    public OpenAIRequest(string question)
    {
        this.Model = "text-davinci-003";
        this.Prompt = question;
        this.Temperature = 0f;
        this.MaxTokens = 500;
    }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("temperature")]
    public float Temperature { get; set; }

    [JsonPropertyName("max_tokens")]
    public int MaxTokens { get; set; }
}