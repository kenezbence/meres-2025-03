using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class Ad
    {
        public int Id { get; set; }          
        public string Description { get; set; } 
        public int Rooms { get; set; }        
        public int Area { get; set; }         
        public int Floors { get; set; }       
        public Category Category { get; set; } 
        public Seller Seller { get; set; }    
        public bool FreeOfCharge { get; set; } 
        public string ImageUrl { get; set; }  
        public string LatLong { get; set; }   
        public DateTime CreateAt { get; set; } 

        
        public double DistanceTo(double targetLat, double targetLon)
        {
            var parts = LatLong.Split(','); 
            double lat = double.Parse(parts[0]); 
            double lon = double.Parse(parts[1]); 
            double dLat = lat - targetLat;       
            double dLon = lon - targetLon;       
            return Math.Sqrt(dLat * dLat + dLon * dLon); 
        }

       
        public static List<Ad> LoadFromCsv(string fileName)
        {
            var ads = new List<Ad>(); 
            using (var reader = new StreamReader(fileName))
            {
                reader.ReadLine(); 
                while (!reader.EndOfStream) 
                {
                    var line = reader.ReadLine(); 
                    var fields = line.Split(';');

                    var ad = new Ad
                    {
                        Id = int.Parse(fields[0]),         
                        Rooms = int.Parse(fields[1]),     
                        LatLong = fields[2],              
                        Floors = int.Parse(fields[3]),    
                        Area = int.Parse(fields[4]),      
                        Description = fields[5],           
                        FreeOfCharge = fields[6] == "1",   
                        ImageUrl = fields[7],              
                        CreateAt = DateTime.Parse(fields[8]), 
                        Seller = new Seller
                        {
                            Id = int.Parse(fields[9]),     
                            Name = fields[10],             
                            Phone = fields[11]            
                        },
                        Category = new Category
                        {
                            Id = int.Parse(fields[12]),    
                            Name = fields[13]              
                        }
                    };
                    ads.Add(ad); 
                }
            }
            return ads; 
        }
    }
}
