﻿using Kingime.Net.Core.Mvc;
using System.Web;
using System.Web.Mvc;

namespace Kingime.Net.MvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TicketAuthorizeAttribute());
        }
    }
}
