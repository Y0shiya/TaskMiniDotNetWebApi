using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDao.Interfaces
{
    public interface IDao
    {
        /// <summary>
        /// <para>データ生成。</para>
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        void Create<E>(E entity);

        /// <summary>
        /// <para>データ取得。</para>
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <returns></returns>
        IEnumerable<E> Read<E>();

        /// <summary>
        /// <para>データ更新。</para>
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        void Update<E>(E entity);

        /// <summary>
        /// <para>データ削除。</para>
        /// </summary>
        /// <typeparam name="E"></typeparam>
        void Delete<E>();

        /// <summary>
        /// <para>データ削除。</para>
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="id"></param>
        void Delete<E>(string id);
    }
}
