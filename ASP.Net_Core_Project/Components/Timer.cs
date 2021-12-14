using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Components
{

    public class Timer : ViewComponent
    {
        public string Invoke()
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        }
    }
}
