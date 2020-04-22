namespace Genix.Services.Services.Messages
{
    public struct NotifyData
    {
        public NotifyType NotifyType { get; set; }
        public string Message { get; set; }
        public bool Encode { get; set; }
    }
}
