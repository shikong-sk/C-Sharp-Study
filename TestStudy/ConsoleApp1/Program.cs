using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;

namespace TestStudy
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            String serverConfig =
                "server=127.0.0.1;port=3306;user=root;password=12341234;database=wzry_helper;Charset=utf8";
            using (MySqlConnection connection = new MySqlConnection(serverConfig))
            {
                try
                {
                    connection.Open();
                    Dictionary<String, List<String>> dictionary = new Dictionary<string, List<string>>();
                    MySqlCommand exec =
                        new MySqlCommand(
                            "SELECT table_name,column_name FROM information_schema.columns WHERE table_schema = 'wzry_helper'",
                            connection);
                    MySqlDataReader res = exec.ExecuteReader();
                    while (res.Read())
                    {
                        String table = res.GetString("table_name");
                        String column = res.GetString("column_name");
                        if (dictionary.ContainsKey(table))
                        {
                            dictionary[table].Add(column);
                        }
                        else
                        {
                            dictionary.Add(table, new List<string>{column});
                        }
                    }

                    foreach (KeyValuePair<String,List<String>> data in dictionary)
                    {
                        Console.WriteLine(data.Key);
                        foreach (String column in data.Value)
                        {
                            Console.Write(column + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }


            new Thread(() =>
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("多线程 ：" + DateTime.Now);
                    Thread.Sleep(1000);
                }
            }).Start();

            Console.WriteLine("Hello World!");
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("主线程 ：" + DateTime.Now);
                Thread.Sleep(1000);
            }
        }
    }
}