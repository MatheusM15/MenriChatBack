using InfraMenriChat.Context;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface.common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class BaseEntityRespository<Tentity> : IBaseEntityRespository<Tentity> where Tentity : BaseEntity
    {
        public MenriChatContext _Context { get; set; }
        public DbSet<Tentity> _DbSet { get; set; }
        public BaseEntityRespository(MenriChatContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<Tentity>();

        }
        public IEnumerable<Tentity> GetAll()
        {
            try
            {
              return _DbSet.AsNoTracking().Where(t => t.Ativo == true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Tentity GetById(Guid Id)
        {
            try
            {
                return _DbSet.AsNoTracking().FirstOrDefault(t => t.Ativo == true && t.Id == Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool InsertOrReplace(Tentity entity)
        {
            try
            {
                var entityDb = _DbSet.AsNoTracking().Where(t => t.Id == entity.Id);
                if (entityDb.Any())
                {
                    entity.DtInclusao = DateTime.Now;
                    _DbSet.Update(entity);
                }
                else
                {
                    entity.DtAlteracao = DateTime.Now;
                    entity.DtInclusao = DateTime.Now;
                    entity.Ativo = true;
                    _DbSet.Add(entity);
                }
                _Context.SaveChanges();
                return true;

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var entityDb = _DbSet.AsNoTracking().Where(t => t.Id == Id);
                if (!entityDb.Any()) return false;

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
