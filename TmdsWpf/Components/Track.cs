using System;
using Tmds.Data;

namespace Tmds.Components
{
    public class Track
    {

        public Track()
        {
            Tags = new Tags();
        }

        public Track(tblCompTrack ti)
        {

            Tags = new Tags();

            AbsolutePermissiveBlockPtcUid = ti.AbsolutePermissiveBlockPTCUID ?? 0;
            AdditionalReferenceUid = ti.AdditionalReferenceUID;
            AllowForceOperationsToTwc = ti.AllowForceOperationsToTWC ?? false;
            AllowMainTrackEntrance = ti.AllowMainTrackEntrance ?? false;
            AllowOpposingAuthorityCreationToLeft = ti.AllowOpposingAuthorityCreationToLeft ?? false;
            AllowOpposingAuthorityCreationToRight = ti.AllowOpposingAuthorityCreationToRight ?? false;
            AlternateTrackAbbreviation = ti.AlternateTrackAbbreviation;
            AlternateTrackNames = ti.AlternateTrackNames;
            AltLinkFour = ti.AltLinkFour ?? 0;
            AltLinkOne = ti.AltLinkOne ?? 0;
            AltLinkThree = ti.AltLinkThree ?? 0;
            AltLinkTwo = ti.AltLinkTwo ?? 0;
            AuthorityConfirmationRequired = ti.AuthorityConfirmationRequired ?? false;
            AuthorityType = ti.AuthorityType;
            BlueFlag = ti.BlueFlag ?? false;
            Codeline = ti.Codeline ?? 0;
            ControlPoint = ti.ControlPoint ?? 0;
            DerailmentDetectorCtlBit = ti.DerailmentDetectorCtlBit;
            DerailmentDetectorEnabled = ti.DerailmentDetectorEnabled ?? false;
            DerailmentDetectorIndBit = ti.DerailmentDetectorIndBit;
            DerailmentDetectorInhibited = ti.DerailmentDetectorInhibited ?? false;
            DeviceBlocking = ti.DeviceBlocking ?? false;
            DisallowLeftSignalRequestOnOccupancy = ti.DisallowLeftSignalRequestOnOccupancy ?? false;
            DisallowRightSignalRequestOnOccupancy = ti.DisallowRightSignalRequestOnOccupancy ?? false;
            DisallowTntOnSplit = ti.DisallowTNTOnSplit ?? false;
            EnableAbsolutePermissiveBlock = ti.EnableAbsolutePermissiveBlock ?? false;
            EnableControlledSiding = ti.EnableControlledSiding ?? false;
            EnableNonControlledSiding = ti.EnableNonControlledSiding ?? false;
            EnablePositionReporting = ti.EnablePositionReporting ?? false;
            Fbk = ti.FBK;
            Fbk2 = ti.FBK2;
            Fbz = ti.FBK2;
            Fbz2 = ti.FBZ2;
            FieldBlocking = ti.FieldBlocking ?? false;
            ForceIgnoreTrainDirectionChange = ti.ForceIgnoreTrainDirectionChange ?? false;
            FoulingTrackSpms = ti.FoulingTrackSPMS ?? false;
            FoulTime = ti.FoulTime ?? false;
            GraphicGroup = ti.GraphicGroup ?? 0;
            Guid = ti.UID;
            HazmatAlarming = ti.HAZMATAlarming ?? false;
            HoldingSignalOSLeftBoundReporting = ti.HoldingSignalOSLeftBoundReporting ?? false;
            HoldingSignalOSRightBoundReporting = ti.HoldingSignalOSRightBoundReporting ?? false;
            HoldingSignalSlottingTrack = ti.HoldingSignalSlottingTrack ?? false;
            JointControl = ti.JointControl ?? false;
            LatitudeLeft = (float)(ti.LatitudeLeft ?? 0.0);
            LatitudeRight = (float)(ti.LatitudeRight ?? 0.0);
            LeftAltLink = ti.LeftAltLink ?? 0;
            LeftLimitMPRange = (float)(ti.LeftLimitMPRange ?? 0.0);
            LeftLimitName = ti.LeftLimitName;
            LeftLimitRange = ti.LeftLimitRange ?? 0;
            LeftLink = ti.LeftLink ?? 0;
            LineSegmentGroupUid = ti.LineSegmentGroupUID;
            LongitudeLeft = (float)(ti.LongitudeLeft ?? 0.0);
            LongitudeRight = (float)(ti.LongitudeRight ?? 0.0);
            LossOfShunt = ti.LossOfShunt ?? 0;
            LX = ti.LX ?? 0.0f;
            LY = ti.LY ?? 0.0f;
            MainTrackEntrancePoints = ti.MainTrackEntrancePoints;
            MatchMode = ti.MatchMode ?? false;
            MilepostPrefix = ti.MilepostPrefix;
            MilePostSuffix = ti.MilePostSuffix;
            Name = ti.Name;
            Notes = ti.Notes;
            Ocs = ti.OCS ?? false;
            OSReporting = ti.OSReporting ?? false;
            OverrideLeftTrafficCheck = ti.OverrideLeftTrafficCheck ?? false;
            OverrideRightTrafficCheck = ti.OverrideRightTrafficCheck ?? false;
            PassRedSignalAlertOff = ti.PassRedSignalAlertOff ?? false;
            Pctl = ti.PCTL;
            Pind = ti.PIND;
            PtcBlockId = ti.PTCBlockID ?? 0;
            PtcTrackType = ti.PTCBlockID ?? 0;
            Qctl = ti.QCTL;
            Qind = ti.QIND;
            RailroadUniqueIdentifierName = ti.RailroadUniqueIdentifierName;
            RefuseOpposingAuthoritiesFromLeft = ti.RefuseOpposingAuthoritiesFromLeft ?? false;
            RefuseOpposingAuthoritiesFromRight = ti.RefuseOpposingAuthoritiesFromRight ?? false;
            ReleaseTrainIDTrack = ti.ReleaseTrainIDTrack ?? false;
            RightAltLink = ti.RightAltLink ?? 0;
            RightLimitMPRange = (float)(ti.RightLimitMPRange ?? 0.0);
            RightLimitName = ti.RightLimitName;
            RightLimitRange = ti.RightLimitRange ?? 0;
            RightLink = ti.RightLink ?? 0;
            RouteBlocking = ti.RouteBlocking ?? false;
            RouteName = ti.RouteName;
            RX = (float)(ti.RX ?? 0.0);
            RY = (float)(ti.RY ?? 0.0);
            ScreenRegion = ti.ScreenRegion ?? 0;
            Sctl = ti.SCTL;
            Sind = ti.SIND;
            SlotFieldTraffic = ti.SlotFieldTraffic ?? false;
            SlottingTK = ti.SlottingTK ?? false;
            Subdivision = ti.Subdivision ?? 0;
            SuppressAuthorityRelease = ti.SuppressAuthorityRelease ?? false;
            Tctl = ti.TCTL;
            TerritoryAssignment = ti.TerritoryAssignment ?? 0;
            TimeZone = ti.TimeZone;
            Tind = ti.TIND;
            TizMonitorModeTimeOut = ti.TIZMonitorModeTimeOut ?? 0;
            TmpsCircuitName = ti.TMPSCircuitName;
            TmpsEnabled = ti.TMPSEnabled ?? false;
            TmpsLinkAlt1 = ti.TMPSLinkAlt1 ?? 0;
            TmpsLinkAlt2 = ti.TMPSLinkAlt2 ?? 0;
            TmpsLinkAlt3 = ti.TMPSLinkAlt3 ?? 0;
            TmpsLinkAlt4 = ti.TMPSLinkAlt4 ?? 0;
            TmpsLinkLeft = ti.TMPSLinkLeft ?? 0;
            TmpsLinkRight = ti.TMPSLinkRight ?? 0;
            TrackBlockingReferences = ti.TrackBlockingReferences;
            TrackElevationAscending = ti.TrackElevationAscending ?? false;
            TrackElevationAverage = (float)(ti.TrackElevationAverage ?? 0.0);
            TrackElevationMaximum = (float)(ti.TrackElevationMaximum ?? 0.0);
            TrackIntegrityZone = ti.TrackIntegrityZone ?? false;
            TrackIntegrityZoneName = ti.TrackIntegrityZoneName;
            TrackIntegrityZoneUid = ti.TrackIntegrityZoneUID ?? 0;
            TrackLength = ti.TrackLength ?? 0;
            TrackLock = ti.TrackLock ?? false;
            TrackLockBit = ti.TrackLockBit;
            TrackNameAlias = ti.TrackNameAlias;
            TrackPermit = ti.TrackPermit ?? false;
            TrackSpeedAverage = ti.TrackSpeedAverage ?? 0;
            TrackSpeedMaximum = ti.TrackSpeedMaximum ?? 0;
            TrackSpeedMaximumFreight = ti.TrackSpeedMaximumFreight ?? 0;
            TrackSpeedMaximumPassengar = ti.TrackSpeedMaximumPassengar ?? 0;
            TrackSpeeds = ti.TrackSpeeds;
            TrackTime = ti.TrackTime ?? false;
            TrackUid = ti.TrackUID ?? 0;
            TrackWarrantEnforcementEnabled = ti.TrackWarrantEnforcementEnabled ?? false;
            Traffic = ti.Traffic ?? false;
            TrkName = ti.TrkName;
            TurnOutTrack = ti.TurnOutTrack ?? false;
            Type = ti.Type;

        }


