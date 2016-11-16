using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_Receivable_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIVABLES_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_Receivable.Remove(entities.TRN_Receivable.Find(RECEIVABLES_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_Receivable Insert(SchoolQPaper_entities entities, int RECEIVABLES_doc_id, decimal RECEIVABLES_value,
            decimal RECEIVABLES_balance, int? RECEIVABLES_ref_id, int DOCU_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receivable receivable_rec = new TRN_Receivable();
            receivable_rec.RECEIVABLES_doc_id = RECEIVABLES_doc_id;
            receivable_rec.RECEIVABLES_value = RECEIVABLES_value;
            receivable_rec.RECEIVABLES_balance = RECEIVABLES_balance;
            receivable_rec.RECEIVABLES_ref_id = RECEIVABLES_ref_id;
            receivable_rec.DOCU_id = DOCU_id;
            entities.TRN_Receivable.Add(receivable_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();

            return receivable_rec;
        }

        public TRN_Receivable Update(SchoolQPaper_entities entities, int RECEIVABLES_id, int RECEIVABLES_doc_id, decimal RECEIVABLES_value,
            decimal RECEIVABLES_balance, int? RECEIVABLES_ref_id, int DOCU_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receivable receivable_rec = entities.TRN_Receivable.Find(RECEIVABLES_id);
            receivable_rec.RECEIVABLES_doc_id = RECEIVABLES_doc_id;
            receivable_rec.RECEIVABLES_value = RECEIVABLES_value;
            receivable_rec.RECEIVABLES_balance = RECEIVABLES_balance;
            receivable_rec.RECEIVABLES_ref_id = RECEIVABLES_ref_id;
            receivable_rec.DOCU_id = DOCU_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();

            return receivable_rec;
        }
    }
}
