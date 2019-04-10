using System;

namespace JNKJ.Domain.Systems
{
    public class ColumnParameterMapping : BaseEntity
    {
        public Guid ColumnId { get; set; }
        public Guid ParameterId { get; set; }

    }
}
