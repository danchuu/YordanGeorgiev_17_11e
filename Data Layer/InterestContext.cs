using System;
using System.Collections.Generic;
using System.Linq;
using Business_Layer;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer
{
    public class InterestContext : IDb<Interest, int>
    {
        DBContext dbContext;
        public InterestContext(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public void Create(Interest item)
        {
            try
            {
                dbContext.Interests.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                dbContext.Interests.Remove(dbContext.Interests.Find(key));
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Interest Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Interest> query = dbContext.Interests;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Category)
                        .Include(p => p.Users);
                }
                return query.FirstOrDefault(p => p.InterestID == key);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Interest> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Interest> query = dbContext.Interests;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Category)
                        .Include(p => p.Users);
                }
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Interest item, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    Interest interestFromDb = Read(item.InterestID);

                    if (interestFromDb != null)
                    {
                        Create(item);
                        return;
                    }

                    interestFromDb.Name = item.Name;
                    interestFromDb.Category = item.Category;

                    dbContext.SaveChanges();
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
