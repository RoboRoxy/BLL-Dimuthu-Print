using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_School_Class
    {
        public void Delete(SchoolQPaper_entities entities, int SCHL_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_School.Remove(entities.MST_School.Find(SCHL_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_School Insert(SchoolQPaper_entities entities, string SCHL_code, string SCHL_name, string SCHL_address,
            string SCHL_font, string SCHL_principal_name, string SCHL_principal_address, string SCHL_principal_tele,
            int? AGENT_id, int? PROVINCE_id, int? ZONE_id, int? DIVISION_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_School school_rec = new MST_School();
            school_rec.SCHL_code = SCHL_code;
            school_rec.SCHL_name = SCHL_name;
            school_rec.SCHL_address = SCHL_address;
            school_rec.SCHL_font = SCHL_font;
            school_rec.SCHL_principal_name = SCHL_principal_name;
            school_rec.SCHL_principal_address = SCHL_principal_address;
            school_rec.SCHL_principal_tele = SCHL_principal_tele;
            school_rec.AGENT_id = AGENT_id;
            school_rec.PROVINCE_id = PROVINCE_id;
            school_rec.ZONE_id = ZONE_id;
            school_rec.DIVISION_id = DIVISION_id;
            entities.MST_School.Add(school_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return school_rec;
        }

        public MST_School Update(SchoolQPaper_entities entities, int SCHL_id, string SCHL_code, string SCHL_name, string SCHL_address,
            string SCHL_font, string SCHL_principal_name, string SCHL_principal_address, string SCHL_principal_tele,
            int? AGENT_id, int? PROVINCE_id, int? ZONE_id, int? DIVISION_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_School school_rec = entities.MST_School.Find(SCHL_id);
            school_rec.SCHL_code = SCHL_code;
            school_rec.SCHL_name = SCHL_name;
            school_rec.SCHL_address = SCHL_address;
            school_rec.SCHL_font = SCHL_font;
            school_rec.SCHL_principal_name = SCHL_principal_name;
            school_rec.SCHL_principal_address = SCHL_principal_address;
            school_rec.SCHL_principal_tele = SCHL_principal_tele;
            school_rec.AGENT_id = AGENT_id;
            school_rec.PROVINCE_id = PROVINCE_id;
            school_rec.ZONE_id = ZONE_id;
            school_rec.DIVISION_id = DIVISION_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return school_rec;
        }
    }
}
