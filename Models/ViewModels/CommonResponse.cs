using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Models.ViewModels
{
    public class CommonResponse<T>
    {
        public int Status { get; set; }

        public string message { get; set; }

        public T dateenum { get; set; }

    }
}
