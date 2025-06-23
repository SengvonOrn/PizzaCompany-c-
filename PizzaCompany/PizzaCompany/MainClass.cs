using PizzaCompany.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using System.Xml.Linq;
namespace PizzaCompany
{
    public class MainClass
    {
        public static readonly string conn_string = "Data Source=DESKTOP-B6N0F08;Initial Catalog=VSUSER;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public static SqlConnection conn = new SqlConnection(conn_string);


    //========================User Login=====================================>
     public static bool isValidatUser(string username, string passwd)
            {
                bool isValidat = false;

                string qry = "SELECT * FROM users WHERE username = @username AND passwd = @passwd";
                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwd", passwd);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    isValidat = true;
                    USER = dt.Rows[0]["username"].ToString();
               
                    // Update the lastLogin timestamp
                    string updateLogin = "UPDATE users SET lastLogin = GETDATE(), uCheckOut = NULL WHERE username = @username";
                    SqlCommand updateCmd = new SqlCommand(updateLogin, conn);
                    updateCmd.Parameters.AddWithValue("@username", USER);
                    conn.Open();
                    updateCmd.ExecuteNonQuery();
                    conn.Close();
                }

                return isValidat;

            }




        //================set user on navbar================================>

                    // username
                    public static string user;
           
                    public static string USER
                    {
                        get { return user; }
                        private set { user = value; }
                    }
                 
        //===============Users Permission===================================>



        public static bool userPermission(string roles, string passwd)
        {
            bool permission = false;

            if (string.IsNullOrWhiteSpace(roles) || string.IsNullOrWhiteSpace(passwd))
                return false;

            try
            {
                string qry = "SELECT * FROM users WHERE uRole = @uRole AND passwd = @passwd AND lastLogin IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.Parameters.AddWithValue("@passwd", passwd);
                    cmd.Parameters.AddWithValue("@uRole", roles);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        permission = dt.Rows.Count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

            return permission;
        }


        //================================Check user verify=================>

        public static object Scalar(string query, Hashtable parameters)
        {
            object result = null;

          
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the command
                    foreach (DictionaryEntry param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }

                    conn.Open();
                    result = cmd.ExecuteScalar();
                    conn.Close();
                }
            

            return result;
        }


        //=========Blure Background laoding====================================>



        public static void BlurBackround(Form dialogForm)
        {
            if (DashbordForm.Instance == null || DashbordForm.Instance.IsDisposed)
            {
                dialogForm.ShowDialog(); 
                return;
            }

            using (Form overlay = new Form())
            {
    
                overlay.StartPosition = FormStartPosition.Manual;
                overlay.FormBorderStyle = FormBorderStyle.None;
                overlay.Opacity = 0.7d;
                overlay.BackColor = Color.Black;
                overlay.Size = DashbordForm.Instance.ClientSize;
                overlay.Location = DashbordForm.Instance.PointToScreen(Point.Empty);
                overlay.ShowInTaskbar = false;
                overlay.TopMost = true; 
                overlay.Enabled = false;
                overlay.Show();

                try
                {
                    dialogForm.StartPosition = FormStartPosition.CenterParent;
                    dialogForm.FormBorderStyle = FormBorderStyle.None; 
                    dialogForm.ShowDialog(overlay);
                }
                finally
                {
                    overlay.Close();
                    overlay.Dispose();
                }
            }
        }


        //============ Main Database Insert==============================>
      

