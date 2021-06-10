using app.api.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Core
{
    public class Cliente : Entity<string>, IAggregateRoot
    {
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }
    }
}
