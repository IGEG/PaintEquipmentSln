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
            //Category[] categories = new Category[] {new Category
            //        {
            //            Name = "Электрические окрасочные аппараты",
            //            Desc = "Компания GRACO предлагает лучшее в отрасли окрасочное оборудование с электрическим приводом! Качество и надежность аппаратов признано во всем мире!Преимущество электрических окрасочных аппаратов заключается в их мобильности,небольших габаритах и высокой производительности!"
            //        }
            //        , new Category
            //        {
            //            Name = "Пневматические окрасочные аппараты",
            //            Desc = "Пневматические окрасочные аппараты GRACO зарекомендовали себя как высоконадежныое оборудование, способное работать в самых тяжелых условиях. Преимущество пневматических аппаратов заключается в их простоте обслуживания и безупречной надежности.Обладая большой производительностью данные апппарты отличаются высоким качеством нанесения покрытий."
            //        }
            //        , new Category
            //        {
            //            Name = "Штукатурные и шпаклевочные станции",
            //            Desc = "Штукатурные и шпаклевочные установки Graco - это верное решение для внутренних штукатурных и отделочных работ.Нанесение штукатурки машинным способом повышает производительность работ в 2 - 3 раза,улучшая при этом качество отделки!"
            //        }
            //        , new Category
            //        {
            //            Name = "Насосы",
            //            Desc = "Компания Graco выпускает широкую линейку насосов для перекачивания и дозирования жидкостей различной вязкости.  Мембранные насосы Graco husky позволяют перекачивать материалы малой вязкости с производительностью до 1т. в минуту. Насосы перистальтические серии EP позволяют дозировать химически активные материалы с высоким содержанием крупных частиц. Системы Chack-mate позволяют разгружать высоковязкие материалы из евротары за считанные минуты!"
            //        }};

            if (!context.Products.Any())
            {
                Product[] product = new Product[] {  new Product
                    {
                        Name = "Graco mark V",
                        URLadress ="graco-mark-v",
                        Description = "GRACO Mark V окрасочный аппарат грако марк 5- это признанный ЛИДЕР в окрасочном строительном оборудовании!!! Профессиональный окрасочный аппарат грако марк 5 предназначен для выполнения больших объемов работ по окраске высоковязких материалов и нанесения шпатлевок",
                        Img="~/Lib/Img/Mark V.png",
                        
                      
                    },
                    new Product
                    {
                        Name = "GRACO GX21",
                        URLadress ="graco-gx21",
                        Description = "GRACO GX21 окрасочный аппарат (грако GX21) - профессиональный компактный электрический аппарат безвоздушного распыления предназначен для окраски стен,потолков,полов,небольших металлоконструкций и сооружений.",
                        Img = "~/Lib/Img/GX21.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO Merkur 30:1",
                        URLadress ="graco-merkur-30-1",
                        Description = "GRACO Merkur 30:1 (грако меркур 30:1) -грако  окрасочный аппарат линейки Merkur c пневматическим соотношением 30 к 1.Сочетает в себе высокую производительность распыления и портативность, что позволяет использовать его в самых тяжелых условиях эксплуатации и распылять материалы с высоким уровнем сухого остатка.",
                        Img = "~/Lib/Img/Merkur.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO NXT Xtreme 70:1 (King)",
                        URLadress ="graco-NXT-xtreme-70-1",
                        Description = "RACO Xtreme NXT 70:1 X70DH3 окрасочный аппарат  (грако xtreme NXT)  - это признанный лидер безвоздушного окрашивания под высоким давлением с пневматическим приводом!",
                        Img = "~/Lib/Img/XtremeNXT.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO KING окрасочный аппарат",
                        URLadress ="graco-king",
                        Description = "GRACO KING (грако кинг) окрасочный аппарат - легендарный пневматический окрасочный аппарат от компании GRACO!!! Сочетание вековых традиций качества и современных технологий производства - GRACO KING!!! Более 60 лет опыта изготовления пневматических окрасочных аппаратов линейки KING!",
                        Img = "~/Lib/Img/king.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO T-MAX 506 шпаклевочная станция",
                        URLadress ="graco-t-max-506",
                        Description = "GRACO T-MAX 506 шпаклеовчная станция (грако t-max 506) - удобная и надежная штукатурная и шпаклевочная станция в одном аппарате! Возможность наносить практически все виды шпатлевок без подключения воздуха и распыление штукатурок и декоративных материалов при дополнительной подаче воздуха от компрессора.",
                        Img = "~/Lib/Img/t-max506.jpg",
                      
                    },
                    new Product
                    {
                        Name = "GRACO RTX 1500 установка",
                        URLadress ="graco-rtx-1500",
                        Description = "Установка GRACO RTX 1500 (грако RTX 1500) - удобный мобильный аппарат для нанесения декоративных материалов без повреждения даже самых крупных частиц.",
                        Img = "~/Lib/Img/rtx 1500.jpg",
                      
                    },
                    new Product
                    {
                        Name = "GRACO Check-Mate насос",
                        URLadress ="graco-check-mate",
                        Description = "GRACO Check-mate насос  (грако чек мэйт) - система разгрузки и перекачивания высоковязких материалов из стандартной евротары: бочка 20л,30л,60л,200л.",
                        Img = "~/Lib/Img/check-mate.jpg",
                        
                    },
                    new Product
                    {
                        Name = "GRACO Monark насос",
                        URLadress ="graco-monark",
                        Description = "GRACO Monark насос  (грако монарк) - пневматический перекачивающий насос Graco Monark выпускается с различными соотношениями 1,5: 1, 2:1, 5:1.",
                        Img = "~/Lib/Img/monark.jpg",
                      
                    }
                };
                //foreach (Product p in product)
                //{
                //    p.CategoryId = 1;
                //}
                context.Products.AddRange(product);
                context.SaveChanges();
            }
        }
    }
}

