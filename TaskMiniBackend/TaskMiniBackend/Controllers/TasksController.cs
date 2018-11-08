using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskMiniBackend.Models;
using TaskMiniBackend.Filters;
using RealmDao.Interfaces;
using RealmDao.Dependencies;

namespace TaskMiniBackend.Controllers
{
    public class TasksController:ApiController
    {
        private IDao dao;
        private IDao Dao
        {
            get { return this.dao = this.dao ?? new Dependency().Inject(); }
        }

        //全件取得
        // Get api/tasks
        public IEnumerable<TaskMiniBackend.Models.Task> Get()
        {
            var tasks = this.Dao.Read<TaskMiniBackend.Models.Task>();

            return tasks.OrderBy(t => t.Order);
        }

        //取得
        // GET api/tasks/id
        public TaskMiniBackend.Models.Task Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; 
            }

            TaskMiniBackend.Models.Task task = null;

            task = this.Dao.Read<TaskMiniBackend.Models.Task>().SingleOrDefault(t => t.Id == id);

            return task;
        }

        //新規登録
        // POST api/tasks
        public void Post([FromBody]TaskMiniBackend.Models.Task task)
        {
            if (task == null)
                return;

            var lastTask = this.Dao.Read<Task>().OrderByDescending(t => t.Order).FirstOrDefault();

            if(lastTask != null)
            {
                task.Order = lastTask.Order + 1;
            }

            this.Dao.Create<TaskMiniBackend.Models.Task>(task);
        }

        //更新
        // PUT api/tasks
        public void Put([FromBody]TaskMiniBackend.Models.Task task)
        {
            if(task == null)
            {
                return;
            }

            this.Dao.Update<TaskMiniBackend.Models.Task>(task);
        }

        //削除
        // DELETE api/tasks/id
        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return;

            this.Dao.Delete<TaskMiniBackend.Models.Task>(id);
        }
    }
}