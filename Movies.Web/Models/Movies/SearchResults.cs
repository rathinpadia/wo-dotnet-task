﻿using System.Collections.Generic;

namespace Movies.Web.Models.Movies
{
    public class SearchResults
    {
        public List<SearchResult> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }

    }
}