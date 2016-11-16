using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receipt_CHQ_Info_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPTCHQ_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receipt_CHQ_Info.Remove(entities.TRN_Receipt_CHQ_Info.Find(RECEIPTCHQ_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receipt_CHQ_Info Insert(SchoolQPaper_entities entities, string RECEIPTCHQ_chq_no, DateTime? RECEIPTCHQ_date,
            int RECEIPTPAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_CHQ_Info receiptchqinfo_rec = new TRN_Receipt_CHQ_Info();
            receiptchqinfo_rec.RECEIPTCHQ_chq_no = RECEIPTCHQ_chq_no;
            receiptchqinfo_rec.RECEIPTCHQ_date = RECEIPTCHQ_date;
            receiptchqinfo_rec.RECEIPTPAYTYP_id = RECEIPTPAYTYP_id;
            entities.TRN_Receipt_CHQ_Info.Add(receiptchqinfo_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptchqinfo_rec;
        }

        public TRN_Receipt_CHQ_Info Update(SchoolQPaper_entities entities, int RECEIPTCHQ_id, string RECEIPTCHQ_chq_no, 
            DateTime? RECEIPTCHQ_date, int RECEIPTPAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_CHQ_Info receiptchqinfo_rec = entities.TRN_Receipt_CHQ_Info.Find(RECEIPTCHQ_id);
            receiptchqinfo_rec.RECEIPTCHQ_chq_no = RECEIPTCHQ_chq_no;
            receiptchqinfo_rec.RECEIPTCHQ_date = RECEIPTCHQ_date;
            receiptchqinfo_rec.RECEIPTPAYTYP_id = RECEIPTPAYTYP_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptchqinfo_rec;
        }
    }
}
