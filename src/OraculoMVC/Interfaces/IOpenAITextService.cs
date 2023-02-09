using OraculoApi.Model.OpenAI;

namespace OraculoApi.Interfaces;

public interface IOpenAITextService
{
    Task<OpenAIResponse> CompletePrompt(OpenAIRequest request);
}
