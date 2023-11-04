using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication_ProximaGen.Models;
using WebAplication_ProximaGen.WS_Client;

namespace WebAplication_ProximaGen.Controllers
{
    public class MaintenanceController : Controller
    {
        // Instancia del Web Service
        WS_ProximaGenSoapClient wsClient = new WS_ProximaGenSoapClient();

        public ActionResult Person()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Status()
        {
            try
            {
                var estados = LeerEstados(0, 100);
                TempData["Estados"] = estados;
                return View();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o redirigir a una página de error)
                // Por ejemplo, puedes registrar el error en un archivo de registro:
                // Log.Error(ex);
                return View("ErrorView"); // Puedes crear una vista de error personalizada
            }
        }

        public List<Status> LeerEstados(int inicio, int final)
        {
            DataSet dsEstado = new DataSet();
            dsEstado = wsClient.LeerEstados(inicio, final);

            // Convertir los datos a una lista de objetos Status
            var estados = new List<Status>();
            foreach (DataRow dr in dsEstado.Tables[0].Rows)
            {
                var estado = new Status
                {
                    idEstado = int.Parse(dr["idEstado"].ToString()),
                    descripcionEstado = dr["descripcionEstado"].ToString()
                };
                estados.Add(estado);
            }

            // Puedes almacenar la lista de estados en TempData para que esté disponible en la vista
            
            return estados;
        }




        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult CreateStatus(Status status)
        {
            try
            {
                string response = "";
                DataSet dsEstado = new DataSet();

                dsEstado = wsClient.AgregarEstado(status.descripcionEstado);

                foreach (DataRow dr in dsEstado.Tables[0].Rows)
                {
                    response = dr["response"].ToString();
                }

                // Codificar el mensaje para JavaScript
                response = HttpUtility.JavaScriptStringEncode(response);

                TempData["response"] = response; // Mensaje de respuesta

                return RedirectToAction("Status");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateStatus(Status status)
        {
            try
            {
                string response = "";
                DataSet dsEstado = new DataSet();

                dsEstado = wsClient.ModificarEstado(status.idEstado,status.descripcionEstado);

                foreach (DataRow dr in dsEstado.Tables[0].Rows)
                {
                    response = dr["response"].ToString();
                }

                // Codificar el mensaje para JavaScript
                response = HttpUtility.JavaScriptStringEncode(response);

                TempData["response"] = response; // Mensaje de respuesta

                return RedirectToAction("Status");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteStatus(Status status)
        {
            try
            {
                string response = "";
                DataSet dsEstado = new DataSet();

                dsEstado = wsClient.EliminarEstado(status.idEstado);

                foreach (DataRow dr in dsEstado.Tables[0].Rows)
                {
                    response = dr["response"].ToString();
                }

                // Codificar el mensaje para JavaScript
                response = HttpUtility.JavaScriptStringEncode(response);

                TempData["response"] = response; // Mensaje de respuesta

                return RedirectToAction("Status");
            }
            catch
            {
                return View();
            }
        }

    }
}
