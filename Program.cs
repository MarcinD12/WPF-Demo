using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_project
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Vehicle car1 = new Vehicle("reeeee", 12);
            //database.Vehicles.Add(car1);
            //database.SaveChanges();

            
        }
        
        
    }
    public static class Dupa
    {
        public static void Send()
        {
            
            Delivery_projectEntities database = new Delivery_projectEntities();
            int cnt = 1;            
            database.Vehicles.Add(new Vehicle("xd", cnt));
            database.SaveChanges();
            cnt++;
        }
    }
}
