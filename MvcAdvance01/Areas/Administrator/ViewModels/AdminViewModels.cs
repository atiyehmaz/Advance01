using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;	

namespace MvcAdvance01.Areas.Administrator.ViewModels
{
    public class AdminViewModels
    {

        #region Constractor

        public AdminViewModels()
        {

        }

        #endregion Constractor




        #region properties


        [DisplayName("آی دی ویو مدل ")]
        [Display(Name = "آی دی ویو مدل")]
        public int ID { get; set; }

        public MvcAdvance01.Areas.Administrator.Models.Admin Admin { get; set; }

        public IList<MvcAdvance01.Areas.Administrator.Models.PostCategory> PostCategories { get; set; }

        public IList<MvcAdvance01.Areas.Administrator.Models.Post> Posts { get; set; }

        public IList<MvcAdvance01.Areas.Administrator.Models.Comment> Comments { get; set; }

        public IList<MvcAdvance01.Models.PriceType> Prices { get; set; }

        public IList<MvcAdvance01.Models.ApplicationUser> Users { get; set; }

        public IList<MvcAdvance01.Models.Customer> Customers { get; set; }


        #endregion properties
    }
}