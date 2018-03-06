using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class AgregarProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }


    protected void B_agregarproducto_Click(object sender, EventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;

        L_productos producto = new L_productos();

        //producto.Fotos(Session["fotos"].ToString());


        DataTable fotos;
        
        
        if (Session["fotos"] == null)
        {
           fotos= new DataTable();
           fotos.Columns.Add("ruta");
           fotos.Columns.Add("descripcion");
           Session["fotos"] = fotos;
        }
        
        fotos = (DataTable)Session["fotos"];

        L_productos datos = new L_productos();
        datos.Fotosnombre(System.IO.Path.GetFileName(FU_imagen.PostedFile.FileName), System.IO.Path.GetExtension(FU_imagen.PostedFile.FileName), Server.MapPath("~\\imagenes") + "\\" + System.IO.Path.GetFileName(FU_imagen.PostedFile.FileName));
        U_pro tad = new U_pro();
       

      /*  if (!(extencion.Equals(".jpg") || extencion.Equals(".gif") || extencion.Equals(".jpge") || extencion.Equals(".png")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
            return;
        }
        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
            return;
        }*/
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert(tad.mensaje);</script>");





        FU_imagen.PostedFile.SaveAs(Server.MapPath("~\\imagenes") + "\\" + System.IO.Path.GetFileName(FU_imagen.PostedFile.FileName));

            U_pro dar = new U_pro();
            L_productos user = new L_productos();
            user.Agregar(("~\\imagenes") + "\\" + System.IO.Path.GetFileName(FU_imagen.PostedFile.FileName), TB_marcaprod.Text, TB_potenciaprod.Text, Int32.Parse(TB_valorprod.Text), Int32.Parse(TB_cantidadprod.Text), Int32.Parse(DDL_categoria.SelectedValue), Int32.Parse(DDL_proveedor.SelectedValue));

           /* E_Producto nuevo = new E_Producto();
            Dao_Motobombas producto = new Dao_Motobombas();

            nuevo.Url_imagen = ("~\\imagenes") + "\\" + nombreArchivo;
            nuevo.Marca = TB_marcaprod.Text;
            nuevo.Referencia = TB_potenciaprod.Text;
            nuevo.Valor = Int32.Parse(TB_valorprod.Text);
            nuevo.Cantidad = Int32.Parse(TB_cantidadprod.Text);
            nuevo.Id_categoria = Int32.Parse(DDL_categoria.SelectedValue);
            nuevo.Proveedor_producto = Int32.Parse(DDL_proveedor.SelectedValue);
            producto.insertarProducto(nuevo);

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Agregado correctamente');window.location=\"AgregarProducto.aspx\"</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error:Algunos datos incorrectos ');</script>");
            return;
        }*/
            cm.RegisterClientScriptBlock(this.GetType(), "",dar.Mensaje1);
            
        


        
        
    }
    protected void B_ver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModificarProducto.aspx");
    }
}