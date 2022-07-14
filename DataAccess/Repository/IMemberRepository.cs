using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IMemberRepository
    {
        void SaveMember(Member m);
        void DeleteMember(Member m);
        void UpdateMember(Member m);
        List<Member> GetMembers();
    }
}
