using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace Apteka
{
    public class DB
    {
        public string dbFileName;
        public SQLiteConnection dbConn;
        public SQLiteCommand sqlCom;

        public void dbConnection()
        {
            dbFileName = "apteka.sqlite";
            dbConn = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;");
        }

        public void InsertSotr(string f, string i, string o, string birth, string role, string adress, string phone)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand("INSERT INTO Sotr (f , i , o, birth , role , adress , phone) VALUES (@f , @i , @o , @birth , @role , @adress , @phone)");
            sqlCom.Connection = dbConn;
            sqlCom.Parameters.Add("@f", DbType.String).Value = f;
            sqlCom.Parameters.Add("@i", DbType.String).Value = i;
            sqlCom.Parameters.Add("@o", DbType.String).Value = o;
            sqlCom.Parameters.Add("@birth", DbType.String).Value = birth;
            sqlCom.Parameters.Add("@role", DbType.String).Value = role;
            sqlCom.Parameters.Add("@adress", DbType.String).Value = adress;
            sqlCom.Parameters.Add("@phone", DbType.String).Value = phone;
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void InsertProd(string kod_prep, string name_prep, string kolvo ,  string price, string n_check, string kod_sotr)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand("INSERT INTO Prodagi (kod_prep , name_prep , kolvo ,  price, n_check , kod_sotr) VALUES (@kod_prep , @name_prep , @kolvo ,  @price , @n_check , @kod_sotr)");
            sqlCom.Connection = dbConn;
            sqlCom.Parameters.Add("@kod_prep", DbType.String).Value = kod_prep;
            sqlCom.Parameters.Add("@name_prep", DbType.String).Value = name_prep;
            sqlCom.Parameters.Add("@kolvo", DbType.String).Value = kolvo;
            sqlCom.Parameters.Add("@price", DbType.String).Value = price;
            sqlCom.Parameters.Add("@n_check", DbType.String).Value = n_check;
            sqlCom.Parameters.Add("@kod_sotr", DbType.String).Value = kod_sotr;
            
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }


        public void InsertPost(string komp, string predst, string country, string city, string adress, string phone)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand("INSERT INTO Postavshik (name_comp , predst , country, city ,  adress , phone) VALUES (@name_comp , @predst , @country, @city ,  @adress , @phone)");
            sqlCom.Connection = dbConn;
            sqlCom.Parameters.Add("@name_comp", DbType.String).Value = komp;
            sqlCom.Parameters.Add("@predst", DbType.String).Value = predst;
            sqlCom.Parameters.Add("@country", DbType.String).Value = country;
            sqlCom.Parameters.Add("@city", DbType.String).Value = city;
            sqlCom.Parameters.Add("@adress", DbType.String).Value = adress;
            sqlCom.Parameters.Add("@phone", DbType.String).Value = phone;
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void InsertNaznach(string n_prep, string name_prep, string opisaniye, string sostav, string analogi, string pokazaniya , string kod_prep)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand("INSERT INTO Naznacheniya (n_prep , name_prep , opisaniye, sostav ,  analogi , pokazaniya , kod_prep) VALUES (@n_prep , @name_prep , @opisaniye, @sostav ,  @analogi , @pokazaniya , @kod_prep)");
            sqlCom.Connection = dbConn;
            sqlCom.Parameters.Add("@n_prep", DbType.String).Value = n_prep;
            sqlCom.Parameters.Add("@name_prep", DbType.String).Value = name_prep;
            sqlCom.Parameters.Add("@opisaniye", DbType.String).Value = opisaniye;
            sqlCom.Parameters.Add("@sostav", DbType.String).Value = sostav;
            sqlCom.Parameters.Add("@analogi", DbType.String).Value = analogi;
            sqlCom.Parameters.Add("@pokazaniya", DbType.String).Value = pokazaniya;
            sqlCom.Parameters.Add("@kod_prep", DbType.String).Value = kod_prep;
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void InsertPrep(string n_prep, string name_prep, string firma, string country, string date_proizv, string forma , string kolvo , string price , string srok , string kod_post)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand("INSERT INTO Preparat (n_prep , name_prep , firma, country ,  date_proizv , forma , kolvo , price , srok , kod_post) VALUES (@n_prep , @name_prep , @firma, @country ,  @date_proizv , @forma , @kolvo , @price , @srok , @kod_post)");
            sqlCom.Connection = dbConn;
            sqlCom.Parameters.Add("@n_prep", DbType.String).Value = n_prep;
            sqlCom.Parameters.Add("@name_prep", DbType.String).Value = name_prep;
            sqlCom.Parameters.Add("@firma", DbType.String).Value = firma;
            sqlCom.Parameters.Add("@country", DbType.String).Value = country;
            sqlCom.Parameters.Add("@date_proizv", DbType.String).Value = date_proizv;
            sqlCom.Parameters.Add("@forma", DbType.String).Value = forma;
            sqlCom.Parameters.Add("@kolvo", DbType.String).Value = kolvo;
            sqlCom.Parameters.Add("@price", DbType.String).Value = price;
            sqlCom.Parameters.Add("@srok", DbType.String).Value = srok;
            sqlCom.Parameters.Add("@kod_post", DbType.String).Value = kod_post;
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void LoadSortr(DataGridView dgw)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = "SELECT * FROM Sotr";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void LoadPost(DataGridView dgw)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = "SELECT * FROM Postavshik";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void LoadPrep(DataGridView dgw)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = "SELECT * FROM Preparat";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void LoadProd(DataGridView dgw)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = "SELECT * FROM Prodagi";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void LoadNaznach(DataGridView dgw)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = "SELECT * FROM Naznacheniya";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void PoiskSotr(DataGridView dgw , string sotr)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = string.Format("SELECT * FROM Sotr where f = '{0}'" , sotr);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void PoiskPost(DataGridView dgw, string post)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = string.Format("SELECT * FROM Postavshik where name_comp = '{0}'", post);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void PoiskPrep(DataGridView dgw, string prep)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = string.Format("SELECT * FROM Preparat where name_prep = '{0}'", prep);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void PoiskProd(DataGridView dgw, string prod)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = string.Format("SELECT * FROM Prodagi where name_prep = '{0}'", prod);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void PoiskNaznach(DataGridView dgw, string name_prep)
        {
            dbConn.Open();
            DataTable tb = new DataTable();
            string sql_query = string.Format("SELECT * FROM Naznacheniya where name_prep = '{0}'", name_prep);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_query, dbConn);
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dgw.Rows.Add(tb.Rows[i].ItemArray);
                }
            }

            dbConn.Close();
        }

        public void UpdateSotr(string f , string i , string o , string dr , string role , string adress , string phone , string id_sotr)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("UPDATE Sotr SET f = '{0}' , i = '{1}'  , o = '{2}' , birth = '{3}' , role = '{4}' , adress = '{5}' , phone = '{6}'  WHERE kod_sotr = '{7}'", f, i, o, dr , role , adress , phone , id_sotr);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void UpdatePost(string name_comp , string predst , string country , string city , string adress , string phone , string id_post)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("UPDATE Postavshik SET name_comp = '{0}' , predst = '{1}'  , country = '{2}' , city = '{3}' , adress = '{4}' , phone = '{5}' WHERE kod_post = '{6}'", name_comp, predst, country, city, adress, phone, id_post);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void UpdatePrep(string n_prep, string name_prep, string firma, string country, string date_proizv, string forma, string kolvo, string price, string srok, string kod_prep)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("UPDATE Preparat SET n_prep = '{0}' , name_prep = '{1}'  , firma = '{2}' , country = '{3}' , date_proizv = '{4}' , forma = '{5}' , kolvo = '{6}' , price = '{7}' , srok = '{8}'  WHERE kod_prep = '{9}'",  n_prep,  name_prep,  firma,  country,  date_proizv,  forma,  kolvo,  price,  srok,  kod_prep);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void UpdateProd(string kod_prep, string name_prep, string kolvo, string price, string n_check, string kod_prod)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("UPDATE Prodagi SET kod_prep = '{0}' , name_prep = '{1}'  , kolvo = '{2}' , price = '{3}' , n_check = '{4}'  WHERE kod_prod = '{5}'",  kod_prep,  name_prep,  kolvo,  price,  n_check,  kod_prod);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }


        public void UpdateNaznach(string n_prep, string name_prep, string opisaniye, string sostav, string analogi, string pokazaniya , string kod_naznach)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("UPDATE Naznacheniya SET n_prep = '{0}' , name_prep = '{1}'  , opisaniye = '{2}' , sostav = '{3}' , analogi = '{4}'  , pokazaniya = '{5}' WHERE kod_naznach = '{6}'",  n_prep,  name_prep,  opisaniye,  sostav,  analogi,  pokazaniya,  kod_naznach);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeleteSotr(string id_sotr)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("DELETE FROM Sotr WHERE kod_sotr = '{0}'", id_sotr);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeletePost(string id_post)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("DELETE FROM Postavshik WHERE kod_post = '{0}'", id_post);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeletePrep(string kod_prep)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("DELETE FROM Preparat WHERE kod_prep = '{0}'", kod_prep);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeleteProd(string kod_prod)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("DELETE FROM Prodagi WHERE kod_prep = '{0}'", kod_prod);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeleteNaznach(string kod_naznach)
        {
            dbConn.Open();
            sqlCom = new SQLiteCommand();
            sqlCom.Connection = dbConn;
            sqlCom.CommandText = string.Format("DELETE FROM Naznacheniya WHERE kod_naznach = '{0}'", kod_naznach);
            sqlCom.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}
