using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaTools.Domain.Contracts.Repositories;
using TibiaTools.Domain.Entities;
using TibiaTools.Domain.Enums;

namespace TibiaTools.Database.Repositories
{
    public class BossRepository : IBossRepository
    {
        public List<TibiaBoss> GetAll()
        {
            var allBosses = new List<TibiaBoss>();
            var database = TibiaDatabase.ResourceManager.GetObject("BossDatabase").ToString();

            foreach (var line in database.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var lineSpl = line.Split(',');
                var boss = new TibiaBoss();
                boss.Id = Convert.ToInt32(lineSpl[0]);
                boss.Name = lineSpl[1];
                boss.RespawnNumber = Convert.ToInt32(lineSpl[2]);
                boss.Type = (BossType)Enum.Parse(typeof(BossType), lineSpl[3], true);

                allBosses.Add(boss);
            }

            return allBosses;
        }
    }
}
