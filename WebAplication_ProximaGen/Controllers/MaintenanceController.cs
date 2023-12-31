﻿using System;
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
                DataSet dataSet = new DataSet();

                List<Contactos> listacontactos = new List<Contactos>();
                dataSet = wsClient.LeerTipoContactos(0,100);
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    var Contactos = new Contactos
                    {
                        TipoContactos_idTipoContacto = int.Parse(dr["idTipoContacto"].ToString()),
                        descripcionContacto = dr["descripcionTipoContacto"].ToString()
                    };
                    listacontactos.Add(Contactos);
                }

                TempData["listaTipoContacto"] = listacontactos;

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
                return View("ErrorView");
            }
        }

        public List<Status> LeerEstados(int inicio, int final)
        {
            try
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
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult Permissions()
        {
            try
            {
                var permisos = LeerPermisos(0, 100);
                TempData["Permisos"] = permisos;
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

        public List<Permissions> LeerPermisos(int inicio, int final)
        {
            try
            {
                DataSet dsPermiso = new DataSet();
                dsPermiso = wsClient.Leer_Permisos(inicio, final);

                // Convertir los datos a una lista de objetos Permissions
                var permisos = new List<Permissions>();
                foreach (DataRow dr in dsPermiso.Tables[0].Rows)
                {
                    var permiso = new Permissions
                    {
                        idPermiso = int.Parse(dr["idPermiso"].ToString()),
                        permiso = dr["permiso"].ToString()
                    };
                    permisos.Add(permiso);
                }

                // Puedes almacenar la lista de permisos en TempData para que esté disponible en la vista

                return permisos;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult Roles()
        {
            try
            {
                var roles = LeerRoles(0, 100);
                TempData["Roles"] = roles;
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

        public List<Roles> LeerRoles(int inicio, int final)
        {
            try
            {
                DataSet dsRol = new DataSet();
                dsRol = wsClient.LeerRoles(inicio, final);

                // Convertir los datos a una lista de objetos Roles
                var roles = new List<Roles>();
                foreach (DataRow dr in dsRol.Tables[0].Rows)
                {
                    var rol = new Roles
                    {
                        idRol = int.Parse(dr["idRol"].ToString()),
                        descripcionRol = dr["descripcionRol"].ToString()
                    };
                    roles.Add(rol);
                }

                // Puedes almacenar la lista de roles en TempData para que esté disponible en la vista

                return roles;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult Generos()
        {
            try
            {
                var generos = LeerGeneros(0, 100);
                TempData["Generos"] = generos;
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

        public List<Generos> LeerGeneros(int inicio, int final)
        {
            try
            {
                DataSet dsGenero = new DataSet();
                dsGenero = wsClient.LeerGenero(inicio, final);

                // Convertir los datos a una lista de objetos Genero
                var generos = new List<Generos>();
                foreach (DataRow dr in dsGenero.Tables[0].Rows)
                {
                    var genero = new Generos
                    {
                        idGenero = int.Parse(dr["idGenero"].ToString()),
                        genero = dr["genero"].ToString()
                    };
                    generos.Add(genero);
                }

                // Puedes almacenar la lista de generos en TempData para que esté disponible en la vista

                return generos;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult Contactos()
        {
            try
            {
                var contactos = LeerContactos(0); //inicio,fin REVISAR SI DEBE QUEDAR CON PARAMETRO**
                TempData["Contactos"] = contactos;
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

        public List<Contactos> LeerContactos(int idPersona)
        {
            try
            {
                DataSet dsContactos = new DataSet();
                dsContactos = wsClient.Leer_Contactos(idPersona);

                // Convertir los datos a una lista de objetos Contactos
                var contactos = new List<Contactos>();
                foreach (DataRow dr in dsContactos.Tables[0].Rows)
                {
                    var contacto = new Contactos
                    {
                        idContacto = int.Parse(dr["idContacto"].ToString()),
                        descripcionContacto = dr["descripcionContacto"].ToString(),
                        TipoContactos_idTipoContacto = int.Parse(dr["TipoContactos_idTipoContacto"].ToString()),
                        Personas_idPersona = int.Parse(dr["Personas_idPersona"].ToString())
                    };
                    contactos.Add(contacto);
                }

                // Puedes almacenar la lista de contactos en TempData para que esté disponible en la vista

                return contactos;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult TipoContactos()
        {
            try
            {
                var tipocontactos = LeerTipoContacto(0, 100);
                TempData["TipoContactos"] = tipocontactos;
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

        public List<TipoContactos> LeerTipoContacto(int inicio, int final)
        {
            try
            {
                DataSet dsTipoContactos = new DataSet();
                dsTipoContactos = wsClient.LeerTipoContactos(inicio, final);

                // Convertir los datos a una lista de objetos TipoContacto
                var tipocontactos = new List<TipoContactos>();
                foreach (DataRow dr in dsTipoContactos.Tables[0].Rows)
                {
                    var tipocontacto = new TipoContactos
                    {
                        idTipoContacto = int.Parse(dr["idTipoContacto"].ToString()),
                        descripcionTipoContacto = dr["descripcionTipoContacto"].ToString()
                    };
                    tipocontactos.Add(tipocontacto);
                }

                // Puedes almacenar la lista de tipocontacto en TempData para que esté disponible en la vista

                return tipocontactos;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult Tarjetas()
        {
            try
            {
                var tarjetas = LeerTarjetas(0);//0,100

                TempData["Tarjetas"] = tarjetas;
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

        public ActionResult TarjetasPersonal()
        {
            try
            {
                int idPersona = 0;
                int.TryParse(Session["idPersona"].ToString(), out idPersona);
                var tarjetas = LeerTarjetas(idPersona);//0,100

                TempData["Tarjetas"] = tarjetas;

                var model = new Tarjetas();
                model.Personas_idPersona = idPersona;
                return View(model);
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o redirigir a una página de error)
                // Por ejemplo, puedes registrar el error en un archivo de registro:
                // Log.Error(ex);
                return View("ErrorView"); // Puedes crear una vista de error personalizada
            }
        }

        public List<Tarjetas> LeerTarjetas(int idPersona)
        {

            try
            {
                DataSet dsTarjetas = new DataSet();
                DataSet dsPersonas = new DataSet();
                DataSet dsEstados = new DataSet();

                dsTarjetas = wsClient.Leer_Tarjetas(idPersona);
                var tarjetas = new List<Tarjetas>();
                foreach (DataRow dr in dsTarjetas.Tables[0].Rows)
                {
                    var tarjeta = new Tarjetas
                    {
                        idTarjeta = int.Parse(dr["idTarjeta"].ToString()),
                        numeroTarjeta = dr["numeroTarjeta"].ToString(),
                        expiracionMes = int.Parse(dr["expiracionMes"].ToString()),
                        expiracionAnno = int.Parse(dr["expiracionAnno"].ToString()),
                        cvv = dr["cvv"].ToString(),
                        Personas_idPersona = int.Parse(dr["idPersona"].ToString()),
                        Estados_idEstado = int.Parse(dr["idEstado"].ToString())
                    };
                    tarjetas.Add(tarjeta);
                }


                List<Personas> listaPersonas = new List<Personas>();
                dsPersonas = wsClient.GetListadoPersonas();
                foreach (DataRow dr in dsPersonas.Tables[0].Rows)
                {
                    var personas = new Personas
                    {
                        idPersona = int.Parse(dr["idPersona"].ToString()),
                        nombre = dr["nombre"].ToString()
                    };
                    listaPersonas.Add(personas);
                }

                TempData["listaPersonas"] = listaPersonas;

                List<Status> listaEstados = new List<Status>();
                dsEstados = wsClient.LeerEstados(0, 100);
                foreach (DataRow dr in dsEstados.Tables[0].Rows)
                {
                    var estados = new Status
                    {
                        idEstado = int.Parse(dr["idEstado"].ToString()),
                        descripcionEstado = dr["descripcionEstado"].ToString()
                    };
                    listaEstados.Add(estados);
                }

                TempData["listaEstados"] = listaEstados;

                // Puedes almacenar la lista de tarjetas en TempData para que esté disponible en la vista

                return tarjetas;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public ActionResult AsignarPermiso()
        {
            try
            {

                var permisos = LeerPermisos(0, 100);//0,100
                var roles = LeerRoles(0, 100);//0,100
                var permisosXRoles = LeerPermisosXRol(20);

                TempData["listaPermisos"] = permisos;
                TempData["listaRoles"] = roles;
                TempData["permisosXRoles"] = permisosXRoles;

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

        // POST: Maintenance/CreateStatus
        [HttpPost]
        public ActionResult CreateStatus(Status status)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsEstado = new DataSet();

                    dsEstado = wsClient.AgregarEstado(status.descripcionEstado);

                    foreach (DataRow dr in dsEstado.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }



                TempData["response"] = response; TempData["responseCode"] = responseCode;

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
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsEstado = new DataSet();

                    dsEstado = wsClient.ModificarEstado(status.idEstado, status.descripcionEstado);

                    foreach (DataRow dr in dsEstado.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

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
                string response = ""; string responseCode = "";

                if (status.idEstado != 0)
                {
                    DataSet dsEstado = new DataSet();

                    dsEstado = wsClient.EliminarEstado(status.idEstado);

                    foreach (DataRow dr in dsEstado.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Status");
            }
            catch
            {
                return View();
            }
        }

        // POST: Maintenance/CreatePermissions
        [HttpPost]
        public ActionResult CreatePermissions(Permissions permissions)
        {
            try
            {
                string response = ""; string responseCode = "";
                DataSet dsPermiso = new DataSet();

                if (ModelState.IsValid)
                {
                    dsPermiso = wsClient.AgregarPermisos(permissions.permiso);

                    foreach (DataRow dr in dsPermiso.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Permissions");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult UpdatePermissions(Permissions permissions)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsPermiso = new DataSet();

                    dsPermiso = wsClient.ModificarPermisos(permissions.idPermiso, permissions.permiso);

                    foreach (DataRow dr in dsPermiso.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }



                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Permissions");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeletePermissions(Permissions permissions)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (permissions.idPermiso != 0)
                {
                    DataSet dsPermiso = new DataSet();

                    dsPermiso = wsClient.EliminarPermisos(permissions.idPermiso);

                    foreach (DataRow dr in dsPermiso.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);

                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Permissions");
            }
            catch
            {
                return View();
            }
        }

        // POST: Maintenance/CreateRoles

        [HttpPost]
        public ActionResult CreateRoles(Roles roles)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsRol = new DataSet();

                    dsRol = wsClient.AgregarRol(roles.descripcionRol);

                    foreach (DataRow dr in dsRol.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Roles");

            }
            catch
            {

                return View();
            }
        }


        [HttpPost]
        public ActionResult UpdateRoles(Roles roles)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsRol = new DataSet();

                    dsRol = wsClient.ModificarRol(roles.idRol, roles.descripcionRol);

                    foreach (DataRow dr in dsRol.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteRoles(Roles roles)
        {
            try
            {
                string response = ""; string responseCode = "";


                if (roles.idRol != 0)
                {
                    DataSet dsRol = new DataSet();

                    dsRol = wsClient.EliminarRol(roles.idRol);

                    foreach (DataRow dr in dsRol.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }


        // POST: Maintenance/CreateGenero
        [HttpPost]
        public ActionResult CreateGenero(Generos generos)
        {

            try
            {
                string response = ""; string responseCode = "";


                if (ModelState.IsValid)
                {
                    DataSet dsGenero = new DataSet();


                    dsGenero = wsClient.AgregarGenero(generos.genero);

                    foreach (DataRow dr in dsGenero.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }


                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);

                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Generos");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult UpdateGenero(Generos generos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsGenero = new DataSet();

                    dsGenero = wsClient.ModificarGenero(generos.idGenero, generos.genero);

                    foreach (DataRow dr in dsGenero.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Generos");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteGenero(Generos generos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (generos.idGenero != 0)
                {
                    DataSet dsGenero = new DataSet();

                    dsGenero = wsClient.EliminarGenero(generos.idGenero);

                    foreach (DataRow dr in dsGenero.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Generos");
            }
            catch
            {
                return View();
            }
        }

        // POST: Maintenance/CreateContactos
        [HttpPost]
        public ActionResult CreateContactos(Contactos contactos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsContactos = new DataSet();

                    dsContactos = wsClient.AgregarContactos(contactos.descripcionContacto, contactos.TipoContactos_idTipoContacto, contactos.Personas_idPersona);

                    foreach (DataRow dr in dsContactos.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Contactos");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateContactos(Contactos contactos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsContactos = new DataSet();

                    dsContactos = wsClient.ModificarContactos(contactos.idContacto, contactos.descripcionContacto, contactos.TipoContactos_idTipoContacto, contactos.Personas_idPersona);

                    foreach (DataRow dr in dsContactos.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Contactos");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteContactos(Contactos contactos)
        {
            try
            {
                string response = ""; string responseCode = "";
                if (contactos.idContacto != 0)
                {

                    DataSet dsContactos = new DataSet();

                    dsContactos = wsClient.EliminarContactos(contactos.idContacto);

                    foreach (DataRow dr in dsContactos.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Contactos");
            }
            catch
            {
                return View();
            }
        }

        // POST: Maintenance/CreateTipoContactos
        [HttpPost]
        public ActionResult CreateTipoContactos(TipoContactos tipocontactos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsTipoContactos = new DataSet();

                    dsTipoContactos = wsClient.AgregarTipoContacto(tipocontactos.descripcionTipoContacto);

                    foreach (DataRow dr in dsTipoContactos.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }

                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("TipoContactos");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult UpdateTipoContactos(TipoContactos tipocontacto)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsTipoContacto = new DataSet();

                    dsTipoContacto = wsClient.ModificarTipoContacto(tipocontacto.idTipoContacto, tipocontacto.descripcionTipoContacto);

                    foreach (DataRow dr in dsTipoContacto.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("TipoContactos");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteTipoContactos(TipoContactos tipocontactos)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (tipocontactos.idTipoContacto != 0)
                {
                    DataSet dsTipoContactos = new DataSet();

                    dsTipoContactos = wsClient.EliminarTipoContacto(tipocontactos.idTipoContacto);

                    foreach (DataRow dr in dsTipoContactos.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("TipoContactos");
            }
            catch
            {
                return View();
            }
        }

        // POST: Maintenance/CreateTarjetas
        [HttpPost]
        public ActionResult CreateTarjetas(Tarjetas tarjetas)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsTarjetas = new DataSet();

                    dsTarjetas = wsClient.AgregarTarjetas(tarjetas.numeroTarjeta, tarjetas.expiracionMes, tarjetas.expiracionAnno, tarjetas.cvv, tarjetas.Personas_idPersona, tarjetas.Estados_idEstado);

                    foreach (DataRow dr in dsTarjetas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Tarjetas");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateTarjetasPersonal(Tarjetas tarjetas)
        {
            try
            {
                string response = ""; string responseCode = "";
                tarjetas.Estados_idEstado = 1;

                if (ModelState.IsValid)
                {
                    DataSet dsTarjetas = new DataSet();

                    dsTarjetas = wsClient.AgregarTarjetas(tarjetas.numeroTarjeta, tarjetas.expiracionMes, tarjetas.expiracionAnno, tarjetas.cvv, tarjetas.Personas_idPersona, tarjetas.Estados_idEstado);

                    foreach (DataRow dr in dsTarjetas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("TarjetasPersonal");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateTarjetas(Tarjetas tarjetas)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsTarjetas = new DataSet();

                    dsTarjetas = wsClient.ModificarTarjetas(tarjetas.idTarjeta, tarjetas.numeroTarjeta, tarjetas.expiracionMes, tarjetas.expiracionAnno, tarjetas.cvv, tarjetas.Personas_idPersona, tarjetas.Estados_idEstado);

                    foreach (DataRow dr in dsTarjetas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Tarjetas");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteTarjetas(int idTarjeta)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (idTarjeta != 0)
                {
                    DataSet dsTarjetas = new DataSet();

                    dsTarjetas = wsClient.EliminarTarjetas(idTarjeta);

                    foreach (DataRow dr in dsTarjetas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Tarjetas");
            }
            catch
            {
                return View();
            }
        }


        //---------------------------------------------------------
        public ActionResult CreatePerson(PersonaUsuario persona)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsPersonas = new DataSet();

                    dsPersonas = wsClient.AgregarPersona_Usuario_Contacto(persona.persona.cedula, persona.persona.nombre, persona.persona.apellido, persona.persona.apellido2, persona.persona.fechaNacimiento, persona.persona.Generos_idGenero, persona.persona.Estados_idEstado,
                        persona.contacto.descripcionContacto, persona.contacto.TipoContactos_idTipoContacto, persona.usuario.nombreUsuarios, persona.usuario.contrasenna, persona.usuario.correo, persona.rol.idRol);

                    foreach (DataRow dr in dsPersonas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Person");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdatePerson(Personas persona, Usuarios usuarios, Contactos contactos, Roles rol)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsPersonas = new DataSet();

                    dsPersonas = wsClient.ModificarPersona_Usuario_Contacto(persona.cedula, persona.nombre, persona.apellido, persona.apellido2, persona.fechaNacimiento, persona.Generos_idGenero, persona.Estados_idEstado,
                        contactos.descripcionContacto, contactos.TipoContactos_idTipoContacto, usuarios.nombreUsuarios, usuarios.contrasenna, usuarios.correo, rol.idRol);

                    foreach (DataRow dr in dsPersonas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Person");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeletePerson(Personas persona, Usuarios usuarios, Contactos contactos, Roles rol)
        {
            try
            {
                string response = ""; string responseCode = "";


                if (persona.cedula != 0)
                {
                    DataSet dsPersonas = new DataSet();

                    dsPersonas = wsClient.EliminarPersona_Usuario_Contacto(persona.cedula, persona.nombre, persona.apellido, persona.apellido2, persona.fechaNacimiento, persona.Generos_idGenero, persona.Estados_idEstado,
                        contactos.descripcionContacto, contactos.TipoContactos_idTipoContacto, usuarios.nombreUsuarios, usuarios.contrasenna, usuarios.correo, rol.idRol);

                    foreach (DataRow dr in dsPersonas.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }


                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("Person");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateAsignarPermiso(AsignarPermisos data)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsEstado = new DataSet();

                    dsEstado = wsClient.AgregarPermisoXRol(data.idPermiso, data.idRol);

                    foreach (DataRow dr in dsEstado.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }



                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("AsignarPermiso");
            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public ActionResult UpdateAsignarPermiso(AsignarPermisos status)
        {
            try
            {
                string response = ""; string responseCode = "";

                if (ModelState.IsValid)
                {
                    DataSet dsEstado = new DataSet();

                    dsEstado = wsClient.ModificarPermisoXRol(status.idPermiso, status.idRol);

                    foreach (DataRow dr in dsEstado.Tables[0].Rows)
                    {
                        response = dr["response"].ToString();
                        responseCode = dr["OperacionExitosa"].ToString();
                    }

                    // Codificar el mensaje para JavaScript
                    response = HttpUtility.JavaScriptStringEncode(response);
                }
                else
                {
                    response = "Modelo Invalido";
                    responseCode = 0.ToString();
                }



                TempData["response"] = response; TempData["responseCode"] = responseCode;

                return RedirectToAction("AsignarPermiso");
            }
            catch
            {
                return View();
            }
        }

        public List<AsignarPermisos> LeerPermisosXRol(int rol)
        {
            try
            {
                DataSet dsPermisos = new DataSet();
                dsPermisos = wsClient.LeerPermisosXRoles(rol);

                // Convertir los datos a una lista de objetos Status
                var permisosXRol = new List<AsignarPermisos>();
                foreach (DataRow dr in dsPermisos.Tables[0].Rows)
                {
                    var permisoXRol = new AsignarPermisos
                    {
                        idPermiso = int.Parse(dr["Permisos_idPermiso"].ToString()),
                        idRol = int.Parse(dr["Roles_idRol"].ToString()),
                        permiso = dr["permiso"].ToString(),
                        rol = dr["descripcionRol"].ToString()
                    };
                    permisosXRol.Add(permisoXRol);
                }

                // Puedes almacenar la lista de estados en TempData para que esté disponible en la vista

                return permisosXRol;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public ActionResult LeerPermisosXRolQuery(AsignarPermisos rol)
        {
            try
            {
                DataSet dsPermisos = new DataSet();

                int.TryParse(rol.idRol.ToString(), out int idRol);
                dsPermisos = wsClient.LeerPermisosXRoles(idRol);

                var permisos = LeerPermisos(0, 100);//0,100
                var roles = LeerRoles(0, 100);//0,100
                var permisosXRoles = LeerPermisosXRol(idRol);

                TempData["listaPermisos"] = permisos;
                TempData["listaRoles"] = roles;
                TempData["permisosXRoles"] = permisosXRoles;

                return View("AsignarPermiso");

            }
            catch (Exception)
            {

                return View();
            }

        }

    }
}
