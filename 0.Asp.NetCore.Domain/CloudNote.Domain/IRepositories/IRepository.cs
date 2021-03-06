﻿using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Domain.IRepositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// 泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : BaseEntity<TPrimaryKey>
    {
        #region 
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        TEntity GetById(TPrimaryKey id);

        /// <summary>
        /// 根据lambda表达式获取实体集合
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据lambda表达式条件获取单个实体
        /// </summary>
        /// <param name="redicate">lambda表达式</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> redicate);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行保存</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行保存</param>
        /// <returns></returns>
        TEntity Update(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 更新或者新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否立即执行保存</param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <param name="autoSave">是否立即执行保存</param>
        void Delete(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="id">要删除的实体</param>
        /// <param name="autoSave">是否立即执行保存</param>
        void Delete(TPrimaryKey id, bool autoSave = true);

        /// <summary>
        /// 根据lambda表达式删除实体
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <param name="autoSave">是否自动保存</param>
        void Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);

        /// <summary>
        /// 事务性保存
        /// </summary>
        void Save();
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startPage">起始页</param>
        /// <param name="pageSize">页面条目</param>
        /// <param name="rowCount">数据总数</param>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        //IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order);

        //PagedObject<TEntity> GetPageList(GridPagerObject filter);

        //PagedObject<TEntity> GetPageList(IQueryable<TEntity> source, GridPagerObject filter);

        //PagedObject<TEntity> GetPageList(GridPagerObject filter, string includes);

        //PagedObject<TEntity> GetPageList(GridPagerObject filter, Expression<Func<TEntity, bool>> expression);

        //PagedObject<TEntity> GetPageList(GridPagerObject filter, IQueryable<TEntity> source, Expression<Func<TEntity, bool>> expression);
        #endregion
    }

    /// <summary>
    /// 默认Guid主键类型仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : BaseEntity
    {

    }
}
