global using API.Exceptions;
global using API.Extensions;



global using Application.Common.Abstractions;
global using Application.Interfaces.Persistence;
global using Application.Todos.Queries.GetTodos;
global using Application.Contracts.Todos.Requests;
global using Application.Todos.Commands.CreateTodo;
global using Application.Todos.Commands.DeleteTodo;
global using Application.Todos.Commands.UpdateTodo;
global using Application.Todos.Queries.GetTodoById;



global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Diagnostics;



global using MediatR;
global using FluentValidation;
global using Infrastructure.Presistance;
global using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;