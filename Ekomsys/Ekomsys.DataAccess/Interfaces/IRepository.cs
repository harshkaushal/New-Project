using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

namespace Ekomsys.DataAccess.Interfaces
{
	public interface IRepository<T>
	{
        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
		T GetSingle(Expression<Func<T, bool>> whereCondition);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		void Add(T entity);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		void Delete(T entity);
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		void Attach(T entity);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
		IList<T> GetAll(Expression<Func<T, bool>> whereCondition);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
		IList<T> GetAll();
        
        
        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <returns></returns>
		IQueryable<T> GetQueryable();
        /// <summary>
        /// Counts the specified where condition.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
		long Count(Expression<Func<T, bool>> whereCondition);
        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
		long Count();
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        IList<T> PagedList(out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int64 noofPages, Func<T, IComparable> orderBy);
        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy);
        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns></returns>
        IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy, string sortOrder);


        IList<T> PagedList( Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy);
	}
}
