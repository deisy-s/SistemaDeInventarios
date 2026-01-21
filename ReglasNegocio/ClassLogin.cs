using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocio
{
    public class ClassLogin
    {
        public String sError;

        public SqlConnection ConectadoUser(string sUser, string sPassword)
        {
            SqlConnection con = null;
            String sCadena = $@"Server=(local); Initial Catalog = Master; User ID = {sUser}; Password = {sPassword}";

            try
            {
                con = new SqlConnection(sCadena);
                con.Open();
                con.Close();

            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }

            return con;
        }

        public bool BDEvaluarSesion(string sUser, string sPassword)
        {
            bool bOk = false;
            string sConection;
            try
            {
                // Crear la conexión con los valores de usuario y contraseña ingresado por el usuario
                sConection = $@"Server=(local); Initial Catalog = Master; User ID = {sUser}; Password = {sPassword}";
                // Llamar al método que se conecta a la BD
                if (BDIniciarSesion(sConection))
                {
                    bOk = true;
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool BDIniciarSesion(string sConection)
        {
            bool bOk = false;
            try
            {
                // Crear la conexión
                SqlConnection conNewUser = new SqlConnection(sConection);
                conNewUser.Open(); // Abrir y cerrar la conexión
                conNewUser.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk; // Regresar al valor bool si se pudo abrir la conexión o no
        }
    }
}
