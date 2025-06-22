using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_to_Blazor_iteration.Models
{
    public class GPXPageViewModel
    {
        [Required(ErrorMessage = "Marker name is required.")]
        public string MarkerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Latitude is required.")]
        public string MarkerLat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Longitude is required.")]
        public string MarkerLng { get; set; } = string.Empty;

        public List<GPXTrack> GpxTracks { get; set; } = new();

        public List<CustomMarker> CustomMarkers { get; set; } = new();

        public List<DistanceBearingInfo> DistanceBearingData { get; set; } = new();
    }

    public class GPXTrack
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Coordinate> Coordinates { get; set; } = new();
        public string Color { get; set; } = "#000000";
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
        public string Name { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class DistanceBearingInfo
    {
        public string PlaneName { get; set; } = string.Empty;
        public int PlaneId { get; set; }
        public List<MarkerData> MarkerData { get; set; } = new();
    }

    public class MarkerData
    {
        public string MarkerName { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public string Bearing { get; set; } = string.Empty;
    }
}