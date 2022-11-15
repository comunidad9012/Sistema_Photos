using InstituteWebApi.Middlewares;

namespace InstituteWebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddlerware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddlerware>();
        }
    }
}
