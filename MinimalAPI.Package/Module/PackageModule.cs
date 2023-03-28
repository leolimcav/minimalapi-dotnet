using Dapper;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Package.Dto;
using Npgsql;

namespace MinimalAPI.Package.Module;

public sealed class PackageModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/package", async ([FromServices]NpgsqlConnection db) =>
        {
            var packages = await db.QueryAsync<RegisterPackageDto>("SELECT * FROM package;").ConfigureAwait(false);

            return Results.Ok(packages);
        });

        app.MapGet("/package/{code}", async([FromServices]NpgsqlConnection db, [FromRoute]string code) =>
        {
            var package = await db.QueryFirstOrDefaultAsync<RegisterPackageDto>("SELECT * FROM package WHERE code = @code", new { code }).ConfigureAwait(false);

            return Results.Ok(package);
        });

        app.MapPost("/package", async ([FromServices]NpgsqlConnection db, [FromBody]RegisterPackageDto dto) => 
        {
           var newPackage = await db.QueryFirstOrDefaultAsync<RegisterPackageDto>(
                   @"INSERT INTO package(code, country, description)
                     VALUES(@code, @country, @description)
                     RETURNING package.*;", dto).ConfigureAwait(false);

           return Results.Created($"/package/{newPackage.PackageId}", newPackage);
        });
    }
}
