using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace participle.lib.data
{
    public class mysql
    {// username =da;power=123
        private string connstr = "Data Source=110-FB3772AF160;Initial Catalog=admin_data;Integrated Security=True";
        private SqlConnection conn;
        private SqlCommand com;
        private SqlTransaction fg;

        public mysql()
        {
            this.conn = new SqlConnection(connstr);
            this.conn.Open();
            //sleep()



        }
        public void chagedatabase(string database)
        {

            SqlCommand mm = new SqlCommand("use " + database, this.conn);
            mm.ExecuteNonQuery();

        }//


        //用来执行没有结果的语句，仅返回受影响行数。没有返回-1；
        public int update(string sql)
        {
            SqlCommand mm = new SqlCommand(sql, this.conn);
            //mm.ExecuteNonQuery();


            return mm.ExecuteNonQuery();
        }
        public SqlConnection getcon()
        {
            return this.conn;

        }
        public SqlDataReader mysql_read(string sql)
        {

            //string[][] retult;
            if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }


            SqlCommand sqlcom = new SqlCommand(sql, this.conn);
            SqlDataReader sqlread = sqlcom.ExecuteReader();
            if (sqlread == null)
            {

                return null;
            }
            else return sqlread;


        }

        public SortedDictionary<string, SortedDictionary<string, string>> mysql_read11(string sql)
        {
            SortedDictionary<string, string> msort;
            SortedDictionary<string, SortedDictionary<string, string>> mmsort = new SortedDictionary<string, SortedDictionary<string, string>>();
            //string[][] retult;
            if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }


            SqlCommand sqlcom = new SqlCommand(sql, this.conn);
            SqlDataReader sqlread = sqlcom.ExecuteReader();
            if (sqlread == null)
            {

                return null;
            }
            else
            {

                while (sqlread.Read())
                {
                    msort = new SortedDictionary<string, string>();
                    for (int i = 0; i < sqlread.FieldCount; i++)
                    {

                        msort.Add(sqlread.GetName(i), sqlread.GetValue(i).ToString());
                        Console.Write("--" + sqlread.GetName(i) + "--" + "--" + sqlread.GetValue(i).ToString() + "\n");

                    }
                    mmsort.Add(sqlread.GetString(1), msort);
                    //msort = null;
                }


                sqlcom.Clone();
                sqlread.Close();


                if (mmsort.Count == 0)
                {
                    return mmsort = null;

                }
                else return mmsort;


            }

        }


        public string mysql_readone(string f)
        {
            SqlCommand sqlcom = null;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }

                sqlcom = new SqlCommand(f, this.conn);
                sqlcom.CommandType = CommandType.Text;
            }
            catch (Exception e)
            {
                this.conn.Close();
            }
            //stringSqlDataReader sqlread = sqlcom.ExecuteReader();
            object d = sqlcom.ExecuteScalar();
            if (d == null)
            {
                return null;

            }
            else return d.ToString();


        }

        public Boolean mysql_write(string df)
        {

            if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }

            try
            {
                SqlCommand sqlcom = new SqlCommand(df, this.conn);
                sqlcom.Prepare();
                // SqlDataReader sqlread = sqlcom.ExecuteReader();
                int d = sqlcom.ExecuteNonQuery();

                if (d > 0)
                {

                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                this.conn.Close();
                return false;
            }

        }

        //自动生成语句
        public SqlDataReader mysql_write_select(string[] key, string database, string where)
        {

            //createsqlselect(key,database,where);

            return mysql_read(createsqlselect(key, database, where));

        }
        //更新
        public Boolean mysql_update(SortedDictionary<string, string> key, string database, string where)
        {


            return update(createsqlupdate(key, database, where)) != -1 ? true : false;


        }
        //插入
        public Boolean mysql_insert(SortedDictionary<string, string> key, string database, string where)
        {

            return update(createsqlinsert(key, database, where)) != -1 ? true : false;

        }
        public void mysql_close()
        {
            if (this.conn.State != ConnectionState.Closed)
                this.conn.Close();


        }
        public DataTable filld(string sql)
        {
            DataTable m = new DataTable();
            SqlDataAdapter msql = new SqlDataAdapter(sql, this.conn);
            msql.Fill(m);




            return m;

        }
        public string createsqlinsert(SortedDictionary<string, string> f, string databses, string where)
        {

            string keys = "";
            string values = "";
            string resul = "";
            foreach (KeyValuePair<string, string> fd in f)
            {

                keys += fd.Key + ',';

                values += "'" + fd.Value + "',";


            }
            keys = keys.Substring(0, keys.Length - 1);
            values = values.Substring(0, values.Length - 1);

            return resul = "insert into " + databses + " (" + keys + ")" + " values " + "(" + values + ")" + where; ;
        }
        public string createsqlupdate(SortedDictionary<string, string> f, string databses, string where)
        {
            string result = "";
            foreach (KeyValuePair<string, string> fd in f)
            {

                result += fd.Key + "=" + "'" + fd.Value + "',";


            }

            result = result.Substring(0, result.Length - 1);


            result = "update " + databses + " set " + result + " " + where;
            return result;
        }

        public string createsqlselect(string[] f, string databses, string where)
        {

            string result = "";
            for (int i = 0; i < f.Length; i++)
            {


                result += f[i] + ",";


            }
            result = result.Substring(0, result.Length - 1);
            return "select " + result + " from " + databses + " " + where;

        }
        //开始事务
        public void begintanr()
        {
            this.fg = this.conn.BeginTransaction();
            this.com = this.conn.CreateCommand();
            this.com.Transaction = fg;
            //return fg;

        }
        public void transaction(string g)
        {

            this.com.CommandText = g;
            this.com.ExecuteNonQuery();
        }

        public void commit()
        {
            this.fg.Commit();

        }

    }
}
