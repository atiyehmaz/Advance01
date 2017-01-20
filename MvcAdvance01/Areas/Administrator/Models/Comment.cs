using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcAdvance01.Areas.Administrator.Models
{
    public class Comment
    {



        #region Configuration

        #endregion Configuration




        #region Constractor

        public Comment()
        {

        }

        #endregion Constractor



        #region properties


        [DisplayName("شماره دیدگاه ")]
        [Display(Name = "شماره دیدگاه")]
        public int ID { get; set; }


        [Required(ErrorMessage = "نام را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام")]
        [Display(Name = "نام")]
        public String Name { get; set; }



        [Required(ErrorMessage = "آدرس پست الکترونیک را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("آدرس پست الکترونیک ")]
        [Display(Name = "آدرس پست الکترونیک")]
        public String Email { get; set; }



        [DisplayName("آدرس وبسایت ")]
        [Display(Name = "آدرس وبسایت")]
        public String Url { get; set; }


        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "دیدگاه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("دیدگاه *")]
        [Display(Name = "دیدگاه *")]
        public String CommentUser { get; set; }



        [DisplayName("تاریخ درج دیدگاه")]
        public Nullable<System.DateTime> PublishDate { get; set; }


        [ScaffoldColumn(false)]
        [DisplayName("دیدگاه مورد تایید است؟")]
        [Display(Name = "دیدگاه مورد تایید است؟")]
        public bool? IsCheked { get; set; }

        #endregion properties




        #region Relation

        [DisplayName("شماره پست ")]
        [Display(Name = "شماره پست")]
        public virtual int postID { get; set; }


        [DisplayName("پست")]
        [Display(Name = "پست")]
        public virtual Post post { get; set; }

        #endregion Relation



        
    }
}