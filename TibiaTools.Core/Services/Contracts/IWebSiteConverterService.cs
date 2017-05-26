using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TibiaTools.Domain.Enums;

namespace TibiaTools.Core.Services.Contracts
{
    public interface IWebSiteConvertService
    {
        Vocation ToVocation(string value);
        Sex ToSex(string value);
        AccountStatus ToAccountStatus(string value);
        string ToCharacterNameLink(string value);
    }
}