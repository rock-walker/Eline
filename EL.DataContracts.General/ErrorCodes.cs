namespace EL.DataContracts.General
{
	/// <summary>
	/// Entity errors
	/// </summary>
	public enum ErrorCodes
	{
		// generic and from system exceptions
		/// <summary>
		/// Internal Error
		/// </summary>
		InternalError = 100,

		/// <summary>
		/// Invalid argument
		/// </summary>
		InvalidArgument = 101,

		/// <summary>
		/// Db error
		/// </summary>
		DbError = 102,

		/// <summary>
		/// Invalid Date-Time Format
		/// </summary>
		InvalidDateTimeFormat = 103,

		/// <summary>
		/// Invalid Xml
		/// </summary>
		InvalidXml = 104,

		/// <summary>
		/// Unspecified Error
		/// </summary>
		UnspecifiedError = 105,

		/// <summary>
		/// Entity Not Found
		/// </summary>
		EntityNotFound = 106,

		/// <summary>
		/// Timeout
		/// </summary>
		Timeout = 107,

		/// <summary>
		/// Delete Entity Error
		/// </summary>
		DeleteEntityError = 108,

		/// <summary>
		/// Create Entity Error
		/// </summary>
		CreateEntityError = 109,

		/// <summary>
		/// Update Entity Error
		/// </summary>
		UpdateEntityError = 110,

		/// <summary>
		/// Gfi Content Is Expired
		/// </summary>
		GfiContentIsExpired = 111,

		/// <summary>
		/// Cancelled
		/// </summary>
		Cancelled = 112,

		/// <summary>
		/// Unexpected Remote Error
		/// </summary>
		UnexpectedRemoteError = 113,

		/// <summary>
		/// Limit Reached
		/// </summary>
		LimitReachedError = 114,

		/// <summary>
		/// Invalid Model
		/// </summary>
		InvalidModel = 115,

		/// <summary>
		/// Invalid operation
		/// </summary>
		InvalidOperation = 116,

		/// <summary>
		/// Conflict
		/// </summary>
		Conflict = 117,

		/// <summary>
		/// Concurrency issue
		/// </summary>
		Concurrency = 118,

		/// <summary>
		/// 300
		/// </summary>
		Repository_Unknown	= 300,

		/// <summary>
		/// 301
		/// </summary>
		Repository_DeleteObjectFault			= 301,

		/// <summary>
		/// 302
		/// </summary>
		Repository_ItemNotFoundFault			= 302,

		/// <summary>
		/// 303
		/// </summary>
		Repository_NoAccessFault				= 303,

		/// <summary>
		/// 304
		/// </summary>
		Repository_ItemIsLockedFault			= 304,

		/// <summary>
		/// 305
		/// </summary>
		Repository_AssociatedPostsFault			= 305,

		/// <summary>
		/// 306
		/// </summary>
		Repository_AssociatedBaselinesFault		= 306,

		/// <summary>
		/// 307
		/// </summary>
		Repository_TreeSourceNotAvailable		= 307,

		/// <summary>
		/// 308
		/// </summary>
		Repository_ObjectOperationFault			= 308,

		/// <summary>
		/// 309
		/// </summary>
		Repository_NotCheckedOutThisUserFault	= 309,

		/// <summary>
		/// 310
		/// </summary>
		Repository_DuplicateNameFault			= 310,

		/// <summary>
		/// 311
		/// </summary>
		Repository_RepAccessDenied				= 311,

		/// <summary>
		/// 312
		/// </summary>
		Repository_TreeSourceContentNotAvailable = 312,

		/// <summary>
		/// 313
		/// </summary>
		Repository_IncompatibleLanguageFault	= 313,

		/// <summary>
		/// 314
		/// </summary>
		Repository_CheckedOutByOtherFault		= 314,

		/// <summary>
		/// 315
		/// </summary>
		Repository_IncompatibleVersionFault		= 315,

		/// <summary>
		/// 316
		/// </summary>
		Repository_CheckedOutOtherHostFault		= 316,

		/// <summary>
		/// 317
		/// </summary>
		Repository_ProblemSharingFault			= 317,

		/// <summary>
		/// 318
		/// </summary>
		Repository_SecurityFault				= 318,

		/// <summary>
		/// 319
		/// </summary>
		Repository_CompoundFault				= 319,

		/// <summary>
		/// 320
		/// </summary>
		Repository_AbortedOperation				= 320,

		/// <summary>
		/// 321
		/// </summary>
		Repository_ReplicaLock					= 321,

		/// <summary>
		/// 322
		/// </summary>
		Repository_NoLongerSupportedVer			= 322,

		/// <summary>
		/// 323
		/// </summary>
		Repository_DataVersion					= 323,

		/// <summary>
		/// 324
		/// </summary>
		Repository_OperationCanceled			= 324,

		/// <summary>
		/// 325
		/// </summary>
		Repository_UserException				= 325,

		/// <summary>
		/// 326
		/// </summary>
		Repository_GuidException				= 326,

		/// <summary>
		/// 327
		/// </summary>
		Repository_BindingException				= 327,

		/// <summary>
		/// 328
		/// </summary>
		Repository_LogicalException				= 328,

		/// <summary>
		/// 329
		/// </summary>
		Repository_UnknownSystemException		= 329,

		/// <summary>
		/// 330
		/// </summary>
		Repository_NotCheckedOutThisUserFaultEx = 330,

		/// <summary>
		/// 331
		/// </summary>
		Repository_CheckedOutByOtherFaultEx = 331,

		/// <summary>
		/// 400
		/// </summary>
		Repository_Error_Last = 400,


		// Repository API error codes

		/// <summary>
		/// 500
		/// </summary>
		OpenDocument_NotFound = 500,

		/// <summary>
		/// 501
		/// </summary>
		OpenDocument_OpenDocument_NoInformation = 501,

		/// <summary>
		/// 502
		/// </summary>
		OpenDocument_OpenDocumentId_NotSpecified = 502,

		/// <summary>
		/// 503
		/// </summary>
		OpenDocument_PingContentError = 503,

		/// <summary>
		/// 504
		/// </summary>
		OpenDocument_NoDiskSpace = 504,

		/// <summary>
		/// 505
		/// </summary>
		OpenDocument_AccessDenied = 505,

		/// <summary>
		/// 506
		/// </summary>
		OpenDocument_Document_CantFindOrConnect = 506,

		/// <summary>
		/// 507
		/// </summary>
		OpenDocument_NotAvailable = 507,

		/// <summary>
		/// 508
		/// </summary>
		OpenDocument_NoSuchDataKind = 508,

		/// <summary>
		/// 509
		/// </summary>
		OpenDocument_NewerVersionAvailable = 509,

		/// <summary>
		/// 510
		/// </summary>
		OpenDocument_VersionIsNotAvailable = 510,
		
		/// <summary>
		/// 800
		/// </summary>
		SearchSessionNotExists = 800,

		/// <summary>
		/// 801
		/// </summary>
		SearchAccessToSessionIsDenied = 801,

		/// <summary>
		/// 802
		/// </summary>
		InvalidQuery = 802,

		/// <summary>
		/// 803
		/// </summary>
		TooLongQuery = 803,

		/// <summary>
		/// 2000
		/// </summary>
		Export_NotAllSearchSourcesAvailable = 2000,

		/// <summary>
		/// 2001
		/// </summary>
		Export_TokenExpired = 2001,

		// PCN DLS support

		/// <summary>
		/// 3000
		/// </summary>
		PCNDLS_NoISEAccount = 3000,

		/// <summary>
		/// 3001
		/// </summary>
		PCNDLS_PartnerAccountAccessDenied = 3001,

		/// <summary>
		/// 3002
		/// </summary>
		PCNDLS_CustAccountAccessDenied = 3002,

		/// <summary>
		/// Tool/feature is not checked out
		/// </summary>
		Simo_Checkout_Required = 3010,
	}
}
