using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }

        public bool? isOK { get; set; }

        public string UserName { get; set; }

    public void OnGet()
        {

        }
        public void OnPost(string inputEmail3, string inputPassword3)
        {
            var c = new ICUTechClient();
            
            var response = c.LoginAsync(new LoginRequest(inputEmail3, inputPassword3, "101.1.0.2")).Result;

            isOK = !response.@return.Contains("ResultCode");

            UserName = inputEmail3;
        }
    }
}
