using HangManApi.Models;
using System.Collections.Generic;

namespace HangManApi
{
    public interface IDataAccess
    {
        List<Actor> GetActors(int? id);
        List<Film> GetFilms(int? id);
        List<LtAnimal> GetLtAnimals(int? id);
        List<Country> GetCountries(int? id);
        void AddRecord(Record record);
        List<Record> GetRecords(int? id);
    }
}