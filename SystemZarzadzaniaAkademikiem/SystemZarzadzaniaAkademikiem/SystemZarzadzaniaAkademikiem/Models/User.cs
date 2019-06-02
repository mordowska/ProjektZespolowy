using System;
using System.Collections.Generic;
using SQLite;
using SystemZarzadzaniaAkademikiem.Enums;

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
        public Sex Sex { set; get; }
        public Floor Floor { set; get; }
        public BedLocation BedLocation { set; get; }
        public SleepTime SleepTime { set; get; }
        public WakeUpTime WakeUpTime { set; get; }
        public HotOrNot HotOrNot { set; get; }
        public Music Music { set; get; }
        public YesNo CleanUp { set; get; }
        public Talkative Talkative { set; get; }
        public StudyField StudyField { set; get; }
        public YesNo Sporting { set; get; }
        public HomeBack HomeBack { set; get; }
        public YesNo Smoking { set; get; }
        public Party Party { set; get; }
        public int RoomNumber { set; get; }
        public bool RoomMate { set; get; }

        public User(List<string> list)
        {
            Name = list[0];
            Lastname = list[1];
            Index = list[2];
            Enum.TryParse(list[3], out Sex sexResult);
            Sex = sexResult;
            Enum.TryParse(list[4], out Floor floorResult);
            Floor = floorResult;
            Enum.TryParse(list[5], out BedLocation bedResult);
            BedLocation = bedResult;
            Enum.TryParse(list[6], out SleepTime sleepTime );
            SleepTime = sleepTime;
            Enum.TryParse(list[7], out WakeUpTime wakeUpTime);
            WakeUpTime = wakeUpTime;
            Enum.TryParse(list[8], out HotOrNot hotOrNot);
            HotOrNot = hotOrNot;
            Enum.TryParse(list[9], out Music music);
            Music = music;
            Enum.TryParse(list[10], out YesNo yesNo);
            CleanUp = yesNo;
            Enum.TryParse(list[11], out Talkative talkative);
            Talkative = talkative;
            Enum.TryParse(list[12], out StudyField studyField);
            StudyField = studyField;
            Enum.TryParse(list[13], out YesNo yesNo2);
            Sporting = yesNo2;
            Enum.TryParse(list[14], out HomeBack homeBack);
            HomeBack = homeBack;
            Enum.TryParse(list[15], out YesNo yesNo3);
            Smoking = yesNo3;
            Enum.TryParse(list[16], out Party party);
            Party = party;
            int.TryParse(list[17], out int result);
            RoomNumber = result;
            bool.TryParse(list[18], out bool boolResult);
            RoomMate = boolResult;
        }
        public User()
        {

        }
    }
}
