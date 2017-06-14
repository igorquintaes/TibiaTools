using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Domain.Contracts.Repositories
{
    public interface IBossRepository
    {
        List<TibiaBoss> GetAll();
    }
}
