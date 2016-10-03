using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GitLab_Clone
{
    public class GetGitProjectsListFromServer
    {
        List<GitProject> gitList;

        public GetGitProjectsListFromServer()
        {
            GetGitLabProjects();
        }
        private async void GetGitLabProjects()
        {
            const string WEBSERVICE_URL = "http://10.10.1.14/api/v3/projects";
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, WEBSERVICE_URL);
                request.Headers.Add("PRIVATE-TOKEN", "QP4y4uGD38rejzuLR7yy");
                HttpResponseMessage response = await client.SendAsync(request);
                String responseString = await response.Content.ReadAsStringAsync();
                while (!response.IsSuccessStatusCode)
                {
                }
                if (response.IsSuccessStatusCode)
                {
                    ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                    gitList = JsonConvert.DeserializeObject<List<GitProject>>(responseString);
                    args.gitProjectList = gitList;
                    OnThresholdReached(args);
                }
                else
                {
                    gitList = null;
                }
            }
            catch (Exception ignore)
            {

            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public event ThresholdReachedEventHandler ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public List<GitProject> gitProjectList { get; set; }
    }

    public delegate void ThresholdReachedEventHandler(Object sender, ThresholdReachedEventArgs e);
}
