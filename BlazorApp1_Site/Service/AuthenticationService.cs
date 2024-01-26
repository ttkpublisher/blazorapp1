using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using BlazorApp1_Site.Models;

namespace BlazorApp1_Site.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAmazonCognitoIdentityProvider _cognitoProvider;
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("7oG#0U$dgQcREwT7", "bzlrO8suw1Zrp9P7egsZUf3u+oDpSw8HcfdvkXEs");
            var awsRegion = RegionEndpoint.GetBySystemName("eu-west-3");
            _cognitoProvider = new AmazonCognitoIdentityProviderClient(awsCredentials, awsRegion);
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<AuthenticateResult> SignInAsync(string username, string password)
        {
            var request = new InitiateAuthRequest
            {
                AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                ClientId = "6f4m403a7ocbfa16275rpqn7d4",
                AuthParameters = new Dictionary<string, string>
            {
                { "USERNAME", username },
                { "PASSWORD", password }
            }
            };

            var response = await _cognitoProvider.InitiateAuthAsync(request);
            AuthenticateResult authenticateResult = new AuthenticateResult();
            authenticateResult.IdToken = response.AuthenticationResult.IdToken;

            return authenticateResult;
        }
    }
}
