using OraculoMVC.Models.OpenAI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OraculoApi.Model.OpenAI;

public class OpenAIResponse
{
    public string Id { get; set; }
    public string Object { get; set; }
    public int Created { get; set; }
    public string Model { get; set; }
    public Choice[] Choices { get; set; }
    public Usage Usage { get; set; }
    public OpenAIError? Error { get; set; }
}
