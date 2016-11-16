using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receipt_H_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receipt_H.Remove(entities.TRN_Receipt_H.Find(RECEIPT_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receipt_H Insert(SchoolQPaper_entities entities, string RECEIPT_code, DateTime RECEIPT_date,
            DateTime RECEIPT_tran_date, decimal RECEIPT_amount, string RECEIPT_remarks, string RECEIPT_font, int? SCHL_id,
            int? AGENT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_H receipth_rec = new TRN_Receipt_H();
            receipth_rec.RECEIPT_code = RECEIPT_code;
            receipth_rec.RECEIPT_date = RECEIPT_date;
            receipth_rec.RECEIPT_tran_date = RECEIPT_tran_date;
            receipth_rec.RECEIPT_amount = RECEIPT_amount;
            receipth_rec.RECEIPT_remarks = RECEIPT_remarks;
            receipth_rec.RECEIPT_font = RECEIPT_font;
            receipth_rec.SCHL_id = SCHL_id;
            receipth_rec.AGENT_id = AGENT_id;
            entities.TRN_Receipt_H.Add(receipth_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receipth_rec;
        }

        public TRN_Receipt_H Update(SchoolQPaper_entities entities, int RECEIPT_id, string RECEIPT_code, DateTime RECEIPT_date,
            DateTime RECEIPT_tran_date, decimal RECEIPT_amount, string RECEIPT_remarks, string RECEIPT_font, int? SCHL_id,
            int? AGENT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_H receipth_rec = entities.TRN_Receipt_H.Find(RECEIPT_id);
            receipth_rec.RECEIPT_code = RECEIPT_code;
            receipth_rec.RECEIPT_date = RECEIPT_date;
            receipth_rec.RECEIPT_tran_date = RECEIPT_tran_date;
            receipth_rec.RECEIPT_amount = RECEIPT_amount;
            receipth_rec.RECEIPT_remarks = RECEIPT_remarks;
            receipth_rec.RECEIPT_font = RECEIPT_font;
            receipth_rec.SCHL_id = SCHL_id;
            receipth_rec.AGENT_id = AGENT_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return receipth_rec;
        }
    }
}
