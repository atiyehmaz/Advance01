using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Html;

namespace MvcAdvance01.Models
{
    public class Personel
    {



        #region ct
        public Personel()
        {

        }
#endregion 



       #region property
        [Key]
        [Required]
        [DisplayName("شماره")]
        public int ID { get; set; }


      
     
        [DisplayName("کد ملی")]
        public int NID { get; set; }

       
        [DisplayName(" شماره پرسنلی")]
        public int PID { get; set; }


        [Required(ErrorMessage="نام و نام خانوادگی را وارد نمایید")]
        [StringLength(50,ErrorMessage="حداکثر باید 50 کاراکتر باشد ")]
        [TypeConverter("NVarchar(121)")]
        [DisplayName("نام و نام خانوادگی")]
        public string Fullname { get; set; }



        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [StringLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد ")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        [TypeConverter("NVarchar(121)")]
        [DisplayName("ایمیل")]
  
        public string Email { get; set; }


        [Required(ErrorMessage = "تاریخ تولد را وارد نمایید")]
        [DisplayName("تاریخ تولد")]
        public Nullable<System.DateTime> Birtdate { get; set; }


        [Required(ErrorMessage = "موبایل را وارد نمایید")]
        [StringLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد ")]
        [DisplayName("موبایل")]
        public string Mobile { get; set; }


        //[Required(ErrorMessage = "شماره بانک را وارد نمایید")]
        [StringLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد ")]
        [DisplayName("شماره بانک")]
        public string BankID { get; set; }



        /// ارتباط یک به چند با جدول حقوق
        public virtual System.Collections.Generic.IList<Salary> Salaries { get; set; }


       #endregion property

    }
}