﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNetCore.Builder;

namespace AspNetCore.Security.OAuth.Gitter {
    /// <summary>
    /// Default values used by the Gitter authentication middleware.
    /// </summary>
    public static class GitterAuthenticationDefaults {
        /// <summary>
        /// Default value for <see cref="AuthenticationOptions.AuthenticationScheme"/>.
        /// </summary>
        public const string AuthenticationScheme = "Gitter";

        /// <summary>
        /// Default value for <see cref="RemoteAuthenticationOptions.DisplayName"/>.
        /// </summary>
        public const string DisplayName = "Gitter";

        /// <summary>
        /// Default value for <see cref="AuthenticationOptions.ClaimsIssuer"/>.
        /// </summary>
        public const string Issuer = "Gitter";

        /// <summary>
        /// Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
        /// </summary>
        public const string CallbackPath = "/signin-gitter";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
        /// </summary>
        public const string AuthorizationEndpoint = "https://gitter.im/login/oauth/authorize";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
        /// </summary>
        public const string TokenEndpoint = "https://gitter.im/login/oauth/token";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
        /// </summary>
        public const string UserInformationEndpoint = "https://api.gitter.im/v1/user";
    }
}