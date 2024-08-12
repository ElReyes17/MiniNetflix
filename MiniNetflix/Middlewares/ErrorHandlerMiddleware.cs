﻿using Azure;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace MiniNetflix.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {               
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = Result<string>.Failure(error.Message);

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        switch (e.ErrorCode)
                        {
                            case (int)HttpStatusCode.BadRequest:
                                response.StatusCode = (int)HttpStatusCode.BadRequest;
                                break;
                            case (int)HttpStatusCode.InternalServerError:
                                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                            case (int)HttpStatusCode.NotFound:
                                response.StatusCode = (int)HttpStatusCode.NotFound;
                                break;

                            case (int)HttpStatusCode.NoContent:
                                response.StatusCode = (int)HttpStatusCode.NoContent;
                                break;
                            default:
                                // unhandled error
                                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                        }
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}

