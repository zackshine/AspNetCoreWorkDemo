﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAuthentication.Models
{
    public static class UrlHelperExtensions
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/Index");
            }

            return localUrl;
        }
    }
}
