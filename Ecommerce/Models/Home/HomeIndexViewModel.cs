using Ecommerce.DAL;
using Ecommerce.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace Ecommerce.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbMyOnlineShoppingEntities1 context = new dbMyOnlineShoppingEntities1();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel createModel(string search, int? page, int pageSize)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel()
            {
                ListOfProducts = data
            };
        }
    }
}