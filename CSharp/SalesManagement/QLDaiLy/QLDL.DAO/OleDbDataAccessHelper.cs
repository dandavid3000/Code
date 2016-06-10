using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Data.OleDb;

namespace QLDL.DAO
{
    public class OleDbDataAccessHelper
    {       
        #region ConnectionString
        protected static String connectionString;
        public static String ConnectionString
        {
            get
            {
                return ReadConnectionString("ConnectionString.xml");
            }
        }
        public static String ReadConnectionString(String file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlElement root = doc.DocumentElement;
                String connectionString = root.InnerText;
                return connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region ExecuteQuery
        public static DataTable ExecuteQuery(String strSql, List<OleDbParameter> oleParams)
        {
            DataTable dt = new DataTable();
            try
            {
                OleDbConnection connect = new OleDbConnection(ConnectionString);
                connect.Open();
                try
                {
                    OleDbCommand command = connect.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    if (oleParams != null)
                    {
                        foreach (OleDbParameter param in oleParams)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                }

                catch (OleDbException ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable ExecuteQuery(String strSql)
        {
            return ExecuteQuery(strSql, null);
        }
        #endregion
        #region ExecuteNoneQuery
        public static int ExecuteNoneQuery(String strSql, List<OleDbParameter> oleParams)
        {
            int n;
            try
            {
                OleDbConnection connect = new OleDbConnection(ConnectionString);
                connect.Open();
                try
                {
                    OleDbCommand command = connect.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    if (oleParams != null)
                    {
                        foreach (OleDbParameter param in oleParams)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    n = command.ExecuteNonQuery();
                }

                catch (OleDbException ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return n;
        }
        public static int ExecuteNoneQuery(String strSql)
        {
            return ExecuteNoneQuery(strSql, null);
        }
        #endregion

    }
}
