using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using VotingIrregularities.Domain.Models;
using VotingIrregularities.Domain.ValueObjects;

namespace VotingIrregularities.Domain
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
            if (context.Counties.Any())
                return;

            context.Counties.AddRange(
                new County { CountyId = 1, CountyCode = "AB", Name = "ALBA" },
                new County { CountyId = 2, CountyCode = "AR", Name = "ARAD" },
                new County { CountyId = 3, CountyCode = "AG", Name = "ARGES" },
                new County { CountyId = 4, CountyCode = "BC", Name = "BACAU" },
                new County { CountyId = 5, CountyCode = "BH", Name = "BIHOR" },
                new County { CountyId = 6, CountyCode = "BN", Name = "BISTRITA-NASAUD" },
                new County { CountyId = 7, CountyCode = "BT", Name = "BOTOSANI" },
                new County { CountyId = 8, CountyCode = "BV", Name = "BRASOV" },
                new County { CountyId = 9, CountyCode = "BR", Name = "BRAILA" },
                new County { CountyId = 10, CountyCode = "BZ", Name = "BUZAU" },
                new County { CountyId = 11, CountyCode = "CS", Name = "CARAS-SEVERIN" },
                new County { CountyId = 12, CountyCode = "CL", Name = "CALARASI" },
                new County { CountyId = 13, CountyCode = "CJ", Name = "CLUJ" },
                new County { CountyId = 14, CountyCode = "CT", Name = "CONSTANTA" },
                new County { CountyId = 15, CountyCode = "CV", Name = "COVASNA" },
                new County { CountyId = 16, CountyCode = "DB", Name = "DÂMBOVITA" },
                new County { CountyId = 17, CountyCode = "DJ", Name = "DOLJ" },
                new County { CountyId = 18, CountyCode = "GL", Name = "GALATI" },
                new County { CountyId = 19, CountyCode = "GR", Name = "GIURGIU" },
                new County { CountyId = 20, CountyCode = "GJ", Name = "GORJ" },
                new County { CountyId = 21, CountyCode = "HR", Name = "HARGHITA" },
                new County { CountyId = 22, CountyCode = "HD", Name = "HUNEDOARA" },
                new County { CountyId = 23, CountyCode = "IL", Name = "IALOMITA" },
                new County { CountyId = 24, CountyCode = "IS", Name = "IASI" },
                new County { CountyId = 25, CountyCode = "IF", Name = "ILFOV" },
                new County { CountyId = 26, CountyCode = "MM", Name = "MARAMURES" },
                new County { CountyId = 27, CountyCode = "MH", Name = "MEHEDINTI" },
                new County { CountyId = 28, CountyCode = "B", Name = "MUNICIPIUL BUCURESTI" },
                new County { CountyId = 29, CountyCode = "MS", Name = "MURES" },
                new County { CountyId = 30, CountyCode = "NT", Name = "NEAMT" },
                new County { CountyId = 31, CountyCode = "OT", Name = "OLT" },
                new County { CountyId = 32, CountyCode = "PH", Name = "PRAHOVA" },
                new County { CountyId = 33, CountyCode = "SM", Name = "SATU MARE" },
                new County { CountyId = 34, CountyCode = "SJ", Name = "SALAJ" },
                new County { CountyId = 35, CountyCode = "SB", Name = "SIBIU" },
                new County { CountyId = 36, CountyCode = "SV", Name = "SUCEAVA" },
                new County { CountyId = 37, CountyCode = "TR", Name = "TELEORMAN" },
                new County { CountyId = 38, CountyCode = "TM", Name = "TIMIS" },
                new County { CountyId = 39, CountyCode = "TL", Name = "TULCEA" },
                new County { CountyId = 40, CountyCode = "VS", Name = "VASLUI" },
                new County { CountyId = 41, CountyCode = "VL", Name = "VÂLCEA" },
                new County { CountyId = 42, CountyCode = "VN", Name = "VRANCEA" },
                new County { CountyId = 43, CountyCode = "D", Name = "DIASPORA" }
                );
        }

        private static void DataCleanUp(this VotingContext context)
        {
            context.Database.ExecuteSqlCommand("delete from AvailableAnswer");
            context.Database.ExecuteSqlCommand("delete from Questions");
            context.Database.ExecuteSqlCommand("delete from Section");
            context.Database.ExecuteSqlCommand("delete from FormVersions");
            // context.Database.ExecuteSqlCommand("delete from County");
        }

        private static void SeedOptiuni(this VotingContext context)
        {
            if (context.Options.Any())
                return;

            context.Options.AddRange(
                new Option { OptionId = 1, TextOption = "Da", },
                new Option { OptionId = 2, TextOption = "Nu", },
                new Option { OptionId = 3, TextOption = "Nu stiu", },
                new Option { OptionId = 4, TextOption = "Dark Island", },
                new Option { OptionId = 5, TextOption = "London Pride", },
                new Option { OptionId = 6, TextOption = "Zaganu", },
                new Option { OptionId = 7, TextOption = "Transmisia manualã", },
                new Option { OptionId = 8, TextOption = "Transmisia automatã", },
                new Option { OptionId = 9, TextOption = "Altele (specificaţi)", TextMustBeInserted = true },
                new Option { OptionId = 10, TextOption = "Metrou" },
                new Option { OptionId = 11, TextOption = "Tramvai" },
                new Option { OptionId = 12, TextOption = "Autobuz" }
            );

            context.SaveChanges();
        }
        private static void SeedSectiune(this VotingContext context)
        {
            if (context.Sections.Any())
                return;

            context.Sections.AddRange(
                new Section { SectionId = 1, SectionCode = "B", Description = "Despre Bere" },
                new Section { SectionId = 2, SectionCode = "C", Description = "Despre programare" },
                new Section { SectionId = 3, SectionCode = "D", Description = "Despre sanatate" },
                new Section { SectionId = 4, SectionCode = "E", Description = "Despre psihologie" },
                new Section { SectionId = 5, SectionCode = "F", Description = "Despre antropologie" },
                new Section { SectionId = 6, SectionCode = "G", Description = "Despre kinetoterapie" },
                new Section { SectionId = 7, SectionCode = "H", Description = "Despre tine" }
            );

            context.SaveChanges();
        }

        private static void SeedQuestions(this VotingContext context, Guid idFormular)
        {
            if (context.Questions.Any(a => a.FormCode == idFormular))
                return;

            context.Questions.AddRange(
                // primul formular
                new Question
                {
                    QuestionId = 1,
                    FormCode = idFormular,
                    SectionId = 1, //B
                    QuestionTypeId = QuestionTypeEnum.SingleOption,
                    QuestionText = "Iti place berea? (se alege o singura optiune selectabila)",
                    AvailableAnswer = new List<AvailableAnswer>
                    {
                        new AvailableAnswer {AvailableAnswerId = 1, OptionId = 1},
                        new AvailableAnswer {AvailableAnswerId = 2, OptionId = 2, AnswerWithFlag = true},
                        new AvailableAnswer {AvailableAnswerId = 3, OptionId = 3}
                    }
                },
                new Question
                {
                    QuestionId = 2,
                    FormCode = idFormular,
                    SectionId = 1, //B
                    QuestionTypeId = QuestionTypeEnum.MultipleOptions,
                    QuestionText = "Ce tipuri de bere iti plac? (se pot alege optiuni multiple)",
                    AvailableAnswer = new List<AvailableAnswer>
                    {
                        new AvailableAnswer {AvailableAnswerId = 11, OptionId = 4, AnswerWithFlag = true},
                        new AvailableAnswer {AvailableAnswerId = 12, OptionId = 5},
                        new AvailableAnswer {AvailableAnswerId = 13, OptionId = 6}
                    }
                },
                new Question
                {
                    QuestionId = 3,
                    FormCode = idFormular,
                    SectionId = 2, //C
                    QuestionTypeId = QuestionTypeEnum.SingleOptionWithText,
                    QuestionText = "Ce tip de transmisie are masina ta? (se poate alege O singura optiune selectabila + text pe O singura optiune)",
                    AvailableAnswer = new List<AvailableAnswer>
                    {
                        new AvailableAnswer {AvailableAnswerId = 14, OptionId = 7, AnswerWithFlag = true},
                        new AvailableAnswer {AvailableAnswerId = 15, OptionId = 8},
                        new AvailableAnswer {AvailableAnswerId = 16, OptionId = 9}
                    }
                },
                new Question
                {
                    QuestionId = 4,
                    FormCode = idFormular,
                    SectionId = 2, //C
                    QuestionTypeId = QuestionTypeEnum.MultipleOptionsWithText,
                    QuestionText = "Ce mijloace de transport folosesti sa ajungi la birou? (se pot alege mai multe optiuni + text pe O singura optiune)",
                    AvailableAnswer = new List<AvailableAnswer>
                    {
                        new AvailableAnswer {AvailableAnswerId = 17, OptionId = 10, AnswerWithFlag = true},
                        new AvailableAnswer {AvailableAnswerId = 18, OptionId = 11},
                        new AvailableAnswer {AvailableAnswerId = 19, OptionId = 12},
                        new AvailableAnswer {AvailableAnswerId = 20, OptionId = 9}
                    }
                }
            );

            context.SaveChanges();
        }

        private static void SeedVersions(this VotingContext context)
        {
            if (context.FormVersions.Any())
                return;

            context.FormVersions.AddRange(
                 new FormVersion
                 {
                     FormCode = new Guid("9875bd98-d071-4c26-9bf3-13a93f8ac9d8"),
                     CurrentVersion = 1,
                     Name = "A",
                     Order = 1,
                     AvailabilityDate = DateTime.Now
                 },
                 new FormVersion
                 {
                     FormCode = new Guid("356e5695-dc48-428a-b7b5-22e1364263a0"),
                     CurrentVersion = 1 ,
                     Name = "B",
                     Order = 2,
                     AvailabilityDate = DateTime.Now
                 },
                 new FormVersion
                 {
                     FormCode = new Guid("c303646c-65ae-461b-bb05-c477500798ef"),
                     CurrentVersion = 1,
                     Name = "C",
                     Order = 3,
                     AvailabilityDate = DateTime.Now
                 }
             );

            context.SaveChanges();
        }

        private static void SeedONGs(this VotingContext context)
        {
            if (context.Ngos.Any())
                return;

            context.Ngos.AddRange(
                new Ngo
                {
                    NgoNameAbbreviation = "CAD",
                    NgoAdmins = new List<NgoAdmin>(),
                    IdOng = 1,
                    NgoName = "Control-Alt-Defeat",
                    Observers = new List<Observer>(),
                    Organizer = true
                }
            );

            context.SaveChanges();
        }

        private static void SeedObservatori(this VotingContext context)
        {
            if (context.Observer.Any())
                return;

            context.Observer.AddRange(
                new Observer
                {
                    NgoId = 1,
                    DeviceRegistrationDate = DateTime.Now,
                    IsPartOfTheTeam = true,
                    MobileDeviceId = "b3ac49ee526f887c",
                    ObserverId = 1,
                    NgoNavigationId = new Ngo(),
                    Ratings = new List<Rating>(),
                    TelephoneNumber = "0742131349",
                    Fullname = "Costan Ancuta Monica",
                    Pin = "31d3fe1ac88a474ed71e037e7908c7f448a8622a9cdd9a1635b0393b15bebbdb",
                    Answers = new List<Answer>(),
                    FormAnswers = new List<FormAnswer>()
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
