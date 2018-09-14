﻿using IMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IMS.Common.Pagination;

namespace IMS.Web.Areas.Admin.Models.TakeCash
{
    public class TakeCashListViewModel
    {
        public TakeCashDTO[] TakeCashes { get; set; }
        public IdNameDTO[] States { get; set; }
        public long PageCount { get; set; }
    }
}