using System;

namespace AspNet.Security.OAuth.OK
{

	/// <summary>
		/// Default values used by the Одноклассники authentication middleware.
		/// </summary>
	public static class OKAuthenticationDefault
	{
			/// <summary>
			/// Default value for <see cref="AuthenticationOptions.AuthenticationScheme"/>.
			/// </summary>
			public const string AuthenticationScheme = "Одноклассники";

			/// <summary>
			/// Default value for <see cref="RemoteAuthenticationOptions.DisplayName"/>.
			/// </summary>
			public const string DisplayName = "Одноклассники";

			/// <summary>
			/// Default value for <see cref="AuthenticationOptions.ClaimsIssuer"/>.
			/// </summary>
			public const string Issuer = "Одноклассники";

			/// <summary>
			/// Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
			/// </summary>
			public const string CallbackPath = "/signin-ok";

			/// <summary>
			/// Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
			/// </summary>
			public const string AuthorizationEndpoint = "https://connect.ok.ru/oauth/authorize";

			/// <summary>
			/// Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
			/// </summary>
			public const string TokenEndpoint = "https://api.ok.ru/oauth/token.do";

			/// <summary>
			/// Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
			/// </summary>
			public const string UserInformationEndpoint = "https://api.ok.ru/fb.do";
		}
	
}
