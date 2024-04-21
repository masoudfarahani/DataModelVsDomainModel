using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Test
{
    public class TestBase : IDisposable
    {
        protected Context _context;
        private IDbContextTransaction _scope;
        public TestBase()
        {

            _context = new Context();

            if (!_context.Database.CanConnect())
            {
                _context.Database.Migrate();
            }
            _scope = _context.Database.BeginTransaction();
        }

        public void DetachAllEntities()
        {
            _context.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            _scope.Rollback();
        }
    }
}