﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webWithAccounts.Models
{
    public class IndawoStat
    {
        public IndawoStat() {
            date = DateTime.Now;
            dayOfWeek = date.DayOfWeek;
        }
        public int id { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public DateTime date { get; set; }
        public int instaCounter { get; set; }
        public int dirCounter { get; set; }

    }
}