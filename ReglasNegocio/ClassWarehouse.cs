using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocio
{
    public struct warehouse
    {
        public string sWID;
        public string sDescripcion;
    }

    public class ClassWarehouse
    {
        public string sError;
        string sCon = "Server=(local); Initial Catalog = SisInventarios; User ID = sa; Password = 12345";

        public bool CreateWarehouse(warehouse ware)
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"INSERT INTO ALMACENES (ALMACENID, DESCRIPCION) VALUES ('{ware.sWID}', '{ware.sDescripcion}');";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    bOk = true;
                }

            }
            catch (Exception e)
            {
                sError = e.Message;
                bOk = false;
            }
            return bOk;
        }

        public bool ReadWarehouse(string sId, ref warehouse ware)
        {
            bool bOK = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VAlmacenes WHERE AlmacenID = '{sId}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ware.sWID = sId;
                        ware.sDescripcion = reader[1].ToString();
                    }

                    con.Close();
                    bOK = true;
                }
            }
            catch (Exception e)
            {
                sError = e.Message;
                bOK = false;
            }
            return bOK;
        }

        public bool UpdateWarehouse(warehouse ware)
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"UPDATE ALMACENES SET Descripcion = '{ware.sDescripcion}' WHERE AlmacenID = {ware.sWID}";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    bOk = true;
                }
            }
            catch (Exception e)
            {
                sError = e.Message;
                bOk = false;
            }
            return bOk;
        }

        public bool DeleteWarehouse(string sID)
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"DELETE FROM ALMACENES WHERE AlmacenID = '{sID}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    bOk = true;
                }
            }
            catch (Exception e)
            {
                sError = e.Message;
                bOk = false;
            }
            return bOk;
        }

        public void FindWarehouses(ref DataTable table)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VAlmacenes";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        // form sales check what warehouse has said product
        public void FindWarehouses(string sID, ref DataTable table)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VSaldo1 s INNER JOIN VAlmacenes a ON s.AlmacenID = a.AlmacenID WHERE ProductoID = '{sID}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void FindID(string sName, ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VAlmacenes WHERE Descripcion = '{sName}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }
    }
}
