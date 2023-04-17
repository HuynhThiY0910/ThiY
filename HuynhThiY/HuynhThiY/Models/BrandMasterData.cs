﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HuynhThiY.Models
{
    public partial class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Hiển thị trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DiscplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUct { get; set; }
        [Display(Name = "Ngày sửa")]
        public Nullable<System.DateTime> UpdatedOnUct { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}