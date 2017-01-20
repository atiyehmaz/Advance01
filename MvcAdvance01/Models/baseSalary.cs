using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAdvance01.Models
{
    public class baseSalary
    {


           #region CTOR
        public baseSalary()
        {

        }
#endregion


         #region properties
        [Key]
        public int ID { get; set; }


       /// <summary>
       /// ارتباط یک به یک با جدول سال
       /// </summary>
     
        [DisplayName("شماره سال")]
        public int YearID { get; set; }


        /// <summary>
        /// ارتباط یک به چند با جدول سال
        /// </summary>
      
        [DisplayName("سال")]
        public virtual Models.Utility.Years Year { get; set; }





        //-----------------------------------------------------------------
        /// <summary>
        /// ارتباط یک به چند با جدول حقوق
        /// </summary>
        [DisplayName("حقوق")]
        public virtual System.Collections.Generic.IList<Salary> Salaries { get; set; }

        //----------------------------------------------------------------

        //#######################################################################

        [Required(ErrorMessage = "پایه حقوق یک روز را وارد نمایید")]
        [DisplayName("پایه حقوق یک روز")]
        [DisplayFormat(ApplyFormatInEditMode=false,DataFormatString="{0:#,##0 ريال}")]
        public double BaseSalaryDaily { get; set; }



        [Required(ErrorMessage = "حق مسکن را وارد نمایید")]
        [DisplayName("حق مسکن")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double HomeSalary { get; set; }


        [Required(ErrorMessage = "ایاب ذهاب را وارد نمایید")]
        [DisplayName("ایاب ذهاب")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال }")]
        public double NavSalary { get; set; }




        [Required(ErrorMessage = "بن کارگری را وارد نمایید")]
        [DisplayName("بن کارگری")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double BonSalary { get; set; }



        [Required(ErrorMessage = "مبلغ اضافه کار ساعتی را وارد نمایید")]
        [DisplayName("مبلغ اضافه کار ساعتی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double EzafeTimeSalary { get; set; }



        [Required(ErrorMessage = "مبلغ مرخصی را وارد نمایید")]
        [DisplayName("مبلغ مرخصی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double RestSalary { get; set; }



        [Required(ErrorMessage = "مبلغ کسر مرخصی را وارد نمایید")]
        [DisplayName("مبلغ کسر مرخصی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double KasrGeibat { get; set; }


        [Required(ErrorMessage = "مبلغ سفته را وارد نمایید")]
        [DisplayName("مبلغ سفته")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double SaftPrice { get; set; }



        [Required(ErrorMessage = "سطح درآمد را وارد نمایید")]
        [DisplayName("سطح درآمد")]
        public string levelPrice { get; set; }

        #endregion
    }
}