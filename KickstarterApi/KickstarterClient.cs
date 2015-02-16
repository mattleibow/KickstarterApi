namespace KickstarterApi
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    public class KickstarterClient
    {
        private const string DefaultClientId = "2II5GGBZLOOZAA5XBU1U0Y44BU57Q58L8KOGM7H0E0YFHP3KTG";
        private const string RootUrl = "https://api.kickstarter.com/";

        private readonly string _clientId;
        private string _accessToken;

        private KickstarterClient(string clientId = null)
        {
            this._clientId = clientId;
        }

        public User User { get; private set; }

        public static async Task<KickstarterClient> CreateAsync(string email, string password, string clientId = null)
        {
            var client = new KickstarterClient(clientId ?? DefaultClientId);

            await client.LoginAsync(email, password);

            //// TODO: possibly throw when login fails

            return client;
        }

        internal async Task<TResult> GetAsync<TResult>(string path)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(this.GetUrl(path));
                return await result.ParsedAsJson<TResult>();
            }
        }

        internal async Task<TResult> PostAsync<TResult>(string path, object parameters)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(this.GetUrl(path), new StringContent(parameters.ToJson()));
                var resultText = await result.Content.ReadAsStringAsync();
                return await resultText.ParsedAsJson<TResult>();
            }
        }

        internal async Task LoginAsync(string email, string password)
        {
            var logonResult = await this.PostAsync<LogonResult>(
                string.Format("xauth/access_token?client_id={0}", this._clientId),
                new { email, password });

            this._accessToken = logonResult.AccessToken;
            this.User = logonResult.User;
        }

        internal string GetUrl(string path)
        {
            var builder = new StringBuilder();
            if (!path.StartsWith("http"))
                builder.Append(RootUrl);
            builder.Append(path);
            if (!string.IsNullOrWhiteSpace(this._accessToken))
            {
                builder.Append(path.Contains("?") ? "&" : "?");
                builder.AppendFormat("oauth_token={0}", this._accessToken);
            }

            return builder.ToString();
        }
    }
}
