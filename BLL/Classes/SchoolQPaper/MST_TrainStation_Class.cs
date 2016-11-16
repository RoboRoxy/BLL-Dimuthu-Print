using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_TrainStation_Class
    {
        public void Delete(SchoolQPaper_entities entities, int TRAINST_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_TrainStation.Remove(entities.MST_TrainStation.Find(TRAINST_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_TrainStation Insert(SchoolQPaper_entities entities, string TRAINST_name, string TRAINST_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_TrainStation trainstation_rec = new MST_TrainStation();
            trainstation_rec.TRAINST_name = TRAINST_name;
            trainstation_rec.TRAINST_font = TRAINST_font;
            entities.MST_TrainStation.Add(trainstation_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return trainstation_rec;
        }

        public MST_TrainStation Update(SchoolQPaper_entities entities, int TRAINST_id, string TRAINST_name, string TRAINST_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_TrainStation trainstation_rec = entities.MST_TrainStation.Find(TRAINST_id);
            trainstation_rec.TRAINST_name = TRAINST_name;
            trainstation_rec.TRAINST_font = TRAINST_font;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return trainstation_rec;
        }
    }
}
