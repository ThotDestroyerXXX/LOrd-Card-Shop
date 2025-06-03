using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class DatabaseSingleton
    {
        private static DatabaseEntities db = null;

        private DatabaseSingleton() { }

        public static DatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities();
            }
            return db;
        }
    }
}