using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receipt_MO_Info_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPTMO_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receipt_MO_Info.Remove(entities.TRN_Receipt_MO_Info.Find(RECEIPTMO_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receipt_MO_Info Insert(SchoolQPaper_entities entities, DateTime? RECEIPTMO_date, string RECEIPTMO_no,
            string RECEIPTMO_office, int RECEIPTPAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_MO_Info receiptmoinfo_rec = new TRN_Receipt_MO_Info();
            receiptmoinfo_rec.RECEIPTMO_date = RECEIPTMO_date;
            receiptmoinfo_rec.RECEIPTMO_no = RECEIPTMO_no;
            receiptmoinfo_rec.RECEIPTMO_office = RECEIPTMO_office;
            receiptmoinfo_rec.RECEIPTPAYTYP_id = RECEIPTPAYTYP_id;
            entities.TRN_Receipt_MO_Info.Add(receiptmoinfo_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptmoinfo_rec;
        }

        public TRN_Receipt_MO_Info Update(SchoolQPaper_entities entities, int RECEIPTMO_id, DateTime? RECEIPTMO_date, 
            string RECEIPTMO_no, string RECEIPTMO_office, int RECEIPTPAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_MO_Info receiptmoinfo_rec = entities.TRN_Receipt_MO_Info.Find(RECEIPTMO_id);
            receiptmoinfo_rec.RECEIPTMO_date = RECEIPTMO_date;
            receiptmoinfo_rec.RECEIPTMO_no = RECEIPTMO_no;
            receiptmoinfo_rec.RECEIPTMO_office = RECEIPTMO_office;
            receiptmoinfo_rec.RECEIPTPAYTYP_id = RECEIPTPAYTYP_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptmoinfo_rec;
        }
    }
}
