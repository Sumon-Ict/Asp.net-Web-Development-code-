using System;

namespace BookSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {

        void Save();

    }
}
