using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PaintEquipment.Models
{

    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Graco mark V",
                        Description = "GRACO Mark V окрасочный аппарат грако марк 5- это признанный ЛИДЕР в окрасочном строительном оборудовании!!! Профессиональный окрасочный аппарат грако марк 5 предназначен для выполнения больших объемов работ по окраске высоковязких материалов и нанесения шпатлевок",
                        Category = "Электрические окрасочные аппараты",
                        Price = 520m
                    },
                    new Product
                    {
                        Name = "GRACO GX21",
                        Description = "GRACO GX21 окрасочный аппарат (грако GX21) - профессиональный компактный электрический аппарат безвоздушного распыления предназначен для окраски стен,потолков,полов,небольших металлоконструкций и сооружений.",
                        Category = "Электрические окрасочные аппараты",
                        Price = 950m
                    },
                    new Product
                    {
                        Name = "GRACO Merkur 30:1",
                        Description = "GRACO Merkur 30:1 (грако меркур 30:1) -грако  окрасочный аппарат линейки Merkur c пневматическим соотношением 30 к 1.Сочетает в себе высокую производительность распыления и портативность, что позволяет использовать его в самых тяжелых условиях эксплуатации и распылять материалы с высоким уровнем сухого остатка.",
                        Category = "Пневматические окрасочные аппараты",
                        Price = 290m
                    },
                    new Product
                    {
                        Name = "GRACO NXT Xtreme 70:1 (King)",
                        Description = "RACO Xtreme NXT 70:1 X70DH3 окрасочный аппарат  (грако xtreme NXT)  - это признанный лидер безвоздушного окрашивания под высоким давлением с пневматическим приводом!",
                        Category = "Пневматические окрасочные аппараты",
                        Price = 490m
                    },
                    new Product
                    {
                        Name = "GRACO KING окрасочный аппарат",
                        Description = "GRACO KING (грако кинг) окрасочный аппарат - легендарный пневматический окрасочный аппарат от компании GRACO!!! Сочетание вековых традиций качества и современных технологий производства - GRACO KING!!! Более 60 лет опыта изготовления пневматических окрасочных аппаратов линейки KING!",
                        Category = "Пневматические окрасочные аппараты",
                        Price = 490m
                    },
                    new Product
                    {
                        Name = "GRACO T-MAX 506 шпаклевочная станция",
                        Description = "GRACO T-MAX 506 шпаклеовчная станция (грако t-max 506) - удобная и надежная штукатурная и шпаклевочная станция в одном аппарате! Возможность наносить практически все виды шпатлевок без подключения воздуха и распыление штукатурок и декоративных материалов при дополнительной подаче воздуха от компрессора.",
                        Category = "Штукатурные и шпатлевочные станции",
                        Price = 650m
                    },
                    new Product
                    {
                        Name = "GRACO RTX 1500 установка",
                        Description = "Установка GRACO RTX 1500 (грако RTX 1500) - удобный мобильный аппарат для нанесения декоративных материалов без повреждения даже самых крупных частиц.",
                        Category = "Штукатурные и шпатлевочные станции",
                        Price = 590m
                    },
                    new Product
                    {
                        Name = "GRACO Check-Mate насос",
                        Description = "GRACO Check-mate насос  (грако чек мэйт) - система разгрузки и перекачивания высоковязких материалов из стандартной евротары: бочка 20л,30л,60л,200л.",
                        Category = "Насосы",
                        Price = 1250m
                    },
                    new Product
                    {
                        Name = "GRACO Monark насос",
                        Description = "GRACO Monark насос  (грако монарк) - пневматический перекачивающий насос Graco Monark выпускается с различными соотношениями 1,5: 1, 2:1, 5:1.",
                        Category = "Насосы",
                        Price = 550m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}