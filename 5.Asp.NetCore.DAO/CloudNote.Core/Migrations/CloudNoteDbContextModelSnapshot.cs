﻿// <auto-generated />
using System;
using CloudNote.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudNote.Core.SqlServer.Migrations
{
    [DbContext(typeof(CloudNoteDbContext))]
    partial class CloudNoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudNote.Domain.Entities.FolderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FolderEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FolderEntityId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("CloudNote.Domain.Entities.NoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("CloudNote.Domain.Entities.FolderEntity", b =>
                {
                    b.HasOne("CloudNote.Domain.Entities.FolderEntity", null)
                        .WithMany("NextFolder")
                        .HasForeignKey("FolderEntityId");
                });

            modelBuilder.Entity("CloudNote.Domain.Entities.FolderEntity", b =>
                {
                    b.Navigation("NextFolder");
                });
#pragma warning restore 612, 618
        }
    }
}
