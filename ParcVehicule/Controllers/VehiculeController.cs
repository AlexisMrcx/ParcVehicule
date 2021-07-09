using ParcVehicule.Models;
using ParcVehicule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcVehicule.Controllers
{
    public class VehiculeController : Controller
    {
        public static VehiculeBuilder VehiculeBuilder { get; set; }
        public static VehiculeDirector VehiculeDirector { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChoixVehicule()
        {
            return View();
        }

        public ActionResult AjoutVehicule(string typeVehicule)
        {
            switch (typeVehicule)
            {
                case "VOITURE":
                    VehiculeBuilder = new VehiculeVoitureBuilder();
                    break;
                case "MOTO":
                    VehiculeBuilder = new VehiculeMotoBuilder();
                    break;
                default:
                    VehiculeBuilder = null;
                    break;
            }

            VehiculeDirector = VehiculeDirector.GetInstance();
            if (VehiculeBuilder != null)
            {
                VehiculeDirector.Construct(VehiculeBuilder);
                return View(VehiculeBuilder.Vehicule);
            } else
            {
                return View("Error");
            }
            
        }

        public ActionResult Enregistrer(Vehicule model)
        {
            int i = 0;

            VehiculeBuilder.Vehicule.Marque = model.Marque;
            VehiculeBuilder.Vehicule.Modele = model.Modele;
            VehiculeBuilder.Vehicule.Puissance = model.Puissance;

            using (DBParcVehiculeEntities db = new DBParcVehiculeEntities())
            {
                VehiculeBuilder.Vehicule.Id = db.Vehicule.ToList().Count;
                db.Vehicule.Add(VehiculeBuilder.Vehicule);
                db.SaveChanges();
            }

            return RedirectToAction("Vehicules");
        }

        public ActionResult Vehicules()
        {
            VehiculeVM vm = new VehiculeVM();

            using(DBParcVehiculeEntities db = new DBParcVehiculeEntities())
            {
                IEnumerable<Vehicule> query = db.Vehicule.OrderBy(v => v.Id);
                vm.ListeVehicule = query.ToList();

            }
            return View(vm);
        }

        public ActionResult Vehicule(int id)
        {
            Vehicule vehicule;
            using(DBParcVehiculeEntities db = new DBParcVehiculeEntities())
            {
                vehicule = db.Vehicule.First(i => i.Id == id);
            }


            return View(vehicule);
        }
    }
}