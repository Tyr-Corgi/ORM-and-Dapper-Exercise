﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            var connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            ////var repo = new DepartmentRepository(connString); //Without Dapper

            //Console.WriteLine("Type a new Department Name");

            //var NewDepartmetn = Console.ReadLine();

            //repo.InsertDepartment(newDepartment);

            //var departments = r.GetAllDepartments();

            //var container = new Container(x =>
            //{
            //    x.AddTransient<IDbConnection>((c) =>
            //    {
            //        return new MySqlConnection(connString);
            //    });

            //    x.AddTransient<IDepartmentRepository, DapperDepartmentRepository>();
            //});
            //var repo = container.GetService<IDepartmentRepository>();

            var repo = new DapperDepartmentRepository(conn);
            var departments = repo.GetAllDepartments();

            Console.WriteLine("ID -- NAME \n---------------------------");
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID}  -- {dept.Name}");
            }
        } 
    }
}
