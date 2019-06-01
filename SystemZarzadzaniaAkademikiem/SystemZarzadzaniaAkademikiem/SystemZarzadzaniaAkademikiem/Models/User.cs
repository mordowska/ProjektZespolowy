using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SystemZarzadzaniaAkademikiem.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { set; get; }
        [NotNull]
        public string Lastname { set; get; }
        [NotNull,Unique]
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
        public User(List<string> list)
        {
            Name = list[0];
            Lastname = list[1];
            Index = list[2];
            Sex = list[3];
            Floor = list[4];
            BedLocation = list[5];
            SleepTime = list[6];
            WakeUpTime = list[7];
            HotOrNot = list[8];
            Music = list[9];
            CleanUp = list[10];
            Talkative = list[11];
            StudyField = list[12];
            Sporting = list[13];
            HomeBack = list[14];
            Smoking = list[15];
            Party = list[16];
            int.TryParse(list[17], out int result);
            Room = result;

        }
        public User()
        {

        }
    }
}
