using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using IActionFilter = System.Web.Http.Filters.IActionFilter;

namespace Example.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class MethodDebugFilterAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple { get; } = false;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine("Before");

                return continuation();
            });
        }
    }
}