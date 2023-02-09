using System.Text.Json.Serialization;

namespace OraculoApi.Model.OpenAI;

public class Usage
{
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens { get; set; }
}
