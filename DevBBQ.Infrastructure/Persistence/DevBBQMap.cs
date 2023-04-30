// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using DevBBQ.Core.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace DevBBQ.Infrastructure.Persistence
// {
//     public class DevBBQMap : IEntityTypeConfiguration<BBQ>
//     {
//         public void Configure(EntityTypeBuilder<BBQ> builder)
//         {
//             builder.HasKey(k => k.Id);

//             builder.HasMany(p => p.Participants)
//                    .WithOne(b => b.BBQ)
//                    .HasForeignKey(p => p.Id);
//         }
//     }
// }