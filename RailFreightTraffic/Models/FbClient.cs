
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    static public class FbClient
    {
        static private string GetConnectionString()
        {
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.DataSource = "localhost";
            //csb.Port = 3050;
            csb.Database = AppDomain.CurrentDomain.BaseDirectory + "RAIL.FDB";
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";

            return csb.ToString();
        }

        static public List<object[]> ExecuteQuery(string cmd)
        {
            List<object[]> result = new List<object[]>();
            FbConnection _database = new FbConnection(GetConnectionString());
            try
            {
                _database.Open();
                FbCommand prc = new FbCommand(cmd, _database);

                using (FbDataReader dr = prc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        object[] objs = new object[dr.FieldCount];
                        for(int i = 0; i < dr.FieldCount; i++)
                        {
                            objs[i] = dr.GetValue(i);
                        }
                        result.Add(objs);
                    }
                }
            }
            finally
            {
                _database.Close();
            }
            return result;
        }

        static public void ExecuteCommand(FbCommandArgs args)
        {
            FbConnection _database = new FbConnection(GetConnectionString());
            try
            {
                _database.Open();
                FbTransaction transaction = _database.BeginTransaction();

                FbCommand command = new FbCommand(args.Name, _database, transaction);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (FbCommandParameterArgs parameter in args.Parameters)
                {
                    command.Parameters.Add(parameter.Name, parameter.Type).Value = parameter.Value;
                }

                Execute(command);

                transaction.Commit();
            }

            finally
            {
                _database.Close();
            }
        }

        static public List<object[]> ExecuteReaderCommand(FbCommandArgs args)
        {
            FbConnection _database = new FbConnection(GetConnectionString());
            List<object[]> result = new List<object[]>();
                try
                {
                    _database.Open();
                    FbTransaction transaction = _database.BeginTransaction();

                    FbCommand command = new FbCommand(args.Name, _database, transaction);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (FbCommandParameterArgs parameter in args.Parameters)
                    {
                        command.Parameters.Add(parameter.Name, parameter.Type).Value = parameter.Value;
                    }

                    result = ExecuteReader(command);

                    transaction.Commit();
                }
                finally
                {
                    _database.Close();                
                }
                return result;
        }

        static private void Execute(FbCommand command)
        {
            command.ExecuteNonQuery();
        }

        static private List<object[]> ExecuteReader(FbCommand command)
        {
            
            FbDataReader dataAdapter = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();

            while (dataAdapter.Read())
            {
                var columns = new object[dataAdapter.FieldCount];
                dataAdapter.GetValues(columns);
                rows.Add(columns);
            }

            return rows;
        }
    }
}
