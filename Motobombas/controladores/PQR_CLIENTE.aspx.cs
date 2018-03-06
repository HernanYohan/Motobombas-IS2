﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;


public partial class vistas_PQR_CLIENTE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void B_PQR_Click(object sender, EventArgs e)
    {
        L_PQR user = new L_PQR();
        user.Insertarpqr(TB_correo.Text, TB_queja.Text);

        ClientScriptManager cm = this.ClientScript;

        //E_PQR nuevo = new E_PQR();
        //Dao_PQR pqr = new Dao_PQR();



        //nuevo.Correo = TB_correo.Text;
        //nuevo.Queja = TB_queja.Text;

        //pqr.insertarpqr(nuevo);


        
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('PQR recibido,en breve responderemos tu Pqr al correo ');window.location=\"PQR_cliente.aspx\"</script>");

        
    }
}