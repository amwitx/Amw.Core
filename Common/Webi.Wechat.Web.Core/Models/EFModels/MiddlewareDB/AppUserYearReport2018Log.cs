using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class AppUserYearReport2018Log
    {
        public string ContractGuid { get; set; }
        public string Username { get; set; }
        public string AppCreateTime { get; set; }
        public int? AppUseDay { get; set; }
        public int? CourseCenterCount { get; set; }
        public int? CourseCityCount { get; set; }
        public int? LearningFootprint { get; set; }
        public int? BurnedCalories { get; set; }
        public string MostSalonDate { get; set; }
        public int? MostSalonCount { get; set; }
        public int? MostSalonOrderCount { get; set; }
        public string EslearningDescription { get; set; }
        public int? TeacherCommentWordLength { get; set; }
        public string TeacherMostCommentWords { get; set; }
        public int? MyClockUsualHour { get; set; }
        public string MyClockLatestDate { get; set; }
        public string MyClockLatestTime { get; set; }
        public int? ClockMonthAvgCount { get; set; }
        public int? ClockUsualHour { get; set; }
        public int? ClockNewYearAvgCount { get; set; }
        public string LoveLearningConstellation { get; set; }
        public string LatestLearningConstellation { get; set; }
        public string LoveWorkingConstellation { get; set; }
        public string BestLearningConstellation { get; set; }
        public string TeacherDistance { get; set; }
        public string ShareImageUrl { get; set; }
    }
}
