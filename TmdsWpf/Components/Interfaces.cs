using System.Collections.Generic;
using System.Windows;

namespace Tmds.Components
{
    public interface IComponent
    {
        #region Public Properties

        int ControlPoint { get; set; }
        int Guid { get; set; }
        string Name { get; set; }
        System.Windows.Shapes.Rectangle Position { get; set; }
        int SubDivision { get; set; }
        int TerritoryId { get; set; }
        string Type { get; set; }

        #endregion
    }

    public interface ITrack
    {
        #region Public Properties

        string AlternateTrackAbbreviation { get; set; }
        string AlternateTrackNames { get; set; }
        int Codeline { get; set; }
        IDictionary<string, int> ComponentLinks { get; set; }
        int ControlPoint { get; set; }
        Point GeolocationLeft { get; set; }
        Point GeolocationRight { get; set; }
        byte GraphicGroup { get; set; }
        int Guid { get; set; }
        string LeftLimitName { get; set; }
        Point ScreenPositionLeft { get; set; }
        Point ScreenPositionRight { get; set; }
        LeftToRightMiles MileageDirection { get; set; }
        float MilePostLeft { get; set; }
        string MilepostPrefix { get; set; }
        float MilePostRight { get; set; }
        string MilePostSuffix { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
        string RailroadUniqueIdentifierName { get; set; }
        string RightLimitName { get; set; }
        byte ScreenRegion { get; set; }
        int SubdivisionId { get; set; }
        int TerritoryId { get; set; }
        bool TrackElevationAscending { get; set; }
        float TrackElevationAverage { get; set; }
        float TrackElevationMaximum { get; set; }
        float TrackLengthInMiles { get; set; }
        string TrackNameAlias { get; set; }
        int TrackSpeedAverage { get; set; }
        int TrackSpeedMaximum { get; set; }
        int TrackSpeedMaximumFreight { get; set; }
        int TrackSpeedMaximumPassenger { get; set; }
        IDictionary<string, int> TrackSpeeds { get; set; }
        bool TurnOutTrack { get; set; }
        string Type { get; set; }

        #endregion
    }
}