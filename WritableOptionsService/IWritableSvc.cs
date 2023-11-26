using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritableOptionsService
{
    public interface IWritableSvc<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        bool Update(Action<T> applyChanges);
    }
}
