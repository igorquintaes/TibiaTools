using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Domain.Contracts.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetAll();
    }
}
