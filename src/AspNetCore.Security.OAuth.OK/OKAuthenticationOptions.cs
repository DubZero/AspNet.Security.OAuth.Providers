using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspNet.Security.OAuth.OK
{    /// <summary>
	 /// Configuration options for <see cref="OKAuthenticationMiddleware"/>.
	 /// </summary>
	public class OKAuthenticationOptions : OAuthOptions
	{
		public string ApplicationKey { get; set; }
		/// <summary>
		/// Initializes a new <see cref="OKAuthenticationOptions"/>.
		/// </summary>
		public OKAuthenticationOptions()
		{
			AuthenticationScheme = OKAuthenticationDefault.AuthenticationScheme;
			DisplayName = OKAuthenticationDefault.DisplayName;
			ClaimsIssuer = OKAuthenticationDefault.Issuer;

			CallbackPath = new PathString("/signin-ok");

			AuthorizationEndpoint = OKAuthenticationDefault.AuthorizationEndpoint;
			TokenEndpoint = OKAuthenticationDefault.TokenEndpoint;
			UserInformationEndpoint = OKAuthenticationDefault.UserInformationEndpoint;
		}
		/// <summary>
		/// Gets the list of fields to retrieve from the user information endpoint.
		/// See https://apiok.ru/dev/methods/rest/users/users.getCurrentUser for more information.
		/// </summary>
		public ICollection<string> Fields { get; } = new HashSet<string> {
			"uid",
			"first_name",
			"last_name",
			"pic_1"
		};
	}
}
