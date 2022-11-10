using Application.Common.Models;
using Application.User.Commands;
using Application.User.Queries;
using Domain.Entities;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Modules
{
    public class UserModule : ICarterModule
    {
        public IMediator Mediator { get; }

        public UserModule(IMediator mediator)
        {
            Mediator = mediator;
        }
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users", GetUsers);
            app.MapGet("/api/users/{id}", GetUser);
            app.MapPost("/api/users", CreateUser);
            app.MapPut("/api/users/", UpdateUser);
            app.MapDelete("/api/users/{id}", DeleteUser);
        }


        private async Task<IResult> GetUser(int id)
        {
            try
            {
                GetUser getUser = new GetUser() { Id = id };
                UserDTO user = await Mediator.Send(getUser);
                if (user == null)
                    Results.NotFound();
                return Results.Ok(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<PaginatedList<UserDTO>> GetUsers(int pageSize = 50, int pageNo = 1)
        {
            GetUsers getUsers = new GetUsers() { pageSize = pageSize, pageNo = pageNo };
            PaginatedList<UserDTO> users = await Mediator.Send(getUsers);
            return users;
        }

        private async Task<IResult> CreateUser(AddUser adduser)
        {
            try
            {
                await Mediator.Send(adduser);
                return Results.Accepted();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
                throw;
            }
        }
        private async Task<IResult> DeleteUser(int id)
        {
            try
            {

                DeleteUser deleteUser = new DeleteUser() { Id = id };
                await Mediator.Send(deleteUser);
                return Results.Accepted();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
                throw;
            }
        }

        private async Task<IResult> UpdateUser([FromBody] EditUser edituser)
        {
            try
            {
                await Mediator.Send(edituser);
                return Results.Accepted();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
                throw;
            }
        }
    }
}
