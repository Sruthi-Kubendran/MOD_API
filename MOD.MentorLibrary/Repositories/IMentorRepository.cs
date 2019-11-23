using System;
using System.Collections.Generic;
using System.Text;
using MOD.DtosLibrary;

namespace MOD.MentorLibrary.Repositories
{
    public interface IMentorRepository
    {
     
        bool UpdateUser(string Id, UserProfileDto userProfileDto);
        void PutAcceptRequest(int id);
       void PutRejectrequest(int id);
    }
}
