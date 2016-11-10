using System;
using Tmds.Data;

namespace Tmds.Components
{
    public abstract class Tag
    {
        public int TrackGuid { get; set; }
        public int Subdivision { get; set; }
        public int TerritoryId { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string TagType { get; set; }
        public abstract string DataString { get; set; }
        public int Restrictive { get; set; }
        public bool RestrictionFlag { get; set; }
        public string DelayData { get; set; }
        public string TagUid { get; set; }
        public string Direction { get; set; }
        public DateTime ExpectedReleaseTime { get; set; }
        public string CompList { get; set; }
        public int RefNumPtc { get; set; }
        public string PtcData { get; set; }
        public string NameRequestingTagPlacement { get; set; }
        public bool IsPtcEnforceable { get; set; }
        public float TagMpLeft { get; set; }
        public string TagMpLeftSuffix { get; set; }
        public float TagMpRight { get; set; }
        public string TagMpRightSuffix { get; set; }
        public string TrackName { get; set; }

        public Tracks AffectedTracks { get; protected set; }



    }

    public class SpeedTag
        : Tag
    {

        public SpeedTag()
        {
            AffectedTracks = new Tracks();
        }

        public SpeedTag(tblTrackTagsActive ta)
        {
            CompList = ta.CompList;
            CreateSpeedRestriction = ta.CreateSpeedRestriction ?? false;
            CreateTime = string.IsNullOrEmpty(ta.CreateTime) ? DateTime.MaxValue : DateTime.Parse(ta.CreateTime);
            Creator = ta.Creator;
            DataString = ta.DataString;
            DelayData = ta.DelayData;
            Direction = ta.Direction;
            ExpectedReleaseTime = ta.ExpectedReleaseTime ?? DateTime.MaxValue;
            IsPtcEnforceable = ta.IsPTCEnforceable;
            NameRequestingTagPlacement = ta.NameRequestingTagPlacement;
            PtcData = ta.PTCData;
            RefNumPtc = ta.RefNumPTC ?? 0;
            RestrictionFlag = ta.RestrictionFlag;
            Restrictive = ta.Restrictive ?? 0;
            SpeedTagFlagInfo = ta.SpeedTagFlagInfo;
            SpeedTagReasonCode = ta.SpeedTagReasonCode;
            Subdivision = ta.Subdivision != null ? int.Parse(ta.Subdivision) : 0;
            TagType = ta.TagType;
            TagUid = ta.TagUID;
            TerritoryId = ta.TerritoryID ?? 0;
            TrackGuid = ta.TrackGUID;

            AffectedTracks = new Tracks();

        }

        private string _dataString;
        public int MphPassenger { get; set; }
        public int MphFreight { get; set; }
        public int CurrentTrackGuid { get; set; }
        public float CurrentTrackMpLeft { get; set; }
        public string CurrentTrackMpLeftSuffix { get; set; }
        public float CurrentTrackMpRight { get; set; }
        public string CurrentTrackMpRightSuffix { get; set; }
        public string CurrentTrackName { get; set; }
        public string SpeedTagFlagInfo { get; set; }
        public string SpeedTagReasonCode { get; set; }
        public bool CreateSpeedRestriction { get; set; }
        public bool NoFlags { get; set; }
        public override string DataString
        {
            get
            {
                return _dataString;
            }

            set
            {
                if (TryParseDataString(value))
                {
                    _dataString = value;
                }
                else
                {
                    _dataString = string.Empty;
                }


            }
        }


        private bool TryParseDataString(string data)
        {

            // DataString 
            // 35 |1117.4|1117.9|MAIN 2|False|    30|       |           |    100112       |   1117.901  |          |    1117.804      |      |  MAIN 2
            // PSGR|MP1 |  MP2 |Track |chkNoFlags|FRT|MP1 Suffix|MP2 Suffix|CurrentTrack|CurrentTrackLeftMP|Suffix|CurrentTrackRightMP|Suffix|TrackName

            var elements = data.Split('|');

            MphPassenger = elements[0].ParseValue<int>();
            TagMpLeft = elements[1].ParseValue<float>();
            TagMpRight = elements[2].ParseValue<float>();
            TrackName = elements[3];
            NoFlags = elements[4].ParseValue<bool>();
            MphFreight = elements[5].ParseValue<int>();
            TagMpLeftSuffix = elements[6];
            TagMpRightSuffix = elements[7];
            CurrentTrackGuid = elements[8].ParseValue<int>();
            CurrentTrackMpLeft = elements[9].ParseValue<float>();
            CurrentTrackMpLeftSuffix = elements[10];
            CurrentTrackMpRight = elements[11].ParseValue<float>();
            CurrentTrackMpRightSuffix = elements[12];
            CurrentTrackName = elements[13];

            return true;


        }


    }

