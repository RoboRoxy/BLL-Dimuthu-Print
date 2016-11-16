using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receipt_PayType_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPTPAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receipt_PayType.Remove(entities.TRN_Receipt_PayType.Find(RECEIPTPAYTYP_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receipt_PayType Insert(SchoolQPaper_entities entities, decimal RECEIPTPAYTYP_amount, int PAYTYP_id,
            int RECEIPT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_PayType receiptpaytype_rec = new TRN_Receipt_PayType();
            receiptpaytype_rec.RECEIPTPAYTYP_amount = RECEIPTPAYTYP_amount;
            receiptpaytype_rec.PAYTYP_id = PAYTYP_id;
            receiptpaytype_rec.RECEIPT_id = RECEIPT_id;
            entities.TRN_Receipt_PayType.Add(receiptpaytype_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptpaytype_rec;
        }

        public TRN_Receipt_PayType Update(SchoolQPaper_entities entities, int RECEIPTPAYTYP_id, decimal RECEIPTPAYTYP_amount, 
            int PAYTYP_id, int RECEIPT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_PayType receiptpaytype_rec = entities.TRN_Receipt_PayType.Find(RECEIPTPAYTYP_id);
            receiptpaytype_rec.RECEIPTPAYTYP_amount = RECEIPTPAYTYP_amount;
            receiptpaytype_rec.PAYTYP_id = PAYTYP_id;
            receiptpaytype_rec.RECEIPT_id = RECEIPT_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receiptpaytype_rec;
        }
    }
}
