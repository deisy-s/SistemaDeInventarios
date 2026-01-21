using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Xml.Linq;

namespace ReglasNegocio
{
    public struct productos
    {
        public string sProductID;
        public string sProductName;
        public double dSalePrice;
        public double dBuyPrice;
    }
    public class ClassProducts
    {
        public string sError;
        string sCon = "Server=LAPTOP-P73RDL1S; Initial Catalog = SisInventarios; User ID = sa; Password = Deisy29";

        public bool CreateProduct( productos producto )
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"INSERT INTO PRODUCTOS (ProductoID, Nombre, PVenta, PCompra) VALUES ('{producto.sProductID}', '{producto.sProductName}', {producto.dSalePrice}, {producto.dBuyPrice});";
                
                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    bOk = true;
                }

            } catch ( Exception e )
            {
                sError = e.Message;
                bOk = false;
            }
            return bOk;
        }

        public bool ReadProduct( string sId, ref productos producto )
        {
            bool bOK = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VProductos WHERE ProductoID = '{sId}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        producto.sProductID = sId;
                        producto.sProductName = reader[1].ToString();
                        producto.dSalePrice = double.Parse(reader[2].ToString());
                        producto.dBuyPrice = double.Parse(reader[3].ToString());
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

        public bool UpdateProduct( productos producto )
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"UPDATE PRODUCTOS SET Nombre = '{producto.sProductName}', PVenta = {producto.dSalePrice}, PCompra = {producto.dBuyPrice} WHERE ProductoID = {producto.sProductID}";

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

        public bool DeleteProduct( string sID )
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"DELETE FROM PRODUCTOS WHERE ProductoID = '{sID}'";

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

        public bool SearchName(string sName, ref productos producto)
        {
            bool bOk = false;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * from VProductos WHERE Nombre = '{sName}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        producto.sProductID = reader[0].ToString();
                        producto.sProductName = reader[1].ToString();
                        producto.dSalePrice = double.Parse(reader[2].ToString());
                        producto.dBuyPrice = double.Parse(reader[3].ToString());
                    }
                    bOk = true;
                    con.Close();
                }
            }
            catch (Exception e)
            {
                sError = e.Message;
                bOk = false;
            }
            return bOk;
        }

        public void FindProducts(ref DataTable table)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * from VProductos";

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

        public void FindProdDisp(string sID, ref DataTable table)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VSaldo1 s INNER JOIN VProductos p ON s.ProductoID = p.ProductoID WHERE AlmacenID = '{sID}'";

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

        public void FindProducts(string sID, ref DataTable table)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * from VProductos WHERE ProductoID = '{sID}'";

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