    public class CrossingTag
        : Tag
    {

        public CrossingTag()
        {
            AffectedTracks = new Tracks();
        }

        public CrossingTag(tblTrackTagsActive ta)
        {
            
            CompList = ta.CompList;
            CreateTime = string.IsNullOrEmpty(ta.CreateTime) ? DateTime.MaxValue : DateTime.Parse(ta.CreateTime);
            Creator = ta.Creator;
            DataString = ta.DataString;
            DelayData = ta.DelayData;
            Direction = ta.Direction;
            ExpectedReleaseTime = ta.ExpectedReleaseTime ?? DateTime.MaxValue;
            IsPtcEnforceable = ta.IsPTCEnforceable;
            NameRequestingTagPlacement = ta.NameRequestingTagPlacement;
            PtcData = ta.PTCData;
            RefNumPtc = ta.RefNumPTC ?? 0;
            RestrictionFlag = ta.RestrictionFlag;
            Restrictive = ta.Restrictive ?? 0;
            Subdivision = ta.Subdivision != null ? int.Parse(ta.Subdivision) : 0;
            TagType = ta.TagType;
            TagUid = ta.TagUID;
            TerritoryId = ta.TerritoryID ?? 0;
            TrackGuid = ta.TrackGUID;

            AffectedTracks = new Tracks();

        }


        private string _dataString;

        public string CrossingName { get; set; }
        public int ProtectionIndex { get; set; }


        // DelayData
        // XG|1116.90|0|COMMENT.|
        // CODE|MilePost|Minutes|Comments|
        public override string DataString
        {
            get
            {
                return _dataString;
            }

            set
            {
                if (TryParseDataString(value))
                {
                    _dataString = value;
                }
                else
                {
                    _dataString = string.Empty;
                }
            }
        }

        private bool TryParseDataString(string data)
        {
            // DataString
            // 1116.90|ZZZ ROAD|?|1
            // MilePost|Road Name|MP Suffix|Protections|

            var elements = data.Split('|');

            TagMpLeft = elements[0].ParseValue<float>();
            TagMpRight = TagMpLeft;
            CrossingName = elements[1];
            TagMpLeftSuffix = elements[2];
            TagMpRightSuffix = TagMpLeftSuffix;
            ProtectionIndex = elements[3].ParseValue<int>();

            return true;

        }


    }

    public class InfoTag
        : Tag
    {

        private string _dataString;

        public InfoTag()
        {
            AffectedTracks = new Tracks();
        }

        public InfoTag(tblTrackTagsActive ta)
        {
            CompList = ta.CompList;
            CreateTime = string.IsNullOrEmpty(ta.CreateTime) ? DateTime.MaxValue : DateTime.Parse(ta.CreateTime);
            Creator = ta.Creator;
            DataString = ta.DataString;
            DelayData = ta.DelayData;
            Direction = ta.Direction;
            ExpectedReleaseTime = ta.ExpectedReleaseTime ?? DateTime.MaxValue;
            IsPtcEnforceable = ta.IsPTCEnforceable;
            NameRequestingTagPlacement = ta.NameRequestingTagPlacement;
            PtcData = ta.PTCData;
            RefNumPtc = ta.RefNumPTC ?? 0;
            RestrictionFlag = ta.RestrictionFlag;
            Restrictive = ta.Restrictive ?? 0;
            Subdivision = ta.Subdivision != null ? int.Parse(ta.Subdivision) : 0;
            TagType = ta.TagType;
            TagUid = ta.TagUID;
            TerritoryId = ta.TerritoryID ?? 0;
            TrackGuid = ta.TrackGUID;

            AffectedTracks = new Tracks();

        }


        public override string DataString
        {
            get
            {
                return _dataString;
            }

            set
            {
                _dataString = value;
            }
        }
    }


    public class WeatherTag
        : Tag
    {

        private string _dataString;

        public WeatherTag()
        {
            AffectedTracks = new Tracks();

        }

        public WeatherTag(tblTrackTagsActive ta)
        {
            CompList = ta.CompList;
            CreateTime = string.IsNullOrEmpty(ta.CreateTime) ? DateTime.MaxValue : DateTime.Parse(ta.CreateTime);
            Creator = ta.Creator;
            DataString = ta.DataString;
            DelayData = ta.DelayData;
            Direction = ta.Direction;
            ExpectedReleaseTime = ta.ExpectedReleaseTime ?? DateTime.MaxValue;
            IsPtcEnforceable = ta.IsPTCEnforceable;
            NameRequestingTagPlacement = ta.NameRequestingTagPlacement;
            PtcData = ta.PTCData;
            RefNumPtc = ta.RefNumPTC ?? 0;
            RestrictionFlag = ta.RestrictionFlag;
            Restrictive = ta.Restrictive ?? 0;
            Subdivision = ta.Subdivision != null ? int.Parse(ta.Subdivision) : 0;
            TagType = ta.TagType;
            TagUid = ta.TagUID;
            TerritoryId = ta.TerritoryID ?? 0;
            TrackGuid = ta.TrackGUID;

            AffectedTracks = new Tracks();

        }


        public override string DataString
        {
            get
            {
                return _dataString;
            }

            set
            {
                _dataString = value;
            }
        }
    }











}
