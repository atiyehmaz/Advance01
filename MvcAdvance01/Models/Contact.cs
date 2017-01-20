using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAdvance01.Models
{
    public class Contact
    {


        #region Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contact>
        {
            public Configuration()
            {
                HasRequired(current => current.Company)
                    .WithMany(Company => Company.Contacts)
                    .HasForeignKey(current => current.CompanyID)
                    .WillCascadeOnDelete(false);


                HasRequired(current => current.Customer)
                   .WithMany(customer =>customer.Contacts)
                   .HasForeignKey(current => current.CustomerID)
                   .WillCascadeOnDelete(false);

            }


        }

        #endregion Configuration




        #region Constractor

        public Contact()
        {

        }


        #endregion Constractor

       

        #region properties

        [Key, Required(ErrorMessage = "آی دی مشخصات تماس را وارد نمایید ")
        , DatabaseGenerated(DatabaseGeneratedOption.None),
        DisplayName("آی دی مشخصات تماس")]
        public int ID { get; set; }


        [Required(ErrorMessage = "نام کشور را وارد کنید"), MaxLength(100),
        Column(TypeName = "NVarchar"), DisplayName("نام کشور")]
        public string Country { get; set; }



        [Required(ErrorMessage = "نام استان را وارد کنید"), MaxLength(100),
   Column(TypeName = "NVarchar"), DisplayName("نام استان")]
        public string State { get; set; }


        [Required(ErrorMessage = "نام شهر را وارد کنید"), MaxLength(100),
Column(TypeName = "NVarchar"), DisplayName("نام شهر")]
        public string City { get; set; }



        [Required(ErrorMessage = "آدرس را وارد کنید"), MaxLength(200),
Column(TypeName = "NVarchar"), DisplayName("آدرس ")]
        public string Address { get; set; }



        [Required(ErrorMessage = "شماره ثابت را وارد کنید"), MaxLength(14),
Column(TypeName = "NVarchar"), DisplayName("شماره ثابت ")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "شماره موبایل را وارد کنید"), MaxLength(14),
Column(TypeName = "NVarchar"), DisplayName("شماره موبایل ")]
        public string Mobile { get; set; }




        [Required(ErrorMessage = "شماره فکس را وارد کنید"), MaxLength(14),
Column(TypeName = "NVarchar"), DisplayName("شماره فکس ")]
        public string Fax { get; set; }



        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید"), MaxLength(100),
Column(TypeName = "NVarchar"), DisplayName("آدرس ایمیل ")]
        public string Email { get; set; }



        #endregion properties




        #region Relation

        [DisplayName("آی دی خریدار")]
        public int CustomerID { get; set; }


        [DisplayName("خریدار")]
        public virtual Customer Customer { get; set; }

        /////////////////////////////////////////////////////////////////

        /// <summary>
        /// ارتباط یک به چند با جدول کمپانی
        /// </summary>
      
        [DisplayName("آی دی شرکت")]
        public int CompanyID { get; set; }


        [DisplayName("شرکت")]
        public virtual Company Company { get; set; }

        #endregion Relation


    }
}