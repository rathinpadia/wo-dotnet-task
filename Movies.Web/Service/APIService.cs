using Movies.Web.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Web.Service
{
    public class APIService : IAPIService
    {
        private readonly  ApplicationSettings _appSettings;
        public APIService(ApplicationSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public Details GetDetailsById(string id)
        {
            Details details = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.API_URL);
                //HTTP GET
                string apiParameters = "?i=" + id + "&apikey=" + _appSettings.API_KEY;
                var responseTask = client.GetAsync(apiParameters);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    details = result.Content.ReadAsAsync<Details>().Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                }
            }
            return details;
        }

        public SearchResults SearchResult(string title)
        {
            SearchResults searchResults = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.API_URL);
                //HTTP GET
                string apiParameters = "?s="+title + "&apikey="+ _appSettings.API_KEY;
                var responseTask = client.GetAsync(apiParameters);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    searchResults = result.Content.ReadAsAsync<SearchResults>().Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                }
            }
            return searchResults;
        }

        public SearchResults SearchResultByTitleandYear(string title,string startYear,string endYear)
        {
            SearchResults searchResults = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.API_URL);
                //HTTP GET
                string apiParameters = "?s=" + title + "&apikey=" + _appSettings.API_KEY;
                var responseTask = client.GetAsync(apiParameters);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    searchResults = result.Content.ReadAsAsync<SearchResults>().Result;
                
                    if (searchResults.Search.Count > 0)
                    {
                        List<SearchResult> filterresult = new List<SearchResult>();
                        foreach (var item in searchResults.Search)
                        {
                            if (item.Year.IndexOf("–") != -1)
                            {
                                string[] arrYear = item.Year.Split("–");
                                int sYear = Convert.ToInt32(arrYear[0]);
                                int eYear = Convert.ToInt32(arrYear[1]);
                                if (sYear >= Convert.ToInt32(startYear) && eYear <= Convert.ToInt32(endYear))
                                {
                                    filterresult.Add(item);
                                }
                            }
                            else
                            {
                                int year = Convert.ToInt32(item.Year);
                                if (year >= Convert.ToInt32(startYear) && year <= Convert.ToInt32(endYear))
                                {
                                    filterresult.Add(item);
                                }
                            }
                        }
                        searchResults.Search = filterresult;
                    }
                }
                else //web api sent error response 
                {
                    //log response status here..
                }
            }
            return searchResults;
        }
    }
}
