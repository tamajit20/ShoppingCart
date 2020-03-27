using ShoppingCart.DBConnect.MySQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ShoppingCart.DBConnect.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {      
        public DbContext Context { get; set; } = GetDBContext();

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
        }

        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual T Update(T entity)
        {
            try
            {
              //  _entities.Set<T>().Update(entity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }


        public T UpdateColumn(T entity, params Expression<Func<T, object>>[] properties)
        {
            try
            {
                Context.Set<T>().Attach(entity);

                var entry = Context.Entry(entity);

                foreach (var property in properties)
                    entry.Property(property).IsModified = true;

                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<T> GetAllUsingExpression(out int totalItemCount, int recordsPerPage = -1, int currentPage = 0,
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Expression<Func<T, T>> columns = null,
           params Expression<Func<T, object>>[] includeExpressions)
        {
            try
            {
                recordsPerPage = recordsPerPage <= 0 ? 10 : recordsPerPage;
                IQueryable<T> query = Context.Set<T>();
                totalItemCount = 0;

                if ((includeExpressions != null && includeExpressions.Any()) || recordsPerPage != -1)
                {
                    query = includeExpressions.Aggregate(query, (current, include) => current.Include(include));
                    if (predicate != null)
                    {
                        query = query.Where(predicate);
                    }
                }
                else
                {
                    if (predicate != null)
                    {
                        query = Context.Set<T>().Where(predicate);
                    }
                }
                totalItemCount = query.Count();
                if (columns != null)
                {
                    query = query.Select<T, T>(columns).AsQueryable<T>();
                }

                if (orderBy != null && totalItemCount > 0 && currentPage > 0)
                {
                    int recordsRequired = currentPage * recordsPerPage;
                    int skipRecords = recordsPerPage * (currentPage - 1);
                    if (recordsRequired > totalItemCount)
                    {
                        recordsPerPage = totalItemCount - skipRecords;
                    }

                    query = orderBy(query).Skip(skipRecords).Take(recordsPerPage);
                }
                else if (orderBy != null && totalItemCount > 0)
                {
                    query = orderBy(query);
                }

                var result = query.AsNoTracking().ToList<T>();
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public T GetByIdUsingExpression(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = Context.Set<T>().AsQueryable<T>();

            try
            {
                if (includeExpressions.Any())
                {
                    set = includeExpressions.Aggregate(set, (current, include) => current.Include(include));

                    if (predicate != null)
                    {
                        return set.Where(predicate).FirstOrDefault();
                    }
                    else
                    {
                        return set.FirstOrDefault();
                    }
                }
                else
                {
                    if (predicate != null)
                    {
                        return Context.Set<T>().Where(predicate).FirstOrDefault(predicate);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public int ExecuteSqlCommand(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlCommand(query, parameters);
        }

        private static DbContext GetDBContext()
        {
            return new MySQLDBContext();
        }
    }
}
