using System;

namespace BookSystem.Data
{
    public interface IEntity<T>
    {

        T Id { get; set; }

    }
}
