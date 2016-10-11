using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sefin.CsPro.Commons.Domain
{
    [Serializable]
    public class Region : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string RegionDescription { get; set; }

        public virtual ISet<Territory> Territories { get; set; }
    }
}
