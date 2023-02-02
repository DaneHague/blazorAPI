using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorAPI.Models
{
    namespace BlazorApp2.Data.Models
    {
        public class CurrencyReference
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }
    }
}
