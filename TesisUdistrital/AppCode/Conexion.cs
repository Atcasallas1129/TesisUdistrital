using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public class ConexionR
    {
    SqlConnection cadenaconexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DocumentacionDemo"].ToString());
    private SqlDataAdapter DA;
    private DataTable DT;
    private DataTable DTAux;
    public DataTable DTScript;
    private DataRow DR;
    private string consulta;

    public DataTable ConsultaAUX(String consulta)
    {
        DA = new SqlDataAdapter(consulta, cadenaconexion);
        DTAux = new DataTable();
        DA.Fill(DTAux);
        return DTAux;
    }

}
public class ConexionL
{
    SqlConnection cadenaconexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DocumentacionDemoLocal"].ToString());
    private SqlDataAdapter DA;
    private DataTable DT;
    private DataTable DTAux;
    public DataTable DTScript;
    private DataRow DR;
    private string consulta;

    public DataTable ConsultaAUX(String consulta)
    {
        DA = new SqlDataAdapter(consulta, cadenaconexion);
        DTAux = new DataTable();
        DA.Fill(DTAux);
        return DTAux;
    }

}