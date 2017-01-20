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
    public class Salary
    {

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Salary>
        {
            public Configuration()
            {
                HasRequired(current => current.Personel)
                    .WithMany(PersonelID => PersonelID.Salaries)
                    .HasForeignKey(current => current.PersonelID)
                    .WillCascadeOnDelete(false);


                HasRequired(current => current.Personel)
                    .WithMany(MountID => MountID.Salaries)
                    .HasForeignKey(current => current.MountID)
                    .WillCascadeOnDelete(false);


                HasRequired(current => current.Personel)
                    .WithMany(BaseSalaryID => BaseSalaryID.Salaries)
                    .HasForeignKey(current => current.BaseSalaryID)
                    .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration



        #region CTOR
        public Salary()
        {

        }
        #endregion



        #region properties

        [Key]
        public int ID { get; set; }


        [DisplayName("شماره ماه")]
        public int MountID { get; set; }


        [DisplayName("ماه")]
        public virtual Models.Utility.Mount Mount { get; set; }


        //##########################################################################3

        [Required(ErrorMessage = "تعداد ساعت اضافه کار را وارد نمایید")]
        [DisplayName("تعداد ساعت اضافه کار")]
        [TypeConverter("smallint")]
        public int Ezafekar { get; set; }



        [Required(ErrorMessage = "تعداد روز کاری را وارد نمایید")]
        [DisplayName("تعداد روز کاری")]
        [TypeConverter("smallint")]
        public int WorkDay { get; set; }



        [Required(ErrorMessage = "تعداد روز کاری فعال را وارد نمایید")]
        [DisplayName("تعداد روز کاری فعال")]
        [TypeConverter("smallint")]
        public int ActiveWorkDay { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ پاداش را وارد نمایید")]
        [DisplayName("مبلغ پاداش")]
        public double GiftSalary { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ مزایا را وارد نمایید")]
        [DisplayName("مبلغ مزایا")]
        public double RewardSalary { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ پورسانت را وارد نمایید")]
        [DisplayName("مبلغ پورسانت")]
        public double Porsant { get; set; }


        [Required(ErrorMessage = "ساعت مرخصی را وارد نمایید")]
        [DisplayName("ساعت مرخصی")]
        public int RestTime { get; set; }


        [Required(ErrorMessage = "تعداد مرخصی را وارد نمایید")]
        [DisplayName("تعداد روز مرخصی")]
        public int RestDay { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مساعده را وارد نمایید")]
        [DisplayName("مساعده")]
        public double HelpSalary { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ جریمه را وارد نمایید")]
        [DisplayName("مبلغ جریمه")]
        public double PenaltSalary { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ سفته را وارد نمایید")]
        [DisplayName("مبلغ سفته")]
        public double SaftehPrice { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بدهی سفته را وارد نمایید")]
        [DisplayName("مبلغ بدهی سفته")]
        public double SaftehBedehi { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بدهی را وارد نمایید")]
        [DisplayName("مبلغ بدهی ")]
        public double Bedehi { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Required(ErrorMessage = "مبلغ بن کالا را وارد نمایید")]
        [DisplayName("مبلغ بن کالا ")]
        public double PBon { get; set; }


        [DisplayName("توضیحات")]
        public string Description { get; set; }



        //################################################################

        #region Relation
        /// <summary>
        /// ارتباط یک به چند با جدول کارکنان
        /// </summary>
        [DisplayName("شماره پرسنل ")]
        public int PersonelID { get; set; }


        [DisplayName("پرسنل ")]
        public virtual Models.Personel Personel { get; set; }

        //################################################################
        /// <summary>
        /// ارتباط یک به چند با جدول پایه حقوق
        /// </summary>
        [DisplayName("شماره حقوق پایه")]
        public int BaseSalaryID { get; set; }

        [DisplayName("حقوق پایه")]
        public virtual Models.baseSalary BaseSalary { get; set; }


        #endregion



        #endregion


        #region Clculate

        /// <summary>
        /// محاسبه پایه حقوق
        /// </summary>
        [DisplayName("پایه حقوق")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0ريال}")]
        public double? CalcBaseSalary1
        {
            get
            {
                double? DblResult = (WorkDay * 237475);
                return DblResult;
            }
        }


        /// <summary>
        /// محاسبه ایاب ذهاب
        /// </summary>
        [DisplayName("ایاب ذهاب")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0ريال}")]
        public double? CalcNavSalary
        {
            get
            {
                double? DblResult = ((BaseSalary.NavSalary / 30) * ActiveWorkDay);
                return DblResult;
            }
        }



        /// <summary>
        /// محاسبه اضافه کار  
        /// </summary>
        [DisplayName("محاسبه اضافه کار")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcEzafekar1
        {
            get
            {
                double? DblResult = ((BaseSalary.EzafeTimeSalary * Ezafekar));
                return DblResult;
            }
        }


        /// <summary>
        /// محاسبه حق مسکن  
        /// </summary>
        [DisplayName("محاسبه حق مسکن")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcHomeSalary1
        {
            get
            {
                double? DblResult = ((BaseSalary.HomeSalary));
                return DblResult;
            }
        }



        /// <summary>
        /// محاسبه غیبت و کسر از حقوق   
        /// </summary>
        [DisplayName("محاسبه غیبت و کسر از حقوق")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcGheibat1
        {
            get
            {
                double? DblResult = ((WorkDay - ActiveWorkDay) * BaseSalary.KasrGeibat);
                return DblResult;
            }
        }


        /// <summary>
        /// محاسبه مانده سفته   
        /// </summary>
        [DisplayName("محاسبه مانده سفته")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcMandeSafteh1
        {
            get
            {
                double? DblResult = (SaftehPrice - SaftehBedehi);
                return DblResult;  
            }
        }



        /// <summary>
        /// محاسبه کسورات     
        /// </summary>
        [DisplayName("محاسبه کسورات ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcKosorat1
        {
            get
            {
                double? DblResult = (PBon + CalcGheibat1 + CalcMandeSafteh1 + PenaltSalary + HelpSalary);
                return DblResult;
            }
        }



        /// <summary>
        /// محاسبه مطالبات مرخصی 
        /// </summary>
        [DisplayName("محاسبه مطالبات مرخصی")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcMMorakhsi
        {
            get
            {
                double? DblResult = (BaseSalary.RestSalary - (RestDay * BaseSalary.BaseSalaryDaily) - ((BaseSalary.BaseSalaryDaily / 8) * RestTime));
                return DblResult;
            }
        }



        /// <summary>
        /// محاسبه پرداخت ها     
        /// </summary>
        [DisplayName("محاسبه پرداخت ها ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcPayment1
        {
            get
            {
                double? DblResult = (Porsant + GiftSalary + BaseSalary.BonSalary+ CalcNavSalary+ RewardSalary + CalcMMorakhsi+
                    BaseSalary.HomeSalary + CalcBaseSalary1+ CalcEzafekar1);
                return DblResult;
            }
        }




        /// <summary>
        /// محاسبه قابل پرداخت ها     
        /// </summary>
        [DisplayName("محاسبه  قابل پرداخت ها ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        public double? CalcRealPayments1
        {
            get
            {
                double? DblResult = (CalcPayment1-CalcKosorat1);
                return DblResult;
            }
        }



       


        #endregion Clculate

    }
}