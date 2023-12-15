using System.Data.SqlClient;
using System.Data;
using ControlDeEstacionamiento.Model;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ControlDeEstacionamiento.DataAcces
{
    public class DataCliente
    {
        private readonly string cadenaSQL;
        private readonly string listarClientes;
        private readonly string obtenerCliente;
        private readonly string guardarCliente;
        private readonly string editarCliente;
        private readonly string eliminarCliente;
        public DataCliente(IConfiguration configuration)
        {
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
            listarClientes = configuration.GetSection("SqlQueries:ListarClientes").Value;
            obtenerCliente = configuration.GetSection("SqlQueries:ObtenerCliente").Value;
            guardarCliente = configuration.GetSection("SqlQueries:GuardarCliente").Value;
            editarCliente = configuration.GetSection("SqlQueries:EditarCliente").Value;
            eliminarCliente = configuration.GetSection("SqlQueries:EliminarCliente").Value;
        }

        public List<Cliente> ListarClientes()
        {
            string connectionString = cadenaSQL;

            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string consulta = listarClientes;

                    using (SqlCommand cmd = new SqlCommand(consulta, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dni = reader["DNI"].ToString();
                                string nombre = reader["Nombre"].ToString();
                                string apellido = reader["Apellido"].ToString();
                                string telefono = reader["Telefono"].ToString();

                                Cliente cliente = new Cliente
                                {
                                    DNI = dni,
                                    Nombre = nombre,
                                    Apellido = apellido,
                                    Telefono = telefono,
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }

                return clientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Se ejecuto el metodo ListarClientes()");
            }

            
        }

        

        public Cliente Obtener(string DNICliente)
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente cliente = new Cliente();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = obtenerCliente;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DNI", DNICliente);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dni = reader["DNI"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            string apellido = reader["Apellido"].ToString();
                            string telefono = reader["Telefono"].ToString();

                            lista.Add(new Cliente
                            {
                                DNI = dni,
                                Nombre = nombre,
                                Apellido = apellido,
                                Telefono = telefono,
                            });
                        }

                    }
                }
                
                cliente = lista.Where(item => item.DNI == DNICliente).FirstOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Se ejecuto el metodo Obtener()");
            }
        }

        
        
        public int Guardar(Cliente cliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = guardarCliente;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

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
                Console.WriteLine("Se ejecuto el metodo Guardar()");
            }
        }

        
        
        public int Editar(Cliente cliente)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = editarCliente;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DNI", cliente.DNI == "" ? DBNull.Value : cliente.DNI);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre is null ? DBNull.Value : cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido is null ? DBNull.Value : cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono is null ? DBNull.Value : cliente.Telefono);

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
                Console.WriteLine("Se ejecuto el metodo Editar()");
            }
        }
        

        public int Eliminar(string DNI)
        {
            int OK = 0;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = eliminarCliente;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DNI", DNI);

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
                Console.WriteLine("Se ejecuto el metodo Eliminar()");                
            }
        }        
    }
}
