using System;

namespace Worker.Data
{
    public interface IUnitOfWork : IDisposable
    {

        void Save();

    }
}
