namespace Services.Wrapper
{
    public class Response
    {
        private bool Success { get; set; } = false;
        public Dictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();
        public dynamic Data { get; set; }
        public string Message { get; set; }
    }
}