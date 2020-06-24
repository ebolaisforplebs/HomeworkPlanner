using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App6
{
    [Table("Database")]
    public class SQLSource
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Description { get; set; }

        public string Department { get; set; }

        public string Subject { get;  set; }

        public string Date { get; set; }

        public int Percent { get; set; }
    }
}
