using System;

namespace Worker.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }

    }
}
