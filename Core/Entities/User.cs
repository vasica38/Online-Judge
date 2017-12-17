using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string IdentityGuid { get; private set; }

        private List<Solution> _solutions = new List<Solution>();

        public IEnumerable<Solution> Solutions => _solutions.AsReadOnly();

        protected User()
        {
        }

        public User(string identity):this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
        }
    }
}
