using System;

namespace Samsung.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
