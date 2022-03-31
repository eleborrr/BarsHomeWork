using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsHomeWork2
{
    public class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public static Dictionary<int, List<Entity>> ConvertToDictionary(List<Entity> collection)
        {
            var result = new Dictionary<int, List<Entity>>();
            foreach(var elem in collection.Select(x => x.ParentId))
                result[elem] = collection.Where(x => x.ParentId == elem).ToList();
            return result;
        }

        public override string ToString()
        {
            return $"[Entity] Id: '{Id}', ParentId: '{ParentId}', Name: '{Name}'";
        }
    }
}
