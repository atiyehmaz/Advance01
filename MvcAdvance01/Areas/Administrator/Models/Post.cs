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
    public class Post
    {



        #region Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Post>

        {
            public Configuration()
            {
                HasRequired(current => current.Admin)
                    .WithMany(admin => admin.Posts)
                    .HasForeignKey(current => current.AdminID)
                    .WillCascadeOnDelete(false);


                //------------------------------------------

                HasRequired(current => current.PostCategory)
                    .WithMany(PostCategory => PostCategory.Posts)
                    .HasForeignKey(current => current.PostCategoryID)
                    .WillCascadeOnDelete(false);

            }
        }



        #endregion Configuration




        #region Constractor

        public Post()
        {

        }


        #endregion Constractor



        #region properties




        [DisplayName("شماره پست ")]
        [Display(Name = "شماره پست")]
        public int ID { get; set; }


        [Required(ErrorMessage = "نام مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام مطلب  ")]
        [Display(Name = "نام مطلب ")]
        public String Name { get; set; }


        [ScaffoldColumn(false)]
        [DisplayName("نام کاربری ")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }



        [Required(ErrorMessage = "نام نویسنده مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("اثری از")]
        [Display(Name = "اثری از")]
        public String PostWriter { get; set; }
         

        [Required(ErrorMessage = "خلاصه توضیحات مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("خلاصه توضیحات مطلب")]
        [Display(Name = "خلاصه توضیحات مطلب")]
        public String SmallBody { get; set; }


        [AllowHtml]
        [Required(ErrorMessage = "متن کامل مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("متن کامل مطلب")]
        [Display(Name = "متن کامل مطلب")]
        //[DataType(DataType.Html, ErrorMessage = "فرمت متن باید اچ دی ام ال باشد")]
        [DataType(DataType.MultilineText)]
        public String FullBody { get; set; }


        [Required(ErrorMessage = "کلمات کلیدی مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("کلمات کلیدی مطلب")]
        [Display(Name = "کلمات کلیدی مطلب")]
        public String Keyword { get; set; }



        [Required(ErrorMessage = "تاریخ درج مطلب را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ درج مطلب")]
        public Nullable<System.DateTime> PublishDate { get; set; }


        [DisplayName("پست فعال است؟")]
        [Display(Name = "پست فعال است؟")]
        public bool IsActive { get; set; }


        [DisplayName("دیدگاه برای پست فعال است؟")]
        [Display(Name = "دیدگاه برای پست فعال است؟")]
        public bool IsCommentable { get; set; }



        [DisplayName("تصویر پست")]
        [Display(Name = "تصویر پست")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        #endregion properties




        #region Relation


        /// <summary>
        /// ارتباط یک به چند با جدول ادمین
        /// </summary>
        [DisplayName("شماره ادمین ")]
        [Display(Name = "شماره ادمین")]
        public virtual int AdminID { get; set; }


        [DisplayName("نام ادمین ")]
        [Display(Name = "نام ادمین")]
        public virtual Admin Admin { get; set; }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


        /// <summary>
        /// ارتباط یک به چند با جدول دسته بندی پست
        /// </summary>
        [DisplayName("شماره دسته بندی پست ")]
        [Display(Name = "شماره دسته بندی پست")]
        public virtual int PostCategoryID { get; set; }


        [DisplayName("نام دسته بندی پست ")]
        [Display(Name = "نام دسته بندی پست")]
        public virtual PostCategory PostCategory { get; set; }


        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// ارتباط چند به یک با جدول کامنت
        /// </summary>
        [DisplayName("دیدگاه های پست")]
        [Display(Name = "دیدگاه های پست")]
        public virtual IList<MvcAdvance01.Areas.Administrator.Models.Comment> Comments { get; set; }

        #endregion Relation



        
    }
}