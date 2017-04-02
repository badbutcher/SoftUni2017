namespace TeamBuilder.Data.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Models;

    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(u => u.Name)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_Team_Name", 1) { IsUnique = true }))
                .HasMaxLength(25).IsRequired();

            this.Property(t => t.Description).HasMaxLength(32);

            this.Property(t => t.Acronym).HasMaxLength(3).IsFixedLength().IsRequired();
        }
    }
}