using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MemberDAO
    {
        public static void SaveMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Members.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Member>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var m1 = context.Members.SingleOrDefault(c => c.MemberId == m.MemberId);
                    context.Members.Remove(m1);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Member> GetListMem()
        {
            List<Member> list = new List<Member>();
            try
            {

                using var context = new FStoreDBContext();
                list = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
