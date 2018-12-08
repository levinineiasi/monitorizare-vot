using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using VotingIrregularities.Domain.Models;
using VotingIrregularities.Domain.ValueObjects;

namespace VotingIrregularities.Domain.Migrations
{
    public static class VotingContextExtensions
    {
        public static void EnsureSeedData(this VotingContext context)
        {
            if (!context.AllMigrationsApplied())
                return;

            using (var tran = context.Database.BeginTransaction())
            {
                context.DataCleanUp();

                context.SeedVersions();
                context.SeedJudete();
                context.SeedSectiune();
                context.SeedOptiuni();
                context.SeedQuestions(new Guid("9875bd98-d071-4c26-9bf3-13a93f8ac9d8"));
                //context.SeedQuestions(new Guid("356e5695-dc48-428a-b7b5-22e1364263a0"));
                //context.SeedQuestions(new Guid("c303646c-65ae-461b-bb05-c477500798ef"));
                context.SeedONGs();
                context.SeedObservatori();

                tran.Commit();
            }
        }

        private static void SeedJudete(this VotingContext context)
        {
            if (context.Judet.Any())
                return;

            context.Judet.AddRange(
                new Judet { IdJudet = 1, CodJudet = "AB", Nume = "ALBA" },
                new Judet { IdJudet = 2, CodJudet = "AR", Nume = "ARAD" },
                new Judet { IdJudet = 3, CodJudet = "AG", Nume = "ARGES" },
                new Judet { IdJudet = 4, CodJudet = "BC", Nume = "BACAU" },
                new Judet { IdJudet = 5, CodJudet = "BH", Nume = "BIHOR" },
                new Judet { IdJudet = 6, CodJudet = "BN", Nume = "BISTRITA-NASAUD" },
                new Judet { IdJudet = 7, CodJudet = "BT", Nume = "BOTOSANI" },
                new Judet { IdJudet = 8, CodJudet = "BV", Nume = "BRASOV" },
                new Judet { IdJudet = 9, CodJudet = "BR", Nume = "BRAILA" },
                new Judet { IdJudet = 10, CodJudet = "BZ", Nume = "BUZAU" },
                new Judet { IdJudet = 11, CodJudet = "CS", Nume = "CARAS-SEVERIN" },
                new Judet { IdJudet = 12, CodJudet = "CL", Nume = "CALARASI" },
                new Judet { IdJudet = 13, CodJudet = "CJ", Nume = "CLUJ" },
                new Judet { IdJudet = 14, CodJudet = "CT", Nume = "CONSTANTA" },
                new Judet { IdJudet = 15, CodJudet = "CV", Nume = "COVASNA" },
                new Judet { IdJudet = 16, CodJudet = "DB", Nume = "DÂMBOVITA" },
                new Judet { IdJudet = 17, CodJudet = "DJ", Nume = "DOLJ" },
                new Judet { IdJudet = 18, CodJudet = "GL", Nume = "GALATI" },
                new Judet { IdJudet = 19, CodJudet = "GR", Nume = "GIURGIU" },
                new Judet { IdJudet = 20, CodJudet = "GJ", Nume = "GORJ" },
                new Judet { IdJudet = 21, CodJudet = "HR", Nume = "HARGHITA" },
                new Judet { IdJudet = 22, CodJudet = "HD", Nume = "HUNEDOARA" },
                new Judet { IdJudet = 23, CodJudet = "IL", Nume = "IALOMITA" },
                new Judet { IdJudet = 24, CodJudet = "IS", Nume = "IASI" },
                new Judet { IdJudet = 25, CodJudet = "IF", Nume = "ILFOV" },
                new Judet { IdJudet = 26, CodJudet = "MM", Nume = "MARAMURES" },
                new Judet { IdJudet = 27, CodJudet = "MH", Nume = "MEHEDINTI" },
                new Judet { IdJudet = 28, CodJudet = "B", Nume = "MUNICIPIUL BUCURESTI" },
                new Judet { IdJudet = 29, CodJudet = "MS", Nume = "MURES" },
                new Judet { IdJudet = 30, CodJudet = "NT", Nume = "NEAMT" },
                new Judet { IdJudet = 31, CodJudet = "OT", Nume = "OLT" },
                new Judet { IdJudet = 32, CodJudet = "PH", Nume = "PRAHOVA" },
                new Judet { IdJudet = 33, CodJudet = "SM", Nume = "SATU MARE" },
                new Judet { IdJudet = 34, CodJudet = "SJ", Nume = "SALAJ" },
                new Judet { IdJudet = 35, CodJudet = "SB", Nume = "SIBIU" },
                new Judet { IdJudet = 36, CodJudet = "SV", Nume = "SUCEAVA" },
                new Judet { IdJudet = 37, CodJudet = "TR", Nume = "TELEORMAN" },
                new Judet { IdJudet = 38, CodJudet = "TM", Nume = "TIMIS" },
                new Judet { IdJudet = 39, CodJudet = "TL", Nume = "TULCEA" },
                new Judet { IdJudet = 40, CodJudet = "VS", Nume = "VASLUI" },
                new Judet { IdJudet = 41, CodJudet = "VL", Nume = "VÂLCEA" },
                new Judet { IdJudet = 42, CodJudet = "VN", Nume = "VRANCEA" },
                new Judet { IdJudet = 43, CodJudet = "D", Nume = "DIASPORA" }
                );
        }

