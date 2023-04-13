namespace Manager.API.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}
