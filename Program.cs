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

        //git init
        //git add -A
        //git commit -m 'Added my project'
        //git remote add origin git @github.com/MarcinD123/Logistics_project.git
        // git push -u -f origin master
        //https://github.com/MarcinD123/Logistics_project.git

    }

    public static class Dupa
    {
        public static Delivery_projectEntities database = new Delivery_projectEntities();

        public static int Send(string ID)
        {

            try
            {
                int cnt = 1;
                database.Vehicles.Add(new Vehicle(ID, cnt));
                database.SaveChanges();
            }
            catch (Exception)
            {

                return 1;
            }
            return 0;


        }
        public static int Remove(string ID)
        {

            //Vehicle entity = database.Vehicles.First(x => x.VehicleID == ID);
            //var ent2 = database.Vehicles.Where(x => x.VehicleID == ID).First();
            //Vehicle ent3 = database.Vehicles.Find(ID);

            var ent = (from Vehicle in database.Vehicles
                      where Vehicle.VehicleID == ID
                      select Vehicle).First();

            database.Vehicles.Remove(ent);
            database.SaveChanges();
            return 0;
             

        }

    }
}
