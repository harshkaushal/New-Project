using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Ekomsys.DataAccess.Interfaces
{
	public interface IRepositoryContext
	{
        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
		IObjectSet<T> GetObjectSet<T>() where T : class;
        /// <summary>
        /// Gets the object context.
        /// </summary>
        /// <value>
        /// The object context.
        /// </value>
		ObjectContext ObjectContext { get; }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
		int SaveChanges();
        /// <summary>
        /// Terminates this instance.
        /// </summary>
		void Terminate();
	}
}
