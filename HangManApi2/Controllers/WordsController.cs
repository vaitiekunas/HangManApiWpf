using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using HangManApi.Models;
using System.Text.Json;

namespace HangManApi.Controllers
{
    
    [ApiController]
    [Route(template: "[controller]")]
    public class WordsController : Controller
    {
        private IDataAccess _dataAccess;
        public WordsController(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        [HttpGet("Actor")]
        public IActionResult ActorGet()
        {
            var actorArray = _dataAccess.GetActors(null);
            var actors = actorArray.Select(x => x.FullName).ToList();
            return Ok(actors);
        }

        [HttpGet("Film")]
        public IActionResult FilmGet()
        {
            var filmArray = _dataAccess.GetFilms(null);
            var films = filmArray.Select(x => x.Title).ToList();
            return Ok(films);
        }

        [HttpGet("LtAnimal")]
        public IActionResult LtAnimalGet()
        {
            var ltAnimalArray = _dataAccess.GetLtAnimals(null);
            var ltAnimals = ltAnimalArray.Select(x => x.Name).ToList();
            return Ok(ltAnimals);
        }

        [HttpGet("Country")]
        public IActionResult CountryGet()
        {
            var countryArray = _dataAccess.GetCountries(null);
            var countries = countryArray.Select(x => x.Name).ToList();
            return Ok(countries);
        }
    }
}
