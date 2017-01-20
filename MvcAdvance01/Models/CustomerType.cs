using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAdvance01.Models
{
    public class CustomerType
    {
        public CustomerType()
        {

        }

        

        #region properties

        [Key, Required(ErrorMessage = "آی دی دسته بندی خریداران را وارد نمایید ")
       , DatabaseGenerated(DatabaseGeneratedOption.None),
       DisplayName("آی دی دسته بندی خریدار")]
        public int ID { get; set; }



        [Required(ErrorMessage = "نام دسته بندی خریدار را وارد کنید"), MaxLength(50),
        Column("CompanyName", TypeName = "NVarchar"), DisplayName("نام دسته بندی خریدار")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Discription { get; set; }

        //---------------------------------------------------------
        [DisplayName("نام و آی دی دسته بندی خریدار")]
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

        [DisplayName("خریداران")]
        public virtual IList<Customer> Customers { get; set; }

        //////////////////////////////////////////////////////////////

         [DisplayName("قیمت گذاری")]
        public virtual IList<PriceType> PriceTypes { get; set; }

        #endregion Relation
    }
}