using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_Zone_Class
    {
        public void Delete(SchoolQPaper_entities entities, int ZONE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_Zone.Remove(entities.MST_Zone.Find(ZONE_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_Zone Insert(SchoolQPaper_entities entities, string ZONE_name, string ZONE_font, int PROVINCE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Zone zone_rec = new MST_Zone();
            zone_rec.ZONE_name = ZONE_name;
            zone_rec.ZONE_font = ZONE_font;
            zone_rec.PROVINCE_id = PROVINCE_id;
            entities.MST_Zone.Add(zone_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return zone_rec;
        }

        public MST_Zone Update(SchoolQPaper_entities entities, int ZONE_id, string ZONE_name, string ZONE_font, int PROVINCE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Zone zone_rec = entities.MST_Zone.Find(ZONE_id);
            zone_rec.ZONE_name = ZONE_name;
            zone_rec.ZONE_font = ZONE_font;
            zone_rec.PROVINCE_id = PROVINCE_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return zone_rec;
        }
    }
}
