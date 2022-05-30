using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(bool estado = true)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.LISTAR_ARTICULOS);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Imagen = (string)datos.Lector["ImagenURL"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    if (estado == false && aux.Estado == false) lista.Add(aux);
                    if (estado == true && aux.Estado == true) lista.Add(aux);

                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo modificar)
        {
            // <German>
            // Se me ocurre crear una clase helper del tipo validarDatos para verificar lo que se ingresa
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.MODIFICAR_ARTICULO);

                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@IdMarca", modificar.Marca.ID);
                datos.setearParametro("@IdCategoria", modificar.Categoria.ID);
                datos.setearParametro("@imagenUrl", modificar.Imagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@ID", modificar.ID);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // <German>
                // Modifica consulta usando Propiedad de la clase Diccionario y el metodo setearParametro de la clase AccesoDatos

                //datos.setearConsulta($"INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ('{nuevo.Codigo}', '{nuevo.Nombre}', '{nuevo.Descripcion}', {nuevo.Marca.ID}, {nuevo.Categoria.ID}, '{nuevo.Imagen}', {nuevo.Precio} )");

                datos.setearConsulta(Diccionario.AGREGAR_ARTICULO);

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCategoria", nuevo.Categoria.ID);
                datos.setearParametro("@imagen", nuevo.Imagen);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@estado", 1);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void baja(int ID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.BAJA_ARTICULO);
                datos.setearParametro("@ID", ID);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void alta(int ID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.ALTA_ARTICULO);
                datos.setearParametro("@ID", ID);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void eliminar(int ID) 
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {

                // <German>
                // Modifica consulta usando Propiedad de la clase Diccionario y el metodo setearParametro de la clase AccesoDatos

                //datos.setearConsulta($"delete from  ARTICULOS where Codigo = '{codigo}'");

                datos.setearConsulta(Diccionario.ELIMINAR_ARTICULO);
                datos.setearParametro("@ID", ID);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro, bool estado = true)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = Diccionario.LISTAR_ARTICULOS + " where ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Precio > " + (string)filtro;
                                break;
                            case "Menor a":
                                consulta += "A.Precio < " + (string)filtro;
                                break;
                            case "Igual a":
                                consulta += "A.Precio = " + (string)filtro;
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Nombre like '%" + filtro + "' ";
                                break;
                            case "Contiene":
                                consulta += "A.Nombre like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "' ";
                                break;
                            case "Contiene":
                                consulta += "A.Descripcion like '%" + filtro + "%' ";
                                break;
                        }
                        break;


                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Imagen = (string)datos.Lector["ImagenURL"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    if (estado == false && aux.Estado == false) lista.Add(aux);
                    if (estado == true && aux.Estado == true) lista.Add(aux);
                   
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}