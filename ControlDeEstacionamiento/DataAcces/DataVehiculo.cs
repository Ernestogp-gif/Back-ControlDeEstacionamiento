using System.Data.SqlClient;
using System.Data;
using ControlDeEstacionamiento.Model;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ControlDeEstacionamiento.DataAcces
{
    public class DataVehiculo
    {
        private readonly string cadenaSQL;
        private readonly string listarVehiculos;
        private readonly string obtenerVehiculo;
        private readonly string guardarVehiculo;
        private readonly string editarVehiculo;
        private readonly string eliminarVehiculo;
        public DataVehiculo(IConfiguration configuration)
        {
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
            listarVehiculos = configuration.GetSection("SqlQueries:ListarVehiculos").Value;
            obtenerVehiculo = configuration.GetSection("SqlQueries:ObtenerVehiculo").Value;
            guardarVehiculo = configuration.GetSection("SqlQueries:GuardarVehiculo").Value;
            editarVehiculo = configuration.GetSection("SqlQueries:EditarVehiculos").Value;
            eliminarVehiculo = configuration.GetSection("SqlQueries:EliminarVehiculos").Value;
        }

        public List<VehiculoCliente> ListarVehiculos()
        {
            string connectionString = cadenaSQL;

            List<VehiculoCliente> oVehiculosCliente = new List<VehiculoCliente>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string consulta = listarVehiculos;

                    using (SqlCommand cmd = new SqlCommand(consulta, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehiculoCliente oVehiculoCliente = new VehiculoCliente
                                {
                                    Placa = reader["Placa"].ToString(),
                                    Modelo = reader["Modelo"].ToString(),
                                    Color = reader["Color"].ToString(),
                                    Marca = reader["Marca"].ToString(),
                                    DNI = reader["DNI"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                };

                                oVehiculosCliente.Add(oVehiculoCliente);
                            }
                        }
                    }
                }

                return oVehiculosCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el metodo ListarVehiculos()");
            }
        }

        

        public VehiculoCliente Obtener(string Placa)
        {
            List<VehiculoCliente> lista = new List<VehiculoCliente>();
            VehiculoCliente oVehiculoCliente = new VehiculoCliente();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = obtenerVehiculo;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Placa", Placa);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculoCliente
                            {
                                Placa = reader["Placa"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                Color = reader["Color"].ToString(),
                                Marca = reader["Marca"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                            });
                        }

                    }
                }

                oVehiculoCliente = lista.Where(item => item.Placa == Placa).FirstOrDefault();

                return oVehiculoCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el metodo Obtener()");
            }
        }


        
        public int Guardar(VehiculoCliente oVehiculoCliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = guardarVehiculo;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Placa", oVehiculoCliente.Placa);
                    cmd.Parameters.AddWithValue("@Modelo", oVehiculoCliente.Modelo);
                    cmd.Parameters.AddWithValue("@Color", oVehiculoCliente.Color);
                    cmd.Parameters.AddWithValue("@Marca", oVehiculoCliente.Marca);
                    cmd.Parameters.AddWithValue("@DNI", oVehiculoCliente.DNI);

                    OK = cmd.ExecuteNonQuery();

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
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el metodo Guardar()");
            }
        }


        
        public int Editar(VehiculoCliente oVehiculoCliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = editarVehiculo;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    
                    cmd.Parameters.AddWithValue("@Placa", oVehiculoCliente.Placa == "" ? DBNull.Value : oVehiculoCliente.Placa);
                    cmd.Parameters.AddWithValue("@Modelo", oVehiculoCliente.Modelo is null ? DBNull.Value : oVehiculoCliente.Modelo);
                    cmd.Parameters.AddWithValue("@Color", oVehiculoCliente.Color is null ? DBNull.Value : oVehiculoCliente.Color);
                    cmd.Parameters.AddWithValue("@Marca", oVehiculoCliente.Marca is null ? DBNull.Value : oVehiculoCliente.Marca);
                    cmd.Parameters.AddWithValue("@DNI", oVehiculoCliente.DNI is null ? DBNull.Value : oVehiculoCliente.DNI);
                    Console.WriteLine(consulta);
                    OK = cmd.ExecuteNonQuery();
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
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el metodo Editar()");
            }
        }

        
        public int Eliminar(VehiculoCliente oVehiculoCliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = eliminarVehiculo;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Placa", oVehiculoCliente.Placa);

                    OK = cmd.ExecuteNonQuery();
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
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el metodo Eliminar()");
            }
        }
        
    }
}
