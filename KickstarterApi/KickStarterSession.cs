﻿namespace KickstarterApi
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    internal class KickStarterSession : IKickstarterSession
    {
        private const string Root = "https://api.kickstarter.com/";
        private string _accessToken;

        public async Task<TResult> Get<TResult>(string path)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(this.GetUrl(path));
                return await result.ParsedAsJson<TResult>();
            }
        }

        public async Task<TResult> Post<TResult>(string path, object parameters)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(this.GetUrl(path), new StringContent(parameters.ToJson()));
                var resultText = await result.Content.ReadAsStringAsync();
                return await resultText.ParsedAsJson<TResult>();
            }
        }

        private string GetUrl(string path)
        {
            var builder = new StringBuilder();
            if (!path.StartsWith("http"))
                builder.Append(Root);
            builder.Append(path);
            if (!String.IsNullOrWhiteSpace(this._accessToken))
            {
                builder.Append(path.Contains("?") ? "&" : "?");
                builder.AppendFormat("oauth_token={0}", this._accessToken);
            }

            return builder.ToString();
        }

        public User User { get; private set; }

        internal async Task<bool> Logon(string email, string password, string clientId)
        {
            var logonResult = await this.Post<LogonResult>(
                String.Format("xauth/access_token?client_id={0}", clientId),
                new {email, password});

            this._accessToken = logonResult.AccessToken;
            this.User = logonResult.User;

            //// TODO: return false for invalid logons

            return true;
        }
    }
}