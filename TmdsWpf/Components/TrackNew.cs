using System;
using System.Collections.Generic;
using System.Windows;
using Tmds.Data;

namespace Tmds.Components
{
    public class TrackNew 
        : ITrack 
    {

        #region Private Fields



        #endregion

        public TrackNew()
        {
            ComponentLinks = new Dictionary<string, int>();
            MileageDirection = LeftToRightMiles.Indeterminate;
            TrackSpeeds = new Dictionary<string, int>();
        }

        public TrackNew(tblCompTrack ti)
        {
            ComponentLinks = new Dictionary<string, int>();
            MileageDirection = LeftToRightMiles.Indeterminate;
            TrackSpeeds = new Dictionary<string, int>();

            AlternateTrackAbbreviation = ti.AlternateTrackAbbreviation;
            AlternateTrackNames = ti.AlternateTrackNames;

            ComponentLinks.Add(new KeyValuePair<string, int>("AltLinkFour", ti.AltLinkFour ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("AltLinkOne", ti.AltLinkOne ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("AltLinkThree", ti.AltLinkThree ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("AltLinkTwo", ti.AltLinkTwo ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("LeftAltLink", ti.LeftAltLink ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("LeftLink", ti.LeftLink ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("RightAltLink", ti.RightAltLink ?? 0));
            ComponentLinks.Add(new KeyValuePair<string, int>("RightLink", ti.RightLink ?? 0));

            Codeline = ti.Codeline ?? 0;
            ControlPoint = ti.ControlPoint ?? 0;
            GraphicGroup = ti.GraphicGroup ?? 0;
            Guid = ti.UID;

            GeolocationLeft = new Point(ti.LatitudeLeft ?? 0.0, ti.LongitudeLeft ?? 0);
            GeolocationRight = new Point(ti.LatitudeRight ?? 0, ti.LongitudeRight ?? 0);

            LeftLimitName = ti.LeftLimitName;
            MilePostLeft = (float)(ti.LeftLimitMPRange ?? 0.0);
            MilePostRight = (float)(ti.RightLimitMPRange ?? 0.0);
            MilepostPrefix = ti.MilepostPrefix;
            MilePostSuffix = ti.MilePostSuffix;
            Name = ti.Name;
            Notes = ti.Notes;
            RailroadUniqueIdentifierName = ti.RailroadUniqueIdentifierName;
            RightLimitName = ti.RightLimitName;

            ScreenPositionLeft = new Point(ti.LX ?? 0.0, ti.LY ?? 0.0);
            ScreenPositionRight = new Point(ti.RX ?? 0.0, ti.RY ?? 0.0);

            ScreenRegion = ti.ScreenRegion ?? 0;
            SubdivisionId = ti.Subdivision ?? 0;
            TerritoryId = ti.TerritoryAssignment ?? 0;
            TrackElevationAscending = ti.TrackElevationAscending ?? false;
            TrackElevationAverage = (float)(ti.TrackElevationAverage ?? 0.0);
            TrackElevationMaximum = (float)(ti.TrackElevationMaximum ?? 0.0);

            TrackLengthInMiles = Math.Abs(MilePostRight - MilePostLeft);

            TrackNameAlias = ti.TrackNameAlias;
            TrackSpeedAverage = ti.TrackSpeedAverage ?? 0;
            TrackSpeedMaximum = ti.TrackSpeedMaximum ?? 0;
            TrackSpeedMaximumFreight = ti.TrackSpeedMaximumFreight ?? 0;
            TrackSpeedMaximumPassenger = ti.TrackSpeedMaximumPassengar ?? 0;

            TurnOutTrack = ti.TurnOutTrack ?? false;
            Type = ti.Type;

            MileageDirection = GetMileageDirection(MilePostLeft, MilePostRight);

        }

        #region Public Properties

        public string AlternateTrackAbbreviation { get; set; }
        public string AlternateTrackNames { get; set; }
        public int Codeline { get; set; }
        public IDictionary<string, int> ComponentLinks { get; set; }
        public int ControlPoint { get; set; }
        public Point GeolocationLeft { get; set; }
        public Point GeolocationRight { get; set; }
        public byte GraphicGroup { get; set; }
        public int Guid { get; set; }
        public string LeftLimitName { get; set; }
        public Point ScreenPositionLeft { get; set; }
        public Point ScreenPositionRight { get; set; }
        public LeftToRightMiles MileageDirection { get; set; }
        public float MilePostLeft { get; set; }
        public string MilepostPrefix { get; set; }
        public float MilePostRight { get; set; }
        public string MilePostSuffix { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string RailroadUniqueIdentifierName { get; set; }
        public string RightLimitName { get; set; }
        public byte ScreenRegion { get; set; }
        public int SubdivisionId { get; set; }
        public int TerritoryId { get; set; }
        public bool TrackElevationAscending { get; set; }
        public float TrackElevationAverage { get; set; }
        public float TrackElevationMaximum { get; set; }
        public float TrackLengthInMiles { get; set; }
        public string TrackNameAlias { get; set; }
        public int TrackSpeedAverage { get; set; }
        public int TrackSpeedMaximum { get; set; }
        public int TrackSpeedMaximumFreight { get; set; }
        public int TrackSpeedMaximumPassenger { get; set; }
        public IDictionary<string, int> TrackSpeeds { get; set; }
        public bool TurnOutTrack { get; set; }
        public string Type { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}, Id={1:D}", GetType(), Guid);
        }

        private LeftToRightMiles GetMileageDirection(float milepostLeft, float milepostRight)
        {
            if (milepostLeft < milepostRight)
            {
                return LeftToRightMiles.Ascending;
            }
            else if (milepostLeft > milepostRight)
            {
                return LeftToRightMiles.Descending;
            }
            else
            {
                return LeftToRightMiles.Indeterminate;
            }
        }

    }
}
