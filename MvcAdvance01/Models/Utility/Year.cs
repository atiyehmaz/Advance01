using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdvance01.Models.Utility
{
    public class Years
    {
        public Years()
        {

        }

        public int ID { get; set; }

        public String Year { get; set; }



        /// <summary>
        /// ارتباط یک به چند با پایه حقوق
        /// </summary>
        public virtual System.Collections.Generic.IList<baseSalary> BaseSalaries { get; set; }
    }
}