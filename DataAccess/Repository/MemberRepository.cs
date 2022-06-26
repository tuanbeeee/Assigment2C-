using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member m) => MemberDAO.DeleteMember(m);

        public void SaveMember(Member m) => MemberDAO.SaveMember(m);

        public void UpdateMember(Member m) => MemberDAO.UpdateMember(m);
    }
}
