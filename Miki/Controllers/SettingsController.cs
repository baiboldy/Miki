using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Miki.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class SettingsController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public SettingsController(IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public void CleanCache() {
            _memoryCache.Dispose();
        }
    }
}
