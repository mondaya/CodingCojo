using LoginReg.Models;
using System.Collections.Generic;

namespace LoginReg.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}