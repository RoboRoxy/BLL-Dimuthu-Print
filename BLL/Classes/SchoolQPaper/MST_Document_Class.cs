using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_Document_Class
    {
        internal MST_Document Update(SchoolQPaper_entities entities, int DOCU_id, string DOCU_name, string DOCU_prefix, 
            int DOCU_last_no)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Document document_rec = entities.MST_Document.Find(DOCU_id);
            document_rec.DOCU_name = DOCU_name;
            document_rec.DOCU_prefix = DOCU_prefix;
            document_rec.DOCU_last_no = DOCU_last_no;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return document_rec;
        }
    }
}
