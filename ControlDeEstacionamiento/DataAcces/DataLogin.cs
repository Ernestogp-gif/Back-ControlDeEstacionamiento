using ControlDeEstacionamiento.Model;
using System.Data.SqlClient;
using System.Data;

namespace ControlDeEstacionamiento.DataAcces
{
    public class DataLogin
    {
        private readonly string cadenaSQL;
        private readonly string InsertarUsuario;
        private readonly string ConsultarUsuario;
        public DataLogin(IConfiguration configuration)
        {
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
            InsertarUsuario = configuration.GetSection("SqlQueries:InsertarUsuario").Value;
            ConsultarUsuario = configuration.GetSection("SqlQueries:ObtenerUsuario").Value;
        }
        public int GuardarUsuario(Usuario oUsuario)
        {
            int Status = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = InsertarUsuario;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NombreUsuario", oUsuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@HashClave", oUsuario.HashClave);
                    cmd.Parameters.AddWithValue("@sal", oUsuario.Sal);

                    Status = cmd.ExecuteNonQuery();

                }
                return Status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return Status;
            }
            finally
            {
                Console.WriteLine("Se ejecuto el metodo GuardarUsuario()");
            }
        }

        public Usuario ObtenerUsuario(string usuario)
        {
            Usuario oUsuario = new Usuario();

            List<Usuario> List = new List<Usuario>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = ConsultarUsuario;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreusuario = reader["NombreUsuario"].ToString();

                            byte[] hashclave = (byte[])reader["HashClave"];

                            byte[] sal = (byte[])reader["Sal"];
                            /*
                            byte[] hashclave = Convert.FromBase64String(reader["HashClave"]);
                            byte[] sal = Convert.FromBase64String(reader["Sal"]);
                            */
                            List.Add(new Usuario
                            {
                                NombreUsuario = nombreusuario,
                                HashClave = hashclave,
                                Sal = sal
                            });
                        }

                    }
                }

                oUsuario = List.Where(item => item.NombreUsuario == usuario).FirstOrDefault();

                return oUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error General: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Se ejecuto el metodo ObtenerUsuario()");
            }
        }
    }
}
