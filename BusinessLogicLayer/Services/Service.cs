using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class Service : IService
    {

        private readonly Repository<Game> _gameRepos;

        public Service()
        {
            // DI later
            _gameRepos = new Repository<Game>(new ApplicationContext());
        }

        public IEnumerable<GameDTO>  GetGames()
        {
            List<GameDTO> games = new List<GameDTO>();
            // Nado bi automappera dodat'
            foreach(var game  in _gameRepos.Get())
            {
                games.Add(new GameDTO { Developer = game.Developer, ID = game.Id, Name = game.Name, Year = game.Year });
            }
            return games;
        }

        public void AddGame(GameDTO g)
        {
            _gameRepos.Create(new Game() { Developer = g.Developer,Name = g.Name,Year = g.Year});
        }
    }
}
