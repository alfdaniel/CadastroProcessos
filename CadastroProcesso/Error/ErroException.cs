namespace CadastroProcesso.Models
{
    public class ErroException
    {
        
        public string? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }

        public ErroException(string? statusCode, string? message, string? details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

    }
}
