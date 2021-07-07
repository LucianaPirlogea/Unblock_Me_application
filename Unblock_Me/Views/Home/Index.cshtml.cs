using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Unblock_Me.Models;

namespace Unblock_Me.Views.Home
    {
        public class IndexModel : PageModel
        {
            private readonly ILogger<IndexModel> _logger;

            public IndexModel(ILogger<IndexModel> logger)
            {
                _logger = logger;
            }
           
            private readonly Unblock_MeContext _context;

            public IndexModel(Unblock_MeContext context)
            {
                _context = context;
            }

            public IList<Car> Cars { get; set; }
            [BindProperty(SupportsGet = true)]
            public string SearchString { get; set; }

            
    }
    }