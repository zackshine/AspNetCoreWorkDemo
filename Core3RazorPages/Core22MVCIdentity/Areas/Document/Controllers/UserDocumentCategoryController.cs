using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core22MVCIdentity.Areas.Document.Controllers
{
    public class LocalUserViewModel
    {
        public int Id { get; set; }
    }
    [Area("Document")]
    public class UserDocumentCategoryController : Controller
    {
        [HttpPost]
        public void RemoveAll(LocalUserViewModel data)
        {
           
        }
    }
}