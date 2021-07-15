using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using TBAppAcierLibrairieClasses.Modeles;
using TBAppAcierLibrairieClasses.Modeles.CoefficientsCTICM;

namespace TBAppAcier.AccesDonnees
{
    // La classe DemoDbContext sert à accéder à la base de données.
    // Elle doit hériter de DbContext qui est une classe fournie par EntityFramework
    //
    // Quand on modifie quelque chose ici ou dans les classes modèles (par exemple XY),
    // il faut faire les étapes suivantes :
    //  1) supprimer les fichier dans le dossier "Migrations"
    //  2) supprimer le fichier "C:\Users\Petole\Documents\demo.db" 
    //  3) lancer la console package manager (View > Other Windows > Package Manager Console)
    //  4) lancer la commande "Add-Migration InitialCreate" (sans les guillemets)
    //  5) lancer la commande "Update-Database" (sans les guillemets)
    class AcierDbContext : DbContext
    {
        // On doit dire à EntityFramework les objets qu'on veut mettre dans la base de
        // données. Avec cette ligne, on dit donc qu'on veut une table XY

        #region Entités


        #region Données


        public DbSet<NuanceAcier> NuanceAciers { get; set; }


        public DbSet<CombinaisonCharges1D> CombinaisonCharges1Ds { get; set; }


        public DbSet<EffortsInternesDistanceX> EffortsInternesDistanceXs { get; set; }
        

        public DbSet<DiagrammesEffortsInternes> DiagrammesEffortsInternes { get; set; }


        public DbSet<EffortsInternesDistanceX> EffortsInternesDistanceXes { get; set; }



        
        public DbSet<GeometrieIH> GeometrieIHs { get; set; }


        public DbSet<ProfileIH> ProfileIHs { get; set; }


        #endregion



        #region Calculs


        public DbSet<ClasseSection> ClasseSections { get; set; }


        public DbSet<Flambage> Flambages { get; set; }


        public DbSet<EffortTranchant> EffortTranchants { get; set; }


        public DbSet<MomentsFlexionnelResistant> MomentsFlexionnelResistants { get; set; }



        #region Déversement

        public DbSet<MomentDeversementSIA> MomentDeversementSIAs { get; set; }




        #region Abaques CTICM

        public DbSet<MomentDeversementCTICM> MomentDeversementCTICMs { get; set; }

        public DbSet<C1ConcMuNeg> C1ConcMuNegs { get; set; }

        public DbSet<C1ConcMuPos> C1ConcMuPos { get; set; }


        public DbSet<C2ConcMuNeg> C2ConcMuNegs { get; set; }

        public DbSet<C2ConcMuPos> C2ConcMuPos { get; set; }


        #endregion


        #endregion


        public DbSet<Stabilite> Stabilites { get; set; }

        public DbSet<ResistanceSection> ResistanceSections { get; set; }

        #endregion




        #endregion





        // Cette method sert à configurer la base de données, elle est obligatoire
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // On récupère le chemin de ce dossier
            var myDocumentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TBAppAcier");

            // Est-ce que le dossier est créé?
            if (!Directory.Exists(myDocumentsPath))
                Directory.CreateDirectory(myDocumentsPath);

            // On dit à EntityFramework d'aller créer le fichier SQLite dans
            // "C:\Users\Petole\Documents\demo.db"
            optionsBuilder.UseSqlite($"Data Source={myDocumentsPath}\\acier.db");

            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region Données


            modelBuilder.Entity<NuanceAcier>().HasKey(x => x.IdNuance); 
                
            modelBuilder.Entity<CombinaisonCharges1D>().HasKey(x => x.IdCombinaisonCharges);
            modelBuilder.Entity<EffortsInternesDistanceX>().HasKey(x => x.IdEffortsInternes);

            modelBuilder.Entity<DiagrammesEffortsInternes>().HasKey(x => x.IdDiagrammeEffortsInternes);

            modelBuilder.Entity<ContraintesElastiques1PointYZ>().HasKey(x => x.IdContraintesElastiques);


            modelBuilder.Entity<ProfileIH>().HasKey(x => x.IdElement);

            modelBuilder.Entity<GeometrieIH>().HasKey(x => x.IdGeometrieIH);


            #endregion



            #region Calculs


            #region Classes, flambage, Résistances


            modelBuilder.Entity<ClasseSection>().HasKey(x => x.IdClasseSection);

            modelBuilder.Entity<Flambage>().HasKey(x=> x.IdFlambage);

            modelBuilder.Entity<EffortTranchant>().HasKey(x => x.IdEffortTranchant);

            modelBuilder.Entity<MomentsFlexionnelResistant>().HasKey(x => x.IdMomentsFlexionnelResistant);


            #endregion



            #region Déversement




            #region Abaques CTICM


            modelBuilder.Entity<C1ConcMuNeg>().HasKey(x => x.IdC1ConcMuNeg);

            modelBuilder.Entity<C1ConcMuPos>().HasKey(x => x.IdC1ConcMuPos);

            modelBuilder.Entity<C2ConcMuNeg>().HasKey(x => x.IdC2ConcMuNeg);

            modelBuilder.Entity<C2ConcMuPos>().HasKey(x => x.IdC2ConcMuPos);


            modelBuilder.Entity<MomentDeversementCTICM>().HasKey(x => x.IdMomentDeversementCTICM);
            modelBuilder.Entity<MomentDeversementSIA>().HasKey(x => x.IdMomentDeversementSIA);



            #endregion

            modelBuilder.Entity<Stabilite>().HasKey(x => x.IdStabilite);

            modelBuilder.Entity<ResistanceSection>().HasKey(x => x.IdResistanceSection);

            #endregion



            #endregion


        }


    }

}
