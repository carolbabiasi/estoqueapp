﻿using EstoqueApp.Domain.Interfaces.Repositories;
using EstoqueApp.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey>
        where TModel : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual void Add(TModel model)
        {
            _dataContext?.Add(model);
        }

        public virtual void Update(TModel model)
        {
            _dataContext?.Update(model);
        }

        public virtual void Delete(TModel model)
        {
            _dataContext?.Remove(model);
        }

        public virtual List<TModel> GetAll()
        {
            return _dataContext?.Set<TModel>().ToList();
        }

        public virtual List<TModel> GetAll(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().Where(where).ToList();
        }

        public virtual TModel? GetById(TKey id)
        {
            return _dataContext?.Set<TModel>().Find(id);
        }

        public virtual TModel? Get(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().FirstOrDefault(where);
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}