using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Common;
/// <summary>
/// Class1 的摘要说明
/// </summary>
namespace Common
{
    public class Base
    {

        protected static string strConn = ConfigurationManager.AppSettings["strConnection"];
        protected static string strSQL;
		public static string Article = ConfigurationManager.AppSettings["Article"];
        public static string ArticleCategory = ConfigurationManager.AppSettings["ArticleCategory"];
		public static string ChannelCategory = ConfigurationManager.AppSettings["Channelcategory"];
		public static string Ecidi_AboutUsInfo = ConfigurationManager.AppSettings["AboutUsInfo"];
		public static string Ecidi_CompanyCultureInfo = ConfigurationManager.AppSettings["CompanyCultureInfo"];
		public static string Ecidi_MarketAndBusinessInfo = ConfigurationManager.AppSettings["MarketAndBusinessInfo"];
		public static string Ecidi_NewsInfo = ConfigurationManager.AppSettings["NewsInfo"];
		public static string Ecidi_TalentAndTechInfo = ConfigurationManager.AppSettings["TalentAndTechInfo"];
        public static string SiteName = ConfigurationManager.AppSettings["SiteName"];


        public static int ExecuteSql(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(strSQL, myCn);
            try
            {
                myCn.Open();
                myCmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCmd.Dispose();
                myCn.Close();
            }
        }
        public static SqlDataReader ExecuteSql4Reader(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(strSQL, myCn);
            try
            {
                myCn.Open();
                SqlDataReader myReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

        }
        public static DataSet ExecuteSql4Ds(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            try
            {
                myCn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(strSQL, myCn);
                DataSet ds = new DataSet("ds");
                sda.Fill(ds);
                return ds;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                 myCn.Close();
            }
        }
        public static DataTable ExecuteSql4Dt(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            try
            {
                myCn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(strSQL, myCn);
                DataTable dt = new DataTable("dt");
                sda.Fill(dt);
                return dt;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCn.Close();
            }
        }
        public static SqlDataAdapter ExecuteSql4Da(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            try
            {
                myCn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, myCn);
                return da;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCn.Close();
            }
        }
        public static int ExecuteSql4Value(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(strSQL, myCn);
            try
            {
                myCn.Open();
                object r = myCmd.ExecuteScalar();
                if (object.Equals(r, null))
                {
                    throw new Exception("Value unavailable!");
                }
                else
                {
                    return (int)r;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCmd.Dispose();
                myCn.Close();
            }
        }
        public static string ExecuteSql4String(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(strSQL, myCn);
            try
            {
                myCn.Open();
                object r = myCmd.ExecuteScalar();
                if (object.Equals(r, null))
                {
                    //throw new Exception("Value unavailable!");
                    return "";
                }
                else
                {
                    return Convert.ToString(r);
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCmd.Dispose();
                myCn.Close();
            }
        }
        public static object ExecuteSql4ValueEx(string strSQL)
        {
            SqlConnection myCn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(strSQL, myCn);
            try
            {
                myCn.Open();
                object r = myCmd.ExecuteScalar();
                if (object.Equals(r, null))
                {
                    throw new Exception("Value unavailable!");
                }
                else
                {
                    return r;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myCmd.Dispose();
                myCn.Close();
            }
        }
    }
}

