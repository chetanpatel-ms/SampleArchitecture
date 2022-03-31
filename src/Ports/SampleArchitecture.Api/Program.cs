using SampleArchitecture.Api.Controllers.Users.CommandHandlers;
using SampleArchitecture.Api.Controllers.Users.CommandHandlers.Audit;
using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Api.Controllers.Users.Validators;
using SampleArchitecture.Api.Extensions;
using SampleArchitecture.Api.Filters;
using SampleArchitecture.Audit;
using SampleArchitecture.Commands;
using SampleArchitecture.Extensions;
using SampleArchitecture.Models;
using SampleArchitecture.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(
        options =>
        {
            options.Filters.Add<RequestValidationExceptionFilter>();
        });

builder.Services.AddScoped<ICommandProcessor, CommandProcessor>();
builder.Services.AddCosmosDBStorage(builder.Configuration);
//builder.Services.AddEFStorage(builder.Configuration); Can swap out easily
builder.Services.AddAuditServices(builder.Configuration);

// Api services
builder.Services.AddScoped<ICommandHandler<DeleteUserByIdRequest, bool>, DeleteUserByIdRequestCommandHandler>();
builder.Services.DecorateWithValidator<ICommandHandler<DeleteUserByIdRequest, bool>, DeleteUserByIdRequestValidator>();
builder.Services.Decorate<ICommandHandler<DeleteUserByIdRequest, bool>, AuditDeleteUserByIdRequestCommandHandler>();

builder.Services.AddScoped<ICommandHandler<GetUserByIdRequest, User>, GetUserByIdRequestCommandHandler>();
builder.Services.DecorateWithValidator<ICommandHandler<GetUserByIdRequest, User>, GetUserByIdRequestValidator>();

builder.Services.AddScoped<ICommandHandler<InsertUserRequest, User>, InsertUserRequestCommandHandler>();
builder.Services.DecorateWithValidator<ICommandHandler<InsertUserRequest, User>, InsertUserRequestValidator>();

builder.Services.AddScoped<ICommandHandler<SearchUsersByFirstNameRequest, IEnumerable<User>>, SearchUsersByFirstNameRequestCommandHandler>();
builder.Services.DecorateWithValidator<ICommandHandler<SearchUsersByFirstNameRequest, IEnumerable<User>>, SearchUsersByFirstNameRequestValidator>();

builder.Services.AddScoped<ICommandHandler<UpdateUserRequest, User>, UpdateUserRequestCommandHandler>();
builder.Services.DecorateWithValidator<ICommandHandler<UpdateUserRequest, User>, UpdateUserRequestValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
