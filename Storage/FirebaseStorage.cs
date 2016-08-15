using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Firebase.Xamarin.Auth;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Storage.v1;

namespace Firebase.Xamarin.Storage {
	public class FirebaseStorage {

		private string apiKey { get; set; }
		private string userId { get; }
		private string token { get; set; }

		public FirebaseStorage(string apiKey, string accessToken, string refreshToken, string bucket) {
			this.apiKey = apiKey;

			var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer());

			var tokenResponse = new TokenResponse();
			tokenResponse.AccessToken = accessToken;
			tokenResponse.RefreshToken = refreshToken;

			var credentials = new Google.Apis.Auth.OAuth2.UserCredential(flow, userId, tokenResponse);

			var serviceInitializer = new BaseClientService.Initializer() {
				ApplicationName = "",
				HttpClientInitializer = credentials,
				ApiKey = apiKey,
			};

			var service = new StorageService(serviceInitializer);

			//Task.Run(async () => {
			//	var list = await service.Objects.List(bucket).ExecuteAsync();
			//	Debug.WriteLine(list.ToString());
			//});

		}
	}
}

