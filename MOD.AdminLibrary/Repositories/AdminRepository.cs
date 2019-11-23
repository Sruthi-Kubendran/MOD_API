using MOD.DtosLibrary;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOD.AdminLibrary.Repository
{
    public class AdminRepository : IAdminRepository
    {
        AdminContext context;
        public AdminRepository(AdminContext context)
        {
            this.context = context;
        }
        public bool AddSkill(Skill skill)
        {

            try
            {
                context.Skills.Add(skill);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserDto> GetUsers()
        {
            var users = (from u in context.UserMods
                         join r in context.UserRoles on u.Id equals r.UserId
                         select new UserDto
                         {
                             Id = u.Id,
                             Email = u.Email,
                             Firstname = u.Firstname,
                             Lastname = u.Lastname,
                             Role = r.RoleId,
                             Active = u.Active
                         });
            return users.ToList();
        }


        public bool BlockUser(string id)
        {
            {
                var userblock = context.UserMods.SingleOrDefault(u => u.Id == id);
                userblock.Active = !userblock.Active;
            }
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSkill(Skill skill)
        {
            try
            {
                context.Skills.Remove(skill);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PaymentDtls GetPaymentById(int id)
        {
            return context.PaymentDtls.Find(id);
        }

        public List<PaymentDtls> GetPayments()
        {
            return context.PaymentDtls.ToList();
        }

      

        public Skill GetSkill(int id)
        {
            return context.Skills.Find(id);
        }

        public IEnumerable<Skill> GetSkills()
        {
            return context.Skills.ToList();
        }

      

        public List<TrainingDtls> GetTrainings()
        {
            return context.TrainingDtls.ToList();
        }

        public UserProfileDto GetUser(string id)
        {
            var profile = from u in context.UserMods
                          where u.Id == id
                          select new UserProfileDto
                          {
                              Id = u.Id,
                              Email = u.Email,
                              Username = u.UserName,
                              Firstname = u.Firstname,
                              Lastname = u.Lastname,
                              YearOfExperience = u.YearOfExperience,
                              TrainerTechnology = u.TrainerTechnology,
                              Contactnumber = u.PhoneNumber
                          };
            return profile.FirstOrDefault();
        }

        //public IEnumerable<UserMod> GetUsers()
        //{
        //    return context.UserMods.ToList();
        //}

        //public IEnumerable<string> GetUsers()
        //{
        //    var users = from u in context.UserMods
        //                join r in context.UserRoles on u.Id equals r.UserId
        //                select r.RoleId;
        //    return users;
        //}

        //public List<UserDto> GetUsers()
        //{
        //    var users = (from u in context.UserMods
        //                 join r in context.UserRoles on u.Id equals r.UserId
        //                 select new UserDto
        //                 {
        //                     Id = u.Id,
        //                     Email = u.Email,
        //                     Firstname = u.Firstname,
        //                     Lastname = u.Lastname,
        //                     Role = r.RoleId,
        //                     Active = u.Active
        //                 });
        //    return users.ToList();
        //}

      
        public void PutupdatePaymentAndCommisionById(string id, PaymentDto payment)
        {
            var paymentCommision = context.PaymentDtls.Find(payment.id);
            paymentCommision.commision = payment.commision;
            paymentCommision.trainerFees = payment.trainerFees;
            context.PaymentDtls.Update(paymentCommision);
            context.SaveChanges();
        }
        public TrainingDtls GetTrainingById(int id)
        {
            return context.TrainingDtls.Find(id);

        }


        //public bool UpdateActor(UserProfileDto user)
        //{
        //    try
        //    {
        //        context.UserMods.Update(user);
        //        int result = context.SaveChanges();
        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<string> GetUsers(int roleId)
        //{
        //    var users = from u in context.UserMods
        //                join r in context.UserRoles on u.Id equals r.UserId
        //                where r.RoleId == roleId.ToString()
        //                select u.Email;

        //    return users;                        
        //}
    }

}
