using System;

namespace TimeawarePolylineApp.Entities
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location()
        {
        }

        public Location(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }

        public double DistanceTo(Location targetCoordinates)
        {
            if (targetCoordinates != null)
            {
                var baseRad = Math.PI * this.Latitude / 180;
                var targetRad = Math.PI * targetCoordinates.Latitude / 180;
                var theta = this.Longitude - targetCoordinates.Longitude;
                var thetaRad = Math.PI * theta / 180;

                double dist =
                    Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                    Math.Cos(targetRad) * Math.Cos(thetaRad);
                dist = Math.Acos(dist);

                dist = dist * 180 / Math.PI;
                dist = dist * 60 * 1.1515;

                return dist;
            }
            return 0;
        }
    }
}