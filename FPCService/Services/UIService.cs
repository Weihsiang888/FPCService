using CommonLibraryP.API;

namespace FPCService.Services
{
    public class UIService
    {
        public Action<RequestResult>? ToastAction;
        public void ShowToast(RequestResult requestResult)
        {
            ToastAction?.Invoke(requestResult);
        }
    }
}
