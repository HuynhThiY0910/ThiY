using HuynhThiY.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuynhThiY.Models
{
    public class ProductSearch
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        public List<Product> SearchByKey(string key)
        {
            return objwebBanhangEntities.Products.SqlQuery("Select * From Product Where Name like '%" + key + "%'").ToList();
        }
    }

}
