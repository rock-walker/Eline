using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace EL.Logic.Core
{
	public class ApiExceptionConvertor
	{
		readonly ExceptionSettings _settings;

		static readonly IDictionary<Type, ErrorCodes> ErrMap = new Dictionary<Type, ErrorCodes>
		{
			{typeof (EntityNotFoundException), ErrorCodes.EntityNotFound},
			{typeof (TimeoutException), ErrorCodes.Timeout},
			{typeof (ArgumentException), ErrorCodes.InvalidArgument},
		};

		public ApiExceptionConvertor(ExceptionSettings sett)
		{
			_settings = sett;
		}

		public ErrorDataContract ConvertException(Exception ex)
		{
			HttpStatusCode httpCode;
			return ConvertException(ex, out httpCode);
		}

		public ErrorDataContract ConvertException(Exception ex, out HttpStatusCode httpCode)
		{
			ErrorDataContract error;

			var origEx = ex;
			ex = ex.TryUnwrap();

			var apiEx = ex as ApiException;

			if (apiEx != null)	// special case: ApiException
			{
				error = CreateError(apiEx.FaultCode, apiEx.Message, apiEx.DeveloperMessage);
				error.CorrelationId = apiEx.CorrelationId;
				error.Details = apiEx.Details;
				httpCode = apiEx.StatusCode;
			}
			else if (ex is XmlException)	// special case: XmlException
			{
				error = CreateError(ErrorCodes.InvalidXml, Resources.ApiErrors.Error_Invalid_Xml, ApiException.BuildDevMsg(origEx));
				httpCode = HttpStatusCode.BadRequest;
			}
			else if (ex is OperationCanceledException)
			{
				error = CreateError(ErrorCodes.Cancelled, ex.Message, ApiException.BuildDevMsg(origEx));
				httpCode = HttpStatusCode.InternalServerError;
			}
			else if (ex is ArgumentException)
			{
				error = CreateError(ErrorCodes.InvalidArgument, ex.Message, ApiException.BuildDevMsg(origEx));
				httpCode = HttpStatusCode.BadRequest;
			}
			else	// other cases
			{
				error = CreateError(ex, origEx);
				httpCode = HttpStatusCode.InternalServerError;
			}

			return error;
		}

		ErrorDataContract CreateError(Exception ex, Exception wrappedException)
		{
			var developerMessage = ApiException.BuildDevMsg(wrappedException);

			ErrorCodes code;
			if (ErrMap.TryGetValue(ex.GetType(), out code))
				return CreateError(code, ex.Message, developerMessage);

			var message = _settings.ProduceDeveloperInfo ? ex.Message : Resources.ApiErrors.Error_Internal_UnspecifiedError;

			return CreateError(ErrorCodes.UnspecifiedError, message, developerMessage);
		}

		ErrorDataContract CreateError(ErrorCodes code, string message, string devMsg)
		{
			return new ErrorDataContract(code) {
				Message = message,
				DeveloperMessage = _settings.ProduceDeveloperInfo ? devMsg : null,
				MoreInfo = !string.IsNullOrWhiteSpace(_settings.ErrorLinkTemplate) ? string.Format(_settings.ErrorLinkTemplate, (int)code) : null,
				CorrelationId = Guid.NewGuid().ToString("N")
			};
		}

		public static void LogException(ILogger log, Exception ex, ErrorDataContract error, HttpStatusCode code)
		{
			if (ex == null)
				return;

			log.Warning(@"[Exception][Type:{0}][Err:{1}][HTTPStatus:{2}][Message:{3}][CorrId:{4}]
*********************** DevMessage ***********************
{5}
**********************************************************
Exception:
{6}",
				ex.GetType().Name, error.FaultCode, code, error.Message, error.CorrelationId, error.DeveloperMessage, ex);
		}
	}
}
