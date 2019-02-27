using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<GameDTO> GetGames();
        void AddGame(GameDTO g);
    }
}
