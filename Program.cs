using LearningSQLClient.Models;
using LearningSQLClient.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace LearningSQLClient
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string choice 


        }

        static void TestSelectAll(ISuperheroRepository repository)
        {

        }
        static void TestSelect(ISuperheroRepository repository)
        {

        }

        static void PrintSuperheroes(IEnumerable<Superheroes> superheroes)
        {
            foreach (var superhero in superheroes)
            {
                PrintSuperheroe(superhero);
            }
        }

        static void PrintSuperheroe(Superheroes superhero)
        {
            Console.WriteLine($"---{ superhero.ID} {superhero.Name} {superhero.Orgin} ");
        }

        /// <summary>
        /// A method that shall execute all prepared SQLscripts in order of apperance
        /// </summary>
        static void ExecuteAssignment2AppendixARequirements()
        {
            string[] allfiles = Directory.GetFiles("/SQLscripts", "*.sql", SearchOption.AllDirectories);
            ConnectionStingHelper ConnectionStingHelper = new ConnectionStingHelper();
            foreach (var sqlScript in allfiles)
            {
                
                string sqlConnectionString = ConnectionStingHelper.GetConnectionString();
                FileInfo file = new FileInfo(sqlScript);
                string script = file.OpenText().ReadToEnd();
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
            }

        }

    }
}
