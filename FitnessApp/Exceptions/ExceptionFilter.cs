using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Security.Authentication;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Exceptions
{
    public class ExceptionResponseFilter : IExceptionFilter
    {

        public ExceptionResponseFilter()
        {
        }

        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                //ApiException apiException => apiException.StatusCode,
                ArgumentNullException _ => StatusCodes.Status422UnprocessableEntity,
                ValidationException _ => StatusCodes.Status422UnprocessableEntity,
                AuthenticationException _ => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var title = context.Exception switch
            {
                //ApiException apiException => apiException.Title,
                ArgumentNullException _ => "This item already exists ",
                ValidationException _ => "Validation error",
                AuthenticationException _ => "Authentication issue",
                _ => "Internal error"
            };

            var message = context.Exception switch
            {
                //ApiException apiException => apiException.Detail,
                ArgumentNullException _ => context.Exception.Message,
                ValidationException _ => context.Exception.Message,
                AuthenticationException _ => "Action is permitted because of authentication reasons",
                _ => "Internal error occured. Please try a little bit later"
            };

            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = message
            };

            var response = BuildResponse(problemDetails);

            context.HttpContext.Response.StatusCode = response.StatusCode ?? StatusCodes.Status500InternalServerError;
            context.Result = response;
            context.ExceptionHandled = true;
        }

        private static ObjectResult BuildResponse(ProblemDetails problem) =>
            new ObjectResult(problem)
            {
                StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError,
                ContentTypes = new MediaTypeCollection { "application/problem+json" }
            };
    }
}
