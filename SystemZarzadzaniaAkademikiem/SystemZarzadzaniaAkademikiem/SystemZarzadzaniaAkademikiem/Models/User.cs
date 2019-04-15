using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZarzadzaniaAkademikiem.Models
{
    class User
    {
        public int Id;
        public string Name { set; get; }
        public string Lastname { set; get; }
        public string Indeks { set; get; }
        public string Sex { set; get; }
        public int Floor { set; get; }
        public string BedLocation { set; get; }
        public string SleepTime { set; get; }
        public string WakeUpTime { set; get; }
        public string HotOrNot { set; get; }
        public string Music { set; get; }
        public bool CleanUp { set; get; }
        public string Talkative { set; get; }
        public string StudyField { set; get; }
        public bool Sporting { set; get; }
        public string HomeBack { set; get; }
        public bool Smoking { set; get; }
        public string Party { set; get; }
    }
}
