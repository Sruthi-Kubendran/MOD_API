using System;
using System.Collections.Generic;
using System.Text;
using MOD.DtosLibrary;

namespace MOD.MentorLibrary.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        MentorContext context;
        public MentorRepository(MentorContext context)
        {
            this.context = context;
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

     

        public void PutAcceptRequest(int id)
        {
            var training = context.TrainingDtls.Find(id);
            training.accept = true;
            context.TrainingDtls.Update(training);
            context.SaveChanges();
        }

        public void PutRejectrequest(int id)
        {
            var reject = context.TrainingDtls.Find(id);
            reject.rejectNotify = true;
            context.TrainingDtls.Update(reject);
            context.SaveChanges();
        }

        



        public bool UpdateUser(string id, UserProfileDto userProfileDto)
        {
            try
            {
                var user = context.UserMods.Find(userProfileDto.Id);
                user.Firstname = userProfileDto.Firstname;
                user.Lastname = userProfileDto.Lastname;
                user.Email = userProfileDto.Email;
                user.PhoneNumber = userProfileDto.Contactnumber;
                user.YearOfExperience = userProfileDto.YearOfExperience;

                context.UserMods.Update(user);
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
