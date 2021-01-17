using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShelterInzynierka.DataAccess.DataObjects
{
    public partial class inzContext : DbContext
    {
        public inzContext()
        {
        }

        public inzContext(DbContextOptions<inzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adopter> Adopter { get; set; }
        public virtual DbSet<Adoption> Adoption { get; set; }
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Catsattitude> Catsattitude { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Dog> Dog { get; set; }
        public virtual DbSet<Dogcolor> Dogcolor { get; set; }
        public virtual DbSet<Dogsattitude> Dogsattitude { get; set; }
        public virtual DbSet<Kidsattitude> Kidsattitude { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("user id=root;persistsecurityinfo=True;server=127.0.0.1;database=inz;allowuservariables=True;password=root123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopter>(entity =>
            {
                entity.HasKey(e => e.IdAdopter)
                    .HasName("PRIMARY");

                entity.ToTable("adopter");

                entity.HasIndex(e => e.IdAdress)
                    .HasName("Adopter_Adress");

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.IdAdressNavigation)
                    .WithMany(p => p.Adopter)
                    .HasForeignKey(d => d.IdAdress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adopter_Adress");
            });

            modelBuilder.Entity<Adoption>(entity =>
            {
                entity.HasKey(e => e.IdAdoption)
                    .HasName("PRIMARY");

                entity.ToTable("adoption");

                entity.HasIndex(e => e.IdAdopter)
                    .HasName("Adoption_Adopter");

                entity.HasIndex(e => e.IdDog)
                    .HasName("Adoption_Dog");

                entity.HasIndex(e => e.IdVolunteer)
                    .HasName("Adoption_Volunteer");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.IdAdopterNavigation)
                    .WithMany(p => p.Adoption)
                    .HasForeignKey(d => d.IdAdopter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_Adopter");

                entity.HasOne(d => d.IdDogNavigation)
                    .WithMany(p => p.Adoption)
                    .HasForeignKey(d => d.IdDog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_Dog");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.Adoption)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Adoption_Volunteer");
            });

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasKey(e => e.IdAdress)
                    .HasName("PRIMARY");

                entity.ToTable("adress");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Catsattitude>(entity =>
            {
                entity.HasKey(e => e.IdCatsAttitude)
                    .HasName("PRIMARY");

                entity.ToTable("catsattitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("color");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.HasKey(e => e.IdDog)
                    .HasName("PRIMARY");

                entity.ToTable("dog");

                entity.HasIndex(e => e.IdCatsAttitude)
                    .HasName("Dog_CatsAttitude");

                entity.HasIndex(e => e.IdDogsAttitude)
                    .HasName("Dog_DogsAttitude");

                entity.HasIndex(e => e.IdKidsAttitude)
                    .HasName("Dog_KidsAttitude");

                entity.Property(e => e.ChipNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCatsAttitudeNavigation)
                    .WithMany(p => p.Dog)
                    .HasForeignKey(d => d.IdCatsAttitude)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dog_CatsAttitude");

                entity.HasOne(d => d.IdDogsAttitudeNavigation)
                    .WithMany(p => p.Dog)
                    .HasForeignKey(d => d.IdDogsAttitude)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dog_DogsAttitude");

                entity.HasOne(d => d.IdKidsAttitudeNavigation)
                    .WithMany(p => p.Dog)
                    .HasForeignKey(d => d.IdKidsAttitude)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dog_KidsAttitude");
            });

            modelBuilder.Entity<Dogcolor>(entity =>
            {
                entity.HasKey(e => e.IdDogColor)
                    .HasName("PRIMARY");

                entity.ToTable("dogcolor");

                entity.HasIndex(e => e.IdColor)
                    .HasName("DogColor_Color");

                entity.HasIndex(e => e.IdDog)
                    .HasName("DogColor_Dog");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Dogcolor)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DogColor_Color");

                entity.HasOne(d => d.IdDogNavigation)
                    .WithMany(p => p.Dogcolor)
                    .HasForeignKey(d => d.IdDog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DogColor_Dog");
            });

            modelBuilder.Entity<Dogsattitude>(entity =>
            {
                entity.HasKey(e => e.IdDogsAttitude)
                    .HasName("PRIMARY");

                entity.ToTable("dogsattitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Kidsattitude>(entity =>
            {
                entity.HasKey(e => e.IdKidsAttitude)
                    .HasName("PRIMARY");

                entity.ToTable("kidsattitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("PRIMARY");

                entity.ToTable("volunteer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
