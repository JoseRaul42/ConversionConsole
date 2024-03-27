//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//static HttpClient ConfigureHttpClient(string personalAccessToken)
//{
//    var httpClient = new HttpClient();

//    // Assuming you're using a Personal Access Token (PAT) for Azure DevOps
//    // Convert the PAT into a Base64 string for Basic Authentication
//    string authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalAccessToken}"));

//    // Set the Authorization header with the Basic scheme and PAT
//    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

//    // Set the base address to Azure DevOps organization URL
//    httpClient.BaseAddress = new Uri("https://dev.azure.com/");

//    return httpClient;
//}
