using app.api.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Core
{
    public class Producto : Entity<int>, IAggregateRoot
    {
        public string Descripcion { get; set; }
    }
}
