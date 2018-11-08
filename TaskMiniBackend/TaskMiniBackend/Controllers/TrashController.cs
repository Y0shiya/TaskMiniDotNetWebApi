using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskMiniBackend.Models;
using RealmDao.Interfaces;
using RealmDao.Dependencies;

namespace TaskMiniBackend.Controllers
{
    public class TrashController:ApiController
    {
        private IDao dao;
        private IDao Dao
        {
            get { return this.dao = this.dao ?? new Dependency().Inject(); }
        }

        //全件取得
        // GET api/trash
        public IEnumerable<Trash> Get()
        {
            var trash = this.Dao.Read<Trash>();

            //削除予定
            //var trash = Enumerable.Range(1, 20).Select(i => new Trash() { Id = i.ToString(), Note = "trash" + i });

            return trash.OrderBy(t => t.Order);
        }

        //新規登録
        // POST api/trash
        public void Post([FromBody] Trash trash)
        {
            if (trash == null)
                return;

            var lastTrash = this.Dao.Read<Trash>().OrderByDescending(t => t.Order).FirstOrDefault();

            if(lastTrash != null)
            {
                trash.Order = lastTrash.Order + 1;
            }

            this.Dao.Create<Trash>(trash);
        }

        //全件削除
        // DELETE api/trash
        public void Delete()
        {
            this.Dao.Delete<Trash>();
        }

        //削除
        // DELETE api/trash/id
        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return;

            this.Dao.Delete<Trash>(id);
        }
    }
}