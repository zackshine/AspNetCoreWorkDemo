using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCore31.Models;

namespace RazorPagesCore31
{
    public class TestEnumModel : PageModel
    {
        [BindProperty]
        public AttributeName AttributeName { get; set; }
        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}