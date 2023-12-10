## Disney Animation Movies API
#### The Disney Animation Movies API allows you to retrieve information about Disney animation movies, including their title, runtime, IMDb page, rating, and more. 

### Base URL
``` [https://disneymoviesapi.bsite.net/api/v1](https://apidisneymovies.bsite.net/api/v1/) ```


### Endpoints

#### Get All Movies 
Get a list of all Disney animation movies.

Endpoint: \
GET /movies/all?deatils=false

#### Response:
```json 
[
  {
    "movieId": 67,
    "title": "Zootopia",
    "year": "(2016)",
    "image": "https://m.media-amazon.com/images/M/MV5BOTMyMjEyNzIzMV5BMl5BanBnXkFtZTgwNzIyNjU0NzE@._V1_FMjpg_UX1000_.jpg",
    "rating": "8"
  },
  // other movies ...
]
```
#### Get All Movies With Details
Get a list of all Disney animation movies with all the other details.

Endpoint:\
GET /movies/all?details=true

#### Response:
```json 
[
  {
    "movieId": 67,
    "title": "Zootopia",
    "year": "(2016)",
    "link": "/title/tt2948356/?ref_=ttls_li_tt",
    "image": "https://m.media-amazon.com/images/M/MV5BOTMyMjEyNzIzMV5BMl5BanBnXkFtZTgwNzIyNjU0NzE@._V1_FMjpg_UX1000_.jpg",
    "runtime": "108 min",
    "genre": "Animation, Adventure, Comedy",
    "summary": "In a city of anthropomorphic animals, a rookie bunny cop and a cynical con artist fox must work together to uncover a conspiracy.",
    "rating": "8",
    "metascore": "78",
    "directors": "Byron Howard, \nRich Moore, \nJared Bush",
    "stars": "Ginnifer Goodwin, \nJason Bateman, \nIdris Elba, \nJenny Slate"
  },
  // other movies ...
]
```
#### Get Movie by ID
Get a specific Disney animation movie using its ID.

Endpoint:\
GET /movies/{id}?details=false

#### Response:
```json 
[
  {
    "movieId": 67,
    "title": "Zootopia",
    "year": "(2016)",
    "image": "https://m.media-amazon.com/images/M/MV5BOTMyMjEyNzIzMV5BMl5BanBnXkFtZTgwNzIyNjU0NzE@._V1_FMjpg_UX1000_.jpg",
    "rating": "8"
  }
]
```
#### Get Movie by ID With Details
Get more details about a specific Disney animation movie using its ID.

Endpoint:\
GET /movies/all/{id}?details=true

#### Response:
```json 
[
  {
    "movieId": 67,
    "title": "Zootopia",
    "year": "(2016)",
    "link": "/title/tt2948356/?ref_=ttls_li_tt",
    "image": "https://m.media-amazon.com/images/M/MV5BOTMyMjEyNzIzMV5BMl5BanBnXkFtZTgwNzIyNjU0NzE@._V1_FMjpg_UX1000_.jpg",
    "runtime": "108 min",
    "genre": "Animation, Adventure, Comedy",
    "summary": "In a city of anthropomorphic animals, a rookie bunny cop and a cynical con artist fox must work together to uncover a conspiracy.",
    "rating": "8",
    "metascore": "78",
    "directors": "Byron Howard, \nRich Moore, \nJared Bush",
    "stars": "Ginnifer Goodwin, \nJason Bateman, \nIdris Elba, \nJenny Slate"
  }
]
```
#### Search Movies
Search for Disney animation movies by a given query string.

Endpoint:\
GET /search?query={query}

#### Response:
```json 
[
  {
    "movieId": 67,
    "title": "Zootopia",
    "year": "(2016)",
    "image": "https://m.media-amazon.com/images/M/MV5BOTMyMjEyNzIzMV5BMl5BanBnXkFtZTgwNzIyNjU0NzE@._V1_FMjpg_UX1000_.jpg",
    "rating": "8"
  },
// other movies ...
]
```
### Implementation
#### .NET Core using C#
``` csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        var baseUrl = "https://apidisneymovies.bsite.net/api/v1";
        bool details=false;

        // Get all movies with less details
        var allMoviesResponse = await client.GetStringAsync($"{baseUrl}/movies/all?details={details}");
        Console.WriteLine(allMoviesResponse);

        // Get movie by ID with all details
        var movieId = 1;
        details=true;
        var movieByIdResponse = await client.GetStringAsync($"{baseUrl}/movies/{movieId}?deatils={details}");
        Console.WriteLine(movieByIdResponse);

        // Search movies
        var query = "Zoo";
        var searchResponse = await client.GetStringAsync($"{baseUrl}/search?query={query}");
        Console.WriteLine(searchResponse);
    }
}
```
#### Node.js using Javascript
```javascript 
import fetch from 'node-fetch';

const baseUrl = 'https://apidisneymovies.bsite.net/api/v1/';

// Get all movies
fetch(`${baseUrl}/movies/all`)
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));

// Get movie by ID
const movieId = 1;
fetch(`${baseUrl}/movies/${movieId}`)
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));

// Search movies
const query = 'Disney';
fetch(`${baseUrl}/search?query=${query}`)
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));
```

### Build-It-Yourself
#### reqiures .NET Core 7.0 sdk
```
git clone https://github.com/zainab7681051/DisneyMoviesApi/
```
```
cd DisneyMoviesApi
```
```
dotnet run
```
if you are not immediately redirected to the Swagger user interface page then append "/swagger/index.html/" to the url.

### Conclusion
This API allows you to access information about Disney animation movies easily. Whether you're using .NET Core or Node.js, you can integrate this API into your projects to retrieve movie details, search for movies, and enhance your application with Disney movie data.
