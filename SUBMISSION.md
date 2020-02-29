CORE TASK

--------------------------------------------------------------
1. A movie search results page to search for movies by title using the omdbapi. Example http://www.omdbapi.com/?apikey=[yourkey]&s=Avengers. Ensure any criteria used to search movies is in the query string of the movie search results page.

Description :
Implemented a Controller Name Movie, Which will call a service, Service will call API Service, Which actually fetches data from Omdbapi.
1. Have read apikey, apiurl from appsettings.json
2. Startup.cs : Configured dependency injection for appsettings, APIService, MovieService -> Movies
3. Flow of Data : MovieController -> Movies - > APIService 
4. MVC URL :  https://localhost:<PORT>/Search?title=avengers will call  http://www.omdbapi.com/?apikey=[yourkey]&s=avengers
5. Injected Dependency of Movies at MoviesController.
6. Injected Dependency of APIService at Movies
7. Injected Dependency of AppSetting at APIService
8. By Default i have used index method to pass search critera as Title.
9. To test Search the URL is :  MVC URL :  https://localhost:<PORT>/Search?title=avengers will call  http://www.omdbapi.com/?apikey=[yourkey]&s=avengers
10. Used MoviesController, SearchResult.cshtml, MovieResult.cshtml,index.cshtml
11. Configured SearchResults.cs, SearchResult.cs,Details.cs, New class - ApplicationSettings.cs,Rating.cs. 
12. Method used in MoviesController :  public IActionResult SearchResult(string title,string startYear, string endYear) 


2. A movie details page displaying more details about a movie using the omdbapi. Example http://www.omdbapi.com/?apikey=[yourkey]&i=tt4154756
Description :
1. Added a method in MoviesController to get details of movie selected.
2. Method used in MoviesController :  public IActionResult Details(string id)
3. view used : Details.cshtml
4. MVC URL when clicked on View Details of Movie list : https://localhost:<PORT>/Details/tt4154756
5. It will call http://www.omdbapi.com/?apikey=[yourkey]&i=tt4154756
6. Just Displayed few details of the Movie in a tabular format.



3.Mark up the movie search results page with movie carousel structured data for the current displayed movies. Make sure the structured data is in JSON-LD format. More guidelines are here https://developers.google.com/search/docs/data-types/movie#summary

Could not parse data into JSON-LD format, tried but it was giving error.

4.Mark up the movie details page with movie structured data for the displayed movie details. Make sure the structured data is in JSON-LD format. More guidelines are here https://developers.google.com/search/docs/data-types/movie#movie

Could not parse data into JSON-LD format, tried but it was giving error.

-------------------------------------------------------------------------------------------------------
Bonus Task:

1. Add a control to search movies by an year range in addition to the title in search results page. Make sure this is part of the query string as well

Description :

1. MVC URL :  https://localhost:44393/Search?title=avengers&StartYear=2012&EndYear=2015 will call  http://www.omdbapi.com/?apikey=[yourkey]&s=avengers
	and once the data is received from the API, it is filtered by year.
2. Injected Dependency of Movies at MoviesController.
3. Injected Dependency of APIService at Movies
4. Injected Dependency of AppSetting at APIService
5. Used MoviesController, SearchResult.cshtml, MovieResult.cshtml,index.cshtml
6. Configured SearchResults.cs, SearchResult.cs,Details.cs, New class - ApplicationSettings.cs,Rating.cs. 
7. Method used in MoviesController :  public IActionResult SearchResult(string title,string startYear, string endYear) 
8. I have not created a Control to pickup dates, instead used only url to search the data.
	MVC URL :  https://localhost:44393/Search?title=avengers&StartYear=2012&EndYear=2015 




