using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcVehicule.Models
{
    public class VehiculeDirector
    {
        private static VehiculeDirector instance;

        private VehiculeDirector() { }

        public static VehiculeDirector GetInstance()
        {
            if (instance == null)
            {
                instance = new VehiculeDirector();
            }

            return instance;
        }

        public void Construct(VehiculeBuilder builder)
        {
            builder.BuildNbRoue();
            builder.BuildType();
        }
    }
}