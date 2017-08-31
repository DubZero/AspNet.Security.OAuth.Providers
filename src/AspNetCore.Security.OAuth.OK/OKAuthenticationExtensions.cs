/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using AspNet.Security.OAuth.OK;

namespace Microsoft.AspNetCore.Builder
{
    public static class OKAuthenticationExtensions
    {
		/// <summary>
		/// Adds the <see cref="VkontakteAuthenticationMiddleware"/> middleware to the specified
		/// <see cref="IApplicationBuilder"/>, which enables Vkontakte authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
		/// <param name="options">A <see cref="VkontakteAuthenticationOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
		public static IApplicationBuilder UseOKAuthentication(
			[NotNull] this IApplicationBuilder app,
			[NotNull] OKAuthenticationOptions options)
		{
			if (app == null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}

			return app.UseMiddleware<OKAuthenticationMiddleware>(Options.Create(options));
		}

		/// <summary>
		/// Adds the <see cref="OKAuthenticationMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Однокласники authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
		/// <param name="configuration">An action delegate to configure the provided <see cref="OKAuthenticationOptions"/>.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
		public static IApplicationBuilder UseOKAuthentication(
			[NotNull] this IApplicationBuilder app,
			[NotNull] Action<OKAuthenticationOptions> configuration)
		{
			if (app == null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var options = new OKAuthenticationOptions();
			configuration(options);

			return app.UseMiddleware<OKAuthenticationMiddleware>(Options.Create(options));
		}
	}
}
