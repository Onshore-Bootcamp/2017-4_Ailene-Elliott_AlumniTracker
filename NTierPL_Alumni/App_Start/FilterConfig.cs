﻿using System.Web;
using System.Web.Mvc;

namespace NTierPL_Alumni
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
