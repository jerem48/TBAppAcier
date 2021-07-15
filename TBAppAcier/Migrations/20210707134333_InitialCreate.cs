using Microsoft.EntityFrameworkCore.Migrations;

namespace TBAppAcier.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C1ConcMuNegs",
                columns: table => new
                {
                    IdC1ConcMuNeg = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MuNeg = table.Column<double>(type: "REAL", nullable: false),
                    Psi00 = table.Column<double>(type: "REAL", nullable: false),
                    Psi01 = table.Column<double>(type: "REAL", nullable: false),
                    Psi02 = table.Column<double>(type: "REAL", nullable: false),
                    Psi03 = table.Column<double>(type: "REAL", nullable: false),
                    Psi04 = table.Column<double>(type: "REAL", nullable: false),
                    Psi05 = table.Column<double>(type: "REAL", nullable: false),
                    Psi06 = table.Column<double>(type: "REAL", nullable: false),
                    Psi07 = table.Column<double>(type: "REAL", nullable: false),
                    Psi08 = table.Column<double>(type: "REAL", nullable: false),
                    Psi09 = table.Column<double>(type: "REAL", nullable: false),
                    Psi10 = table.Column<double>(type: "REAL", nullable: false),
                    Psi11 = table.Column<double>(type: "REAL", nullable: false),
                    Psi12 = table.Column<double>(type: "REAL", nullable: false),
                    Psi13 = table.Column<double>(type: "REAL", nullable: false),
                    Psi14 = table.Column<double>(type: "REAL", nullable: false),
                    Psi15 = table.Column<double>(type: "REAL", nullable: false),
                    Psi16 = table.Column<double>(type: "REAL", nullable: false),
                    Psi17 = table.Column<double>(type: "REAL", nullable: false),
                    Psi18 = table.Column<double>(type: "REAL", nullable: false),
                    Psi19 = table.Column<double>(type: "REAL", nullable: false),
                    Psi20 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C1ConcMuNegs", x => x.IdC1ConcMuNeg);
                });

            migrationBuilder.CreateTable(
                name: "C1ConcMuPos",
                columns: table => new
                {
                    IdC1ConcMuPos = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MuPos = table.Column<double>(type: "REAL", nullable: false),
                    Psi00 = table.Column<double>(type: "REAL", nullable: false),
                    Psi01 = table.Column<double>(type: "REAL", nullable: false),
                    Psi02 = table.Column<double>(type: "REAL", nullable: false),
                    Psi03 = table.Column<double>(type: "REAL", nullable: false),
                    Psi04 = table.Column<double>(type: "REAL", nullable: false),
                    Psi05 = table.Column<double>(type: "REAL", nullable: false),
                    Psi06 = table.Column<double>(type: "REAL", nullable: false),
                    Psi07 = table.Column<double>(type: "REAL", nullable: false),
                    Psi08 = table.Column<double>(type: "REAL", nullable: false),
                    Psi09 = table.Column<double>(type: "REAL", nullable: false),
                    Psi10 = table.Column<double>(type: "REAL", nullable: false),
                    Psi11 = table.Column<double>(type: "REAL", nullable: false),
                    Psi12 = table.Column<double>(type: "REAL", nullable: false),
                    Psi13 = table.Column<double>(type: "REAL", nullable: false),
                    Psi14 = table.Column<double>(type: "REAL", nullable: false),
                    Psi15 = table.Column<double>(type: "REAL", nullable: false),
                    Psi16 = table.Column<double>(type: "REAL", nullable: false),
                    Psi17 = table.Column<double>(type: "REAL", nullable: false),
                    Psi18 = table.Column<double>(type: "REAL", nullable: false),
                    Psi19 = table.Column<double>(type: "REAL", nullable: false),
                    Psi20 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C1ConcMuPos", x => x.IdC1ConcMuPos);
                });

            migrationBuilder.CreateTable(
                name: "C2ConcMuNegs",
                columns: table => new
                {
                    IdC2ConcMuNeg = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MuNeg = table.Column<double>(type: "REAL", nullable: false),
                    Psi00 = table.Column<double>(type: "REAL", nullable: false),
                    Psi01 = table.Column<double>(type: "REAL", nullable: false),
                    Psi02 = table.Column<double>(type: "REAL", nullable: false),
                    Psi03 = table.Column<double>(type: "REAL", nullable: false),
                    Psi04 = table.Column<double>(type: "REAL", nullable: false),
                    Psi05 = table.Column<double>(type: "REAL", nullable: false),
                    Psi06 = table.Column<double>(type: "REAL", nullable: false),
                    Psi07 = table.Column<double>(type: "REAL", nullable: false),
                    Psi08 = table.Column<double>(type: "REAL", nullable: false),
                    Psi09 = table.Column<double>(type: "REAL", nullable: false),
                    Psi10 = table.Column<double>(type: "REAL", nullable: false),
                    Psi11 = table.Column<double>(type: "REAL", nullable: false),
                    Psi12 = table.Column<double>(type: "REAL", nullable: false),
                    Psi13 = table.Column<double>(type: "REAL", nullable: false),
                    Psi14 = table.Column<double>(type: "REAL", nullable: false),
                    Psi15 = table.Column<double>(type: "REAL", nullable: false),
                    Psi16 = table.Column<double>(type: "REAL", nullable: false),
                    Psi17 = table.Column<double>(type: "REAL", nullable: false),
                    Psi18 = table.Column<double>(type: "REAL", nullable: false),
                    Psi19 = table.Column<double>(type: "REAL", nullable: false),
                    Psi20 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C2ConcMuNegs", x => x.IdC2ConcMuNeg);
                });

            migrationBuilder.CreateTable(
                name: "C2ConcMuPos",
                columns: table => new
                {
                    IdC2ConcMuPos = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MuPos = table.Column<double>(type: "REAL", nullable: false),
                    Psi00 = table.Column<double>(type: "REAL", nullable: false),
                    Psi01 = table.Column<double>(type: "REAL", nullable: false),
                    Psi02 = table.Column<double>(type: "REAL", nullable: false),
                    Psi03 = table.Column<double>(type: "REAL", nullable: false),
                    Psi04 = table.Column<double>(type: "REAL", nullable: false),
                    Psi05 = table.Column<double>(type: "REAL", nullable: false),
                    Psi06 = table.Column<double>(type: "REAL", nullable: false),
                    Psi07 = table.Column<double>(type: "REAL", nullable: false),
                    Psi08 = table.Column<double>(type: "REAL", nullable: false),
                    Psi09 = table.Column<double>(type: "REAL", nullable: false),
                    Psi10 = table.Column<double>(type: "REAL", nullable: false),
                    Psi11 = table.Column<double>(type: "REAL", nullable: false),
                    Psi12 = table.Column<double>(type: "REAL", nullable: false),
                    Psi13 = table.Column<double>(type: "REAL", nullable: false),
                    Psi14 = table.Column<double>(type: "REAL", nullable: false),
                    Psi15 = table.Column<double>(type: "REAL", nullable: false),
                    Psi16 = table.Column<double>(type: "REAL", nullable: false),
                    Psi17 = table.Column<double>(type: "REAL", nullable: false),
                    Psi18 = table.Column<double>(type: "REAL", nullable: false),
                    Psi19 = table.Column<double>(type: "REAL", nullable: false),
                    Psi20 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C2ConcMuPos", x => x.IdC2ConcMuPos);
                });

            migrationBuilder.CreateTable(
                name: "ClasseSections",
                columns: table => new
                {
                    IdClasseSection = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClasseSectionCalculee = table.Column<int>(type: "INTEGER", nullable: false),
                    ContraintesElastiquesMaxIdContraintesElastiques = table.Column<int>(type: "INTEGER", nullable: false),
                    RapportContraintePsiAme = table.Column<double>(type: "REAL", nullable: false),
                    RapportContraintePsiAile = table.Column<double>(type: "REAL", nullable: false),
                    Valeurintermediairek1 = table.Column<double>(type: "REAL", nullable: false),
                    HauteurComprimeeAme = table.Column<double>(type: "REAL", nullable: false),
                    PartEffortPlastiqueAme = table.Column<double>(type: "REAL", nullable: false),
                    LargeurComprimeeAile = table.Column<double>(type: "REAL", nullable: false),
                    PartEffortPlastiqueAile = table.Column<double>(type: "REAL", nullable: false),
                    ElancementEffectifAme = table.Column<double>(type: "REAL", nullable: false),
                    ElancementEffectifAile = table.Column<double>(type: "REAL", nullable: false),
                    ElancementLimiteAme = table.Column<double>(type: "REAL", nullable: false),
                    ElancementLimiteAile = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseSections", x => x.IdClasseSection);
                });

            migrationBuilder.CreateTable(
                name: "CombinaisonCharges1Ds",
                columns: table => new
                {
                    IdCombinaisonCharges = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LongueurElement = table.Column<double>(type: "REAL", nullable: false),
                    EffortNormalNed = table.Column<double>(type: "REAL", nullable: false),
                    ChargeRepartieUniformeqAxeY = table.Column<double>(type: "REAL", nullable: false),
                    ChargeRepartieUniformeqAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    ChargeConcentreMilieuTraveeQAxeY = table.Column<double>(type: "REAL", nullable: false),
                    ChargeConcentreMilieuTraveeQAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeYExtremiteO = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeYExtremiteE = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeZExtremiteO = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeZExtremiteE = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinaisonCharges1Ds", x => x.IdCombinaisonCharges);
                });

            migrationBuilder.CreateTable(
                name: "EffortTranchants",
                columns: table => new
                {
                    IdEffortTranchant = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RésistanceCisaillementZ = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientVoilementCisaillementZ = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteCritiqueCisaillementZ = table.Column<double>(type: "REAL", nullable: false),
                    RésistanceVoilementCisaillementZ = table.Column<double>(type: "REAL", nullable: false),
                    RésistanceCisaillementMinZ = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffortTranchants", x => x.IdEffortTranchant);
                });

            migrationBuilder.CreateTable(
                name: "Flambages",
                columns: table => new
                {
                    IdFlambage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElancementLimiteelastique = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteCritiqueAxeY = table.Column<double>(type: "REAL", nullable: false),
                    EffortNormalCritiqueAxeY = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientElancementY = table.Column<double>(type: "REAL", nullable: false),
                    FacteurReductionFlambageChikAxeY = table.Column<double>(type: "REAL", nullable: false),
                    RésistanceFlambageAxeY = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteCritiqueAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    EffortNormalCritiqueAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientElancementZ = table.Column<double>(type: "REAL", nullable: false),
                    FacteurReductionFlambageChikAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    RésistanceFlambageAxeZ = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flambages", x => x.IdFlambage);
                });

            migrationBuilder.CreateTable(
                name: "GeometrieIHs",
                columns: table => new
                {
                    IdGeometrieIH = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomGeometrieIH = table.Column<string>(type: "TEXT", nullable: true),
                    AireTotal = table.Column<double>(type: "REAL", nullable: false),
                    AireAmeAvecConge = table.Column<double>(type: "REAL", nullable: false),
                    AireAmeSansConge = table.Column<double>(type: "REAL", nullable: false),
                    MomentInertieAxeY = table.Column<double>(type: "REAL", nullable: false),
                    ModuleFlexionElastiqueAxeY = table.Column<double>(type: "REAL", nullable: false),
                    ModuleFlexionMoyenAxe = table.Column<double>(type: "REAL", nullable: false),
                    ModuleFlexionPlastiqueAxeY = table.Column<double>(type: "REAL", nullable: false),
                    RayonGirationAxeY = table.Column<double>(type: "REAL", nullable: false),
                    MomentInertieAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    ModuleFlexionElastiqueAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    ModuleFlexionPlastiqueAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    RayonGirationAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    MomentInertieAxeX = table.Column<double>(type: "REAL", nullable: false),
                    Hauteur = table.Column<double>(type: "REAL", nullable: false),
                    Largeur = table.Column<double>(type: "REAL", nullable: false),
                    EpaisseurAme = table.Column<double>(type: "REAL", nullable: false),
                    EpaisseurAile = table.Column<double>(type: "REAL", nullable: false),
                    RayonConge = table.Column<double>(type: "REAL", nullable: false),
                    HauteurPortionDroiteAme = table.Column<double>(type: "REAL", nullable: false),
                    DistanceAilesProfile = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeometrieIHs", x => x.IdGeometrieIH);
                });

            migrationBuilder.CreateTable(
                name: "MomentDeversementCTICMs",
                columns: table => new
                {
                    IdMomentDeversementCTICM = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LongueurCritiqueDeversement = table.Column<double>(type: "REAL", nullable: false),
                    MomentExtremiteO = table.Column<double>(type: "REAL", nullable: false),
                    MomentExtremiteE = table.Column<double>(type: "REAL", nullable: false),
                    RapportMomentsExtremitePsi = table.Column<double>(type: "REAL", nullable: false),
                    RapportMomentIsoMomentExtremiteMu = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientChargeC1 = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientPositionChargeC2 = table.Column<double>(type: "REAL", nullable: false),
                    MomentCritiqueDeversement = table.Column<double>(type: "REAL", nullable: false),
                    ElancementReduitDeversement = table.Column<double>(type: "REAL", nullable: false),
                    FacteurReductionDeversementChi = table.Column<double>(type: "REAL", nullable: false),
                    MomentResistantReduit = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomentDeversementCTICMs", x => x.IdMomentDeversementCTICM);
                });

            migrationBuilder.CreateTable(
                name: "MomentDeversementSIAs",
                columns: table => new
                {
                    IdMomentDeversementSIA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LongueurDeversementCritique = table.Column<double>(type: "REAL", nullable: false),
                    MomentExtremiteO = table.Column<double>(type: "REAL", nullable: false),
                    MomentExtremiteE = table.Column<double>(type: "REAL", nullable: false),
                    RapportMomentsExtremitePsi = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientMomentEta = table.Column<double>(type: "REAL", nullable: false),
                    RayonGirationMembrureComprimée = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteTorsionUniforme = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteTorsionNonUniforme = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteCritiqueDeversement = table.Column<double>(type: "REAL", nullable: false),
                    MomentCritiqueDeversement = table.Column<double>(type: "REAL", nullable: false),
                    ElancementReduitDeversement = table.Column<double>(type: "REAL", nullable: false),
                    FacteurReductionDeversementChi = table.Column<double>(type: "REAL", nullable: false),
                    MomentResistantReduit = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomentDeversementSIAs", x => x.IdMomentDeversementSIA);
                });

            migrationBuilder.CreateTable(
                name: "MomentsFlexionnelResistants",
                columns: table => new
                {
                    IdMomentsFlexionnelResistant = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EffortNormalResistant = table.Column<double>(type: "REAL", nullable: false),
                    PartEffortTranchantZ = table.Column<double>(type: "REAL", nullable: false),
                    MomentFlexionResistantY = table.Column<double>(type: "REAL", nullable: false),
                    MomentFlexionResistantZ = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomentsFlexionnelResistants", x => x.IdMomentsFlexionnelResistant);
                });

            migrationBuilder.CreateTable(
                name: "NuanceAciers",
                columns: table => new
                {
                    IdNuance = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomNuance = table.Column<string>(type: "TEXT", nullable: true),
                    LimiteElastique = table.Column<double>(type: "REAL", nullable: false),
                    LimiteElastiqueCisaillement = table.Column<double>(type: "REAL", nullable: false),
                    ResistanceTraction = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NuanceAciers", x => x.IdNuance);
                });

            migrationBuilder.CreateTable(
                name: "Stabilites",
                columns: table => new
                {
                    IdStabilite = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResultatStabilite = table.Column<double>(type: "REAL", nullable: false),
                    EquationUtiliseeStabilite = table.Column<string>(type: "TEXT", nullable: true),
                    OmegaY = table.Column<double>(type: "REAL", nullable: false),
                    OmegaZ = table.Column<double>(type: "REAL", nullable: false),
                    Resultat = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stabilites", x => x.IdStabilite);
                });

            migrationBuilder.CreateTable(
                name: "ContraintesElastiques1PointYZ",
                columns: table => new
                {
                    IdContraintesElastiques = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoordonnéeY = table.Column<double>(type: "REAL", nullable: false),
                    CoordonnéeZ = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteNormalSigmaX = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteTangentielleTauZX = table.Column<double>(type: "REAL", nullable: false),
                    ContrainteComparaisonVonMises = table.Column<double>(type: "REAL", nullable: false),
                    ClasseSectionCalculeIdClasseSection = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraintesElastiques1PointYZ", x => x.IdContraintesElastiques);
                    table.ForeignKey(
                        name: "FK_ContraintesElastiques1PointYZ_ClasseSections_ClasseSectionCalculeIdClasseSection",
                        column: x => x.ClasseSectionCalculeIdClasseSection,
                        principalTable: "ClasseSections",
                        principalColumn: "IdClasseSection",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiagrammesEffortsInternes",
                columns: table => new
                {
                    IdDiagrammeEffortsInternes = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CombinaisonCharges1DSelectionneeIdCombinaisonCharges = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagrammesEffortsInternes", x => x.IdDiagrammeEffortsInternes);
                    table.ForeignKey(
                        name: "FK_DiagrammesEffortsInternes_CombinaisonCharges1Ds_CombinaisonCharges1DSelectionneeIdCombinaisonCharges",
                        column: x => x.CombinaisonCharges1DSelectionneeIdCombinaisonCharges,
                        principalTable: "CombinaisonCharges1Ds",
                        principalColumn: "IdCombinaisonCharges",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EffortsInternesDistanceX",
                columns: table => new
                {
                    IdEffortsInternes = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DistanceX = table.Column<double>(type: "REAL", nullable: false),
                    EffortNormalNed = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeYDistanceX = table.Column<double>(type: "REAL", nullable: false),
                    MomentMAxeZDistanceX = table.Column<double>(type: "REAL", nullable: false),
                    EffortTranchanVAxeZDistanceX = table.Column<double>(type: "REAL", nullable: false),
                    EffortTranchanVAxeYDistanceX = table.Column<double>(type: "REAL", nullable: false),
                    DiagrammesEffortsInternesIdDiagrammeEffortsInternes = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffortsInternesDistanceX", x => x.IdEffortsInternes);
                    table.ForeignKey(
                        name: "FK_EffortsInternesDistanceX_DiagrammesEffortsInternes_DiagrammesEffortsInternesIdDiagrammeEffortsInternes",
                        column: x => x.DiagrammesEffortsInternesIdDiagrammeEffortsInternes,
                        principalTable: "DiagrammesEffortsInternes",
                        principalColumn: "IdDiagrammeEffortsInternes",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResistanceSections",
                columns: table => new
                {
                    IdResistanceSection = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResultatResistanceSection = table.Column<double>(type: "REAL", nullable: false),
                    EquationUtiliseeResistanceSection = table.Column<string>(type: "TEXT", nullable: true),
                    EffortsDeterminantsResistanceSectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ContraintesDeterminantesId = table.Column<int>(type: "INTEGER", nullable: true),
                    Resultat = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResistanceSections", x => x.IdResistanceSection);
                    table.ForeignKey(
                        name: "FK_ResistanceSections_ContraintesElastiques1PointYZ_ContraintesDeterminantesId",
                        column: x => x.ContraintesDeterminantesId,
                        principalTable: "ContraintesElastiques1PointYZ",
                        principalColumn: "IdContraintesElastiques",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResistanceSections_EffortsInternesDistanceX_EffortsDeterminantsResistanceSectionId",
                        column: x => x.EffortsDeterminantsResistanceSectionId,
                        principalTable: "EffortsInternesDistanceX",
                        principalColumn: "IdEffortsInternes",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileIHs",
                columns: table => new
                {
                    IdElement = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeometrieIHSelectionneeIdGeometrieIH = table.Column<int>(type: "INTEGER", nullable: true),
                    NomEntier = table.Column<string>(type: "TEXT", nullable: true),
                    NomElement = table.Column<string>(type: "TEXT", nullable: true),
                    NomPersonnalise = table.Column<string>(type: "TEXT", nullable: true),
                    NuanceAcierSelectionneeIdNuance = table.Column<int>(type: "INTEGER", nullable: true),
                    Longueur = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientFlambageAxeY = table.Column<double>(type: "REAL", nullable: false),
                    CoefficientFlambageAxeZ = table.Column<double>(type: "REAL", nullable: false),
                    SectionNette = table.Column<double>(type: "REAL", nullable: false),
                    PositionnementCharge = table.Column<double>(type: "REAL", nullable: false),
                    OmegaY1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    OmegaZ1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes = table.Column<int>(type: "INTEGER", nullable: true),
                    ClasseSectionCalculeIdClasseSection = table.Column<int>(type: "INTEGER", nullable: true),
                    FlambageCalculeIdFlambage = table.Column<int>(type: "INTEGER", nullable: true),
                    EffortTranchantCalculeIdEffortTranchant = table.Column<int>(type: "INTEGER", nullable: true),
                    MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant = table.Column<int>(type: "INTEGER", nullable: true),
                    MomentDeversementCTICMCalculeIdMomentDeversementCTICM = table.Column<int>(type: "INTEGER", nullable: true),
                    MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM = table.Column<int>(type: "INTEGER", nullable: true),
                    C1ConcMuPosesIdC1ConcMuPos = table.Column<int>(type: "INTEGER", nullable: true),
                    C2ConcMuNegsIdC2ConcMuNeg = table.Column<int>(type: "INTEGER", nullable: true),
                    C2ConcMuPosesIdC2ConcMuPos = table.Column<int>(type: "INTEGER", nullable: true),
                    C1ConcMuNegsIdC1ConcMuNeg = table.Column<int>(type: "INTEGER", nullable: true),
                    MomentDeversementSIACalculeIdMomentDeversementSIA = table.Column<int>(type: "INTEGER", nullable: true),
                    MomentDeversementSIACalculeMinIdMomentDeversementSIA = table.Column<int>(type: "INTEGER", nullable: true),
                    StabiliteCalculeIdStabilite = table.Column<int>(type: "INTEGER", nullable: true),
                    ResistanceSectionCalculeeIdResistanceSection = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileIHs", x => x.IdElement);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_C1ConcMuNegs_C1ConcMuNegsIdC1ConcMuNeg",
                        column: x => x.C1ConcMuNegsIdC1ConcMuNeg,
                        principalTable: "C1ConcMuNegs",
                        principalColumn: "IdC1ConcMuNeg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_C1ConcMuPos_C1ConcMuPosesIdC1ConcMuPos",
                        column: x => x.C1ConcMuPosesIdC1ConcMuPos,
                        principalTable: "C1ConcMuPos",
                        principalColumn: "IdC1ConcMuPos",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_C2ConcMuNegs_C2ConcMuNegsIdC2ConcMuNeg",
                        column: x => x.C2ConcMuNegsIdC2ConcMuNeg,
                        principalTable: "C2ConcMuNegs",
                        principalColumn: "IdC2ConcMuNeg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_C2ConcMuPos_C2ConcMuPosesIdC2ConcMuPos",
                        column: x => x.C2ConcMuPosesIdC2ConcMuPos,
                        principalTable: "C2ConcMuPos",
                        principalColumn: "IdC2ConcMuPos",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_ClasseSections_ClasseSectionCalculeIdClasseSection",
                        column: x => x.ClasseSectionCalculeIdClasseSection,
                        principalTable: "ClasseSections",
                        principalColumn: "IdClasseSection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_DiagrammesEffortsInternes_DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes",
                        column: x => x.DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes,
                        principalTable: "DiagrammesEffortsInternes",
                        principalColumn: "IdDiagrammeEffortsInternes",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_EffortTranchants_EffortTranchantCalculeIdEffortTranchant",
                        column: x => x.EffortTranchantCalculeIdEffortTranchant,
                        principalTable: "EffortTranchants",
                        principalColumn: "IdEffortTranchant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_Flambages_FlambageCalculeIdFlambage",
                        column: x => x.FlambageCalculeIdFlambage,
                        principalTable: "Flambages",
                        principalColumn: "IdFlambage",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_GeometrieIHs_GeometrieIHSelectionneeIdGeometrieIH",
                        column: x => x.GeometrieIHSelectionneeIdGeometrieIH,
                        principalTable: "GeometrieIHs",
                        principalColumn: "IdGeometrieIH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_MomentDeversementCTICMs_MomentDeversementCTICMCalculeIdMomentDeversementCTICM",
                        column: x => x.MomentDeversementCTICMCalculeIdMomentDeversementCTICM,
                        principalTable: "MomentDeversementCTICMs",
                        principalColumn: "IdMomentDeversementCTICM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_MomentDeversementCTICMs_MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM",
                        column: x => x.MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM,
                        principalTable: "MomentDeversementCTICMs",
                        principalColumn: "IdMomentDeversementCTICM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_MomentDeversementSIAs_MomentDeversementSIACalculeIdMomentDeversementSIA",
                        column: x => x.MomentDeversementSIACalculeIdMomentDeversementSIA,
                        principalTable: "MomentDeversementSIAs",
                        principalColumn: "IdMomentDeversementSIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_MomentDeversementSIAs_MomentDeversementSIACalculeMinIdMomentDeversementSIA",
                        column: x => x.MomentDeversementSIACalculeMinIdMomentDeversementSIA,
                        principalTable: "MomentDeversementSIAs",
                        principalColumn: "IdMomentDeversementSIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_MomentsFlexionnelResistants_MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant",
                        column: x => x.MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant,
                        principalTable: "MomentsFlexionnelResistants",
                        principalColumn: "IdMomentsFlexionnelResistant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_NuanceAciers_NuanceAcierSelectionneeIdNuance",
                        column: x => x.NuanceAcierSelectionneeIdNuance,
                        principalTable: "NuanceAciers",
                        principalColumn: "IdNuance",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_ResistanceSections_ResistanceSectionCalculeeIdResistanceSection",
                        column: x => x.ResistanceSectionCalculeeIdResistanceSection,
                        principalTable: "ResistanceSections",
                        principalColumn: "IdResistanceSection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileIHs_Stabilites_StabiliteCalculeIdStabilite",
                        column: x => x.StabiliteCalculeIdStabilite,
                        principalTable: "Stabilites",
                        principalColumn: "IdStabilite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContraintesElastiques1PointYZ_ClasseSectionCalculeIdClasseSection",
                table: "ContraintesElastiques1PointYZ",
                column: "ClasseSectionCalculeIdClasseSection");

            migrationBuilder.CreateIndex(
                name: "IX_DiagrammesEffortsInternes_CombinaisonCharges1DSelectionneeIdCombinaisonCharges",
                table: "DiagrammesEffortsInternes",
                column: "CombinaisonCharges1DSelectionneeIdCombinaisonCharges");

            migrationBuilder.CreateIndex(
                name: "IX_EffortsInternesDistanceX_DiagrammesEffortsInternesIdDiagrammeEffortsInternes",
                table: "EffortsInternesDistanceX",
                column: "DiagrammesEffortsInternesIdDiagrammeEffortsInternes");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_C1ConcMuNegsIdC1ConcMuNeg",
                table: "ProfileIHs",
                column: "C1ConcMuNegsIdC1ConcMuNeg");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_C1ConcMuPosesIdC1ConcMuPos",
                table: "ProfileIHs",
                column: "C1ConcMuPosesIdC1ConcMuPos");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_C2ConcMuNegsIdC2ConcMuNeg",
                table: "ProfileIHs",
                column: "C2ConcMuNegsIdC2ConcMuNeg");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_C2ConcMuPosesIdC2ConcMuPos",
                table: "ProfileIHs",
                column: "C2ConcMuPosesIdC2ConcMuPos");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_ClasseSectionCalculeIdClasseSection",
                table: "ProfileIHs",
                column: "ClasseSectionCalculeIdClasseSection");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes",
                table: "ProfileIHs",
                column: "DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_EffortTranchantCalculeIdEffortTranchant",
                table: "ProfileIHs",
                column: "EffortTranchantCalculeIdEffortTranchant");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_FlambageCalculeIdFlambage",
                table: "ProfileIHs",
                column: "FlambageCalculeIdFlambage");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_GeometrieIHSelectionneeIdGeometrieIH",
                table: "ProfileIHs",
                column: "GeometrieIHSelectionneeIdGeometrieIH");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_MomentDeversementCTICMCalculeIdMomentDeversementCTICM",
                table: "ProfileIHs",
                column: "MomentDeversementCTICMCalculeIdMomentDeversementCTICM");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM",
                table: "ProfileIHs",
                column: "MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_MomentDeversementSIACalculeIdMomentDeversementSIA",
                table: "ProfileIHs",
                column: "MomentDeversementSIACalculeIdMomentDeversementSIA");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_MomentDeversementSIACalculeMinIdMomentDeversementSIA",
                table: "ProfileIHs",
                column: "MomentDeversementSIACalculeMinIdMomentDeversementSIA");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant",
                table: "ProfileIHs",
                column: "MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_NuanceAcierSelectionneeIdNuance",
                table: "ProfileIHs",
                column: "NuanceAcierSelectionneeIdNuance");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_ResistanceSectionCalculeeIdResistanceSection",
                table: "ProfileIHs",
                column: "ResistanceSectionCalculeeIdResistanceSection");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileIHs_StabiliteCalculeIdStabilite",
                table: "ProfileIHs",
                column: "StabiliteCalculeIdStabilite");

            migrationBuilder.CreateIndex(
                name: "IX_ResistanceSections_ContraintesDeterminantesId",
                table: "ResistanceSections",
                column: "ContraintesDeterminantesId");

            migrationBuilder.CreateIndex(
                name: "IX_ResistanceSections_EffortsDeterminantsResistanceSectionId",
                table: "ResistanceSections",
                column: "EffortsDeterminantsResistanceSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileIHs");

            migrationBuilder.DropTable(
                name: "C1ConcMuNegs");

            migrationBuilder.DropTable(
                name: "C1ConcMuPos");

            migrationBuilder.DropTable(
                name: "C2ConcMuNegs");

            migrationBuilder.DropTable(
                name: "C2ConcMuPos");

            migrationBuilder.DropTable(
                name: "EffortTranchants");

            migrationBuilder.DropTable(
                name: "Flambages");

            migrationBuilder.DropTable(
                name: "GeometrieIHs");

            migrationBuilder.DropTable(
                name: "MomentDeversementCTICMs");

            migrationBuilder.DropTable(
                name: "MomentDeversementSIAs");

            migrationBuilder.DropTable(
                name: "MomentsFlexionnelResistants");

            migrationBuilder.DropTable(
                name: "NuanceAciers");

            migrationBuilder.DropTable(
                name: "ResistanceSections");

            migrationBuilder.DropTable(
                name: "Stabilites");

            migrationBuilder.DropTable(
                name: "ContraintesElastiques1PointYZ");

            migrationBuilder.DropTable(
                name: "EffortsInternesDistanceX");

            migrationBuilder.DropTable(
                name: "ClasseSections");

            migrationBuilder.DropTable(
                name: "DiagrammesEffortsInternes");

            migrationBuilder.DropTable(
                name: "CombinaisonCharges1Ds");
        }
    }
}
