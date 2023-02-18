namespace CarShop.Web.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException e)
            {
                LogException(e);
                await CreateErrorResponse(context.Response, StatusCodes.Status400BadRequest, e.Message);
            }
            catch (KeyNotFoundException e)
            {
                LogException(e);
                await CreateErrorResponse(context.Response, StatusCodes.Status404NotFound, e.Message);
            }
            catch(Exception e)
            {
                LogException(e);
                await CreateErrorResponse(context.Response, StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private async Task CreateErrorResponse(HttpResponse response, int status, string errorMessage)
        {
            response.Clear();
            response.StatusCode = status;

            await response.WriteAsync(errorMessage);
        }

        private void LogException(Exception exception)
        {
            Console.WriteLine($"{DateTime.Now} - {exception.Message} - {exception.StackTrace}");
        }
    }
}
