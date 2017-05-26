using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Core.DTO.WebSiteDTO;

namespace TibiaTools.Core.Services.Contracts
{
    public interface IWebSiteRequestService
    {
        IEnumerable<CharacterDTO> GetOnlineCharacters(string world);

        CharacterDTO GetCharacterInformation(string characterName);

        IEnumerable<GuildDTO> GetAllGuilds(string world);

        GuildDTO GetGuildInformation(string guildName);
    }
}