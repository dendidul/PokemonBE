using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PokemonBE.Dao;
using PokemonBE.Models;

namespace PokemonBE.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PokemonDataController : Controller
    {

        private readonly PokemonDataDao PokemonDataDao;

        public PokemonDataController(IConfiguration config)
        {
            this.PokemonDataDao = new PokemonDataDao(config) ;
        }


        [HttpPost]
        [Route("~/api/PokemonData/ValidateLogin")]
        public IActionResult ValidateLogin(UserModel model)
        {
            try
            {

                var data = PokemonDataDao.ValidateUser(model);

                if (data != null)
                {
                    return Json(new { status = StatusCodes.Status200OK, result = data, message = "valid" });
                }
                else
                {
                 
                    var IsExist = PokemonDataDao.CheckExistsUser(model);

                    if (IsExist == true)
                    {
                        return Json(new { status = StatusCodes.Status200OK, result = false, message = "Username / password not valid" });
                    }
                    else
                    {
                        var IsValid = PokemonDataDao.CreateUser(model);
                        var newuserdata = PokemonDataDao.GetUserById(IsValid);
                        return Json(new { status = StatusCodes.Status200OK, result = newuserdata, message = "success" });
                    }
                }


            }
            catch (Exception ex)
            {

                return Json(new { status = StatusCodes.Status400BadRequest, result = false, message = "error" });
            }
        }


        [HttpPost]
        [Route("~/api/PokemonData/CreateUser")]
        public IActionResult CreateUser(UserModel model)
        {
            try
            {
                var IsExist = PokemonDataDao.CheckExistsUser(model);

                if(IsExist == true)
                {
                    return Json(new { status = StatusCodes.Status200OK, result = false, message = "Username already exist" });
                }
                else
                {
                    var IsValid = PokemonDataDao.CreateUser(model);
                    return Json(new { status = StatusCodes.Status200OK, result = true, message = "success" });
                }


                
              
            }
            catch (Exception ex)
            {

                return Json(new { status = StatusCodes.Status400BadRequest, result = false, message = "error" });
            }
        }

        [HttpPost]
        [Route("~/api/PokemonData/CreateUserPokemon")]
        public IActionResult CreateUserPokemon(UserListPokemonModel model)
        {
            try
            {
                var checkIsExists = PokemonDataDao.CheckExistsPokemonNickName(model);

                if(checkIsExists == true)
                {
                    
                    return Json(new { status = StatusCodes.Status200OK, result = false, message = "your pokemon name has been used" });
                }
                else
                {
                    var IsValid = PokemonDataDao.CreateUserPokemon(model);
                    return Json(new { status = StatusCodes.Status200OK, result = true, message = "success" });
                }

               
            }
            catch (Exception ex)
            {

                return Json(new { status = StatusCodes.Status400BadRequest, result = false, message = "error" });
            }
        }

        [HttpPost]
        [Route("~/api/PokemonData/UpdateUserPokemon")]
        public IActionResult UpdateUserPokemon(UserListPokemonModel model)
        {
            try
            {
                var checkIsExists = PokemonDataDao.CheckExistsPokemonNickName(model);

                if (checkIsExists == true)
                {
                  
                    return Json(new { status = StatusCodes.Status200OK, result = false, message = "your pokemon name has been used" });
                }
                else
                {
                    var IsValid = PokemonDataDao.UpdateUserPokemon(model);
                    return Json(new { status = StatusCodes.Status200OK, result = true, message = "success" });
                }


            }
            catch (Exception ex)
            {

                return Json(new { status = StatusCodes.Status400BadRequest, result = false, message = "error" });
            }
        }

        [HttpPost]
        [Route("~/api/PokemonData/GetListPokemon")]
        public IActionResult GetListPokemon(UserListPokemonModel model)
        {
            try
            {
                
                    var data = PokemonDataDao.GetListPokemon(model);
                    return Json(new { status = StatusCodes.Status200OK, result = data, message = "success" });
               


            }
            catch (Exception ex)
            {

                return Json(new { status = StatusCodes.Status400BadRequest, result = false, message = "error" });
            }
        }

    }
}