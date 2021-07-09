using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcVehicule.Models
{
    public abstract class VehiculeBuilder
    {
        protected Vehicule vehicule;
        public Vehicule Vehicule
        {
            get { return vehicule; }
        }

        public abstract void BuildNbRoue();

        public abstract void BuildType();
    }
}