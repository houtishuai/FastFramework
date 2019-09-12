using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Demo.Core
{
    /// <summary>
    /// Dapper仓储类接口
    /// </summary>
    /// <typeparam name="TEntity">仓储实体</typeparam>
    public interface IRepository<TEntity> where TEntity : class,new()
    {

        #region Base

        /// <summary>
        /// 根据表主键获取数据
        /// </summary>
        /// <param name="key">表主键</param>
        /// <returns></returns>
        TEntity Get(object key);

        /// <summary>
        /// 获取表所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entityToInsert">待插入表实体类</param>
        /// <returns></returns>
        bool Insert(TEntity entityToInsert);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entityToUpdate">待更新表实体类</param>
        /// <returns></returns>
        bool Update(TEntity entityToUpdate);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entityToUpdate">待删除表实体类</param>
        /// <returns></returns>
        bool Delete(TEntity entityToDelete);

        #endregion

        #region Get

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        TEntity Get(object key, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="TEntity">仓储实体</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object key, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        T Get<T>(object key, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 根据主键获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(object key, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>(IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        #endregion

        #region Insert

        /// <summary>
        /// 新增实体数据
        /// </summary>
        /// <param name="entityToInsert">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>成功插入条数</returns>
        bool Insert(TEntity entityToInsert, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 新增实体数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entityToInsert">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>成功插入条数</returns>
        Task<bool> InsertAsync(TEntity entityToInsert, IDbTransaction traction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null);

        /// <summary>
        /// 新增实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToInsert">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>成功插入条数</returns>
        long Insert<T>(T entityToInsert, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 新增实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToInsert">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>成功插入条数</returns>
        Task<long> InsertAsync<T>(T entityToInsert, IDbTransaction traction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class,new();

        #endregion

        #region Update

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <param name="entityToUpdate">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否修改成功</returns>
        bool Update(TEntity entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entityToUpdate">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否修改成功</returns>
        Task<bool> UpdateAsync(TEntity entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToUpdate">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否修改成功</returns>
        bool Update<T>(T entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToUpdate">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否修改成功</returns>
        Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        #endregion

        #region Delete

        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <param name="entityToDelete">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否删除成功</returns>
        bool Delete(TEntity entityToDelete, IDbTransaction traction = null, int? commandTimeout = null);

        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToDelete">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否删除成功</returns>
        bool Delete<T>(T entityToDelete, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityToDelete">实体对象</param>
        /// <param name="traction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction traction = null, int? commandTimeout = null) where T : class,new();

        #endregion

        #region Execute

        /// <summary>
        /// 执行sql语句,用于增删改查
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <returns>返回执行sql后受影响的行数</returns>
        int Execute(string sql, object param = null);

        /// <summary>
        /// 执行sql语句,用于增删改查
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <returns>返回执行sql后受影响的行数</returns>
        Task<int> ExecuteAsync(string sql, object param = null);

        /// <summary>
        /// 执行sql命令,用于增删改查
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回执行sql后受影响的行数</returns>
        int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行sql命令,用于增删改查
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回执行sql后受影响的行数</returns>
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

        #region Query

        /// <summary>
        /// 查询数据,返回指定数据类型
        /// </summary>
        /// <typeparam name="TEntity">返回数据的类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="buffered">是否缓冲</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回指定数据类型的数据序列</returns>
        IEnumerable<TEntity> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 查询数据,返回指定数据类型
        /// </summary>
        /// <typeparam name="TEntity">返回数据的类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="buffered">是否缓冲</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回指定数据类型的数据序列</returns>
        Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 查询数据,返回指定数据类型
        /// </summary>
        /// <typeparam name="T">返回数据的类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="buffered">是否缓冲</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回指定数据类型的数据序列</returns>
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class,new();

        /// <summary>
        /// 查询数据,返回指定数据类型
        /// </summary>
        /// <typeparam name="T">返回数据的类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="buffered">是否缓冲</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回指定数据类型的数据序列</returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new();

        /// <summary>
        /// 执行查询并将第一个结果映射到指定类型对象,无结果则抛出异常
        /// </summary>
        /// <typeparam name="T">指定类型对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回查询结果集的第一个结果</returns>
        T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new();

        /// <summary>
        /// 执行查询并将第一个结果映射到指定类型对象,无结果则抛出异常
        /// </summary>
        /// <typeparam name="T">指定类型对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回查询结果集的第一个结果</returns>
        Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class,new();

        /// <summary>
        /// 执行查询并将第一个结果映射到指定类型对象,无结果返回默认值
        /// </summary>
        /// <typeparam name="T">指定类型对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回查询结果集的第一个结果</returns>
        T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行查询并将第一个结果映射到指定类型对象,无结果返回默认值
        /// </summary>
        /// <typeparam name="T">指定类型对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数对象</param>
        /// <param name="transaction">此次操作的事务对象</param>
        /// <param name="commandTimeout">执行的超时时间</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>返回查询结果集的第一个结果</returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

        /// <summary>
        /// 释放对象方法
        /// </summary>
        void Dispose();
    }
}
