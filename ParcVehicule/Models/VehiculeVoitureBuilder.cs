using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcVehicule.Models
{
    public class VehiculeVoitureBuilder : VehiculeBuilder
    {
        public VehiculeVoitureBuilder()
        {
            vehicule = new Vehicule();
        }

        public override void BuildNbRoue()
        {
            vehicule.NbRoue = 4;
        }

        public override void BuildType()
        {
            vehicule.type = "VOITURE";
        }
    }
}