
using Npgsql;
using System.Data;

namespace WebApplication1.cs
{
    public class DBService
    {
        public NpgsqlConnection connectionDB = new NpgsqlConnection("server = localHost; port = 5432; Database = PointDB; user ID = postgres; password = 1234");
    }

   /*public void GetAllDB(Point point, EventArgs e)
    {
        string ques = "select * from Points";
        NpgsqlDataAdapter _dataAdapter = new NpgsqlDataAdapter(ques, connectionDB);
        DataSet _dataSet = new DataSet();
        _dataAdapter.Fill(_dataSet);
        dataGrid

        

    }*/
}
