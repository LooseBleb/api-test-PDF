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
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
          public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(w => w.Name).IsUnique();

            builder.Property(w => w.Description).IsRequired().HasMaxLength(1000);
            builder.Property(w => w.PDF).IsRequired();


            builder.HasOne(c => c.Matter).WithMany(c => c.Works).HasForeignKey(c => c.MatterId).IsRequired();

            builder.ToTable("Works");
        }
    }
}
