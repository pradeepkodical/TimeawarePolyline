using System;
using TimeawarePolyline.Lib.Utility;

namespace TimeawarePolylineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = @"aittElx|bQejoqk{AU?GWf@IBlIUH~_@q@?rNU?vHM?n[k@H`i@_ACxO[?rCK?TCl@RIvI?WvS?c@bIDUdA\GD~EOElIOHvXi@D~Ia@?DENXEzIDYxOEYvG?M`FEQXa@GD_EU";
            var util = new DistanceServicesUtil();
            var distance = util.GetDistance(str);
            Console.WriteLine(distance);
        }
    }
}
