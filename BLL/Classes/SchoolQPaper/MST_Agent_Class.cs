using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class MST_Agent_Class
    {
        public void Delete(SchoolQPaper_entities entities, int AGENT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.MST_Agent.Remove(entities.MST_Agent.Find(AGENT_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public MST_Agent Insert(SchoolQPaper_entities entities, string AGENT_name, string AGENT_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Agent agent_rec = new MST_Agent();
            agent_rec.AGENT_name = AGENT_name;
            agent_rec.AGENT_font = AGENT_font;
            entities.MST_Agent.Add(agent_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return agent_rec;
        }

        public MST_Agent Update(SchoolQPaper_entities entities, int AGENT_id, string AGENT_name, string AGENT_font)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            MST_Agent agent_rec = entities.MST_Agent.Find(AGENT_id);
            agent_rec.AGENT_name = AGENT_name;
            agent_rec.AGENT_font = AGENT_font;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return agent_rec;
        }
    }
}
