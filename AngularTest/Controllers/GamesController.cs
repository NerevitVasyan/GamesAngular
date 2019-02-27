using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularTest.Models;
using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTest.Controllers
{
   

    //[Produces("application/json")]
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IService _service;
        public GamesController(IService service)
        {
            _service = new Service();
        }
        [HttpGet]
        public IEnumerable<GameViewModel> Get()
        {
            return Mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameViewModel>>(_service.GetGames()); ;
        }

        [HttpPost]
        public IActionResult Post([FromBody]GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                _service.AddGame(Mapper.Map<GameViewModel, GameDTO>(game));
                return Ok(game);
            }
            return BadRequest(ModelState);
        }

    }
}