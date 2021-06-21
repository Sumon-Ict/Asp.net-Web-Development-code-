using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
   public class MyORM<T>where T:IData
    {

        private SqlConnection _sqlconnection;

        public MyORM(SqlConnection connection)
        {
            _sqlconnection = connection;

        }

        public MyORM(  string ConnectionString):
            this(new SqlConnection(ConnectionString))
        {


        }

        public void Insert(T item)
        {
            var type = typeof(T);

            var sql = new StringBuilder("insert into ");

            sql.Append(type.Name + "(");

            var sqlValue = new StringBuilder();

            var fields = item.GetType().GetProperties();

            var sqlParameters = new SqlParameter[fields.Length - 1];

            for (int i = 1; i < fields.Length; i++)
            {
                if (i == fields.Length - 1)
                {
                    sql.Append(fields[i].Name + ") VALUES(");
                    sqlValue.Append("@" + fields[i].Name + ")");
                }
                else
                {
                    sql.Append(fields[i].Name + ",");
                    sqlValue.Append("@" + fields[i].Name + ",");
                }
                sqlParameters[i - 1] = new SqlParameter("@" + fields[i].Name, fields[i].GetValue(item));
            }
            sql.Append(sqlValue.ToString());

            var query = sql.ToString();

            var sqlCommand = new SqlCommand(query, _sqlconnection);

            sqlCommand.Parameters.AddRange(sqlParameters);

            sqlCommand.ExecuteNonQuery();
        }

       
        public void Update(T item)
        {

            var type = typeof(T);

         
        var sql = new StringBuilder("update ");

        sql.AppendFormat("{0} set ", type.Name);

        var  fields = item.GetType().GetProperties();

        var sqlParameters = new SqlParameter[fields.Length];
                        
          for(int i=1;i<fields.Length;i++)
            {
                if(i==fields.Length-1)
                { 
                    sql.AppendFormat("{0}=@{0} ", fields[i].Name);
                }
                else
                {
                    sql.AppendFormat("{0}=@{0},", fields[i].Name);
                }

              sqlParameters[i - 1] = new SqlParameter("@" + fields[i].Name, fields[i].GetValue(item));
            }

        sql.AppendFormat("WHERE {0}=@{0}", fields[0].Name);

         sqlParameters[fields.Length - 1] = new SqlParameter("@" + fields[0].Name, fields[0].GetValue(item));

         var query = sql.ToString();

        var  command = new SqlCommand(query, _sqlconnection);
      
        command.Parameters.AddRange(sqlParameters);

        command.ExecuteNonQuery();
              
        }

        public void Delete(int id)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            var sql = new StringBuilder("delete from ");

            sql.Append(type.Name);
            sql.Append(" where ");
            sql.Append(properties[0].Name);
            sql.Append('=');
            sql.Append(id);

            var query = sql.ToString();
            var command = new SqlCommand(query, _sqlconnection);

            command.ExecuteNonQuery();
        }
        public void Delete(T item)
        {
            var type = typeof(T);

            var sql = new StringBuilder("delete from ");

            sql.Append(type.Name);

            var query = sql.ToString();

            var command = new SqlCommand(query, _sqlconnection);

            command.ExecuteNonQuery();

        }
        private T GetOneRowValue(DataTable dt)
        {

            T t = Activator.CreateInstance<T>();

            var type = typeof(T);

            PropertyInfo[] fields = type.GetProperties();

            DataRow dr = dt.Rows[0];

            int count = dt.Columns.Count;

            foreach (var field in fields)
            {
                for (int i = 0; i < count; i++)
                {
                    if (field.Name.ToUpper() == dt.Columns[i].ColumnName.ToUpper())
                    {
                        field.SetValue(t, dr[i], null);
                        break;
                    }
                }
            }
            return t;
        }
        public T GetById(int id)
        {
            var type = typeof(T);

            var sql = new StringBuilder("select * from ");
            sql.Append(type.Name);
            sql.Append(" where id=");
            sql.Append(id);

            var query = sql.ToString();

            var command = new SqlCommand(query, _sqlconnection);

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter(command);

            sda.Fill(ds);

            T t = GetOneRowValue(ds.Tables[0]);

            return t;
        }
        private List<T> GetAllRowValue(DataTable dt)
        {
            List<T> arrList = new List<T>();

            var properties = typeof(T).GetProperties();

            int columnCount = dt.Columns.Count;

            int rowCount = dt.Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                T t = Activator.CreateInstance<T>();
                for (int j = 0; j < columnCount; j++)
                {
                    foreach (var property in properties)
                    {
                        if (property.Name.ToUpper() == dt.Columns[j].ColumnName.ToUpper())
                        {
                            property.SetValue(t, dt.Rows[i][j], null);
                            break;
                        }
                    }
                }
                arrList.Add(t);
            }
            return arrList;
        }

        public List<T> GetAll()
        {

            var type = typeof(T);

            string query = "SELECT * FROM " + type.Name;

            var command = new SqlCommand(query, _sqlconnection);

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter(command);

            sda.Fill(ds);

            DataTable dt = ds.Tables[0];

            List<T> arrList = GetAllRowValue(dt);

            return arrList;
        }


    }
}
