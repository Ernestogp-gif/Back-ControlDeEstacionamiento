using System.Data.SqlClient;
using System.Data;
using ControlDeEstacionamiento.Model;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ControlDeEstacionamiento.Interfaces;

namespace ControlDeEstacionamiento.DataAcces
{
    public class DataCliente : IRepository<Cliente>
    {
        private readonly string cadenaSQL;
        private readonly string listarClientes;
        private readonly string obtenerCliente;
        private readonly string guardarCliente;
        private readonly string editarCliente;
        private readonly string eliminarCliente;
        //private List<Cliente> clientes = new List<Cliente>();
        public DataCliente(IConfiguration configuration)
        {
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
            listarClientes = configuration.GetSection("SqlQueries:ListarClientes").Value;
            obtenerCliente = configuration.GetSection("SqlQueries:ObtenerCliente").Value;
            guardarCliente = configuration.GetSection("SqlQueries:GuardarCliente").Value;
            editarCliente = configuration.GetSection("SqlQueries:EditarCliente").Value;
            eliminarCliente = configuration.GetSection("SqlQueries:EliminarCliente").Value;
        }
        public async Task<IEnumerable<Cliente>> GetAll()
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

                return await Task.FromResult(clientes);
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
        
        public async Task<Cliente> GetById(string DNI)
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    string consulta = obtenerCliente;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DNI", DNI);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dni = reader["DNI"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            string apellido = reader["Apellido"].ToString();
                            string telefono = reader["Telefono"].ToString();

                            clientes.Add(new Cliente
                            {
                                DNI = dni,
                                Nombre = nombre,
                                Apellido = apellido,
                                Telefono = telefono,
                            });
                        }
                    }
                }

                cliente = clientes.Where(item => item.DNI == DNI).FirstOrDefault();

                return await Task.FromResult(clientes.FirstOrDefault(p => p.DNI == DNI));
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


        /*
        public async Task<Cliente> Create(Cliente entity)
        {            
            clientes.Add(entity);
            return await Task.FromResult(entity);
        }

        
        public async Task<Cliente> Update(int id, Cliente entity)
        {
            var existing = await GetById(id);
            if (existing != null)
            {
                existing.Nombre = entity.Nombre;
                // Actualizar otros campos según sea necesario
            }
            return await Task.FromResult(existing);
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await GetById(id);
            if (persona != null)
            {
                clientes.Remove(persona);
                return true;
            }
            return false;
        }

        */
        /*
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
        */
    }
}
