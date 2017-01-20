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
    public class PriceType
    {



        #region Configuration

        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PriceType>
        {
            public Configuration()
            {
                HasRequired(current => current.Product)
                    .WithMany(Product => Product.PriceTypes)
                    .HasForeignKey(current => current.ProductID)
                    .WillCascadeOnDelete(false);


                HasRequired(current => current.CustomerType)
                   .WithMany(CustomerType => CustomerType.PriceTypes)
                   .HasForeignKey(current => current.CustomerTypeID)
                   .WillCascadeOnDelete(false);

            }


        }

        #endregion Configuration




        #region Constractor



        #endregion Constractor



        #region properties

        [Key, Required(ErrorMessage = "آی دی را وارد نمایید ")
        , DatabaseGenerated(DatabaseGeneratedOption.None),
       DisplayName("آی دی قیمت گذاری ")]
        public int ID { get; set; }


        [Required(ErrorMessage = "قیمت درب کارخانه را وارد نمایید ")
        , DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("قیمت درب کارخانه ")]
        public double Factory { get; set; }


        [Required(ErrorMessage = "قیمت مصرف کننده را وارد نمایید ")
        , DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("مصرف کننده ")]
        public double Final { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName("تخفیف خرید ")]
        public float? TakhfifKharid { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName("اشانتیون خرید ")]
        public float? Eshantion { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName(" مارجین")]
        public float? Marjin { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
     DisplayName("پروموشن ")]
        public float? Promotion { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
     DisplayName("تبلیغات")]
        public float? Tablighat { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName("ریبیت")]
        public float? Rebate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName("تخفیف نقدی فروش")]
        public float? TakhfifForush { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#0 درصد}"),
        DisplayName("ارزش افزوده")]
        public float? ArzeshAfzude { get; set; }



        [Required(ErrorMessage = "تاریخ شروع مصوب را وارد کنید"),
         DisplayName("تاریخ شروع مصوب")]
        public Nullable<System.DateTime> StartDateLicence { get; set; }


        [Required(ErrorMessage = "تاریخ پایان مصوب را وارد کنید"),
         DisplayName("تاریخ پایان مصوب")]
        public Nullable<System.DateTime> EndDateLicence { get; set; }



        [DisplayName("تاریخ شروع پروموشن")]
        public Nullable<System.DateTime> StartDatePro { get; set; }



        [DisplayName("تاریخ پایان پروموشن")]
        public Nullable<System.DateTime> EndDatePro { get; set; }

        #endregion properties








        #region Relation

        [DisplayName("آی دی گروه فروشگاه")]
        public virtual int CustomerTypeID { get; set; }

        [DisplayName("گروه فروشگاه")]
        public virtual CustomerType CustomerType { get; set; }

        ///////////////////////////////////////////////////////

        [DisplayName("آی دی محصول")]
        public virtual int ProductID { get; set; }

          [DisplayName("محصول")]
        public virtual Product Product { get; set; }

        #endregion Relation




        #region Calculators


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت مصرف کننده بدون ارزش افزوده ")]
        public double? calcFinalWithArzesh
        {
            get
            {
                double? dblResult = (Final * 100 / (100 + ArzeshAfzude));
                return (dblResult);
            }
        }


        //-----------------------------------------------------------------------------------


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت مصوب باارزش افزوده ")]
        public double? calcLicencePriceWhitArzesh
        {
            get
            {
                double? dblLicence = (Final * Marjin) / 100;
                double? dblResult = (Final - dblLicence);
                return (dblResult);
            }
        }

        //----------------------------------------------------------------------------------


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت مصوب بدون ارزش افزوده ")]
        public double? calcLicencePriceWhitoutArzesh
        {
            get
            {
                double? dblLicence = (calcFinalWithArzesh * Marjin) / 100;
                double? dblResult = (calcFinalWithArzesh - dblLicence);
                return (dblResult);
            }
        }
        //----------------------------------------------------------------------------------

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت پروموشن باارزش افزوده ")]
        public double? calcPromotionWhitArzesh
        {
            get
            {
                double? dblPromotion = (calcLicencePriceWhitArzesh * Promotion) / 100;
                double? strResult = (calcLicencePriceWhitArzesh - dblPromotion);
                return (strResult);
            }
        }

        //----------------------------------------------------------------------------

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت پروموشن بدون ارزش افزوده ")]
        public double? calcPromotionWhitoutArzesh
        {
            get
            {
                double? dblPromotion = (calcLicencePriceWhitoutArzesh * Promotion) / 100;
                double? strResult = (calcLicencePriceWhitoutArzesh - dblPromotion);
                return (strResult);
            }
        }

        //----------------------------------------------------------------------------


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت ریبیت باارزش افزوده ")]
        public double? calcRebateWhitArzesh
        {
            get
            {
                double? dblRebate = (calcLicencePriceWhitArzesh * Rebate) / 100;
                double? strResult = (calcLicencePriceWhitArzesh - dblRebate);
                return (strResult);
            }
        }

        //----------------------------------------------------------------------------

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
        DisplayName("محاسبه قیمت ریبیت بدون ارزش افزوده ")]
        public double? calcRebateWhitoutArzesh
        {
            get
            {
                double? dblRebate = (calcLicencePriceWhitoutArzesh * Rebate) / 100;
                double? strResult = (calcLicencePriceWhitoutArzesh - dblRebate);
                return (strResult);
            }
        }

        //----------------------------------------------------------------------------

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
    DisplayName("محاسبه خالص خرید ")]
        public double? calcKhaleseKharid
        {
            get
            {
                double? dblEshantion = Factory / (100 + Eshantion);
                double? dblEshantionPer = dblEshantion * 100;
                double? dblTakhfifKharid = ((dblEshantionPer - (dblEshantionPer * (TakhfifKharid)) / 100));
                double? dblResult = (dblTakhfifKharid);

                return (dblResult);
            }
        }
        //------------------------------------------------------------------------------


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
    DisplayName("محاسبه خالص فروش ")]
        public double? calcKhalesForush
        {
            get
            { 
                double? dblLicene=((Final*Marjin)/100);

                double? dblPromotion = ((calcLicencePriceWhitArzesh * Promotion) / 100);

                double? dblRebate = ((calcLicencePriceWhitArzesh * Rebate) / 100);

                double? dblTakhfifNaghdi=((Final*TakhfifForush)/100);

                  double? dblTakhfifTablighat=((Final*Tablighat)/100);

                double? dblTakhfifat=(dblLicene + dblPromotion + dblRebate + dblTakhfifNaghdi + dblTakhfifTablighat);

                double? dblResult = Final - dblTakhfifat;
                return(dblResult);
            }
        }
        //------------------------------------------------------------------------

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}"),
 DisplayName("محاسبه سود و زیان ")]
        public double? calcSoodeForush
        {
            get 
            {
                double? dblResult = ((calcKhalesForush - calcKhaleseKharid));
                return (dblResult);
            }
        }
        #endregion Calculators


    }
}