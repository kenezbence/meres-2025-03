using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var ads = Ad.LoadFromCsv("realestates.csv");

            // 1. feladat: Földszinti ingatlanok átlagos alapterülete
            var groundFloorAds = ads.Where(ad => ad.Floors == 0).ToList();
            if (groundFloorAds.Count > 0) // Ha van földszinti ingatlan
            {
                double averageArea = groundFloorAds.Average(ad => ad.Area);
                Console.WriteLine($"Az eladásra kínált földszinti ingatlanok átlagos alapterülete: {averageArea:F2} m2");
            }
            else
            {
                Console.WriteLine("Nincs földszinti ingatlan.");
            }

            // 2. feladat: Legközelebbi tehermentes ingatlan az óvodához
            double targetLat = 47.4164220114023;  
            double targetLon = 19.066342425796986;
            var freeAds = ads.Where(ad => ad.FreeOfCharge).ToList();
            if (freeAds.Count > 0) 
            {
                var closestAd = freeAds.OrderBy(ad => ad.DistanceTo(targetLat, targetLon)).First();
                double distance = closestAd.DistanceTo(targetLat, targetLon);
                Console.WriteLine($"A legközelebbi tehermentes ingatlan id-je: {closestAd.Id}, távolsága: {distance:F2} fok");
            }
            else
            {
                Console.WriteLine("Nincs tehermentes ingatlan.");
            }
        }
    }
}
