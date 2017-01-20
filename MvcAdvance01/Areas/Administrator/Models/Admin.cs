using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Html;

namespace MvcAdvance01.Areas.Administrator.Models
{
    public class Admin
    {
        

        #region Configuration

		#endregion Configuration




		 #region Constractor

        public Admin ()
	    {

	    }

        #endregion Constractor



        #region properties

        [DisplayName("شماره پست ")]
        [Display(Name="شماره پست")]
        public int ID { get; set; }


        [Required(ErrorMessage="نام ادمین را وارد کنید",AllowEmptyStrings=false)]
        [DisplayName("نام ")]
        [Display(Name = "نام")]
        public String Name { get; set; }



        [Required(ErrorMessage = "نام خانوادگی ادمین را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام خانوادگی ")]
        [Display(Name = "نام خانوادگی")]
        public String Family { get; set; }



        [Required(ErrorMessage = "سن را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("سن ")]
        [Display(Name = "سن")]
        public String Age { get; set; }

        //-----------------------------------------------------------------

        [Required(ErrorMessage = "مدرک تحصیلی اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("مدرک تحصیلی اول ")]
        [Display(Name = "مدرک تحصیلی اول")]
        public String Licence1 { get; set; }


        [Required(ErrorMessage = "مدرک تحصیلی دوم را وارد کنید")]
        [DisplayName("مدرک تحصیلی دوم ")]
        [Display(Name = "مدرک تحصیلی دوم")]
        public String Licence2 { get; set; }


        [Required(ErrorMessage = "مدرک تحصیلی سوم را وارد کنید")]
        [DisplayName("مدرک تحصیلی سوم ")]
        [Display(Name = "مدرک تحصیلی سوم")]
        public String Licence3 { get; set; }

        //----------------------------------------------------------------

        [Required(ErrorMessage = "مهارت اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("مهارت اول ")]
        [Display(Name = "مهارت اول")]
        public String Prof1 { get; set; }



        [Required(ErrorMessage = "مهارت دوم را وارد کنید")]
        [DisplayName("مهارت دوم ")]
        [Display(Name = "مهارت دوم")]
        public String Prof2 { get; set; }


        [Required(ErrorMessage = "مهارت سوم را وارد کنید")]
        [DisplayName("مهارت سوم ")]
        [Display(Name = "مهارت سوم")]
        public String Prof3 { get; set; }

        //-----------------------------------------------------------------

        [Required(ErrorMessage = "علاقه مندی اول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("علاقه مندی اول ")]
        [Display(Name = "علاقه مندی اول")]
        public String Fav1 { get; set; }



        [Required(ErrorMessage = "علاقه مندی دوم را وارد کنید")]
        [DisplayName("علاقه مندی دوم ")]
        [Display(Name = "علاقه مندی دوم")]
        public String Fav2 { get; set; }




        [Required(ErrorMessage = "علاقه مندی سوم را وارد کنید")]
        [DisplayName("علاقه مندی سوم ")]
        [Display(Name = "علاقه مندی سوم")]
        public String Fav3 { get; set; }

        //------------------------------------------------------------------------


        [Required(ErrorMessage = "آدرس پست الکترونیک را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("آدرس پست الکترونیک ")]
        [Display(Name = "آدرس پست الکترونیک")]
        public String Email { get; set; }


        [Required(ErrorMessage = "موبایل را وارد کنید")]
        [DisplayName("موبایل ")]
        [Display(Name = "موبایل")]
        public String Mobile { get; set; }



        [Required(ErrorMessage = "تلفن ثابت را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("تلفن ثابت ")]
        [Display(Name = "تلفن ثابت")]
        public String Phone { get; set; }


        [Required(ErrorMessage = "آدرس را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("آدرس ")]
        [Display(Name = "آدرس")]
        public String Address { get; set; }
     

      
        #endregion properties


		

        #region Relation
        /// <summary>
        /// ارتباط یک به چند با جدول پست
        /// </summary>
        [DisplayName(" پست")]
        [Display(Name = "پست")]
        public virtual IList<MvcAdvance01.Areas.Administrator.Models.Post> Posts { get; set; }


        #endregion Relation

	

	  #region Calculators


        #endregion Calculators



    }
}