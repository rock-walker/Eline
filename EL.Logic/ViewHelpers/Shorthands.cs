using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EL.Logic.ViewHelpers
{
	public static class Shorthands
	{
		public static IHtmlString JsString<TModel>(this HtmlHelper<TModel> html, string str)
		{
			if (str == null)
				str = "";
			return html.Raw(HttpUtility.JavaScriptStringEncode(str));
		}
		public static IHtmlString JsStringHtml<TModel>(this HtmlHelper<TModel> html, string str)
		{
			if (str == null)
				str = "";
			return new HtmlString(HttpUtility.JavaScriptStringEncode(str));
		}
		public static IHtmlString LineBreaks<TModel>(this HtmlHelper<TModel> html, string str)
		{
			if (str == null)
				str = "";
			return html.Raw(HttpUtility.HtmlEncode(str).Replace("\r\n", "<br />"));
		}
	}

	/// <summary>
	/// Utility class for sewrialization/desrialization data of JSON format
	/// </summary>
	public static class JsonPacket
	{
		/// <summary>
		/// Reads object of specified type from JSON formatted UTF8 stream
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static T Parse<T>(Stream stream) where T: class
		{
			var parser = new DataContractJsonSerializer(typeof(T));
			return parser.ReadObject(stream) as T;
		}

		/// <summary>
		/// Reads object of specified type from JSON formatted string
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <returns></returns>
		public static T Parse<T>(String input) where T: class
		{
			using(var ms = new MemoryStream(Encoding.UTF8.GetBytes(input)))
			{
				return Parse<T>(ms);
			}
		}

		/// <summary>
		/// Stores object to stream in JSON format
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="stream"></param>
		public static void Compose<T>(T input, Stream stream) where T: class
		{
			var composer = new DataContractJsonSerializer(typeof(T));
			composer.WriteObject(stream, input);
		}

		/// <summary>
		/// Stores object to string in JSON format
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <returns></returns>
		public static String Compose<T>(T input) where T: class
		{
			var serializer = new JavaScriptSerializer();
			return serializer.Serialize(input);
		}
	}

}