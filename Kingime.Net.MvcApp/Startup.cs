﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kingime.Net.MvcApp.Startup))]
namespace Kingime.Net.MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
