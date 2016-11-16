using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receipt_D_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPTD_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receipt_D.Remove(entities.TRN_Receipt_D.Find(RECEIPTD_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receipt_D Insert(SchoolQPaper_entities entities, decimal RECEIPTD_amount, int RECEIPTD_doc_id,
            int RECEIPT_id, int DOCU_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_D receiptd_rec = new TRN_Receipt_D();
            receiptd_rec.RECEIPTD_amount = RECEIPTD_amount;
            receiptd_rec.RECEIPTD_doc_id = RECEIPTD_doc_id;
            receiptd_rec.RECEIPT_id = RECEIPT_id;
            receiptd_rec.DOCU_id = DOCU_id;
            entities.TRN_Receipt_D.Add(receiptd_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptd_rec;
        }

        public TRN_Receipt_D Update(SchoolQPaper_entities entities, int RECEIPTD_id, decimal RECEIPTD_amount, int RECEIPTD_doc_id,
            int RECEIPT_id, int DOCU_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_D receiptd_rec = entities.TRN_Receipt_D.Find(RECEIPTD_id);
            receiptd_rec.RECEIPTD_amount = RECEIPTD_amount;
            receiptd_rec.RECEIPTD_doc_id = RECEIPTD_doc_id;
            receiptd_rec.RECEIPTD_id = RECEIPT_id;
            receiptd_rec.DOCU_id = DOCU_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptd_rec;
        }
    }
}
