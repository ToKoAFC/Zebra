using System;

namespace Zebra.ViewModels.Models.PandaModels
{
    public static class JsonResponse
    {
        public static BaseResponse<T> CreateResponse<T>(object data)
        {
            var response = new BaseResponse<T>();

            if (data.GetType() == typeof(Exception))
            {
                response.IsSucceeded = false;
                response.ErrorMessage = ((Exception)data).Message;
                response.Data = (T)data;
            }
            else
            {
                response.IsSucceeded = true;
                response.Data = (T)data;
            }
            return response;
        }
    }
}
