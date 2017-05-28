using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    [Serializable()]
    public class CharacterDeathDTO
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
