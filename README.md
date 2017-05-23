# Tibia Tools

This applications provides usefull tools to any Tibia Player. Some of these tools, that requires an external data, requires a internet connection, buy overall it is not necessary. Also, Tibia Tools is a open source C# Windows Forms Project, that provides to everyone see all the application code and runs it safely. Remember only to download Tibia Tools in this project page on GitHub, and to run this tool on a Windows computer with at least .NET Framework 4.

- Multi-language support

- Safe (Open Source)

- Loot Splitter Calculator works offline (uses a internal database file, updated on 22/05/2017)

- Does not break Tibia rules

**#1 Tool: Loot Splitter Calculator**

Provides a powerfull calculator to split a list of items to a number of players, and calculte all the waste and profit for each player. The player just need to input all Tibia look texts about the itemt that want to count the loot and split to all the players, also input the players quantity and how much each player spent to obtain the loot. Providing these informations, the calculator will split all the itens to player in order to all have the same profit or waste. So, there are some scenarios:

- Player1 wasted 5k and Player2 wasted 10k, total loot value was 45k. So, Player1 will recive 20k (5k to pay supplies and a 15k profit) and Player2 will reicive 25k (10k to pay supplies and a 15k profit). Each player will earn 15k as profit;

- Player1 wasted 5k and Player2 wasted 10k, total loot value was 15k. So, Player1 will recive 5k (5k to pay supplies) and Player2 will reicive 10k (10k to pay supplies). No profit or waste;

- Player1 wasted 5k and Player2 wasted 10k, total loot value was 11k. So, Player1 will recive 3k (3k to pay supplies, 2k waste) and Player2 will reicive 8k (8k to pay supplies, 2k waste). Each player wasted 2k;

- Player1 wasted 5k and Player2 wasted 10k, total loot value was 2k. So, Player1 will recive nothing and need to pay 1.5k to Player2 to compensate his waste (5k waste + 1.5k to Player2, 6.5k total) and Player2 will reicive 2k from loot and 1.5 from Player1 (2k + 1.5k to pay supplies, 6.5k waste total). Player1 and Player2 will waste the same amount.

- This case is a little complex: Player1 wasted 5k and Player2 wasted 10k, and just looted 1 item in all hunt, that the value is 45k. Is impossible to break the item in the middle to split it, so in these cases the calculator do a recomendation: to sell all the itens that are showed into a table of items impossible to split and split the money result to the indicated players. In this case, selling the 45k item, Player1 will recive 20k (5k to pay supplies and a 15k profit) and Player2 will reicive 25k (10k to pay supplies and a 15k profit). Each player will earn 15k as profit.

**#2 Tool: Last Deaths**

Soon! This tool will provide the user check all last deaths based a world. It uses the online player lists of Tibia official website to check the last deaths, so, it only will show the deaths of online players. It was not implemented yet.
