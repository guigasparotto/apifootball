using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiFootballTests.Helpers
{
    //public static class Libraries
    //{
    //    public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(
    //        this RestClient client,
    //        IRestRequest request) where T : class, new()
    //    {
    //        var taskCompletionSourcce = new TaskCompletionSource<IRestResponse<T>>();

    //        client.ExecuteAsync<T>(request, response =>
    //        {
    //            if (response.ErrorException != null)
    //            {
    //                const string message = "Error retrieving response.";
    //                throw new ApplicationException(message, response.ErrorException);
    //            }

    //            taskCompletionSourcce.SetResult(response);
    //        });

    //        return await taskCompletionSourcce.Task;
    //    }
    //}
}
