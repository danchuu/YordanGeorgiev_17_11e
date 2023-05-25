using Business_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Layer
{
  public  class UserContext : IDb<User, int>
    {
        DBContext dbContext;

        public UserContext(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(User item)
        {
            try
            {
                dbContext.Users.Add(item);
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
                dbContext.Users.Remove(dbContext.Users.Find(key));
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Friends)
                        .Include(p => p.Interests);

                }
                return query.FirstOrDefault(p => p.ID == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Friends)
                        .Include(p => p.Interests);

                }
                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User item, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    User userFromDb = Read(item.ID);

                    if (userFromDb == null)
                    {
                        Create(item);
                        return;
                    }

                    userFromDb.Name = item.Name;
                    userFromDb.Surname = item.Surname;
                    userFromDb.Age = item.Age;
                    userFromDb.Username = item.Username;
                    userFromDb.Password = item.Password;
                    userFromDb.Email = item.Email;


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