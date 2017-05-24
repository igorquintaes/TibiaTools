using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaTools.Domain.Entities;
using TibiaTools.Core.DTO;

namespace TibiaTools.Application.Helpers.Contracts
{
    public interface IPathHelper
    {
        string DefaultImgPath { get; }
        string GetItemImagePath(ItemResultDTO item);
        string GetItemImagePath(Item item);
    }
}
