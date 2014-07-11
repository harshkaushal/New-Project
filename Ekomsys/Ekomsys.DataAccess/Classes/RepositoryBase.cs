using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.EntityClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.Metadata.Edm;

namespace Ekomsys.DataAccess.Classes
{
    using Ekomsys.DataAccess.Interfaces;
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private IRepositoryContext _repositoryContext;
        private IObjectSet<T> _objectSet;
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}" /> class.
        /// </summary>
        public RepositoryBase() : this(new RepositoryContext()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryBase(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext = repositoryContext ?? new RepositoryContext();
            _objectSet = _repositoryContext.GetObjectSet<T>();
        }

        /// <summary>
        /// Gets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        public IRepositoryContext RepositoryContext
        {
            get
            {
                return this._repositoryContext;
            }
        }

        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <value>
        /// The object set.
        /// </value>
        public IObjectSet<T> ObjectSet
        {
            get
            {
                return _objectSet;
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            this.ObjectSet.AddObject(entity);
            this.RepositoryContext.SaveChanges();
        }
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            string esName = ((System.Data.Objects.ObjectSet<T>)this.ObjectSet).EntitySet.Name; //((System.Data.Metadata.Edm.EntitySetBase)(((System.Data.Objects.ObjectSet<Sample.Entities.Customer>)(this.ObjectSet)).EntitySet)).Name;           
            this.RepositoryContext.ObjectContext.ApplyCurrentValues(esName, entity);
            this.RepositoryContext.SaveChanges();

        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            this.ObjectSet.DeleteObject(entity);
            this.RepositoryContext.SaveChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            return this.ObjectSet.ToList<T>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).ToList<T>();
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).FirstOrDefault<T>();
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Attach(T entity)
        {
            this.ObjectSet.Attach(entity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }

        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetQueryable()
        {
            return this.ObjectSet.AsQueryable<T>();
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public long Count()
        {
            return this.ObjectSet.LongCount<T>();
        }

        /// <summary>
        /// Counts the specified where condition.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).LongCount<T>();
        }
        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid Page number;original</exception>
        public IList<T> PagedList(out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int64 noofPages, Func<T, IComparable> orderBy)
        {
            noofRecords = Count();
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                throw new System.ArgumentException("Invalid Page number", "original");
            var products = this.ObjectSet.OrderBy(orderBy).AsQueryable();
            return products.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //return this.ObjectSet.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //return this.ObjectSet.OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
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
        public IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy)
        {
            noofRecords = Count(whereCondition);
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                return null;
            if (pageNo == noofPages)
                pageNo = pageNo - 1;            
            //throw new System.ArgumentException("Invalid Page number", "");
            return this._objectSet.Where(whereCondition).OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereCondition">where condition</param>
        /// <param name="noofRecords">no of total records based on query</param>
        /// <param name="pageNo">current page no</param>
        /// <param name="pageSize">no of items per page</param>
        /// <param name="noofPages">total page in list</param>
        /// <param name="orderBy">order by query</param>
        /// <param name="sortOrder">asc or desc</param>
        /// <returns></returns>
        public IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy, string sortOrder)
        {
            noofRecords = Count(whereCondition);
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                return null;
            if (pageNo == noofPages)
                pageNo = pageNo - 1;
            if (sortOrder == "asc")
                return this._objectSet.Where(whereCondition).OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
            else
                return this._objectSet.Where(whereCondition).OrderByDescending(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }



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
        public IList<T> PagedList(Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy)
        {
            
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                return null;
            //if (pageNo == noofPages)
            //    pageNo = pageNo - 1;
            //throw new System.ArgumentException("Invalid Page number", "");
            var products = this.ObjectSet.OrderBy(orderBy).AsQueryable();
            return products.Skip(pageSize * pageNo).Take(pageSize).ToList();
        }

    }
}
