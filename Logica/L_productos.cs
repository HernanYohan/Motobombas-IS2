using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilitarios;
using Encapsular;
using Datos;


namespace Logica 
{
   public class L_productos
    {
       public U_pro Fotosnombre(string nombreArchivo, string extencion, String saveLocation)
       {
           U_pro datos = new U_pro();

          

           if (!(extencion.Equals(".jpg") || extencion.Equals(".gif") || extencion.Equals(".jpge") || extencion.Equals(".png")))
           {

               datos.Mensaje = "Tipo de archivo no valido";
;
           }
           if (System.IO.File.Exists(saveLocation))
           {
               datos.Mensaje = "Ya existe un archivo en el servidor con ese nombre";
              
           }

           return datos;
       }
       public  DataTable Agregar (String url_imagen,String marca,String referencia, Int32 valor,Int32 cantidad,Int32 id_categoria,Int32 proveedor_producto )
      {
               U_pro enviar = new U_pro();
               e_producto datos = new e_producto();
               D_Motobombas producto = new D_Motobombas();
               DataTable user = new DataTable();
       try
        {
              

               datos.Url_imagen = url_imagen;
               datos.Marca = marca;
               datos.Referencia = referencia;
               datos.Valor = valor;
               datos.Cantidad = cantidad;
               datos.Id_categoria = id_categoria;
               datos.Proveedor_producto = proveedor_producto;

              user = producto.insertarProducto(datos);





              enviar.Mensaje1 = "<script type='text/javascript'>alert('Agregado correctamente');window.location=\"AgregarProducto.aspx\"</script>)";
        }
        catch (Exception exc)
        {
            U_pro envi = new U_pro();

            enviar.Mensaje1 = "<script type='text/javascript'>alert('Error:Algunos datos incorrectos ');</script>)";
             
        }
       return user;
       }


       
       public DataTable verProductos()
       {
           D_Motobombas data = new D_Motobombas();
           DataTable ver = new DataTable();

           ver = data.obtenerproducto();

           return ver;

       }

       public DataTable EliminarProductos(Int32 id_producto)
       {
           D_Motobombas eliminarProducto = new D_Motobombas();
           DataTable Eliminar = new DataTable();

           Eliminar=eliminarProducto.EliminarProducto(id_producto);

           return Eliminar;

       }


       public DataTable ModificarProductos(Int32 id_producto, String marca, Int32 valor, Int32 cantidad, Int32 id_categoria, String referencia, String url_imagen)
       {
           D_Motobombas modificarProducto = new D_Motobombas();
           DataTable Modificar = new DataTable();

           Modificar = modificarProducto.modificarProducto(id_producto, marca, valor, cantidad, id_categoria, referencia, url_imagen);

           return Modificar;
       }
    }

   
}
