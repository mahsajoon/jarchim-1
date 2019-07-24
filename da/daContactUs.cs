using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.da
{
    public class daContactUs
    {
        JarchimDb Db = new JarchimDb();
        public List<mContact> fAboutUsList(int pGet, int pSkip)
        {

            var vContactUs = (from n in Db.tbl_contact
                            select new mContact
                            {
                                contact_date = n.contact_date,
                                contact_email = n.contact_email,
                                contact_id = n.contact_id,
                                contact_is_read = n.contact_is_read,
                                contact_name = n.contact_name,
                                contact_phone = n.contact_phone,
                                contact_text = n.contact_text
                            }).OrderBy(b => b.contact_id).Skip(pSkip).Take(pGet);
            return vContactUs.ToList();

        }
         public bool fDeleteContact(int pId)
        {
            try
            {
                var vContact = (from a in Db.tbl_contact
                               where a.contact_id.Equals(pId)
                               select a).OrderBy(a => a.contact_id).SingleOrDefault();
                Db.tbl_contact.Remove(vContact);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}