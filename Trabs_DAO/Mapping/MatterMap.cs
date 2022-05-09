using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabs_BLL.Models;

namespace Trabs_DAO.Mapping
{
    public class MatterMap : IEntityTypeConfiguration<Matter>
    {
        public void Configure(EntityTypeBuilder<Matter> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(w => w.Name).IsUnique();

            builder.HasMany(t => t.Works).WithOne(t => t.Matter);

            builder.ToTable("Matter");
        }
    }
}
