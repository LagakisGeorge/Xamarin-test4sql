﻿using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



using System.Data.SqlClient;





using Mono.Data.Sqlite;
using System.Data;


namespace test4sql
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PARAGGELIES : ContentPage
    {
        public PARAGGELIES()
        {
            InitializeComponent();
            laritmisi.Text = ReadSQL("select CAST(ARITMISI AS VARCHAR(10) ) FROM ARITMISI where ID=1");

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            AFM.Focus();
        }



        async void posothtaCompleted(object sender, EventArgs e)
        {

        }



        async void kataxorisi(object sender, EventArgs e)
        {

        }

        async void BRES_AFM(object sender, EventArgs e)
        {

            // determine the path for the database file
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "adodemo.db3");
            bool exists = File.Exists(dbPath);
            if (!exists)
            {
                Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);

            }

            SqliteConnection connection = new SqliteConnection("Data Source=" + dbPath);
            // Open the database connection and create table with data
            connection.Open();

            /* var c = connection.CreateCommand();           
            c.CommandText = "Query";
            var rowcount = c.ExecuteNonQuery(); // rowcount will be 1    */

            // query the database to prove data was inserted!
            var contents = connection.CreateCommand();
            contents.CommandText = "SELECT  * from PEL WHERE AFM like '%" + AFM.Text + "%' LIMIT 1 ; "; // +BARCODE.Text +"'";
            var r = contents.ExecuteReader();
            Console.WriteLine("Reading data");
            while (r.Read())
            {
                LABPEL.Text = r["EPO"].ToString();
            }
            // r["ONO"].ToString();



            connection.Close();

            BARCODE.Focus();





        }


        async void Click_Login(object sender, EventArgs e)
         {
            // determine the path for the database file
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "adodemo.db3");
            bool exists = File.Exists(dbPath);
            if (!exists)
            {
                Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);

            }

            SqliteConnection connection = new SqliteConnection("Data Source=" + dbPath);
            // Open the database connection and create table with data
            connection.Open();

            /* var c = connection.CreateCommand();           
            c.CommandText = "Query";
            var rowcount = c.ExecuteNonQuery(); // rowcount will be 1    */

            /*   string c = "CREATE TABLE IF NOT EXISTS EID( ID  INTEGER PRIMARY KEY,KOD [nvarchar](25)," +
                      "[ONO] [nvarchar](255) ," +
                       "[ENAL] [nvarchar](25) ," +
                        "[YPOL] [real] ," +
                         "[XONDR] [real] ," +
                           "[DESM] [real] ," +
                           "[ANAM] [real] ," +
                         "[BARCODE] [nvarchar](15)  )  ";   */






            // query the database to prove data was inserted!
            var contents = connection.CreateCommand();
            contents.CommandText = "SELECT  ONO,XONDR,ANAM,DESM,YPOL,BARCODE from EID WHERE BARCODE like '%"+BARCODE.Text +"%' LIMIT 1 ; "; // +BARCODE.Text +"'";
                var r = contents.ExecuteReader();
                Console.WriteLine("Reading data");
            while (r.Read())
            {
                lper.Text = r["ONO"].ToString();  // ****
                ltimh.Text = r["XONDR"].ToString();
                string ccc = r["XONDR"].ToString();
                lanam.Text = r["ANAM"].ToString(); // ***
                ldesm.Text = r["DESM"].ToString(); // ****
                lypol.Text = r["YPOL"].ToString();
                lbarcode.Text = r["BARCODE"].ToString();  // ***



            }
               // r["ONO"].ToString();
                   
                

            connection.Close();


        /*    var r = contents.ExecuteReader();
            Console.WriteLine("Reading data");
            while (r.Read())
            {
                i = i + 1;
                ff[i] = r["Symbol"].ToString();
                Console.WriteLine("\tKey={0}; Value={1}",
                                  r["_id"].ToString(),
                                  r["Symbol"].ToString());
            }  */






        }


        public string ReadSQL(string Query)
        {
            string dbPath = Path.Combine(
                  Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                  "adodemo.db3");
            SqliteConnection connection = new SqliteConnection("Data Source=" + dbPath);
            // Open the database connection and create table with data
            connection.Open();
            // query the database to prove data was inserted!
            var contents = connection.CreateCommand();
            contents.CommandText = Query ;
            var r = contents.ExecuteReader();
            Console.WriteLine("Reading data");
            string cc="";
            while (r.Read())
            {cc = r[0].ToString();}
            connection.Close();
            return cc;

        }









    } //PARAGGELIES
} //NAMESPACE 