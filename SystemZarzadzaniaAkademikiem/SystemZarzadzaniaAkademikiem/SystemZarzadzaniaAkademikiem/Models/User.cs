using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class User
    {
        public int Id;
        public string Name { set; get; }
        public string Lastname { set; get; }
        public string Index { set; get; }
        public string Sex { set; get; }
        public string Floor { set; get; }
        public string BedLocation { set; get; }
        public string SleepTime { set; get; }
        public string WakeUpTime { set; get; }
        public string HotOrNot { set; get; }
        public string Music { set; get; }
        public string CleanUp { set; get; }
        public string Talkative { set; get; }
        public string StudyField { set; get; }
        public string Sporting { set; get; }
        public string HomeBack { set; get; }
        public string Smoking { set; get; }
        public string Party { set; get; }
        public int Room { set; get; }
    }
}
