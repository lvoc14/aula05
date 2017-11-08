using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppPB_Lab2_2017_2.Models.Configurations;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class CinemaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CinemaContext() : base("name=CinemaContext")
        {

        }

        public System.Data.Entity.DbSet<WebAppPB_Lab2_2017_2.Models.Sala> Salas { get; set; }

        public System.Data.Entity.DbSet<WebAppPB_Lab2_2017_2.Models.Sessao> Sessaos { get; set; }

        public System.Data.Entity.DbSet<WebAppPB_Lab2_2017_2.Models.Filme> Filmes { get; set; }

        public System.Data.Entity.DbSet<WebAppPB_Lab2_2017_2.Models.Ingresso> Ingressoes { get; set; }

        public System.Data.Entity.DbSet<WebAppPB_Lab2_2017_2.Models.Ator> Ators { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove convenções de pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove conveções de deleção em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ConfiguracaoSala());
            modelBuilder.Configurations.Add(new ConfiguracaoSessao());
            modelBuilder.Configurations.Add(new ConfiguracaoIngresso());
            modelBuilder.Configurations.Add(new ConfiguracaoFilme());

            //Adicionando configurações globais do Fluent API
            modelBuilder.Properties<string>()
                .Configure(prop => prop.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(prop => prop.HasMaxLength(200));

            modelBuilder.Properties<DateTime>()
                .Configure(prop => prop.HasColumnType("datetime2"));

        }
    }
}
