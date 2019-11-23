using System;
using System.Collections.Generic;
using System.Text;
using MOD.DtosLibrary;
using MOD.ModelLibrary;
using System.Linq;

namespace MOD.StudentLibrary.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StudentContext context;
        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }

      

        public bool AddPayment(PaymentDtls payment)
        {

            try
            {
                context.PaymentDtls.Add(payment);
                var result = context.SaveChanges();
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

        public bool AddTraining(TrainingDtls training)
        {
            try
            {
                context.TrainingDtls.Add(training);
                var result = context.SaveChanges();
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

        public List<UserProfileDto> GetSearchData(string trainertechnology)
        {
            var search = from u in context.UserMods
                         where u.TrainerTechnology == trainertechnology
                         select new UserProfileDto
                         {
                             Id = u.Id,
                             Email = u.Email,
                             Firstname = u.Firstname,
                             Lastname = u.Lastname,
                             YearOfExperience = u.YearOfExperience,
                             TrainerTechnology = u.TrainerTechnology
                         };
            return search.ToList();
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

        public void PutupdateTrainingAndPaymentStatusbyId(int id)
        {
            var payment = context.TrainingDtls.Find(id);
            payment.trainingPaymentStatus = true;
            context.TrainingDtls.Update(payment);
            context.SaveChanges();
        }



        public void PutupdateTrainingProgressById(int id, int progressValue)
        {
            var progressbyId = context.TrainingDtls.Find(id);
            progressbyId.progress = progressValue;
            if (progressValue == 100)
            {
                progressbyId.status = "completed";
            }
            context.TrainingDtls.Update(progressbyId);
            context.SaveChanges();
        }

        public void PutupdateTrainingRatingById(int id, int rating)
        {
            var ratings = context.TrainingDtls.Find(id);
            ratings.rating = rating;
            context.TrainingDtls.Update(ratings);
            context.SaveChanges();
        }

        public void PutupdateTrainingStatusById(int id)
        {
            var trainingstatus = context.TrainingDtls.Find(id);
            trainingstatus.status = "Current";
            trainingstatus.progress = 0;
            context.TrainingDtls.Update(trainingstatus);
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
