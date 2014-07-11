using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Ekomsys.DataAccess.Classes
{
    using Ekomsys.DataAccess.Interfaces;
    using Ekomsys.DataAccess.Classes;
    public class RepositoryContext : IRepositoryContext
    {
        private const string OBJECT_CONTEXT_KEY = "ekomsysEntities";
        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IObjectSet<T> GetObjectSet<T>()
            where T : class
        {
            return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY).CreateObjectSet<T>();
        }
        /// <summary>
        /// Returns the active object context
        /// </summary>
        /// <value>
        /// The object context.
        /// </value>
        public ObjectContext ObjectContext
        {
            get
            {
                return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY);
            }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return this.ObjectContext.SaveChanges();
        }

        /// <summary>
        /// Terminates this instance.
        /// </summary>
        public void Terminate()
        {
            ContextManager.SetRepositoryContext(null, OBJECT_CONTEXT_KEY);
        }
    }
}
