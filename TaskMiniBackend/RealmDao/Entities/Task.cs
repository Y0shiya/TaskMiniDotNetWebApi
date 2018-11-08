using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace RealmDao.Entities
{
    public class Task:RealmObject
    {
        [PrimaryKey]
        [Required]
        [MapTo("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MapTo("note")]
        public string Note { get; set; } = "";

        [MapTo("order")]
        public Int64 Order { get; set; } = 0;
    }
}
