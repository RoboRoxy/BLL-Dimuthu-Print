using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_PaperOrder01_D_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR01D_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_PaperOrder01_D.Remove(entities.TRN_PaperOrder01_D.Find(PPRODR01D_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_PaperOrder01_D Insert(SchoolQPaper_entities entities, int PPRODR01D_paper_qty, bool PPRODR01D_ignore_qty,
            int GRADE_id, int SUBJ_id, int PPRODR01_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_D paperorder01_d_rec = new TRN_PaperOrder01_D();
            paperorder01_d_rec.PPRODR01D_paper_qty = PPRODR01D_paper_qty;
            paperorder01_d_rec.PPRODR01D_ignore_qty = PPRODR01D_ignore_qty;
            paperorder01_d_rec.GRADE_id = GRADE_id;
            paperorder01_d_rec.SUBJ_id = SUBJ_id;
            paperorder01_d_rec.PPRODR01_id = PPRODR01_id;
            entities.TRN_PaperOrder01_D.Add(paperorder01_d_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder01_d_rec;
        }

        public TRN_PaperOrder01_D Update(SchoolQPaper_entities entities, int PPRODR01D_id, int PPRODR01D_paper_qty, bool PPRODR01D_ignore_qty,
            int GRADE_id, int SUBJ_id, int PPRODR01_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_D paperorder01_d_rec = entities.TRN_PaperOrder01_D.Find(PPRODR01D_id);
            paperorder01_d_rec.PPRODR01D_paper_qty = PPRODR01D_paper_qty;
            paperorder01_d_rec.PPRODR01D_ignore_qty = PPRODR01D_ignore_qty;
            paperorder01_d_rec.GRADE_id = GRADE_id;
            paperorder01_d_rec.SUBJ_id = SUBJ_id;
            paperorder01_d_rec.PPRODR01_id = PPRODR01_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder01_d_rec;
        }
    }
}
