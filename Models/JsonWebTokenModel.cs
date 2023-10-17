namespace VacationRequester.Models
{
    public class JsonWebTokenModel
    {
        public string Token { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Expires { get; set; } 
    }
}