        private static void DataCleanUp(this VotingContext context)
        {
            context.Database.ExecuteSqlCommand("delete from RaspunsDisponibil");
            context.Database.ExecuteSqlCommand("delete from Intrebare");
            context.Database.ExecuteSqlCommand("delete from Sectiune");
            context.Database.ExecuteSqlCommand("delete from VersiuneFormular");
            // context.Database.ExecuteSqlCommand("delete from Judet");
        }

        private static void SeedOptiuni(this VotingContext context)
        {
            if (context.Optiune.Any())
                return;

            context.Optiune.AddRange(
                new Optiune { IdOptiune = 1, TextOptiune = "Da", },
                new Optiune { IdOptiune = 2, TextOptiune = "Nu", },
                new Optiune { IdOptiune = 3, TextOptiune = "Nu stiu", },
                new Optiune { IdOptiune = 4, TextOptiune = "Dark Island", },
                new Optiune { IdOptiune = 5, TextOptiune = "London Pride", },
                new Optiune { IdOptiune = 6, TextOptiune = "Zaganu", },
                new Optiune { IdOptiune = 7, TextOptiune = "Transmisia manualã", },
                new Optiune { IdOptiune = 8, TextOptiune = "Transmisia automatã", },
                new Optiune { IdOptiune = 9, TextOptiune = "Altele (specificaţi)", SeIntroduceText = true },
                new Optiune { IdOptiune = 10, TextOptiune = "Metrou" },
                new Optiune { IdOptiune = 11, TextOptiune = "Tramvai" },
                new Optiune { IdOptiune = 12, TextOptiune = "Autobuz" }
            );

            context.SaveChanges();
        }
        private static void SeedSectiune(this VotingContext context)
        {
            if (context.Sectiune.Any())
                return;

            context.Sectiune.AddRange(
                new Sectiune { IdSectiune = 1, CodSectiune = "B", Descriere = "Despre Bere" },
                new Sectiune { IdSectiune = 2, CodSectiune = "C", Descriere = "Despre programare" },
                new Sectiune { IdSectiune = 3, CodSectiune = "D", Descriere = "Despre sanatate" },
                new Sectiune { IdSectiune = 4, CodSectiune = "E", Descriere = "Despre psihologie" },
                new Sectiune { IdSectiune = 5, CodSectiune = "F", Descriere = "Despre antropologie" },
                new Sectiune { IdSectiune = 6, CodSectiune = "G", Descriere = "Despre kinetoterapie" },
                new Sectiune { IdSectiune = 7, CodSectiune = "H", Descriere = "Despre tine" }
            );

            context.SaveChanges();
        }

