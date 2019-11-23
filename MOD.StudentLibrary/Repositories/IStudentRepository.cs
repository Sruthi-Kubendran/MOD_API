using System;
using System.Collections.Generic;
using System.Text;
using MOD.DtosLibrary;
using MOD.ModelLibrary;

namespace MOD.StudentLibrary.Repositories
{
    public interface IStudentRepository
    {
        bool UpdateUser(string Id, UserProfileDto userProfileDto);
        List<UserProfileDto> GetSearchData(string trainertechnology);
        bool AddTraining(TrainingDtls training);
        bool AddPayment(PaymentDtls payment);
        void PutupdateTrainingAndPaymentStatusbyId(int id);
        void PutupdateTrainingStatusById(int id);
        void PutupdateTrainingProgressById(int id, int progressValue);
        void PutupdateTrainingRatingById(int id, int rating);
    }
}
