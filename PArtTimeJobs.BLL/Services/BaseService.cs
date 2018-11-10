using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using PartTimeJobs.DAL.Repository;
using PArtTimeJobs.BLL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PArtTimeJobs.BLL.Services
{
    public abstract class BaseService<T> where T:BaseEntity
    {
        protected IRepository<T> _repository;
        protected IValidator<T> _validator;

        protected BaseService(IValidator<T> validator)
        {
            _repository = UnitOfWork.GetRepository<T>();
            _validator = validator;
        }

        protected void PerformOperation(Action action)
        {
            try
            {
                action();
                UnitOfWork.Commit();
            }
            catch (ValidatorException vaEx)
            {
                //ar fi dragut sa logam eroare asta undeva
                throw vaEx;
            }
            catch (Exception ex)
            {
                //ar fi dragut sa logam eroarea asta undeva
                UnitOfWork.Revert();
                throw ex;
            }
        }

        public virtual void Add(T entity)
        {
            PerformOperation(() =>
            {
                _validator.Validate(entity);
                _repository.Add(entity);
            });
        }

        public virtual void Delete(int id)
        {
            PerformOperation(() => _repository.Delete(id));
        }

        public virtual void Update(T entity)
        {
            PerformOperation(() =>
            {
                _validator.Validate(entity);
                _repository.Update(entity);
            });
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

    }
}
