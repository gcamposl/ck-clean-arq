using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Application.Mappings;
using Ck.Server.Application.Services;
using Ck.Server.Application.Services.Interfaces;
using Ck.Server.Domain.Repositories;
using Ck.Server.Infra.Data.Context;
using Ck.Server.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ck.Server.Infra.IoC
{
  public static class DependencyInjection
  {

    // injetando depencia para infra
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      // injetando service de database
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("")));

      // injetando service de repository
      services.AddScoped<IPersonRepository, PersonRepository>();

      return services;
    }

    // injetando depencia para services
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddAutoMapper(typeof(DtoToDomainMapping));
      services.AddScoped<IPersonService, PersonService>();

      return services;
    }
  }
}