using CRM.Application.Responses;
using System.Net;
using System.Text.Json;

namespace CRM.API.Middlewares
{
    public class ExceptionHandler(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // İsteği bir sonraki adıma (Controller'a) gönder
                await _next(context);
            }
            catch (Exception ex)
            {
                // Eğer bir hata fırlatılırsa burası yakalar
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // Varsayılan olarak 500 Internal Server Error (Sistem Hatası)
            var statusCode = HttpStatusCode.InternalServerError;
            string errorMessage = "An unexpected error occurred on the server.";

            // Hatayı tipine göre ayırıyoruz (Pattern Matching)
            if (exception is Exception businessException)
            {
                // Bizim fırlattığımız bilerek yapılan kısıtlamalar (Örn: "Müşteri bulunamadı")
                statusCode = HttpStatusCode.BadRequest; // 400
                errorMessage = businessException.Message;
            }
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized; // 401
                errorMessage = "You are not authorized to access this resource.";
            }

            context.Response.StatusCode = (int)statusCode;

            // Senin o meşhur kurumsal BaseResponse formatın!
            // T tipini object veya string olarak verebilirsin, Failure zaten Data dönmez.
            var response = BaseResponse<object>.FailureResult(errorMessage);

            // JSON'a serialize ederken camelCase kalıbına uysun diye ayar yapıyoruz
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            return context.Response.WriteAsync(jsonResponse);
        }

    }
}
