using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Server
{
    internal class YachtClubBDController
    {
        private YachtClubContext dbContext;

        public YachtClubBDController()
        {
            dbContext = new YachtClubContext();
        }

        public string RemoveRecord(int id)
        {
            var yachtClub = dbContext.YachtClubs.Find(id);
            if (yachtClub != null)
            {
                dbContext.YachtClubs.Remove(yachtClub);
                dbContext.SaveChanges();
                return JsonConvert.SerializeObject(new { Message = "Запись успешко удалена" });
            }
            else
            {
                return JsonConvert.SerializeObject(new { Message = "Запись не найдена" });
            }
        }

        public string GetYachtClubs()
        {
            List<YachtClub> yachtClubs = dbContext.YachtClubs.ToList();
            return JsonConvert.SerializeObject(yachtClubs);
        }

        public string GetYachtClub(int id)
        {
            YachtClub yachtClub = dbContext.YachtClubs.Find(id);
            if (yachtClub != null)
            {
                return JsonConvert.SerializeObject(yachtClub);
            }
            else
            {
                return JsonConvert.SerializeObject(new { Message = "Запись не найдена" });
            }
        }

        public string AddRecord(YachtClub yachtClub)
        {
            dbContext.YachtClubs.Add(yachtClub);
            dbContext.SaveChanges();
            return JsonConvert.SerializeObject(yachtClub);
        }
    }
}
