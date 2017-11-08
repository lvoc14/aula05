namespace WebAppPB_Lab2_2017_2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppPB_Lab2_2017_2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebAppPB_Lab2_2017_2.Models.CinemaContext";
        }

        protected override void Seed(CinemaContext context)
        {
            if (context.Salas.Count() == 0)
            {
                try
                {
                    PopularDados(context);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: fazer log de erro
                    ex.ToString();
                }
            }
        }

        private void PopularDados(CinemaContext contexto)
        {
            var salas = new List<Sala>
            {
                new Sala
                {
                    Descricao = "Sala 1",
                    Capacidade =50,
                    Numero = 20
                },
                new Sala
                {
                    Descricao = "Sala 1",
                    Capacidade =50,
                    Numero = 20
                }
            };

            contexto.Salas.AddRange(salas);
        }
    }
}
