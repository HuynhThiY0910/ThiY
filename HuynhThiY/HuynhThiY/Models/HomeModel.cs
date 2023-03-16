using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuynhThiY.Context;

namespace HuynhThiY.Models
{
    public class HomeModel
    {
        public List<Category> ListCategory { get; set; }
        public List<product> ListProduct { get; set; }
    }
}