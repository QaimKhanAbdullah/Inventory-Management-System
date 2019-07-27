using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace DBproject
{
    class Get
    {


        public double getSellingRatesOfProduct(int product_ID) 
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetSellingRatesOfProduct", conn);
                cmd.Parameters.AddWithValue("@product_ID", product_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -9999;
            }
        }

        public double getProductStockInHand(int product_ID) 
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetProductStockInHand", conn);
                cmd.Parameters.AddWithValue("@product_ID", product_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -9999;
            }
        }

        public DataSet getAllUnitmeasures()
        {
            try
            {
                DataSet DS = new DataSet();
                SqlConnection con = DBClass.getsqlcon();
                con.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllUnitmeasures", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataSet();
            }
        }


        public DataSet getAllCustomerNames()
        {
            try
            {
                DataSet DS = new DataSet();
                SqlConnection con = DBClass.getsqlcon();
                con.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllCustomerNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataSet();
            }
        }


        public DataSet getAllProductNames()
        {
            try
            {
                DataSet DS = new DataSet();
                SqlConnection con = DBClass.getsqlcon();
                con.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllProductNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataSet();
            }
        }

        public DataSet getAllSubCategoriesForThisCategory(int CategoryID)
        {
            try
            {
                DataSet DS = new DataSet();
                SqlConnection con = DBClass.getsqlcon();
                con.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllSubCategoriesForThisCategory", con);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataSet();
            }
        }



        public DataTable getAllCustomerDetails()
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllCustomersDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DT;
            }
        }




        public DataTable getAllStockDetails()
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllStockDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DT;
            }
        }


        public DataTable getAllUnitMeasureDetails()
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllUnitMeasureDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DT;
            }
        }


        public DataSet getAllCategories()
        {
            try
            {
                DataSet DS = new DataSet();
                SqlConnection con = DBClass.getsqlcon();
                con.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataSet();
            }
        }



        public DataTable getAllCategoriesDetails()
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllCategoriesDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DT;
            }
        }


        public DataTable getAllSubCategoriesDetails()
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdGetAllSubCategoriesDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DT;
            }
        }


    }
}
