using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Data.Model;
using XMLToAnyViewParser.Data.Repository;

namespace XMLToAnyViewParser.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        /// <summary>
        /// Data context
        /// </summary>
        private DbContext _context;

        private UserRepository _userRepository;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Data context
        /// </summary>
        public DbContext DataContext => _context ?? (_context = new XMLToAnyViewParserEntities());

        #region Repository

        public UserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(DataContext));

        #endregion Repository

        #endregion Properties

        #region Methods

        /// <summary>
        /// Save changes for unit of work async
        /// </summary>
        public async Task SaveAsync()
        {
            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Save changes for unit of work
        /// </summary>
        public void Save()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }

        #endregion Methods

        #region IDisposable Members

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
