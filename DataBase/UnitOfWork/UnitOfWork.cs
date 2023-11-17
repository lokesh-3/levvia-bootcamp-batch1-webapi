using DataBase.Interface;
using DataBase.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, dynamic> _repositories = new Dictionary<Type, dynamic>();
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            engagements = new EngagementRepository(_context);
            clientAuditors = new ClientAuditorsRepository(_context);
            country=new CountryRepository(_context);
            file=new FileRepository(_context);
            auditOutcomeMaster = new AuditOutcomeMasterRepository(_context);
            users=new UserRepository(_context);
            accountDetails = new AccountDetailsRepository(_context);
            auditMaster = new AudtiMasterRepository(_context);
            
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEngagementRepository engagements { get; private set; }
        public IClientAuditorsRepository clientAuditors { get; private set; }

        public ICountryRepository country { get; private set; }

        public IFileRepository file { get; private set; }
        public IUserRepository users { get; private set; }

        public IAuditOutcomeMasterRepository auditOutcomeMaster { get; private set; }

        public IAccountDetailsRepository accountDetails { get; private set; }

        public IAudtiMasterRepository auditMaster { get; private set; }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            var type = typeof(T);

            if (_repositories.Keys.Contains(type))
            {
                return _repositories[type];
            }

            if (_context == null)
                return null;
            var repository = new GenericRepository<T>(_context);
            _repositories[type] = repository;
            return repository;
        }
    }
}
