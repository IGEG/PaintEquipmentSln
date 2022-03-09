﻿using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

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
            Category[] categories = new Category[] {new Category
                    {
                        Name = "Электрические окрасочные аппараты",
                        Desc = "Компания GRACO предлагает лучшее в отрасли окрасочное оборудование с электрическим приводом! Качество и надежность аппаратов признано во всем мире!Преимущество электрических окрасочных аппаратов заключается в их мобильности,небольших габаритах и высокой производительности!"
                    }
                    , new Category
                    {
                        Name = "Пневматические окрасочные аппараты",
                        Desc = "Пневматические окрасочные аппараты GRACO зарекомендовали себя как высоконадежныое оборудование, способное работать в самых тяжелых условиях. Преимущество пневматических аппаратов заключается в их простоте обслуживания и безупречной надежности.Обладая большой производительностью данные апппарты отличаются высоким качеством нанесения покрытий."
                    }
                    , new Category
                    {
                        Name = "Штукатурные и шпаклевочные станции",
                        Desc = "Штукатурные и шпаклевочные установки Graco - это верное решение для внутренних штукатурных и отделочных работ.Нанесение штукатурки машинным способом повышает производительность работ в 2 - 3 раза,улучшая при этом качество отделки!"
                    }
                    , new Category
                    {
                        Name = "Насосы",
                        Desc = "Компания Graco выпускает широкую линейку насосов для перекачивания и дозирования жидкостей различной вязкости.  Мембранные насосы Graco husky позволяют перекачивать материалы малой вязкости с производительностью до 1т. в минуту. Насосы перистальтические серии EP позволяют дозировать химически активные материалы с высоким содержанием крупных частиц. Системы Chack-mate позволяют разгружать высоковязкие материалы из евротары за считанные минуты!"
                    }};

            if (!context.Products.Any())
            {
                Product[] product = new Product[] {  new Product
                    {
                        Name = "Graco mark V",
                        URLadress ="graco-mark-v",
                        SmallDescription = "GRACO Mark V окрасочный аппарат грако марк 5- это признанный ЛИДЕР в окрасочном строительном оборудовании!!! Профессиональный окрасочный аппарат грако марк 5 предназначен для выполнения больших объемов работ по окраске высоковязких материалов и нанесения шпатлевок",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м. вертлюг, окрасочный пистолет-распылитель,  сопла, TSL 0.25, инструкции по эксплуатации, разводные ключи, шарики из нерж. стали и керамики.",
                        Img ="~/Lib/Img/Mark V.png",
                        
                      
                    },
                    new Product
                    {
                        Name = "GRACO GX21",
                        URLadress ="graco-gx21",
                        SmallDescription = "GRACO GX21 окрасочный аппарат (грако GX21) - профессиональный компактный электрический аппарат безвоздушного распыления предназначен для окраски стен,потолков,полов,небольших металлоконструкций и сооружений.",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/GX21.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO Merkur 30:1",
                        URLadress ="graco-merkur-30-1",
                        SmallDescription = "GRACO Merkur 30:1 (грако меркур 30:1) -грако  окрасочный аппарат линейки Merkur c пневматическим соотношением 30 к 1.Сочетает в себе высокую производительность распыления и портативность, что позволяет использовать его в самых тяжелых условиях эксплуатации и распылять материалы с высоким уровнем сухого остатка.",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/Merkur.jpg",
                       
                    },
                    new Product
                    {
                        Name = "NXT Xtreme 70:1",
                        URLadress ="graco-NXT-xtreme-70-1",
                        SmallDescription = "RACO Xtreme NXT 70:1 X70DH3 окрасочный аппарат  (грако xtreme NXT)  - это признанный лидер безвоздушного окрашивания под высоким давлением с пневматическим приводом!",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/XtremeNXT.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO KING ",
                        URLadress ="graco-king",
                        SmallDescription = "GRACO KING (грако кинг) окрасочный аппарат - легендарный пневматический окрасочный аппарат от компании GRACO!!! Сочетание вековых традиций качества и современных технологий производства - GRACO KING!!! Более 60 лет опыта изготовления пневматических окрасочных аппаратов линейки KING!",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/king.jpg",
                       
                    },
                    new Product
                    {
                        Name = "GRACO T-MAX 506",
                        URLadress ="graco-t-max-506",
                        SmallDescription = "GRACO T-MAX 506 шпаклеовчная станция (грако t-max 506) - удобная и надежная штукатурная и шпаклевочная станция в одном аппарате! Возможность наносить практически все виды шпатлевок без подключения воздуха и распыление штукатурок и декоративных материалов при дополнительной подаче воздуха от компрессора.",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/t-max506.jpg",
                      
                    },
                    new Product
                    {
                        Name = "GRACO RTX 1500 ",
                        URLadress ="graco-rtx-1500",
                        SmallDescription = "Установка GRACO RTX 1500 (грако RTX 1500) - удобный мобильный аппарат для нанесения декоративных материалов без повреждения даже самых крупных частиц.",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/rtx 1500.jpg",
                      
                    },
                    new Product
                    {
                        Name = "GRACO Check-Mate",
                        URLadress ="graco-check-mate",
                        SmallDescription = "GRACO Check-mate насос  (грако чек мэйт) - система разгрузки и перекачивания высоковязких материалов из стандартной евротары: бочка 20л,30л,60л,200л.",
                        BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/check-mate.jpg",
                        
                    },
                    new Product
                    {
                        Name = "GRACO Monark",
                        URLadress ="graco-monark",
                        SmallDescription = "GRACO Monark насос  (грако монарк) - пневматический перекачивающий насос Graco Monark выпускается с различными соотношениями 1,5: 1, 2:1, 5:1.",
                       BigDescription ="Преимущество  Graco Mark V (грако марк 5)   - это: - Привод AdvantageDrive.- Управление smart control 3.- Фильтры EasyOut. - Съемный насос Endurance. Распыляемы материалы GRACO MARK V окрасочный аппарат грако марк 5: -шпатлевки - огнезащитные краски - разбухающие огнезащитные материалы-акриловые краски- водоэмульсионные краски- эпоксидный смолы- краски на основе растворителейОкрасочный аппарат GRACO Mark V(грако марк 5) поставляется полностью укомплектованным и готовым к работе! Окрасочный аппарат Mark V для ббезвоздушного распыления красок, лаков, эмалей и др. видов жидкостей -это самым популярным метод нанесения материалов. Неоспоримые преимущество безвоздушного окрасочного аппарата сподвигли компанию GRACO в создании аппарата безвоздушного распыления ,который совместил бы в себе все передовые технологии GRACOGRACO MARK V окрасочный аппарат - это абсолютный лидер среди окрасочных аппаратов безвоздушного распыления с электрическим приводом , он способен распылять лакокрасочные материалы с высокой производительностью.Mark V способен работать с материалами с высоким содержанием сухого остатка .Широкая популярность окрасочного аппарата Graco MARK V позволяет легко и просто производить его ремонт и обслуживание в любой географической точке и иметь широкую базу запасных частей и комплектующих . Все окрасочное оборудование GRACO прошло проверку временем и продолжает эксплуатироваться в различных географических точках и при разнообразных климатических условиях , внедряясь во все области экономики .",
                        MaxVolume="4.3 л/минуту",
                        MaxPressure="227 бар",
                        MaxWeight="68 кг.",
                        Kit="шланг высокого давления Blue Max 15 метров,гибкий шланг Blue Max 0,9 м.",
                        Img = "~/Lib/Img/monark.jpg",
                      
                    }
                };
                Random rand=new Random();
                foreach (Product p in product)
                {
                    
                    p.CategoryId = rand.Next(1,2);
                   
                }

                context.Products.AddRange(product);
                context.SaveChanges();
            }
        }
    }
}

