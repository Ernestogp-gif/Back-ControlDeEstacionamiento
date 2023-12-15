using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using ControlDeEstacionamiento.Model;
using ControlDeEstacionamiento.DataAcces;
using System.Net;

namespace ControlDeEstacionamiento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public int CrearUsuario(string usuario, string clave)
        {
            int Status = 0;
            try
            {
                byte[] salt = GenerarSal();

                byte[] hashClave = GenerarHashContraseña(clave, salt);

                DataLogin ODataLogin = new DataLogin(_configuration);

                Usuario oUsuario = new Usuario
                {
                    NombreUsuario = usuario,
                    HashClave = hashClave,
                    Sal = salt,
                };

                Status = ODataLogin.GuardarUsuario(oUsuario);

                return Status;
            } 
            catch(Exception ex) 
            {
                Console.WriteLine("Error general:" + ex.ToString());
                return Status;
            }
            finally
            {
                Console.WriteLine("Se ejecuto el metodo CrearUsuario()");
            }
        }

        static byte[] GenerarSal()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        static byte[] GenerarHashContraseña(string clave, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: clave,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 64
            );
        }

        [HttpPost]
        [Route("Autenticar")]
        public int Autenticar([FromBody] Usuario_ request) 
        {
            string usuario = request.NombreUsuario.ToString();

            string clave = request.Clave.ToString();

            int Status = 0;

            DataLogin oDatalogin = new DataLogin(_configuration);

            try
            {
                Usuario oUsuario = oDatalogin.ObtenerUsuario(usuario);

                if (oUsuario != null)
                {
                    bool autenticado = VerificarClave(clave, oUsuario.HashClave, oUsuario.Sal);

                    if (autenticado)
                    {
                        Status = 1;
                        Console.WriteLine("Inicio de sesión exitoso");
                    }
                    else
                    {
                        Console.WriteLine("Credenciales inválidas");
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                }
                return Status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.ToString());
                throw;
            }
            finally 
            {
                Console.WriteLine("Se ejecuto el Controlador Autenticar()");
            }
        }

        static bool VerificarClave(string clave, byte[] hashClaveAlmacenado, byte[] salAlmacenada)
        {
            byte[] hashClaveIngresada = GenerarHashClave(clave, salAlmacenada);

            return hashClaveIngresada.SequenceEqual(hashClaveAlmacenado);
        }

        static byte[] GenerarHashClave(string clave, byte[] sal)
        {
            return KeyDerivation.Pbkdf2(
                password: clave,
                salt: sal,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 64
            );
        }
    }
}
