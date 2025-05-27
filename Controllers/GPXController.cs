using FinalProjectAl1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace FinalProjectAl1.Controllers
{
    public class GPXController : Controller
    {
        public IActionResult Index()
        {
            var model = new GPXPageViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadGPX([FromForm] IFormFile file, [FromForm] GPXPageViewModel model)
        {
            if (file != null && file.FileName.EndsWith(".gpx", StringComparison.OrdinalIgnoreCase))
            {
                using var stream = file.OpenReadStream();
                using var reader = new StreamReader(stream);
                string gpxText = await reader.ReadToEndAsync();
                var track = ParseGPX(gpxText, file.FileName, model.GpxTracks.Count + 1);
                if (track != null) model.GpxTracks.Add(track);
                else ModelState.AddModelError("", "No valid track data found.");
            }
            else
            {
                ModelState.AddModelError("", "Unsupported file type.");
            }
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMarker([FromForm] GPXPageViewModel model)
        {
            if (!string.IsNullOrEmpty(model.MarkerName) &&
                float.TryParse(model.MarkerLat, out float lat) &&
                float.TryParse(model.MarkerLng, out float lng))
            {
                model.CustomMarkers.Add(new CustomMarker
                {
                    Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    Name = model.MarkerName,
                    Lat = lat,
                    Lng = lng
                });
                model.MarkerName = model.MarkerLat = model.MarkerLng = "";
            }
            else
            {
                ModelState.AddModelError("", "Please enter valid marker details.");
            }
            return View("Index", model);
        }

        private GPXTrack? ParseGPX(string gpxText, string fileName, int id)
        {
            var coordinates = new List<Coordinate>();
            var xml = new XmlDocument();
            xml.LoadXml(gpxText);
            var trkpts = xml.GetElementsByTagName("trkpt");
            foreach (XmlNode trkpt in trkpts)
            {
                if (!float.TryParse(trkpt.Attributes?["lat"]?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float lat) ||
                    !float.TryParse(trkpt.Attributes?["lng"]?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float lng))
                {
                    continue;
                }

                var elevateNode = trkpt.SelectSingleNode("ele");
                float ele = 0;
                if (elevateNode != null) float.TryParse(elevateNode.InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ele);

                var timeNode = trkpt.SelectSingleNode("time");
                if (timeNode == null || !DateTime.TryParse(timeNode.InnerText, out var time)) continue;

                coordinates.Add(new Coordinate { Lat = lat, Lng = lng, Ele = ele, Time = time });
            }

            if (coordinates.Count > 0) return null;

            return new GPXTrack
            {
                Id = id,
                Name = fileName,
                Coordinates = coordinates,
                Color = GetRandomColour()
            };
        }

        private string GetRandomColour()
        {
            var rand = new Random();
            return $"#{rand.Next(0x1000000):X6}";
        }
    }
}
