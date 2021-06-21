using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
      
          using  SqlConnection connection = new SqlConnection();

            connection.ConnectionString= "Server=DESKTOP-PAVS32T\\SQLEXPRESS;Database=Aspdotnetb5;User Id=aspdotnetb5;Password=aspdotnetb5";


            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }

            MyORM<Students> orm = new MyORM<Students>(connection);

            

            orm.Insert(new Students() { StudentName = "kajol", Home = "magura" });
            orm.Insert(new Students() { StudentName = "mehedi", Home = "Thakurgaon" });
            orm.Insert(new Students() { StudentName = "Kalam", Home = "Panchagarh" });
            orm.Insert(new Students() { StudentName = "Imran", Home = "dhaka" });


            var getinfo = orm.GetById(2);


            Console.WriteLine(getinfo.Home);

            Console.WriteLine(getinfo.StudentName);


             orm.Delete(2);
            orm.Update(new Students() { ID = 3, StudentName = "Asik", Home = "Rajshahi" });

            List<Students> list = orm.GetAll();

            foreach(var info in list)
            {
                Console.WriteLine($"studentname: {info.StudentName} , Home: {info.Home}");

            }

            orm.Delete(new Students());


            




            




        }
    }
}
