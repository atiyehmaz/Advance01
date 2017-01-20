using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAdvance01.Models
{
    public class Company
    {
        public Company()
        {

        }


        #region properties

        [Key, Required(ErrorMessage = "آی دی را وارد نمایید ")
        , DatabaseGenerated(DatabaseGeneratedOption.None),
        DisplayName("آی دی شرکت")]
        public int ID { get; set; }


        [Required(ErrorMessage = "نام شرکت را وارد کنید"), MaxLength(50),
        Column("CompanyName", TypeName = "NVarchar"), DisplayName("نام شرکت")]
        public string Title { get; set; }


        [Required(ErrorMessage = "نام دسته بندی محصول را وارد کنید"), MaxLength(50),
         Column("CategoryName", TypeName = "NVarchar"), DisplayName("نام دسته بندی محصول")]
        public string Category { get; set; }


        //----------------------------------------------------------
        [DisplayName("نام و فعالیت شرکت")]
        public string DisplayName
        {
            get
            {
                string strResult = string.Format("{0} - {1} - {2}", ID, Title, Category);
                return strResult;
            }
        }


        #endregion properties



        #region Relation

        /// <summary>
        /// ارتباط یک به چند با جدول کانتک
        /// </summary>
        /// 
        [DisplayName(" اطلاعات تماس")]
        public virtual IList<Contact> Contacts { get; set; }

        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ارتباط یک به چند با جدول محصولات
        /// </summary>
        /// 
        [DisplayName(" محصولات ")]
        public virtual IList<Product> Products { get; set; }

        ////////////////////////////////////////////////////////////
        #endregion Relation
    }
}