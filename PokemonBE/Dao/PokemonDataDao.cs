using Dapper;
using PokemonBE.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PokemonBE.Dao
{
    public class PokemonDataDao
    {

        private readonly IConfiguration _config;


        public PokemonDataDao(IConfiguration config)
        {
           
            this._config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DbConnection"));
            }
        }


        public bool ValidateUser(UserModel model)
        {
            var data = false;

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();
                   


                    data = conn.Query<UserModel>(
                                                @"SELECT  [id]
                                              ,[username]
                                              ,[password]
                                          FROM [tbl_user] where username = @username and password = @password ", 
                                                new { @username = model.username , @password = model.password}).Any();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public bool CheckExistsUser(UserModel model)
        {
            var data = false;

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<UserModel>(
                                                @"SELECT  [id]
                                              ,[username]
                                              ,[password]
                                             FROM [tbl_user] where username = @username ",
                                                new
                                                {
                                                    @username = model.username,
                                                    
                                                }).Any();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;
        }

        public UserModel CreateUser(UserModel model)
        {
            var data = new UserModel();

            try
            {
                using (IDbConnection conn = Connection)
                {
                  



                    data = conn.Query<UserModel>(
                                                @"insert into tbl_user (Username,Password) 
                                                 values(@username,@password)

                                                    ", new { @username = model.username,
                                                    @password = model.password }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public UserListPokemonModel CreateUserPokemon(UserListPokemonModel model)
        {
            var data = new UserListPokemonModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<UserListPokemonModel>(
                                                @"INSERT INTO [dbo].[tbl_user_list_pokemon]
                                                   ([user_id]
                                                   ,[pokemon_id]
                                                   ,[pokemon_origin_name]
                                                   ,[pokemon_nickname])
                                             VALUES
                                                   (@user_id,
                                                   ,@pokemon_id,
                                                   ,@pokemon_origin_name,
                                                   ,@pokemon_nickname)      
                                                    ", new { @user_id = model.user_id,
                                                            @pokemon_id = model.pokemon_id,
                                                            @pokemon_origin_name = model.pokemon_origin_name,
                                                            @pokemon_nickname = model.pokemon_nickname
                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public UserListPokemonModel UpdateUserPokemon(UserListPokemonModel model)
        {
            var data = new UserListPokemonModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<UserListPokemonModel>(
                                                @"UPDATE [dbo].[tbl_user_list_pokemon]
                                                   SET [user_id] = @user_id
                                                      ,[pokemon_id] = @pokemon_id
                                                      ,[pokemon_origin_name] = @pokemon_origin_name
                                                      ,[pokemon_nickname] = @pokemon_nickname
                                                 WHERE  id= @id
                                                    ", new
                                                {
                                                    @user_id = model.user_id,
                                                    @pokemon_id = model.pokemon_id,
                                                    @pokemon_origin_name = model.pokemon_origin_name,
                                                    @pokemon_nickname = model.pokemon_nickname,
                                                    @id = model.id
                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public bool CheckExistsPokemonNickName(UserListPokemonModel model)
        {
            var data = false;

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<UserModel>(
                                                @"SELECT [id]
                                                  ,[user_id]
                                                  ,[pokemon_id]
                                                  ,[pokemon_origin_name]
                                                  ,[pokemon_nickname]
                                              FROM [pokemon].[dbo].[tbl_user_list_pokemon]
                                              where [user_id] = @user_id and pokemon_origin_name = @pokemon_origin_name and pokemon_nickname = @pokemon_nickname ", 
                                                new { @user_id = model.user_id,
                                                    @pokemon_origin_name = model.pokemon_origin_name,
                                                    @pokemon_nickname = model.pokemon_nickname
                                                }).Any();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;
        }

        public List<UserListPokemonModel> GetListPokemon(UserListPokemonModel model)
        {
            var data = new List<UserListPokemonModel>();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<UserListPokemonModel>(
                                                @"SELECT [id]
                                                      ,[user_id]
                                                      ,[pokemon_id]
                                                      ,[pokemon_origin_name]
                                                      ,[pokemon_nickname]
                                                  FROM [pokemon].[dbo].[tbl_user_list_pokemon]
                                                  where [user_id] = @user_id 
                                                    ", new
                                                {
                                                    @user_id = model.user_id
                                                   
                                                }).ToList();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


    }
}
