using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using Demo.Core;

namespace Demo.Dapper
{
    /// <summary>
    /// Dapper仓储类基类
    /// </summary>
    /// <typeparam name="TEntity">仓储实体</typeparam>
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class,new()
    {
        public DapperRepository()
        {
            this.Connection = DBFactory.CreateConnection();
        }

        public DapperRepository(IDbConnection dbConnection)
        {
            this.Connection = dbConnection;
        }
        public IDbConnection Connection { get; private set; }

        #region Connection基础操作

        /// <summary>
        /// 打开数据库连接,如果关闭或者连接中断,则打开连接
        /// </summary>
        public void OpenConnection(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            else if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }

        /// <summary>
        /// 以指定的 System.Data.IsolationLevel 值开始一个数据库事务。
        /// </summary>
        /// <param name="il">指定连接的事务锁定行为</param>
        /// <returns>表示新事务的对象</returns>
        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            OpenConnection(this.Connection);
            return this.Connection.BeginTransaction(il);
        }

        /// <summary>
        /// 开始一个数据库事务
        /// </summary>
        /// <returns></returns>
        public IDbTransaction BeginTransaction()
        {
            OpenConnection(this.Connection);
            return this.Connection.BeginTransaction();
        }

        /// <summary>
        /// 为打开的 Connection 对象更改当前数据库
        /// </summary>
        /// <param name="dataBaseName">要代替当前数据库进行使用的数据库的名称</param>
        public void ChangeDataBase(string dataBaseName)
        {
            this.Connection.ChangeDatabase(dataBaseName);
        }

        /// <summary>
        /// 创建并返回一个与该连接相关联的 Command 对象
        /// </summary>
        /// <returns>一个与该连接相关联的 Command 对象</returns>
        public IDbCommand CreateCommand()
        {
            return this.Connection.CreateCommand();
        }

        #endregion

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="TEntity">仓储实体</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        public virtual TEntity Get(object key)
        {
            return Get<TEntity>(key);
        }

        public TEntity Get(object key, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return this.Get<TEntity>(key, traction, commandTimeout);
        }

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="TEntity">仓储实体</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(object key, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return await GetAsync<TEntity>(key);
        }

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        public T Get<T>(object key, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return Connection.Get<T>(key, traction, commandTimeout);
        }

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(object key, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return await Connection.GetAsync<T>(key, traction, commandTimeout);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetAll<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(IDbTransaction traction = null, int? commandTimeout = null)
        {
            return this.GetAll<TEntity>(traction, commandTimeout);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(IDbTransaction traction = null, int? commandTimeout = null)
        {
            return await Connection.GetAllAsync<TEntity>(traction, commandTimeout);
        }

        public IEnumerable<T> GetAll<T>(IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return Connection.GetAll<T>(traction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return await Connection.GetAllAsync<T>(traction, commandTimeout);
        }

        public bool Insert(TEntity entityToInsert)
        {
            return this.Connection.Insert<TEntity>(entityToInsert) > 0;
        }

        public bool Insert(TEntity entityToInsert, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return this.Insert<TEntity>(entityToInsert, traction, commandTimeout) > 0;
        }

        public async Task<bool> InsertAsync(TEntity entityToInsert, IDbTransaction traction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null)
        {
            return await InsertAsync<TEntity>(entityToInsert, traction, commandTimeout) > 0;
        }

        public long Insert<T>(T entityToInsert, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return Connection.Insert<T>(entityToInsert, traction, commandTimeout);
        }

        public async Task<long> InsertAsync<T>(T entityToInsert, IDbTransaction traction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class,new()
        {
            return await Connection.InsertAsync<T>(entityToInsert, traction, commandTimeout, sqlAdapter);
        }

        public bool Update(TEntity entityToUpdate)
        {
            return this.Connection.Update<TEntity>(entityToUpdate);
        }

        public bool Update(TEntity entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return this.Update<TEntity>(entityToUpdate, traction, commandTimeout);
        }

        public async Task<bool> UpdateAsync(TEntity entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return await UpdateAsync<TEntity>(entityToUpdate);
        }

        public bool Update<T>(T entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return Connection.Update<T>(entityToUpdate, traction, commandTimeout);
        }

        public async Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return await Connection.UpdateAsync<T>(entityToUpdate, traction, commandTimeout);
        }

        public bool Delete(TEntity entityToDelete, IDbTransaction traction = null, int? commandTimeout = null)
        {
            return this.Delete<TEntity>(entityToDelete, traction, commandTimeout);
        }

        public bool Delete(TEntity entityToDelete)
        {
            return this.Connection.Delete<TEntity>(entityToDelete);
        }

        public bool Delete<T>(T entityToDelete, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return Connection.Delete(entityToDelete, traction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new()
        {
            return await Connection.DeleteAsync<T>(entityToDelete, traction, commandTimeout);
        }

        public int Execute(string sql, object param = null)
        {
            return Connection.Execute(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await Connection.ExecuteAsync(sql, param);
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public IEnumerable<TEntity> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query<TEntity>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryAsync<TEntity>(sql, param, transaction, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class,new()
        {
            return Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new()
        {
            return await Connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new()
        {
            return Connection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new()
        {
            return await Connection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
