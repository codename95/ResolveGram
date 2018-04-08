using ResolveGram.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResolveGram.Models.ViewModel
{
    public class HomeDashBoardViewModel
    {
        public int TodayTask { get; set; }
        public int TommorrowsTask { get; set; }
        public int NestWeekTask { get; set; }
        public int CompletedTask { get; set; }
        public string VideoCode { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }
    }
}