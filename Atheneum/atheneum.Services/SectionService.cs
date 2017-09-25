using System;
using atheneum.Core;
using System.Collections.Generic;

namespace atheneum.Services
{
    public interface ISectionService
    {
        bool Add(Section section, List<Section> sections);
    }

    public class SectionService : ISectionService
    {
        public bool Add(Section section, List<Section> sections)
        {
            bool return_value = true;

            if (sections.Find(s => s.Id == section.Id) == null && sections.Find(s => s.Code == section.Code) == null)
            {
                sections.Add(section);
            }
            else
            {
                return_value = false;
            }

            return return_value;
        }
    }
}
