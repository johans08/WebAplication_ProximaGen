using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication_ProximaGen.Logica;
using WebAplication_ProximaGen.Models;
using WebAplication_ProximaGen.WS_Client;

namespace WebAplication_ProximaGen.Controllers
{
    public class LoginController : Controller
    {

        WS_ProximaGenSoapClient wsClient = new WS_ProximaGenSoapClient();


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(Usuarios user)
        {
            try
            {

                string response = ""; string responseCode = "";
                DataSet dsLogin = new DataSet();

                Cifrados cifrados = new Cifrados();
                string contrasennaCifrada = cifrados.ConvertirMD5(user.contrasenna);
                dsLogin = wsClient.Login(user.nombreUsuarios, contrasennaCifrada);


                if (dsLogin != null && dsLogin.Tables.Count > 0)
                {
                    responseCode = dsLogin.Tables[0].Rows[0]["OperacionExitosa"].ToString();

                    if (responseCode.Equals(Constantes.responsesCode[0].ToString()))
                    {
                        Session["idPersona"] = dsLogin.Tables[0].Rows[0]["idPersona"].ToString();
                        Session["Cedula"] = dsLogin.Tables[0].Rows[0]["Cedula"].ToString();
                        Session["Nombre"] = dsLogin.Tables[0].Rows[0]["Nombre"].ToString();
                        Session["Apellido"] = dsLogin.Tables[0].Rows[0]["Apellido"].ToString();
                        Session["Apellido2"] = dsLogin.Tables[0].Rows[0]["Apellido2"].ToString();
                        Session["FechaNacimiento"] = dsLogin.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                        Session["Usuario"] = dsLogin.Tables[0].Rows[0]["Usuario"].ToString();
                        Session["Rol"] = dsLogin.Tables[0].Rows[0]["Rol"].ToString();
                        Session["idRol"] = dsLogin.Tables[0].Rows[0]["idRol"].ToString();

                        TempData["response"] = response; TempData["responseCode"] = responseCode;
                        return RedirectToAction("Index", "Home");
                    }

                    if (responseCode.Equals(Constantes.responsesCode[1].ToString()))
                    {
                        response = dsLogin.Tables[0].Rows[0]["response"].ToString();
                        response = HttpUtility.JavaScriptStringEncode(response);

                        TempData["response"] = response; TempData["responseCode"] = responseCode;
                    }
                    return View("Login");
                }
                else
                {
                    response = "No hay comunicacion con el servicio web, comunicate con TI";
                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                    return View("Login");
                }
            }
            catch (Exception)
            {

                return View("Login");
            }
        }
    }
}