            public static int SQL(string sql, Hashtable hashTable)
            {
                int result = 0;
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        foreach (DictionaryEntry item in hashTable)
                        {
                            cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value ?? DBNull.Value);
                        }

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                    if (sql.TrimStart().StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                    {
                        cmd.CommandText += "; SELECT CAST(SCOPE_IDENTITY() AS INT)";
                        object scalarResult = cmd.ExecuteScalar();
                        if (scalarResult != null && int.TryParse(scalarResult.ToString(), out int insertedId))
                        { 

                            result = insertedId;

                        }


                        }

                        else
                        {
                            result = cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

                return result;
            }




        //===============Get Product By Search and default loading===========================>

            public List<ProductModel> GetProductsBySearch(string search, string menutype, string _myselectOption, string myselectgroup)
            {
            List<ProductModel> products = new List<ProductModel>();

 
            string qry = $"SELECT * FROM productManagement WHERE pCategory = '{menutype}'";


            if (!string.IsNullOrWhiteSpace(search))
            {
                qry += " AND pName LIKE @search";
            }
            if (_myselectOption == "6" || _myselectOption == "9" || _myselectOption == "12")
            {
                qry += " AND pSize = @size";
            }         
            if(myselectgroup == "seafood Deluxe" || myselectgroup == "deluxe pizza" || myselectgroup == "seafood Deluxe" || myselectgroup == "Alcohol"  || myselectgroup == "soft drink && water")
            {
                qry += " AND pGroup = @group";
            }
            qry += " ORDER BY pCategory ASC, pName ASC";




            SqlCommand cmd = new SqlCommand(qry, conn);



            if (!string.IsNullOrWhiteSpace(search))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            }

            if (_myselectOption == "6" || _myselectOption == "9" || _myselectOption == "12")
            {
                cmd.Parameters.AddWithValue("@size", _myselectOption);
            }
            if(myselectgroup == "seafood Deluxe" || myselectgroup == "deluxe pizza" || myselectgroup == "seafood Deluxe" || myselectgroup == "Alcohol" || myselectgroup == "soft drink && water")
            {
                cmd.Parameters.AddWithValue("@group", myselectgroup);
            }
         



            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductModel product = new ProductModel
                    {

                        pId = reader["pId"].ToString(),
                        Name = reader["pName"].ToString(),
                        Category = reader["pCategory"].ToString(),
                    
                        Price = reader["pPrice"].ToString(),
                       

                        Size = reader["pSize"].ToString(),
                        ImageBytes = reader["pImage"] != DBNull.Value ? (byte[])reader["pImage"] : null,
                        command = reader["command"].ToString()




                    };
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return products;
        }

        //=========================================================
        public List<stockModel> getUpdatestock(int Id)
        { 
            List<stockModel> stocks = new List<stockModel>();
            string sql = $"SELECT Id, Name, Price, Stocks, InStock, OutStock From StockProduct WHERE Id = {Id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stockModel model = new stockModel
                    {

                        Id = Convert.ToInt32(reader["Id"]),
                        name = reader["Name"].ToString(),
                        price = Convert.ToDecimal(reader["Price"]),
                        stocks = Convert.ToDecimal(reader["Stocks"]),
                        In_stock = Convert.ToDecimal(reader["InStock"]),
                        outStock = Convert.ToDecimal(reader["OutStock"]),

                    };

                    stocks.Add(model);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show( "Error" + e);

            }
            finally {  reader?.Close(); if (conn.State == ConnectionState.Open) conn.Close(); }

