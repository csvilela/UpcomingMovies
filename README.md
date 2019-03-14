# UpcomingMovies
Sample Xamarin Forms project for displaying IMDB upcoming movies.

An API was implemented along with the mobile app.
The API performs the calls to the IMDB API.
For testing purposes the API is currently running on Azure Web Services and the mobile app is pointing to it.(https://upcomingmoviesapi.azurewebsites.net/swagger/)

Third-party libraries used:
-NUnit - Unit-testing framework;
-Newtonsoft.Json - For parsing Json content;
-MOQ - For mocking objects to create unit tests;
-AutoMapper - For parsing objects between the different layers of the application;
-Autofac - Inversion of Control container to achieve loose coupling;
