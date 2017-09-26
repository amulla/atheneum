using System;
using atheneum.Core;
using System.Collections.Generic;

namespace atheneum.Services
{
    public interface ISectionService
    {
        bool Add(Section section, List<Section> sections);
        bool Update(Guid guid, Section section, List<Section> sections);
        bool Delete(Guid guid, List<Section> sections);
    }

    public class SectionService : ISectionService
    {
        public bool Add(Section section, List<Section> sections)
        {
            bool return_value = false;

            if (sections.Find(s => s.Id == section.Id) == null && sections.Find(s => s.Code == section.Code) == null)
            {
                sections.Add(section);
                return_value = true;
            }

            return return_value;
        }

        public bool Update(Guid guid, Section section, List<Section> sections)
        {
            bool return_value = false;
            int index = sections.FindIndex(s => s.Id == guid);

            if (index >= 0)
            {
                sections[index].Name = section.Name;
                sections[index].Description = section.Description;
                return true;
            }

            return return_value;
        }

        public bool Delete(Guid guid, List<Section> sections)
        {
            bool return_value = false;
            var removeSection = sections.Find(s => s.Id == guid);

            if (removeSection != null)
            {
                sections.Remove(removeSection);
                return_value = true;
            }

            return return_value;

        }
    }
}