            return stocks;
        }


        //=================Show Product Popular====================>

        public List<ProductModel> PopulerProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            string qry = @"
                           WITH RankedOrders AS (
                            SELECT
                                o.oId,
                                o.Quantity,
                                o.Size,
                                o.DineType,
                                o.Subtotal,
                                o.CreatedAt AS OrderDate,
                                c.cName AS CustomerName,
                                c.cPhone,
                                p.pName AS ProductName,
                                p.pPrice,
                                p.pImage,
                                ROW_NUMBER() OVER (
                                    PARTITION BY p.pName 
                                    ORDER BY o.Quantity DESC, o.CreatedAt DESC
                                ) AS rn
                            FROM [VSUSER].[dbo].[OrderTable] o
                            JOIN [VSUSER].[dbo].[Custmer] c ON o.cId = c.cId
                            JOIN [VSUSER].[dbo].[productManagement] p ON o.pId = p.pId
                        )
                        SELECT TOP 10 
                            oId,
                            Quantity,
                            Size,
                            DineType,
                            Subtotal,
                            OrderDate,
                            CustomerName,
                            cPhone,
                            ProductName,
                            pPrice,
                            pImage
                        FROM RankedOrders
                        WHERE rn = 1
                        ORDER BY OrderDate DESC;";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductModel product = new ProductModel
                    {

                        Name = reader["ProductName"].ToString(),
                        qty = reader["Quantity"].ToString(),
                        Price = reader["pPrice"].ToString(),
                        ImageBytes = reader["pImage"] != DBNull.Value ? (byte[])reader["pImage"] : null

                    };

                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return products;
        }

        //===>Count Popular
        public int CountPopuler(string name)
        {
            int totalQuantity = 0;

            string sql = @"
                        SELECT 
                            SUM(o.Quantity) AS TotalQuantity
                        FROM OrderTable o 
                        JOIN Custmer c ON o.cId = c.cId 
                        JOIN productManagement p ON o.pId = p.pId 
                        WHERE p.pName = @name;";

            using (SqlConnection con = new SqlConnection(conn_string))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@name", name);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    totalQuantity = Convert.ToInt32(result);
                }
            }

            return totalQuantity;
        }





        //=============Get Customer ByID==============================>



        public static CustomerModel GetCustomerById(int customerId)
        {
            CustomerModel customer = null;

            string query = "SELECT * FROM Custmer WHERE cId = @cId";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cId", customerId);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["cId"]),
                        Phone = reader["cPhone"].ToString(),
                        Name = reader["cName"].ToString(),
                        Ext = reader["cExt"].ToString(),
                        Address = reader["cAdress"].ToString(),
                        Suite = reader["cSuite"].ToString(),
                        Crosst = reader["cCrost"].ToString(),
                        cityR = reader["cCR"].ToString(),
                        CR = reader["city"].ToString(),
                        Post = reader["cPost"].ToString(),
                        Dl = reader["cDl"].ToString(),
                        Isc = reader["cIsc"].ToString()
                    };
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer: " + ex.Message);
                conn.Close();
            }
            return customer;
        }






        //==== GetOrder count=====================>


        public static int GetOrderCount(string sql)
        {
            int total = 0;


            SqlConnection con = new SqlConnection(conn_string);


            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        total = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error counting orders: " + ex.Message);
                }
            }

            return total;
        }



        //==Order Over Time and amount==============>



        public static object GetScalarValue(string query)
        {
            using (SqlConnection con = new SqlConnection(conn_string))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                return result;
            }

        }

    




        //================UpdateAction Order with sql condition=======>
        public static void UpdateAction(int id)
        {


            string sql = @"
        UPDATE OrderTable
        SET Action = CASE 
                        WHEN Action = 'good' THEN 'bad'
                        WHEN Action = 'bad' THEN 'good'
                        ELSE 'good'
                     END
        WHERE oId = @oId";


            using (SqlCommand updateCmd = new SqlCommand(sql, conn))
            {
                updateCmd.Parameters.AddWithValue("@oId", id);
                conn.Open();
                updateCmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void UpdatePayment(int id)
        {


            string sql = @"
        UPDATE OrderTable
        SET payment = CASE 
                        WHEN payment = 'Success' THEN 'Pending'
                        WHEN payment = 'Pending' THEN 'Success'
                        ELSE 'Success'
                     END
        WHERE cId = @cId";


            using (SqlCommand updateCmd = new SqlCommand(sql, conn))
            {
                updateCmd.Parameters.AddWithValue("@cId", id);
                conn.Open();
                updateCmd.ExecuteNonQuery();
                conn.Close();
            }
        }



        //========================Chart Data==========================>

        public static DataTable GetDataTableforchart(string query)
        {
        
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                
            }
        }
     
        
        
        
        //============================================================>



       public static  DataTable GetData(string query, Hashtable parameters)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
        
                if (parameters != null)
                {
                    foreach (DictionaryEntry param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                  da.Fill(dt);
                }
            }

            return dt;
        }


        //====get selected to print===================>


            public static List<CartItem> getdataPrint(int id)
            {
                List<CartItem> items = new List<CartItem>();

                string query = @"
                    SELECT 
                        o.pId,
                        p.pName,
                        p.pPrice,
                        o.Quantity,
                        o.Size,
                        o.DineType,
                        o.payment,
                        o.Action,
                        o.Subtotal,

                        c.cName,
                        c.cPhone,
                        c.cAdress,
                        c.cExt,
                        c.cSuite,
                        c.cCrost,
                        c.city,
                        c.cCR,
                        c.cPost,
                        c.cIsc,
                        c.cDl
                    from OrderTable o
                    INNER JOIN productManagement p ON o.pId = p.pId
                    INNER JOIN Custmer c ON o.cId = c.cId
                    WHERE o.cId = @CustomerId";




                Hashtable ht = new Hashtable();
                ht.Add("@CustomerId", id);

                DataTable dt = GetData(query, ht);

                foreach (DataRow row in dt.Rows)
                {
                    CartItem item = new CartItem
                    {
                        pId = (row["pId"].ToString()),
                        Name = row["pName"].ToString(),
                        Price = row["pPrice"].ToString(),
                        qty = Convert.ToInt32(row["Quantity"]),
                        Size = row["Size"].ToString(),
                        dine_in = row["DineType"].ToString(),
                        payment = row["payment"].ToString(),
                        action = row["Action"].ToString(),

                        // Customer info
                        cCustomer = row["cName"].ToString(),
                        cPhone = row["cPhone"].ToString(),
                        cAddress = row["cAdress"].ToString(),
                        extention = row["cExt"].ToString(),
                        suit = row["cSuite"].ToString(),
                        Crosst = row["cCrost"].ToString(),
                        cityregion = row["city"].ToString(),
                        CR = row["cCR"].ToString(),
                        Post = row["cPost"].ToString(),
                        Dl = row["cDl"].ToString(),
                        Isc = row["cIsc"].ToString(),
                    };

                    items.Add(item);
                }

                return items;
            }




        //======= For Loading data form database ===========================>

        public static void LoadingData(string sry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sry, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();
                }
                gv.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }





        internal IEnumerable<object> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
