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
    public class PostCategory
    {


        #region Configuration

        #endregion Configuration




        #region Constractor

        public PostCategory()
        {

        }

        #endregion Constractor



        #region properties


        [DisplayName("شماره دسته بندی ")]
        [Display(Name = "شماره دسته بندی")]
        public int ID { get; set; }


        [Required(ErrorMessage = "عنوان دسته بندی مطالب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("عنوان دسته بندی مطالب  ")]
        [Display(Name = "عنوان دسته بندی مطالب ")]
        public String Name { get; set; }

        #endregion properties




        #region Relation


        /// <summary>
        /// ارتباط یک به چند با جدول پست
        /// </summary>
        [DisplayName(" پست")]
        [Display(Name = "پست")]
        public virtual IList<MvcAdvance01.Areas.Administrator.Models.Post> Posts { get; set; }


        #endregion Relation




    }
}