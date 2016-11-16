using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_Division_Class
    {
        public void Delete(SchoolQPaper_entities entities, int DIVISION_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_Division.Remove(entities.MST_Division.Find(DIVISION_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_Division Insert(SchoolQPaper_entities entities, string DIVISION_name, string DIVISION_font, int ZONE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Division division_rec = new MST_Division();
            division_rec.DIVISION_name = DIVISION_name;
            division_rec.DIVISION_font = DIVISION_font;
            division_rec.ZONE_id = ZONE_id;
            entities.MST_Division.Add(division_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return division_rec;
        }

        public MST_Division Update(SchoolQPaper_entities entities, int DIVISION_id, string DIVISION_name, string DIVISION_font, 
            int ZONE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Division division_rec = entities.MST_Division.Find(DIVISION_id);
            division_rec.DIVISION_name = DIVISION_name;
            division_rec.DIVISION_font = DIVISION_font;
            division_rec.ZONE_id = ZONE_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return division_rec;
        }
    }
}
