using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocio
{
    public class ClassMovement
    {
        public string sError;
        string sCon = "Server=(local); Initial Catalog = SisInventarios; User ID = sa; Password = 12345";

        public bool BuyProduct(List<string> prodID, List<string> quantity, List<string> price, List<string> wareID, DateTime now)
        {
            bool bOk = false;
            using (SqlConnection con = new SqlConnection(sCon))
            {
                con.Open();
                
                using(SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string sFolio = GetFolio();
                        if (string.IsNullOrEmpty(sFolio))
                        {
                            sFolio = "1001";
                        }
                        else
                        {
                            int i = Convert.ToInt32(sFolio);
                            i++;
                            sFolio = i.ToString();
                        }

                        string sQry = $"INSERT INTO INVENTARIOS (Folio, Fecha, Tmovimiento) VALUES ('{sFolio}', '{now}', 'Entrada');";

                        //SqlCommand cmd = new SqlCommand(sQry, con, transaction);
                        using(SqlCommand cmd = new SqlCommand(sQry, con, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i < prodID.Count; i++)
                        {
                            double tQuantity = 0;
                            tQuantity += CheckSaldo(prodID[i], wareID[i]);
                            string sQry1 = "";

                            if (tQuantity == 0)
                            {
                                tQuantity += Convert.ToInt32(quantity[i]);
                                sQry1 = $"INSERT INTO SALDOS (AlmacenID, ProductoID, Saldo) VALUES ('{wareID[i]}', '{prodID[i]}', {tQuantity});";
                            }
                            else
                            {
                                tQuantity += Convert.ToInt32(quantity[i]);
                                sQry1 = $"UPDATE SALDOS SET Saldo = {tQuantity} WHERE AlmacenID = '{wareID[i]}' AND ProductoID = '{prodID[i]}'";
                            }

                            //SqlCommand cmd1 = new SqlCommand(sQry1, con, transaction);
                            using(SqlCommand SaldoCmd = new SqlCommand(sQry1, con, transaction))
                            {
                                SaldoCmd.ExecuteNonQuery();
                            }
                        }
                        for (int i = 0; i < prodID.Count; i++)
                        {
                            string sQry2 = $"INSERT INTO INVENTARIOSDETALLE (Folio, ProductoID, Cantidad, PCompra, AlmacenID, Tmovimiento) VALUES ('{sFolio}', '{prodID[i]}', {quantity[i]}, {price[i]}, '{wareID[i]}', 'Entrada');";

                            //SqlCommand cmd2 = new SqlCommand(sQry2, con, transaction);
                            using (SqlCommand IDcmd = new SqlCommand (sQry2, con, transaction))
                            {
                                IDcmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        bOk = true;
                    }
                    catch (Exception ex)
                    {
                        sError = ex.Message;
                        bOk = false;
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                
            }
            return bOk;
        }

        public double CheckSaldo(string prodID, string wareID)
        {
            double quantity = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VSaldo1 WHERE AlmacenID = '{wareID}' AND ProductoID = '{prodID}'";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        quantity = double.Parse(reader[2].ToString());
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return quantity;
        }

        public string GetFolio()
        {
            string folio = "";
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT TOP 1 * FROM VInventarios ORDER BY Folio DESC";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        folio = reader[0].ToString();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }

            return folio;
        }

        public string GetSaleID()
        {
            string folio = "";
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT TOP 1 * FROM VVenta ORDER BY VentaID DESC";

                    con.Open();

                    SqlCommand cmd = new SqlCommand(sQry, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        folio = reader[0].ToString();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }

            return folio;
        }

        public bool SellProduct(List<string> prodID, List<string> quantity, List<string> price, List<string> wareID, DateTime now)
        {
            bool bOk = false;
            using (SqlConnection con = new SqlConnection(sCon))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string sFolio = GetFolio();
                        if (string.IsNullOrEmpty(sFolio))
                        {
                            sFolio = "1001";
                        }
                        else
                        {
                            int i = Convert.ToInt32(sFolio);
                            i++;
                            sFolio = i.ToString();
                        }

                        string sQry = $"INSERT INTO INVENTARIOS (Folio, Fecha, Tmovimiento) VALUES ('{sFolio}', '{now}', 'Salida');";

                        using (SqlCommand cmd = new SqlCommand(sQry, con, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i < prodID.Count; i++)
                        {
                            double tQuantity = 0;
                            tQuantity += CheckSaldo(prodID[i], wareID[i]);
                            string sQry1 = "";

                            if (tQuantity == 0)
                            {
                                tQuantity -= Convert.ToInt32(quantity[i]);
                                sQry1 = $"INSERT INTO SALDOS (AlmacenID, ProductoID, Saldo) VALUES ('{wareID[i]}', '{prodID[i]}', {tQuantity});";
                            }
                            else
                            {
                                tQuantity -= Convert.ToInt32(quantity[i]);
                                sQry1 = $"UPDATE SALDOS SET Saldo = {tQuantity} WHERE AlmacenID = '{wareID[i]}' AND ProductoID = '{prodID[i]}'";
                            }

                            using (SqlCommand SaldoCmd = new SqlCommand(sQry1, con, transaction))
                            {
                                SaldoCmd.ExecuteNonQuery();
                            }
                        }
                        for (int i = 0; i < prodID.Count; i++)
                        {
                            string sQry2 = $"INSERT INTO INVENTARIOSDETALLE (Folio, ProductoID, Cantidad, PCompra, AlmacenID, Tmovimiento) VALUES ('{sFolio}', '{prodID[i]}', {quantity[i]}, {price[i]}, '{wareID[i]}', 'Salida');";

                            //SqlCommand cmd2 = new SqlCommand(sQry2, con, transaction);
                            using (SqlCommand IDcmd = new SqlCommand(sQry2, con, transaction))
                            {
                                IDcmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        bOk = true;
                    }
                    catch (Exception ex)
                    {
                        sError = ex.Message;
                        bOk = false;
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
            return bOk;
        }

        public void VistaSaldo(ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VSaldo1";

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

        public void VistaInvD(ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VInvDetalle";

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

        public void VistaInv(ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VInventarios";

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

        public void VistaSale(ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VVenta";

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

        public void VistaSaleD(ref DataTable table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    string sQry = $"SELECT * FROM VVentaDetalle";

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

        public bool Sale(DateTime now, string wareID, double tPrice, int tQuantity, List<string> prodID, List<double> quantity, List<double> price)
        {
            bool bOk = false;
            using (SqlConnection con = new SqlConnection(sCon))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string ventaID = GetSaleID();
                        if (string.IsNullOrEmpty(ventaID))
                        {
                            ventaID = "1001";
                        }
                        else
                        {
                            int i = Convert.ToInt32(ventaID);
                            i++;
                            ventaID = i.ToString();
                        }

                        string sQry = $"EXEC spAltaVenta @VentaID = '{ventaID}', @FechaVenta = '{now}', @AlmacenID = '{wareID}', @TotalVenta = {tPrice}, @CantidadArticulos = {tQuantity};";

                        using (SqlCommand cmd = new SqlCommand(sQry, con, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        for(int i = 0; i < prodID.Count; i++)
                        {
                            string sQry1 = $"EXEC spAltaVentasDetalle @VentaID = '{ventaID}', @ProductoID = '{prodID[i]}', @Cantidad = {quantity[i]}, @PVenta = {price[i]}, @AlmacenID = '{wareID}';";

                            using (SqlCommand SaldoCmd = new SqlCommand(sQry1, con, transaction))
                            {
                                SaldoCmd.ExecuteNonQuery();
                            }
                        }
                        
                        transaction.Commit();

                        bOk = true;
                    }
                    catch (Exception ex)
                    {
                        sError = ex.Message;
                        bOk = false;
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
            return bOk;
        }
    }
}
