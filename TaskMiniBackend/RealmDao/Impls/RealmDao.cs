using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using Realms;
using Realms.Exceptions;
using Newtonsoft.Json;
using RealmDao.Interfaces;
using RealmDao.Entities;

namespace RealmDao.Impls
{
    internal class RealmDao : IDao
    {
        /// <summary>
        /// <para>Realm操作インスタンス</para>
        /// </summary>
        private Realm Instance
        {
            get
            {
                var config = new RealmConfiguration("taskminibackend.realm") { SchemaVersion = 3 };

                var realm = Realm.GetInstance(config);

                return realm;
            }
        }

        private IEnumerable<Type> realmObjTypes = new List<Type>()
        { typeof(Entities.Task), typeof(Trash) };

        #region Public CRUD

        public void Create<E>(E entity)
        {
            try
            {
                var realm = this.Instance;

                var keyValueEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));

                var realmObjType = this.GetRealmObjType<E>();

                var realmObj = Activator.CreateInstance(realmObjType) as RealmObject;

                foreach (var keyValue in keyValueEntity.Where(kv => kv.Key != "id"))
                {
                    //Entityプロパティ値 ⇒ RealmObjectプロパティ値
                    var propName = this.ConvToPropNameOnCSharpeCulture(keyValue.Key);
                    realmObj.GetType().GetProperty(propName).SetValue(realmObj, keyValue.Value);
                }

                realm.Write(() => { realm.Add(realmObj); });
            }
            catch(RealmException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw new Exception(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw ex;
            }
        }

        public IEnumerable<E> Read<E>()
        {
            var entities = new List<E>();

            try
            {
                var realm = this.Instance;

                var realmObjType = this.GetRealmObjType<E>();

                var realmObjs = realm.All(realmObjType.Name);

                foreach (var realmObj in realmObjs)
                {
                    var entity = Activator.CreateInstance<E>();

                    foreach (var entityProp in entity.GetType().GetProperties())
                    {
                        //RealmObjectプロパティ値 ⇒ Entityプロパティ値
                        entityProp.SetValue(entity, ((RealmObject)realmObj).GetType().GetProperty(entityProp.Name).GetValue(realmObj));
                    }

                    entities.Add(entity);
                }
            }
            catch(RealmException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw new Exception(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw ex;
            }

            return entities;
        }

        public void Update<E>(E entity)
        {
            try
            {
                var realm = this.Instance;

                var keyValueEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));

                var realmObjType = this.GetRealmObjType<E>();

                foreach (var realmObj in realm.All(realmObjType.Name))
                {
                    if ((string)((RealmObject)realmObj).GetType().GetProperty("Id").GetValue(realmObj) == (string)keyValueEntity["id"])
                    {
                        realm.Write(() =>
                        {
                            foreach (var kv in keyValueEntity.Where(kv => kv.Key != "id"))
                            {
                                var propName = this.ConvToPropNameOnCSharpeCulture(kv.Key);
                                ((RealmObject)realmObj).GetType().GetProperty(propName).SetValue(realmObj, kv.Value);
                            }
                        });

                        break;
                    }
                }
            }
            catch(RealmException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //new Exception(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw ex;
            }
        }

        public void Delete<E>()
        {
            try
            {
                var realm = this.Instance;

                var realmObjType = this.GetRealmObjType<E>();

                using (var trans = realm.BeginWrite())
                {
                    realm.RemoveAll(realmObjType.Name);
                    trans.Commit();
                }
            }
            catch(RealmException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw new Exception(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw ex;
            }
        }

        public void Delete<E>(string id)
        {
            try
            {
                var realm = this.Instance;

                var realmObjType = this.GetRealmObjType<E>();

                foreach (var realmObj in realm.All(realmObjType.Name))
                {
                    if (((RealmObject)realmObj).GetType().GetProperty("Id").GetValue(realmObj) == id)
                    {
                        using (var trans = realm.BeginWrite())
                        {
                            realm.Remove((RealmObject)realmObj);
                            trans.Commit();
                        }

                        break;
                    }
                }
            }
            catch(RealmException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw new Exception(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                //throw ex;
            }
        }

        #endregion

        #region Support for public CRUD

        private Type GetRealmObjType<E>()
        {
            var realmObjType = this.realmObjTypes.Single(rot => rot.Name == typeof(E).Name);

            return realmObjType;
        }

        private string ConvToPropNameOnCSharpeCulture(string lowerPropName)
        {
            var convertedName = lowerPropName.Substring(0, 1).ToUpper() + lowerPropName.Substring(1);
            return convertedName;
        }

        #endregion
    }
}
