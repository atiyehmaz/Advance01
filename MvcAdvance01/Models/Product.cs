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
    public class Product
    {



        #region Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Product>
        {
            public Configuration()
            {
                HasRequired(current => current.Company)
                    .WithMany(Company => Company.Products)
                    .HasForeignKey(current => current.CompanyID)
                    .WillCascadeOnDelete(false);


                HasRequired(current => current.ProductCategory)
                   .WithMany(customer => customer.Products)
                   .HasForeignKey(current => current.ProductCategoryID)
                   .WillCascadeOnDelete(false);

            }


        }

        #endregion Configuration




        #region Constractor

        public Product()
        {

        }

        #endregion Constractor



        #region properties



        [Key, Required(ErrorMessage = "آی دی محصول  را وارد نمایید ")
        , DatabaseGenerated(DatabaseGeneratedOption.None),
       DisplayName("آی دی محصول")]
        public int ID { get; set; }


        [Required(ErrorMessage = " بارکد را وارد کنید"),
        DisplayName("بارکد")]
        public Int64 Barcode { get; set; }



        [Required(ErrorMessage = " نام محصول را وارد کنید"), MaxLength(121),
        Column(TypeName = "NVarchar"), DisplayName("نام محصول")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وزن محصول را وارد نمایید")
        , DisplayName("وزن محصول")]
        public int Weight { get; set; }


        [Required(ErrorMessage = "تعداد در بسته را وارد نمایید")
        , DisplayName("تعداد در بسته")]
        public int CountNumber { get; set; }

        #endregion properties




        #region Relation

        [DisplayName("آی دی شرکت")]
        public virtual int CompanyID { get; set; }

        [DisplayName("شرکت")]
        public virtual Company Company { get; set; }

        /////////////////////////////////////////////////////

        [DisplayName("آی دی گروه محصول")]
        public virtual int ProductCategoryID { get; set; }

        [DisplayName("گروه محصول")]
        public virtual ProductCategory ProductCategory { get; set; }

        ///////////////////////////////////////////////////

         [DisplayName("قیمت گذاری")]
        public virtual IList<PriceType> PriceTypes { get; set; }

        #endregion Relation



    }
}