using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_Province_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PROVINCE_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_Province.Remove(entities.MST_Province.Find(PROVINCE_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_Province Insert(SchoolQPaper_entities entities, string PROVINCE_name, string PROVINCE_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Province province_rec = new MST_Province();
            province_rec.PROVINCE_name = PROVINCE_name;
            province_rec.PROVINCE_font = PROVINCE_font;
            entities.MST_Province.Add(province_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return province_rec;
        }

        public MST_Province Update(SchoolQPaper_entities entities, int PROVINCE_id, string PROVINCE_name, string PROVINCE_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Province province_rec = entities.MST_Province.Find(PROVINCE_id);
            province_rec.PROVINCE_name = PROVINCE_name;
            province_rec.PROVINCE_font = PROVINCE_font;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return province_rec;
        }
    }
}
