using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Assignment1
{
    public class SqlConnect
    {
        public OracleConnection ConnectToSqlDB()
        {
            string oradb = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=feenix-oracle.swin.edu.au)(PORT=1521))"
             + "(CONNECT_DATA=(SERVICE_NAME=DMS)));"
             + "User Id=s101143294;Password=Mdl465358;";
            OracleConnection conn = new OracleConnection(oradb);
     
            return conn; 

        }

        

        public string ExecuteProcedure(OracleConnection connection,string sqlProcedureName)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sqlProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            connection.Open();
            cmd.Parameters.Add(new OracleParameter("vTotRows",OracleDbType.Int16) );
            cmd.Parameters["vTotRows"].Direction = ParameterDirection.ReturnValue;
            
            cmd.ExecuteScalar();
            string output = cmd.Parameters["vTotRows"].Value.ToString();
            connection.Close();
            return output;
           
        }
        public OracleDataAdapter GetCustomerDetails()
        {
            OracleDataAdapter adapter=  GetAllDetails("GET_ALLCUST");
            return adapter;
        }

        public OracleDataAdapter GetAllSalesDetails()
        {
            OracleDataAdapter adapter = GetAllDetails("GET_ALLSALES_FROM_DB");
            return adapter;
        }
        public OracleDataAdapter GetProductDetails()
        {
            OracleDataAdapter adapter = GetAllDetails("GET_ALLPROD_FROM_DB");
            return adapter;
        }
        
        public OracleDataAdapter GetAllDetails(string SqlProcedureName)
        {
            OracleConnection con = ConnectToSqlDB();
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = SqlProcedureName;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add("Customer_cursor", OracleDbType.RefCursor);
                cmd.Parameters["Customer_cursor"].Direction = ParameterDirection.ReturnValue;
             
                con.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                return adapter;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();

            }
            
        }

        public void AddCustomerToDB(OracleConnection connection, int custID, string custName)
        {
            OracleTransaction trans;
           
               
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader;
                cmd.CommandText = "ADD_CUST_TO_DB";
                cmd.Parameters.Add("pCustId", custID);
                cmd.Parameters.Add("pCustName", custName);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
            
                connection.Open();
              trans=  connection.BeginTransaction();
                cmd.Transaction = trans;
            try
            {
                reader = cmd.ExecuteReader();
                trans.Commit();
               
            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message.ToString());


            }
            finally
            {
                connection.Close();
            }
        }

        public string DeleteAllCustomersFromDB()
        {
            OracleConnection con = ConnectToSqlDB();
            string ProcName = "DELETE_ALL_CUSTOMERS_FROM_DB";
           return ExecuteProcedure(con, ProcName);
            
        }

        public string DeleteAllProductsFromDB()
        {
            OracleConnection con = ConnectToSqlDB();
            string ProcName = "DELETE_ALL_PRODUCTS_FROM_DB";
            return ExecuteProcedure(con, ProcName);

        }
        public void ExecuteQuery(string sqlProcedure)
        {
            OracleConnection con = ConnectToSqlDB();
            
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProcedure;
            cmd.Connection = con;
            con.Open();


            cmd.ExecuteNonQuery();

            con.Close();

        }
        public void DeleteAllSaleFromDB()
        {
            string procName = "DELETE_ALL_SALES_FROM_DB";
            ExecuteQuery(procName);

        }

        public void DeleteCustomer(int custId)
        {
      
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pcustid", custId);
            cmd.CommandText = "DELETE_CUSTOMER";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection, cmd);
        }
        public string DeleteSaleFromDB()
        {
            OracleConnection con = ConnectToSqlDB();
            string ProcName = "DELETE_SALE_FROM_DB";
            return ExecuteProcedure(con, ProcName);

        }

        public void AddProductToDB(OracleConnection connection,int prodId, string prodName, double prodPrice)
        {
            OracleTransaction trans;


            OracleCommand cmd = new OracleCommand();
            OracleDataReader reader;
            cmd.CommandText = "ADD_PROD_TO_DB";
            cmd.Parameters.Add("pprodId", prodId);
            cmd.Parameters.Add("pprodName", prodName);
            cmd.Parameters.Add("pprice", prodPrice);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;

            connection.Open();
            trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                reader = cmd.ExecuteReader();
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message.ToString());


            }
            finally
            {
                connection.Close();
            }
        }

        public string GetCustStringFromDB(int pcustId)
        {
            OracleConnection con = ConnectToSqlDB(); ;
            try
            {
               
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "GET_CUST_STRING_FROM_DB";
              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
               
           
                cmd.Parameters.Add("vCustString", OracleDbType.Varchar2,200);
                cmd.Parameters["vCustString"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pcustid", pcustId);
                con.Open();
                cmd.ExecuteScalar();
                string output = cmd.Parameters["vCustString"].Value.ToString();
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                
            }

        }

        public void UpdateSalesYTD(int custid,int amount)
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pcustid", custid);
            cmd.Parameters.Add("pamt", amount);
            cmd.CommandText = "UPD_CUST_SALESYTD_IN_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection,cmd);
        }

        public void UpdateCustStatus(int custid, string status)
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pcustid", custid);
            cmd.Parameters.Add("pstatus", status);
            cmd.CommandText = "UPD_CUST_STATUS_IN_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection, cmd);
        }

        public void UpdateProdSalesYTD(int pprodId, int amount)
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pprodid", pprodId);
            cmd.Parameters.Add("pamt", amount);
            cmd.CommandText = "UPD_PROD_SALESYTD_IN_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection, cmd);
        }

        public void AddSimpleSale(int pcustId,int pprodId, int pqty)
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pcustid", pcustId);
            cmd.Parameters.Add("pprodid", pprodId);
            cmd.Parameters.Add("pqty", pqty);
            cmd.CommandText = "ADD_SIMPLE_SALE_TO_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection, cmd);
        }

        public void AddComplexSale(int pcustId, int pprodId, int pqty,string pdate)
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("pcustid", pcustId);
            cmd.Parameters.Add("pprodid", pprodId);
            cmd.Parameters.Add("pqty", pqty);
            cmd.Parameters.Add("pdate", pdate);
            cmd.CommandText = "ADD_COMPLEX_SALE_TO_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            ExecuteNonQuery(connection, cmd);
        }
        public void ExecuteNonQuery(OracleConnection connection, OracleCommand cmd)
        {
            OracleTransaction transaction;
            cmd.Connection = connection;
            connection.Open();
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
           
        }

        public string GetProdStringFromDB(int pprodid)
        {
            OracleConnection con = ConnectToSqlDB(); ;
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "GET_PROD_STRING_FROM_DB";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add("vProdString", OracleDbType.Varchar2, 200);
                cmd.Parameters["vProdString"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pprodid", pprodid);
                con.Open();
                cmd.ExecuteScalar();
                string output = cmd.Parameters["vProdString"].Value.ToString();
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();

            }

        }
        public string GetSumCustSalesYTD()
        {
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SUM_CUST_SALESYTD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            connection.Open();
            cmd.Parameters.Add(new OracleParameter("vSumSalesYTD", OracleDbType.Int16));
            cmd.Parameters["vSumSalesYTD"].Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteScalar();
            string output = cmd.Parameters["vSumSalesYTD"].Value.ToString();
            connection.Close();
            return output;

        }

        public string GetCountSales(int daysCount)
        {
            
            OracleConnection connection = ConnectToSqlDB();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "COUNT_PRODUCT_SALES_FROM_DB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            connection.Open();
            cmd.Parameters.Add(new OracleParameter("vCount", OracleDbType.Int16));
            cmd.Parameters["vCount"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add("pdays", daysCount);
            cmd.ExecuteNonQuery();
            string output = cmd.Parameters["vCount"].Value.ToString();
            connection.Close();
            return output;

        }

    }
}