        private static void SeedQuestions(this VotingContext context, Guid idFormular)
        {
            if (context.Intrebare.Any(a => a.CodFormular == idFormular))
                return;

            context.Intrebare.AddRange(
                // primul formular
                new Intrebare
                {
                    IdIntrebare = 1,
                    CodFormular = idFormular,
                    IdSectiune = 1, //B
                    IdTipIntrebare = TipIntrebareEnum.OSinguraOptiune,
                    TextIntrebare = "Iti place berea? (se alege o singura optiune selectabila)",
                    RaspunsDisponibil = new List<RaspunsDisponibil>
                    {
                        new RaspunsDisponibil {IdRaspunsDisponibil = 1, IdOptiune = 1},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 2, IdOptiune = 2, RaspunsCuFlag = true},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 3, IdOptiune = 3}
                    }
                },
                new Intrebare
                {
                    IdIntrebare = 2,
                    CodFormular = idFormular,
                    IdSectiune = 1, //B
                    IdTipIntrebare = TipIntrebareEnum.OptiuniMultiple,
                    TextIntrebare = "Ce tipuri de bere iti plac? (se pot alege optiuni multiple)",
                    RaspunsDisponibil = new List<RaspunsDisponibil>
                    {
                        new RaspunsDisponibil {IdRaspunsDisponibil = 11, IdOptiune = 4, RaspunsCuFlag = true},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 12, IdOptiune = 5},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 13, IdOptiune = 6}
                    }
                },
                new Intrebare
                {
                    IdIntrebare = 3,
                    CodFormular = idFormular,
                    IdSectiune = 2, //C
                    IdTipIntrebare = TipIntrebareEnum.OSinguraOptiuneCuText,
                    TextIntrebare = "Ce tip de transmisie are masina ta? (se poate alege O singura optiune selectabila + text pe O singura optiune)",
                    RaspunsDisponibil = new List<RaspunsDisponibil>
                    {
                        new RaspunsDisponibil {IdRaspunsDisponibil = 14, IdOptiune = 7, RaspunsCuFlag = true},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 15, IdOptiune = 8},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 16, IdOptiune = 9}
                    }
                },
                new Intrebare
                {
                    IdIntrebare = 4,
                    CodFormular = idFormular,
                    IdSectiune = 2, //C
                    IdTipIntrebare = TipIntrebareEnum.OptiuniMultipleCuText,
                    TextIntrebare = "Ce mijloace de transport folosesti sa ajungi la birou? (se pot alege mai multe optiuni + text pe O singura optiune)",
                    RaspunsDisponibil = new List<RaspunsDisponibil>
                    {
                        new RaspunsDisponibil {IdRaspunsDisponibil = 17, IdOptiune = 10, RaspunsCuFlag = true},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 18, IdOptiune = 11},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 19, IdOptiune = 12},
                        new RaspunsDisponibil {IdRaspunsDisponibil = 20, IdOptiune = 9}
                    }
                }
            );

            context.SaveChanges();
        }

        private static void SeedVersions(this VotingContext context)
        {
            if (context.VersiuneFormular.Any())
                return;

            context.VersiuneFormular.AddRange(
                 new VersiuneFormular
                 {
                     CodFormular = new Guid("9875bd98-d071-4c26-9bf3-13a93f8ac9d8"),
                     VersiuneaCurenta = 1,
                     Nume = "A",
                     Ordine = 1,
                     Data = DateTime.Now
                 },
                 new VersiuneFormular
                 {
                     CodFormular = new Guid("356e5695-dc48-428a-b7b5-22e1364263a0"),
                     VersiuneaCurenta = 1 ,
                     Nume = "B",
                     Ordine = 2,
                     Data = DateTime.Now
                 },
                 new VersiuneFormular
                 {
                     CodFormular = new Guid("c303646c-65ae-461b-bb05-c477500798ef"),
                     VersiuneaCurenta = 1,
                     Nume = "C",
                     Ordine = 3,
                     Data = DateTime.Now
                 }
             );

            context.SaveChanges();
        }

        private static void SeedONGs(this VotingContext context)
        {
            if (context.Ong.Any())
                return;

            context.Ong.AddRange(
                new Ong
                {
                    AbreviereNumeOng = "CAD",
                    AdminOng = new List<AdminOng>(),
                    IdOng = 1,
                    NumeOng = "Control-Alt-Defeat",
                    Observator = new List<Observator>(),
                    Organizator = true
                }
            );

            context.SaveChanges();
        }

        private static void SeedObservatori(this VotingContext context)
        {
            if (context.Observator.Any())
                return;

            context.Observator.AddRange(
                new Observator
                {
                    IdOng = 1,
                    DataInregistrariiDispozitivului = DateTime.Now,
                    EsteDinEchipa = true,
                    IdDispozitivMobil = "b3ac49ee526f887c",
                    IdObservator = 1,
                    IdOngNavigation = new Ong(),
                    Nota = new List<Nota>(),
                    NumarTelefon = "0742131349",
                    NumeIntreg = "Costan Ancuta Monica",
                    Pin = "31d3fe1ac88a474ed71e037e7908c7f448a8622a9cdd9a1635b0393b15bebbdb",
                    Raspuns = new List<Raspuns>(),
                    RaspunsFormular = new List<RaspunsFormular>()
                }
            );

            context.SaveChanges();
        }


        private static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}
