using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Domain.Entity {
    public class BaseEntity {
        public Guid Id { get; set; }
        public DateTime DtCreation { get; private set; } = DateTime.Now;
        public bool IsEnable { get; private set; } = true;

        public void DisableEntity() {
            this.IsEnable = false;
        }

        public void EnableEntity() {
            this.IsEnable = true;
        }

    }
}
