using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace hotelv2
{
    public class baza
    {
        private string url = "mongodb+srv://ks:skola@cluster0-oxl2a.mongodb.net/test?retryWrites=true&w=majority";
        string dbo = "hotel";
        private IMongoDatabase db;
        public baza( )
        {
            IMongoClient client = new MongoClient(url);
            db = client.GetDatabase(dbo);
        }
        public void insertRecord<T>(string collection, T record)
        {
            var col = db.GetCollection<T>(collection);
            col.InsertOne(record);


        }
        public T findDoc<T>(string col, string ime, string prezime, string jmbg, string brojSobe,string brojtel, string datumd, string datumo)
        {
            Guest q = new Guest();

            var colection = db.GetCollection<T>(col);

            var filter2 = new BsonDocument();
            if (ime != "")
            {
                filter2 = filter2.Add("ime", ime);
            }
            if (prezime != "")
            {
                filter2 = filter2.Add("prezime", prezime);
            }
            if (jmbg != "")
            {
                filter2 = filter2.Add("jmbg", jmbg);
            }
            if (brojSobe != "")
            {
                filter2 = filter2.Add("brojSobe", brojSobe);
            }
            if (brojtel != "")
            {
                filter2 = filter2.Add("brojtel", brojtel);
            }
            if (datumd != "")
            {
                filter2 = filter2.Add("datumDolaska", datumd);
            }
            if (datumo != "")
            {
                filter2 = filter2.Add("datumOdlaska", datumo);
            }
            var res=colection.FindSync(filter2).First();
            return res;
            
        }
        public List<T> findAll<T>(string col)
        {

            var collection = db.GetCollection<T>(col);
            return  collection.Find(new BsonDocument()).ToList();
        }
        public T findOne<T>(string col,string username)
        {
            var filter2 = new BsonDocument();
            var filterbackup = new BsonDocument();
            filterbackup.Add("username", "a");
            var collection = db.GetCollection<T>(col);
            filter2.Add("username", username);
           
            try {
                return collection.FindSync(filter2).First();
            }
            catch {
                return collection.FindSync(filterbackup).First(); ;
            }
            
            
           
            
               


            
           
        }
     
    }
}
