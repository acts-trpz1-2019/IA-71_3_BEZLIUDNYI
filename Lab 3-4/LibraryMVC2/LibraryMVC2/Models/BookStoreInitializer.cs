using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LibraryMVC2.Models
{
    public class BookStoreInitializer : DropCreateDatabaseAlways<BookStoreContext>
    {
        protected override void Seed(BookStoreContext db)
        {

            SubscriptionType st1 = new SubscriptionType
            {
                Name = "Бесплатно",
                Price = 0,
                Level = 1,
                Description = "Базовый каталог книг, доступный для каждого посетителя."
            };

            SubscriptionType st2 = new SubscriptionType
            {
                Name = "Обычный",
                Price = 150,
                Level = 2,
                Description = "За этой подпиской вы получаете доступ до множества книг и аудиокниг мировых классиков."
            };

            SubscriptionType st3 = new SubscriptionType
            {
                Name = "Премиум",
                Price = 300,
                Level = 3,
                Description = "Полный доступ до всех книг библиотеки." +
                " Получите доступ до самых новых и популярных книг и аудиокниг за этой подпиской."
            };

            db.SubscriptionTypes.AddRange(new List<SubscriptionType>(){ st1, st2, st3 });

            Genre g1 = new Genre
            {
                Name = "Детективы",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\detectives.png"
            };

            Genre g2 = new Genre
            {
                Name = "Фантастика",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\fantasy.png"
            };

            Genre g3 = new Genre
            {
                Name = "Книги о программировании",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\programming.png"
            };

            Genre g4 = new Genre
            {
                Name = "Научная фантастика",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\science_fiction.png"
            };

            Genre g5 = new Genre
            {
                Name = "Ужасы",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\horrors.png"
            };

            Genre g6 = new Genre
            {
                Name = "Повести",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\narratives.png"
            };

            Genre g7 = new Genre
            {
                Name = "Приключенческая литература",
                CoverFilePath = Properties.Settings.Default.GenreCoveringsFilePath + @"\adventures.png"
            };

            db.Genres.AddRange(new List<Genre>() { g1, g2, g3, g4, g5, g6, g7 });

            TextBook b1 = new TextBook
            {
                BookName = "Я, Робот",
                Author = "А. Азимов",
                Genres = new List<Genre>() { g2, g4 },
                SubscriptionType = st2,
                Pages = 100,
                RateCount = 130,
                RateSum = 500,
                ContentFilePath = @"\А._Азимов_-_Я,_робот.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\А._Азимов_-_Я,_робот.jpg"
            };

            TextBook b2 = new TextBook
            {
                BookName = "Собака Баскервилей",
                Author = "А. К. Дойл",
                Genres = new List<Genre>() { g1 },
                SubscriptionType = st1,
                Pages = 250,
                ContentFilePath = @"\А._К._Дойл_-_Собака_Баскервилей.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\А._К._Дойл_-_Собака_Баскервилей.jpg"
            };

            TextBook b3 = new TextBook
            {
                BookName = "Шерлок Холмс на сцене",
                Author = "А. К. Дойл",
                Genres = new List<Genre>() { g1 },
                SubscriptionType = st1,
                Pages = 400,
                ContentFilePath = @"\А._К._Дойл_-_Шерлок_Холмс_на_сцене.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\А._К._Дойл_-_Шерлок_Холмс_на_сцене.jpg"
            };

            TextBook b4 = new TextBook
            {
                BookName = "C# 4.0.",
                Author = "Г. Шилдт",
                Genres = new List<Genre>() { g3 },
                SubscriptionType = st3,
                Pages = 950,
                ContentFilePath = @"\Г._Шилдт_-_Csharp_4.0.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Г._Шилдт_-_Csharp_4.0.jpg"
            };

            TextBook b5 = new TextBook
            {
                BookName = "Java 8",
                Author = "Г. Шилдт",
                Genres = new List<Genre>() { g3 },
                SubscriptionType = st3,
                Pages = 1300,
                ContentFilePath = @"\Г._Шилдт_-_Java_8.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Г._Шилдт_-_Java_8.jpg"
            };

            TextBook b6 = new TextBook
            {
                BookName = "Изучаем C#",
                Author = "Дж. Грин",
                Genres = new List<Genre>() { g3 },
                SubscriptionType = st2,
                Pages = 600,
                ContentFilePath = @"\Дж._Грин_-_Изучаем_Сsharp.pdf",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Дж._Грин_-_Изучаем_Сsharp.jpg"
            };

            AudioBook a1 = new AudioBook
            {
                BookName = "Ночь перед рождеством",
                Author = "Н. Гоголь",
                Genres = new List<Genre>() { g6 },
                SubscriptionType = st1,
                ReadingTime = 6206,
                ContentFilePath = @"\Н._Гоголь_-_Ночь_перед_рождеством.mp3",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Н._Гоголь_-_Ночь_перед_рождеством.jpg"
            };

            //AudioBook a2 = new AudioBook
            //{
            //    BookName = "Алхимик",
            //    Author = "П. Коэльо",
            //    Genres = new List<Genre>() { g7 },
            //    SubscriptionType = st2,
            //    ReadingTime = 13755,
            //    ContentFilePath = @"\П._Коэльо_-_Алхимик.mp3",
            //    CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\П._Коэльо_-_Алхимик.jpg"
            //};

            //AudioBook a3 = new AudioBook
            //{
            //    BookName = "Иллюзии",
            //    Author = "Р. Бах",
            //    Genres = new List<Genre>() { g2, g7 },
            //    SubscriptionType = st2,
            //    ReadingTime = 12142,
            //    ContentFilePath = @"\Р._Бах_-_Иллюзии.mp3",
            //    CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Р._Бах_-_Иллюзии.jpg"
            //};

            AudioBook a4 = new AudioBook
            {
                BookName = "Убийца",
                Author = "Р. Брэдбери",
                Genres = new List<Genre>() { g2 },
                SubscriptionType = st1,
                ReadingTime = 1198,
                ContentFilePath = @"\Р._Брэдбери_-_Убийца.mp3",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Р._Брэдбери_-_Убийца.jpg"
            };

            AudioBook a5 = new AudioBook
            {
                BookName = "Поле Боя",
                Author = "С. Кинг",
                Genres = new List<Genre>() { g5 },
                SubscriptionType = st1,
                ReadingTime = 1351,
                ContentFilePath = @"\С._Кинг_-_Поле_Боя.mp3",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\С._Кинг_-_Поле_Боя.jpg"
            };

            AudioBook a6 = new AudioBook
            {
                BookName = "Человек который любил цветы",
                Author = "С. Кинг",
                Genres = new List<Genre>() { g5 },
                SubscriptionType = st1,
                ReadingTime = 1027,
                ContentFilePath = @"\С._Кинг_-_Человек_который_любил_цветы.mp3",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\С._Кинг_-_Человек_который_любил_цветы.jpg"
            };

            AudioBook a7 = new AudioBook
            {
                BookName = "Из глубин памяти",
                Author = "Ф. Дик",
                Genres = new List<Genre>() { g2, g4 },
                SubscriptionType = st2,
                ReadingTime = 2788,
                ContentFilePath = @"\Ф._Дик_-_Из_глубин_памяти.mp3",
                CoverFilePath = Properties.Settings.Default.BookCoveringsFilePath + @"\Ф._Дик_-_Из_глубин_памяти.jpg"
            };

            db.TextBooks.AddRange(new List<TextBook>() { b1, b2, b3, b4, b5, b6 });
            db.AudioBooks.AddRange(new List<AudioBook>() { a1, a4, a5, a6, a7 });

            TitledInfo t1 = new TitledInfo
            {
                Title = "Новинки, классика и бестселлеры",
                InfoBlocks = new List<string>
                        {
                            "LitNet — самая большая библиотека электронных книг и аудиокниг на русском языке по подписке. " +
                            "Более 150 000 произведений всех жанров в мобильном приложении и на сайте: " +
                            "детективы, фантастика, фэнтези, любовные романы, книги по бизнесу, психологии, для детей, современная и классическая литература. " +
                            "Новинки поступают каждый день — как в книжном магазине, только удобнее. " +
                            "Некоторые электронные книги в библиотеке бесплатны, их можно читать без подписки. " +
                            "Это классические произведения из школьной программы и современная литература начинающих авторов."
                        }
            };

            TitledInfo t2 = new TitledInfo
            {
                Title = "Любые книги по подписке",
                InfoBlocks = new List<string>
                        {
                            "Все произведения входят в подписки — стандартную или премиум. " +
                            "При регистрации каждый читатель получает в подарок три дня безлимитного чтения. А дальше — выбор за вами. " +
                            "Оформите премиум, чтобы получить полный доступ к онлайн-библиотеке, или стандарт, чтобы читать только бестселлеры и классику. " +
                            "Можно выбрать подходящий срок подписки: на месяц, три месяца или год. " +
                            "Больше не нужно покупать по одной!Если вам не понравилась книга, вы можете ее бросить без сожаления о потраченных деньгах. " +
                            "Безлимитный доступ к библиотеке позволяет тут же выбрать новую."
                        }
            };

            TitledInfo t3 = new TitledInfo
            {
                Title = "Рекомендуем хорошие книги",
                InfoBlocks = new List<string>
                        {
                            "Подборки в LitNet — помощники в выборе подходящих произведений по настроению, теме, сезону, популярности или экспертной оценке. " +
                            "Мы отбираем лучшие книги и аудиокниги в нашей электронной библиотеке, чтобы вам не приходилось тратить время на поиски. " +
                            "Рассказываем о лауреатах книжных премий и победителях конкурсов. " +
                            "Подсказываем, что модно, а что малоизвестно, что почитать в отпуске, зимой и летом, в дороге и дома. " +
                            "Большой выбор хороших книг — в разделе «Что читать» на сайте и в приложении."
                        }
            };
            //-------------------------------------------
            TitledInfo t4 = new TitledInfo
            {
                InfoBlocks = new List<string>
                            {
                                "Каждый день в библиотеку LitNet поступают новинки. " +
                                "Это книги и аудиокниги всех жанров: классика и современная литература, переиздания и новые произведения популярных авторов. " +
                                "Наш каталог — это ветвистое дерево. Детективы, любовные романы, фэнтези, фантастика, научно-популярные и бизнес-книги — самые популярные жанры. " +
                                "Каждый раздел содержит в себе несколько категорий, которые распределяют произведения по темам и уточняют поиск нужных книг."
                            }
            };

            TitledInfo t5 = new TitledInfo
            {
                InfoBlocks = new List<string>
                            {
                                "В разделе современной прозы вы встретите Несбё и Акунина, Барнса и Токареву, " +
                                "Пелевина и Сорокина — весь спектр писателей, которые создают литературу сегодня. " +
                                "Шедевры Достоевского, Толстого, Бунина и Куприна — в разделе классической литературы. " +
                                "Многие из классических романов и рассказов можно читать бесплатно."
                            }
            };

            TitledInfo t6 = new TitledInfo
            {
                InfoBlocks = new List<string>
                            {
                                "Если у вас есть вопросы к самому себе, если вы хотите измениться или наладить отношения с близкими " +
                                "— обратитесь к книгам по психологии. Тысячи читателей ежедневно находят в них информацию, " +
                                "которая помогает улучшить качество жизни. Читать эти электронные книги удобно в любой ситуации, " +
                                "отмечая полезные мысли и возвращаясь к главному в своих заметках."
                            }
            };

            TitledInfo t7 = new TitledInfo
            {
                InfoBlocks = new List<string>
                            {
                                "О том, как привести дела в порядок, все успевать, запоминать важное, презентовать и продавать, " +
                                "планировать и считать, рассказывают книги лучших российских издательств деловой литературы: " +
                                "«Манн, Иванов и Фербер», «Альпина Паблишер», «Эксмо», «Олимп - Бизнес», «Питер». " +
                                "Эти книги помогают улучшить личную эффективность и работу всего коллектива."
                            }
            };

            TitledInfo t8 = new TitledInfo
            {
                InfoBlocks = new List<string>
                            {
                                "Что почитать, чтобы развлечься? Заходите в раздел детективов, любовных романов, фантастики и фэнтези. " +
                                "Там вы найдете новинки и классику любимых жанров. В MyBook каждый сможет выбрать книгу по душе, даже ребенок. " +
                                "Сказки, повести, обучающие пособия и поучительные рассказы подойдут для чтения в кругу семьи. " +
                                "Вы можете читать и слушать книги онлайн на сайте или в мобильном приложении даже без интернета."
                            }
            };

            db.TitledInfoSet.AddRange(new List<TitledInfo> { t1, t2, t3, t4, t5, t6, t7, t8 });

           
            Description d1 = new Description
            {
                TargetName = "LibNet Description",
                Title = "О библиотеке LibNet",
                TitledInfoList = new List<TitledInfo> { t1, t2, t3 }
            };

            Description d2 = new Description
            {
                TargetName = "Book Catalog Description",
                Title = "О каталоге книг",
                TitledInfoList = new List<TitledInfo> { t4, t5, t6, t7 }
            };

            db.Descriptions.AddRange(new List<Description> { d1, d2 });

            base.Seed(db);
        }
    }
}