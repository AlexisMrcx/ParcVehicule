using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcVehicule.Models
{
    public class VehiculeMotoBuilder : VehiculeBuilder
    {
        public VehiculeMotoBuilder()
        {
            vehicule = new Vehicule();
        }

        public override void BuildNbRoue()
        {
            vehicule.NbRoue = 2;
        }

        public override void BuildType()
        {
            vehicule.type = "MOTO";
        }
    }
}