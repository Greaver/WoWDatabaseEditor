using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WDE.Updater.Models;

namespace WDE.Updater.Client
{
    public class UpdateClient : IUpdateClient
    {
        private readonly Uri updateServerUrl;
        private readonly string marketplace;
        private readonly string? key;
        private readonly Platforms platform;

        public UpdateClient(Uri updateServerUrl, string marketplace, string? key, Platforms platform)
        {
            this.updateServerUrl = updateServerUrl;
            this.marketplace = marketplace;
            this.key = key;
            this.platform = platform;
        }

        public async Task<CheckVersionResponse> CheckForUpdates(string branch, long version)
        {
            var request = new CheckVersionRequest(version, marketplace, branch, platform, key);
            var client = new HttpClient();
            var response = await client.PostAsync(
                updateServerUrl + "CheckVersion", 
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CheckVersionResponse>(responseBody);
            }

            throw new Exception("Update server returned " + response.StatusCode);
        }

        public async Task DownloadUpdate(CheckVersionResponse versionResponse, string destination, IProgress<float>? progress = null)
        {
            var client = new HttpClient();
            using var response = await client.GetAsync(Path.Join(updateServerUrl.AbsoluteUri, versionResponse.DownloadUrl!.TrimStart('/')), HttpCompletionOption.ResponseHeadersRead);
            var contentLength = response.Content.Headers.ContentLength;
            
            await using var stream = await response.Content.ReadAsStreamAsync();
            await using var file = File.OpenWrite(destination);
            
            var relativeProgress = new Progress<long>(totalBytes => progress?.Report((float)totalBytes / contentLength ?? 1));
            await stream.CopyToAsync(file, 81920, relativeProgress);
            progress?.Report(1);
            await stream.CopyToAsync(file);
        }
    }
}