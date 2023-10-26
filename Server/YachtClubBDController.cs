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

        public void RemoveRecord(int id)
        {
            var yachtClub = dbContext.YachtClubs.Find(id);
            if (yachtClub != null)
            {
                dbContext.YachtClubs.Remove(yachtClub);
                dbContext.SaveChanges();
            }
        }

        public List<YachtClub> GetYachtClubs()
        {
            return dbContext.YachtClubs.ToList();
        }

        public YachtClub GetYachtClub(int id)
        {
            return dbContext.YachtClubs.Find(id);
        }

        public void AddRecord(YachtClub yachtClub)
        {
            dbContext.YachtClubs.Add(yachtClub);
            dbContext.SaveChanges();
        }
    }
}
