using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper.Document
{
    public class Document_Class
    {
        public string GetDocumentCode(SchoolQPaper_entities entities, int DOCU_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Document document_rec = entities.MST_Document.Find(DOCU_id);
            string Code = document_rec.DOCU_prefix + new SchoolQPaper.MST_Document_Class().Update(entities, DOCU_id, document_rec.DOCU_name, document_rec.DOCU_prefix, document_rec.DOCU_last_no + 1).DOCU_last_no.ToString().PadLeft(7, '0');

            if (dispose)
                entities.Dispose();
            return Code;
        }
    }
}
