using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DUPSS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiChatController : ControllerBase
    {
        private readonly string _gptApiKey;
        private const string SystemPrompt = "Bạn là một trợ lý tâm lý tận tâm, thân thiện và không phán xét. " +
            "Hãy cung cấp thông tin chính xác, dễ hiểu và lời khuyên an toàn về các vấn đề liên quan đến ma túy, " +
            "bao gồm tác hại, cách phòng tránh và hỗ trợ người có nguy cơ hoặc đang sử dụng. Luôn khuyến khích người dùng tìm kiếm sự giúp đỡ từ chuyên gia khi cần thiết.";

        public AiChatController(IConfiguration configuration)
        {
            _gptApiKey = configuration["OpenAI:ApiKey"];
        }
                            
        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _gptApiKey);

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = SystemPrompt },
                    new { role = "user", content = request.Message }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"AI service error: {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var aiResponse = JsonDocument.Parse(responseString)
                .RootElement.GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return Ok(new { response = aiResponse });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}