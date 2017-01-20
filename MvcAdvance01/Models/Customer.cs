using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAdvance01.Models
{
    public class Customer
    {


        #region Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Customer>
        {
            public Configuration()
            {
                HasRequired(current => current.CustomerType)
                    .WithMany(customerType => customerType.Customers)
                    .HasForeignKey(current => current.CustomerTypeID)
                    .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration




        #region Constractor

        public Customer()
        {

        }
        #endregion Constractor
   



        #region properties



        [Key, Required(ErrorMessage = "آی دی خریدار  را وارد نمایید ")
       , DatabaseGenerated(DatabaseGeneratedOption.None),
       DisplayName("آی دی خریدار")]
        public int ID { get; set; }



        [Required(ErrorMessage = "نام خریدار را وارد کنید"), MaxLength(50),
        Column("CompanyName", TypeName = "NVarchar"), DisplayName("نام خریدار")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Discription { get; set; }

        //---------------------------------------------------------
        [DisplayName("نام و آی دی خریدار")]
        public string DisplarName
        {
            get
            {
                string strResult = string.Format("{0} - {1} ", ID, Title);
                return strResult;
            }
        }


        #endregion properties



        #region Relation

      
        ///////////////////////////////////////////////////////////////////////
      
         [DisplayName("آی دی دسته بندی خریدار")]
        public virtual int CustomerTypeID { get; set; }


         [DisplayName(" دسته بندی خریدار")]
        public virtual CustomerType CustomerType { get; set; }

        ////////////////////////////////////////////////////////////////////////

         [DisplayName(" اطلاعات تماس")]
         public virtual IList<Contact> Contacts { get; set; }

        #endregion Relation
    }
}