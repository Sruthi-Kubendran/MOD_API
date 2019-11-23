using MOD.DtosLibrary;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.AdminLibrary.Repository
{
    public interface IAdminRepository
    {
        TrainingDtls GetTrainingById(int id);
        bool AddSkill(Skill skill);
        IEnumerable<Skill> GetSkills();
        Skill GetSkill(int id);
        bool DeleteSkill(Skill skill);
        UserProfileDto GetUser(string id);
        // IEnumerable<UserListDto> GetUsers();
        List<UserDto> GetUsers();
        bool BlockUser(string id);
        // bool UpdateActor(UserProfileDto user);
        List<TrainingDtls> GetTrainings();
        List<PaymentDtls> GetPayments();
        PaymentDtls GetPaymentById(int id);
        void PutupdatePaymentAndCommisionById(string id, PaymentDto payment);
    }
}
