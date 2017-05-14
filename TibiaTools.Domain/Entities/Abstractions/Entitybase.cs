using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaTools.Domain.Entities.Abstractions
{
    public abstract class EntityBase<T>
    {
        protected EntityBase()
        {
            this.CreatedAt = DateTime.Now;
        }

        public T Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
