using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class line_up
    {
        protected int LU_ID { get; set; }
        protected string LU_Name { get; set; }
        protected string LU_Surname { get; set; }
        protected string LU_Country { get; set; }
        protected int LF_Status { get; set; }

        public string getActor()
        {
            return $"{LU_Name} {LU_Surname}";
        }
        

    }
}
