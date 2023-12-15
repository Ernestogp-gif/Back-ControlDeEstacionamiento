using ControlDeEstacionamiento.Model;
using System.Data;
using System.Data.SqlClient;

namespace ControlDeEstacionamiento.DataAcces
{
    public class DataPlaza
    {
        private readonly string cadenaSQL;
        private readonly string listarPlaza;
        private readonly string obtenerPlaza;
        private readonly string guardarPlaza;
        private readonly string editarPlaza;
        private readonly string revocarPlaza;
        private readonly string actualizarPlaza1;
        private readonly string actualizarPlaza2;
        
        public DataPlaza(IConfiguration configuration)
        {
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
            listarPlaza = configuration.GetSection("SqlQueries:ListarPlazas").Value;
            guardarPlaza = configuration.GetSection("SqlQueries:GuardarPlaza").Value;
            editarPlaza = configuration.GetSection("SqlQueries:EditarPlaza").Value;
            revocarPlaza = configuration.GetSection("SqlQueries:RevocarPlaza").Value;
            actualizarPlaza1 = configuration.GetSection("SqlQueries:ActualizarPlaza1").Value;
            actualizarPlaza2 = configuration.GetSection("SqlQueries:ActualizarPlaza2").Value;
        }

        public List<PlazaCliente> ListarPlazas()
        {
            string connectionString = cadenaSQL;

            List<PlazaCliente> oPlazaClientes = new List<PlazaCliente>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = listarPlaza;

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PlazaCliente oPlazaCliente = new PlazaCliente
                                {
                                    CodPlaza = reader["CodPlaza"].ToString(),
                                    estado = reader["estado"].ToString(),
                                    DNI = reader["DNI"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                };

                                oPlazaClientes.Add(oPlazaCliente);
                            }
                        }
                    }
                    conexion.Close();

                }

                return oPlazaClientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el metodo ListarVehiculos()");
            }
        }



        public int Guardar(PlazaCliente oPlazaCliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = guardarPlaza;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodPlaza", oPlazaCliente.CodPlaza);
                    cmd.Parameters.AddWithValue("@estado", oPlazaCliente.estado);
                    cmd.Parameters.AddWithValue("@DNI", oPlazaCliente.DNI);
                    OK = cmd.ExecuteNonQuery();

                    if (OK == 1)
                    {
                        consulta = actualizarPlaza1;
                        cmd.CommandText = consulta;
                        OK = cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                }

                return OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return OK;
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el metodo Guardar()");
            }
        }



        public int Editar(PlazaCliente oPlazaCliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = revocarPlaza;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CodPlaza", oPlazaCliente.CodPlaza == "" ? DBNull.Value : oPlazaCliente.CodPlaza);
                    cmd.Parameters.AddWithValue("@estado", oPlazaCliente.estado);
                    cmd.Parameters.AddWithValue("@DNI", oPlazaCliente.DNI is null ? DBNull.Value : oPlazaCliente.DNI);
                    Console.WriteLine(consulta);
                    OK = cmd.ExecuteNonQuery();

                    if (OK == 1)
                    {
                        consulta = guardarPlaza;
                        cmd.CommandText = consulta;
                        OK = cmd.ExecuteNonQuery();
                    }
                    conexion.Close();
                }

                return OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return OK;
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el metodo Editar()");
            }
        }


        public int Revocar(PlazaCliente oPlazaCliente)
        {
            int OK = 0;
            string consulta = "";
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    consulta = revocarPlaza;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodPlaza", oPlazaCliente.CodPlaza);
                    cmd.Parameters.AddWithValue("@DNI", oPlazaCliente.DNI);
                    OK = cmd.ExecuteNonQuery();

                    if (OK == 1)
                    {
                        consulta = actualizarPlaza2;
                        cmd.CommandText = consulta;
                        OK = cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                }

                return OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return OK;
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el metodo Eliminar()");
            }
        }



    }
}