        #region Properties

        #region Common Properties
        public int Guid { get; set; }
        public int ControlPoint { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float LX { get; set; }
        public float LY { get; set; }
        public float RX { get; set; }
        public float RY { get; set; }
        public int LeftLink { get; set; }
        public int RightLink { get; set; }
        public int LeftAltLink { get; set; }
        public int RightAltLink { get; set; }
        public int AltLinkOne { get; set; }
        public int AltLinkTwo { get; set; }
        public int Codeline { get; set; }
        public string Pind { get; set; }
        public string Pctl { get; set; }
        public string Sind { get; set; }
        public string Sctl { get; set; }
        public string Tind { get; set; }
        public string Tctl { get; set; }
        public float LeftLimitMPRange { get; set; }
        public float RightLimitMPRange { get; set; }
        public string AuthorityType { get; set; }
        public string TrkName { get; set; }
        public string LeftLimitName { get; set; }
        public string RightLimitName { get; set; }
        public int TerritoryAssignment { get; set; }
        public int Subdivision { get; set; }
        public bool SlottingTK { get; set; }
        public int TrackLength { get; set; }
        public bool DeviceBlocking { get; set; }
        public bool FieldBlocking { get; set; }
        public bool FoulTime { get; set; }
        public bool TrackPermit { get; set; }
        public bool TrackTime { get; set; }
        public bool Traffic { get; set; }
        public string Fbz { get; set; }
        public string Fbk { get; set; }
        public string TimeZone { get; set; }
        public bool TrackLock { get; set; }
        public string TrackLockBit { get; set; }
        public bool OSReporting { get; set; }
        public byte GraphicGroup { get; set; }
        public byte ScreenRegion { get; set; }
        public byte LossOfShunt { get; set; }
        public bool ReleaseTrainIDTrack { get; set; }
        public bool DisallowTntOnSplit { get; set; }
        public bool BlueFlag { get; set; }
        public bool Ocs { get; set; }
        public string TrackSpeeds { get; set; }
        public bool PassRedSignalAlertOff { get; set; }
        public string Notes { get; set; }
        public string MilePostSuffix { get; set; }
        public bool TurnOutTrack { get; set; }
        public int AltLinkThree { get; set; }
        public int AltLinkFour { get; set; }
        public bool HazmatAlarming { get; set; }
        public string RouteName { get; set; }
        public string AlternateTrackNames { get; set; }
        public string AlternateTrackAbbreviation { get; set; }

        #endregion

        #region Uncommon Properties
        public int  LeftLimitRange { get; set; }
        public int RightLimitRange { get; set; }
        public int TrackUid { get; set; }
        public string Fbz2 { get; set; }
        public string Fbk2 { get; set; }
        public bool SlotFieldTraffic { get; set; }
        public int PtcBlockId { get; set; }
        public bool RefuseOpposingAuthoritiesFromLeft { get; set; }
        public bool RefuseOpposingAuthoritiesFromRight { get; set; }
        public bool AllowOpposingAuthorityCreationToLeft { get; set; }
        public bool AllowOpposingAuthorityCreationToRight { get; set; }
        public bool HoldingSignalSlottingTrack { get; set; }
        public bool HoldingSignalOSLeftBoundReporting { get; set; }
        public bool HoldingSignalOSRightBoundReporting { get; set; }
        public bool OverrideLeftTrafficCheck { get; set; }
        public bool OverrideRightTrafficCheck { get; set; }
        public string TrackBlockingReferences { get; set; }
        public bool MatchMode { get; set; }
        public bool FoulingTrackSpms { get; set; }
        public bool RouteBlocking { get; set; }
        public bool TrackIntegrityZone { get; set; }
        public int TrackIntegrityZoneUid { get; set; }
        public string TrackIntegrityZoneName { get; set; }
        public int TizMonitorModeTimeOut { get; set; }
        public bool AuthorityConfirmationRequired { get; set; }
        public bool AllowMainTrackEntrance { get; set; }
        public string MainTrackEntrancePoints { get; set; }
        public bool AllowForceOperationsToTwc { get; set; }
        public bool EnableAbsolutePermissiveBlock { get; set; }
        public int AbsolutePermissiveBlockPtcUid { get; set; }
        public string LineSegmentGroupUid { get; set; }
        public bool DerailmentDetectorEnabled { get; set; }
        public string DerailmentDetectorIndBit { get; set; }
        public string DerailmentDetectorCtlBit { get; set; }
        public bool DerailmentDetectorInhibited { get; set; }
        public string MilepostPrefix { get; set; }
        public string AdditionalReferenceUid { get; set; }
        public bool EnablePositionReporting { get; set; }
        public string TrackNameAlias { get; set; }
        public bool EnableNonControlledSiding { get; set; }
        public bool EnableControlledSiding { get; set; }
        public bool DisallowLeftSignalRequestOnOccupancy { get; set; }
        public bool DisallowRightSignalRequestOnOccupancy { get; set; }
        public int TrackSpeedAverage { get; set; }
        public int TrackSpeedMaximum { get; set; }
        public float TrackElevationAverage { get; set; }
        public float TrackElevationMaximum { get; set; }
        public bool TrackElevationAscending { get; set; }
        public int TrackSpeedMaximumFreight { get; set; }
        public int TrackSpeedMaximumPassengar { get; set; }
        public string Qind { get; set; }
        public string Qctl { get; set; }
        public int PtcTrackType { get; set; }
        public bool JointControl { get; set; }

        public bool TmpsEnabled { get; set; }
        public string TmpsCircuitName { get; set; }
        public int TmpsLinkLeft { get; set; }
        public int TmpsLinkRight { get; set; }
        public int TmpsLinkAlt1 { get; set; }
        public int TmpsLinkAlt2 { get; set; }
        public int TmpsLinkAlt3 { get; set; }
        public int TmpsLinkAlt4 { get; set; }
        public float LatitudeLeft { get; set; }
        public float LongitudeLeft { get; set; }
        public float LatitudeRight { get; set; }
        public float LongitudeRight { get; set; }
        public bool ForceIgnoreTrainDirectionChange { get; set; }
        public bool SuppressAuthorityRelease { get; set; }
        public bool TrackWarrantEnforcementEnabled { get; set; }
        public string RailroadUniqueIdentifierName { get; set; }
        public Tags Tags { get; private set; }

        #endregion

        #endregion


        public override string ToString()
        {
            return string.Format("{0}, Id={1:D}", GetType(), Guid);
        }

    }
}
