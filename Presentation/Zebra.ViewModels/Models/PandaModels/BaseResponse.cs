namespace Zebra.ViewModels.Models.PandaModels
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool IsSucceeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
