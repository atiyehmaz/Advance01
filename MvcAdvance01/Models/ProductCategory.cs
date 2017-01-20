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
    public class ProductCategory
    {




        #region Constractor

        public ProductCategory()
        {

        }

        #endregion Constractor



        #region properties

        [Key, Required(ErrorMessage = "آی دی گروه محصول  را وارد نمایید ")
       , DatabaseGenerated(DatabaseGeneratedOption.None),
       DisplayName("آی دی گروه محصول")]
        public int ID { get; set; }



        [Required(ErrorMessage = "گروه محصول را وارد کنید"), MaxLength(50),
        Column("CompanyName", TypeName = "NVarchar"), DisplayName("گروه محصول")]
        public string Title { get; set; }


        #endregion properties




        #region Relation

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