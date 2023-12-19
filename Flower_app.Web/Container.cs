﻿using Flower_app.Web.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Flower_App1.Services.Shared;

namespace Flower_app.Web
{
    public class Container
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            // Registration of all the database services you have
            container.AddScoped<SharedService>();

            // Registration of SignalR events
            container.AddScoped<IPublishDomainEvents, SignalrPublishDomainEvents>();
        }
    }
}
