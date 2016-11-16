using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_PaperOrder02_D_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR02D_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_PaperOrder02_D.Remove(entities.TRN_PaperOrder02_D.Find(PPRODR02D_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_PaperOrder02_D Insert(SchoolQPaper_entities entities, int PPRODR02D_paper_qty, int GRADE_id, int SUBJ_id, 
            int PPRODR02_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_D paperorder02_d_rec = new TRN_PaperOrder02_D();
            paperorder02_d_rec.PPRODR02D_paper_qty = PPRODR02D_paper_qty;
            paperorder02_d_rec.GRADE_id = GRADE_id;
            paperorder02_d_rec.SUBJ_id = SUBJ_id;
            paperorder02_d_rec.PPRODR02_id = PPRODR02_id;
            entities.TRN_PaperOrder02_D.Add(paperorder02_d_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder02_d_rec;
        }

        public TRN_PaperOrder02_D Update(SchoolQPaper_entities entities, int PPRODR02D_id, int PPRODR02D_paper_qty, int GRADE_id, 
            int SUBJ_id, int PPRODR02_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_D paperorder02_d_rec = new TRN_PaperOrder02_D();
            paperorder02_d_rec.PPRODR02D_paper_qty = PPRODR02D_paper_qty;
            paperorder02_d_rec.GRADE_id = GRADE_id;
            paperorder02_d_rec.SUBJ_id = SUBJ_id;
            paperorder02_d_rec.PPRODR02_id = PPRODR02_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder02_d_rec;
        }
    }
}
