namespace FinalProjectAl1.Models
{
    public class GPXPageViewModel
    {
        public List<GPXTrack> GpxTracks { get; set; } = new();
        public List<CustomMarker> CustomMarkers { get; set; } = new();
        public List<DistanceBearingInfo> DistanceBearingData { get; set; } = new();
        public string? MarkerName { get; set; }
        public string? MarkerLat { get; set; }
        public string? MarkerLng { get; set; }
    }

    public class GPXTrack
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Coordinate> Coordinates { get; set; } = new();
        public string Color { get; set; } = "";
    }

    public class Coordinate
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Ele { get; set; }
        public DateTime Time { get; set; }
    }

    public class CustomMarker
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class DistanceBearingInfo
    {
        public string PlaneName { get; set; } = "";
        public int PlaneId { get; set; }
        public List<MarkerData> MarkerData { get; set; } = new();
    }

    public class MarkerData
    {
        public string MarkerName { get; set; } = "";
        public string Distance { get; set; } = "";
        public string Bearing { get; set; } = "";
    }
}
