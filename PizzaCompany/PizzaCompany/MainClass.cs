using PizzaCompany.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PizzaCompany
{
    public class MainClass
    {
        public static readonly string conn_string = "Data Source=DESKTOP-B6N0F08;Initial Catalog=VSUSER;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public static SqlConnection conn = new SqlConnection(conn_string);
        public static bool isValidatUser(string username, string passwd)
        {
            bool isValidat = false;
            string qry = @"Select * from users where username = '" + username + "' and passwd = '" + passwd + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count >0)
            {
                isValidat = true;
                USER = dt.Rows[0]["username"].ToString();
            }
            return isValidat;
        }
        // username
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        //===============Users Permission========>
     public static bool userPermission(string username, string passwd)
        {
            bool permission = false;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwd))
                return false;
            try
            {
                string qry = "SELECT * FROM users WHERE username = @username AND passwd = @passwd";

                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwd", passwd);

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

        //=======================================>



        //=========Blure Background==============>
        public static void BlurBackround(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = System.Drawing.Color.Black;
                Background.Size = DashbordForm.Instance.Size;
                Background.Location = DashbordForm.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
        //============Database insert==========>
        public static int SQL(string sql, Hashtable hashTabe)
        {
            //==================================================>
            int insertedId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql + "; SELECT SCOPE_IDENTITY();", conn);
                cmd.CommandType = CommandType.Text;
                foreach (DictionaryEntry item in hashTabe)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value ?? DBNull.Value);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    insertedId = id;

                }

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                conn.Close();
            }
            return insertedId;
        }

        //-------------Get Product By Search---------------->
        public List<ProductModel> GetProductsBySearch(string search, string menutype)
        {
            List<ProductModel> products = new List<ProductModel>();

            string qry = $"SELECT * FROM productManagement WHERE pCategory = '{menutype}'";


            if (!string.IsNullOrWhiteSpace(search))
            {
                qry += " AND pName LIKE @search";
            }

            SqlCommand cmd = new SqlCommand(qry, conn);

            if (!string.IsNullOrWhiteSpace(search))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
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
                        Name = reader["pName"].ToString(),
                        Category = reader["pCategory"].ToString(),
                        Price = reader["pPrice"].ToString()
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
        //=============Get User ByID========================>
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
                        CR = reader["cCR"].ToString(),
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
        //======= For Loading data form database ==========>
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


//int res = 0;
//try
//{
//    SqlCommand cmd = new SqlCommand(sql, conn);
//    cmd.CommandType = CommandType.Text;
//    foreach (DictionaryEntry  item in hashTabe)
//    {
//        cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value ?? DBNull.Value);
//    }              
//    if (conn.State == ConnectionState.Closed)
//    { 
//        conn.Open();
//    }
//    res = cmd.ExecuteNonQuery();
//    if(conn.State == ConnectionState.Open) { conn.Close(); }
//}
//catch (Exception e)
//{
//    MessageBox.Show(e.ToString());
//    conn.Close();
//}
//return res;