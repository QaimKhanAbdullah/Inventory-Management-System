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
    class AddUpdate
    {
        
        public void addTransactionProductDetails(
		        double Quantity , 
		        double Amount ,  
		        string poductName  
        )
        {
            try
            {
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateTransactionProductDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Quantity", Quantity );
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@poductName", poductName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }


        public void addTransactionDetails(
                int Cust_ID , 
                DateTime TransactionDate , 
                double billAmount
            )
        {
            try
            {
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateTransactionDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cust_ID", Cust_ID);
                cmd.Parameters.AddWithValue("@billAmount", billAmount);
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate.ToShortDateString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }



        public void addUpdateStockDetails(
            double amount  ,
            double rate  ,
            double quantity  ,
            int product_ID , 
            int unit_ID  ,
            string productName ,
            int IDToUpdate,
            int flag

        )
        {
            try
            {
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateStockDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@product_ID", product_ID);
                cmd.Parameters.AddWithValue("@unit_ID", unit_ID);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@idToUpdaate", IDToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        public void addUpdateProducts(
            string ItemName,
            string ItemCode,
            string SeqNo,
            string MinLevelStock,
            string ReorderQty,
            string Remarks,
            string Type,
            int CategoryID,
            int SubCategoryID,
            double sellingRate,
            int IDToUpdate,
            int flag
        )
        {
            try
            {
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                cmd.Parameters.AddWithValue("@SeqNo", SeqNo);
                cmd.Parameters.AddWithValue("@MinLevelStock", MinLevelStock);
                cmd.Parameters.AddWithValue("@ReorderQty", ReorderQty);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                cmd.Parameters.AddWithValue("@sellingRate ", sellingRate);
                cmd.Parameters.AddWithValue("@IDToUpdate", IDToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void addUpdateCustomerDetails(
            string CustomerName,
            string Address,
            string FaxNumber,
            string Remarks,
            string CustomerCOde,
            string City,
            string Address2,
            string MobileNO,
            string EmailID,
            int idToUpdate,
            int flag
        )
        {
            try
            {

                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateCustomerDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@CustomerCOde", CustomerCOde);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Address2", Address2);
                cmd.Parameters.AddWithValue("@MobileNO", MobileNO);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@idToUpdate", idToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public void addUpdateUnitMeasure(
            string unitMeasure,
            int IDToUpdate,
            int flag
        )
        {
            try
            {
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateUnitMeasure", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unitMeasure", unitMeasure);
                cmd.Parameters.AddWithValue("@IDToUpdate", IDToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void addUpdateSubCategories(
            string categoryName, 
            string subCategoryName, 
            string subCategoryDesc, 
            int IDToUpdate, 
            int flag
         )
        {
            try
            {
                int id = 0;
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateSubCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                cmd.Parameters.AddWithValue("@subCategoryName", subCategoryName);
                cmd.Parameters.AddWithValue("@subCategoryDesc", subCategoryDesc);
                cmd.Parameters.AddWithValue("@IDToUpdate", IDToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                id = Convert.ToInt32(cmd.ExecuteScalar());
                switch (id)
                {
                    case -1:
                        System.Windows.Forms.MessageBox.Show("Sub-Category ' " + subCategoryName + " ' already exists for Category ' " + categoryName + " ' ..");
                        break;
                    case 2:
                        System.Windows.Forms.MessageBox.Show("Sub-Category Deatils Updated for ' " + subCategoryName + " ' ..");
                        break;
                    default:
                        {
                            System.Windows.Forms.MessageBox.Show("Sub-Category Added");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addUpdateCategories(string categoryName, string categoryDesc, int IDToUpdate, int flag)
        {
            try
            {

                int id = 0;
                SqlConnection conn = DBClass.getsqlcon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("strpdAddUpdateCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                cmd.Parameters.AddWithValue("@categoryDesc", categoryDesc);
                cmd.Parameters.AddWithValue("@IDToUpdate", IDToUpdate);
                cmd.Parameters.AddWithValue("@flag", flag);

                id = Convert.ToInt32(cmd.ExecuteScalar());
                switch (id)
                {
                    case -1:
                        System.Windows.Forms.MessageBox.Show("Category exists for ' " + categoryName + " ' ..");
                        break;
                    case 2:
                        System.Windows.Forms.MessageBox.Show("Category Deatils Updated for ' " + categoryName + " ' ..");
                        break;
                    default:
                        {
                            System.Windows.Forms.MessageBox.Show("Category Added");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
