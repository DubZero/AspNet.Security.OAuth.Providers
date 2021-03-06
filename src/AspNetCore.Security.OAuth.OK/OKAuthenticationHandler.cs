﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.Security.OAuth.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AspNet.Security.OAuth.OK
{
	public class OKAuthenticationHandler : OAuthHandler<OKAuthenticationOptions>
	{
		public OKAuthenticationHandler(HttpClient client)
			: base(client)
		{
		}
		public string CalculateMD5Hash(string input_str)
		{
			string input = input_str;
			// step 1, calculate MD5 hash from input
			MD5 md5 = MD5.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}
		protected override async Task<AuthenticationTicket> CreateTicketAsync([NotNull] ClaimsIdentity identity, [NotNull] AuthenticationProperties properties, [NotNull] OAuthTokenResponse tokens)
		{

			Dictionary<string, string> QueryString = new Dictionary<string, string>();

			var sercert_key = $"{tokens.AccessToken}{Options.ClientSecret}";
			sercert_key = CalculateMD5Hash(sercert_key).ToLower();

			var sig = $"application_key={Options.ApplicationKey}format=jsonmethod=users.getCurrentUser{sercert_key}";
			sig = CalculateMD5Hash(sig);

			QueryString.Add("application_key", Options.ApplicationKey);
			QueryString.Add("format", "json");
			QueryString.Add("method", "users.getCurrentUser");
			QueryString.Add("sig", sig);
			QueryString.Add("access_token", tokens.AccessToken);
			var address = QueryHelpers.AddQueryString(Options.UserInformationEndpoint, QueryString);

			var response = await Backchannel.GetAsync(address, Context.RequestAborted);
			if (!response.IsSuccessStatusCode)
			{
				Logger.LogError("An error occurred when retrieving the user profile: the remote server " +
								"returned a {Status} response with the following payload: {Headers} {Body}.",
								/* Status: */ response.StatusCode,
								/* Headers: */ response.Headers.ToString(),
								/* Body: */ await response.Content.ReadAsStringAsync());

				throw new HttpRequestException("An error occurred when retrieving the user profile.");
			}

			var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

			identity.AddOptionalClaim(ClaimTypes.NameIdentifier, OKAuthenticationHelper.GetId(payload), Options.ClaimsIssuer)
					.AddOptionalClaim(ClaimTypes.GivenName, OKAuthenticationHelper.GetFirstName(payload), Options.ClaimsIssuer)
					.AddOptionalClaim(ClaimTypes.Surname, OKAuthenticationHelper.GetLastName(payload), Options.ClaimsIssuer)
					.AddOptionalClaim(ClaimTypes.Email, OKAuthenticationHelper.GetEmail(payload), Options.ClaimsIssuer);

			var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
			var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);


			await Options.Events.CreatingTicket(context);

			return context.Ticket;
		}
	}
}
