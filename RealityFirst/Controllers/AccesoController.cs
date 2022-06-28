using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RealityFirst.Models;
using RealityFirst.Servicio;
using RealityFirst.Controllers;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace RealityFirst.Controllers
{
    public class AccesoController : Controller
    {
        static string cadenaConnection = "Server=tcp:realityfirst.database.windows.net,1433;Initial Catalog=RealityFirst;Persist Security Info=False;User ID=AlexSky;Password=Pandikwa2016.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IConfiguration config;
        UsuarioServicio usuario;

        public AccesoController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            usuario = new UsuarioServicio(ConnectionString);

        }

        // GET: Acceso
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel Usuario)
        {
            bool registrado;
            string mensaje;

            if (Usuario.Clave == Usuario.ConfirmarClave)
            {
                Usuario.Clave = ConvertirSha256(Usuario.Clave);
            }
            else {
                ViewData["Mensaje"] = "Las contraseñas no coindicen, intentelo nuevamente";
                return View();
            }

            using (SqlConnection connection = new SqlConnection(cadenaConnection)) { 
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", connection);
                cmd.Parameters.AddWithValue("Correo", Usuario.Correo);
                cmd.Parameters.AddWithValue("Clave", Usuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Correo", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel Usuario)
        {
            Usuario.Clave = ConvertirSha256(Usuario.Clave);
            using (SqlConnection connection = new SqlConnection(cadenaConnection))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", connection);
                cmd.Parameters.AddWithValue("Correo", Usuario.Correo);
                cmd.Parameters.AddWithValue("Clave", Usuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                
            }

            if (Usuario.IdUsuario != 0)
            {
                HttpContext.Session.SetInt32("usuario", Usuario.IdUsuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensajes"] = "Usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] resultado = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in resultado)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();   
        }
    }
}
