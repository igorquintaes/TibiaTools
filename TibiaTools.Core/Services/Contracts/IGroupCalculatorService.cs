using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Core.DTO;

namespace TibiaTools.Core.Services.Contracts
{
    public interface IGroupCalculatorService
    {
        /// <summary>
        /// Returns an IEnumerable of itens after check a text with all loot information.
        /// We expect a look item message as text, not monster drop messages.
        /// This way, is needed less messages and there is no worry if you drop log clean or be full.
        /// </summary>
        /// <param name="textInput">Text with all look messages</param>
        /// <returns>List of items of what system could recognize</returns>
        IEnumerable<ItemResultDTO> ResolveItemList(string textInput);

        /// <summary>
        /// Check if the input is valid as player quantity.
        /// It only can be numbers and non-negative values.
        /// </summary>
        /// <param name="textQuantity">User imput about players quantity</param>
        /// <returns>Players quantity as int. 0 will be returned if the input is not valid</returns>
        int ObtainPlayersQuantity(string textQuantity);
    }
}
