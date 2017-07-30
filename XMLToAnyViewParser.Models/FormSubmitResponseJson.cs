namespace XMLToAnyViewParser.Models
{
    public enum ResponseStatus
    {
        Unknown = -1,
        Ok = 0,
        EmptyObject,
        BadDataSent
    }
    public class FormSubmitResponseJson
    {
        public ResponseStatus Status { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }
        
    }
}