# Rest_Api_Movies

Create a `REST API` for movie/actors data with `CRUD` options.Implemented according to scheme below

![DbSchema](/Rest_Api_Moviea/architectura.jpg)

## Endpoints

- Movies
  - `GET`
    - api/movies
	- api/movies/{id}
  - `POST`
    - api/movies
  - `PUT`
    - api/movies/{id}
  - `PATCH`
    - api/movies/{id}
  - `DELETE`
    - api/movies/{id}

    
- To validate `POST` endpoint

```
{
    "title": "Matrixa 4",
    "year": 2021,
    "ageRestriction": 18,
    "price": 100
}
```