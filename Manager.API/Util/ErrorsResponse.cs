using Manager.API.ViewModels;
using System.Collections.ObjectModel;

namespace Manager.API.Util
{
    public static class ErrorsResponse
    {
        public static ResultViewModel ApplicationErrorMessage()
        {


            return new ResultViewModel
            {

                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
            };

        }


        public static ResultViewModel DomainErrorMessage(string message)
        {

            return new ResultViewModel
            {
                Message = message,
                Success = false,

            };

        }


        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {


            return new ResultViewModel
            {
                Data = errors,
                Message = message,
                Success = false,
            };

        }


        public static ResultViewModel UnathorizedErrorMessage()
        {

            return new ResultViewModel()
            {
                Message = "Não autorizado",
                Success = false,
            };



        }



    }
}
