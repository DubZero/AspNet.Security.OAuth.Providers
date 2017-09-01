/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
namespace AspNet.Security.OAuth.OK
{
	public static class OKAuthenticationHelper
    {
		/// <summary>
		/// Gets the identifier associated with the logged in user.
		/// </summary>
		public static string GetId([NotNull] JObject user) => user.Value<string>("uid");

		/// <summary>
		/// Gets the first name associated with the logged in user.
		/// </summary>
		public static string GetFirstName([NotNull] JObject user) => user.Value<string>("first_name");

		/// <summary>
		/// Gets the last name associated with the logged in user.
		/// </summary>
		public static string GetLastName([NotNull] JObject user) => user.Value<string>("last_name");

		/// <summary>
		/// Gets the pic_1 photo.
		/// </summary>
		public static string GetPhoto([NotNull] JObject user) => user.Value<string>("pic_1");

		/// <summary>
		/// Gets the first name associated with the logged in user.
		/// </summary>
		public static string GetEmail([NotNull] JObject user) => user.Value<string>("email");
	}
}
