using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Contracts.Movies.Requests;
using VHub.Media.Common.Enums;
using Xunit;

namespace VHub.Media.Tests.IntegrationTests.Movies;

public class MoviesTestCases
{
    public static TheoryData<GetMoviesByFilterRequest, MovieDto[]> TestCases => new()
    {
        {
            new GetMoviesByFilterRequest()
            {
                Id = "68fbdb2388052130a64d83f8",
            },
            [
                new MovieDto
                {
                    Id = "68fbdb2388052130a64d83f8",
                    Title = "Дюна",
                    OriginalTitle = "Dune: Part One",
                    Countries = ["США", "Канада", "Венгрия"],
                    ReleaseDate = new DateOnly(2021, 9, 3),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Drama, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                }
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                Title = "паук",
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23476323981a7a3f7e",
                    Title = "Человек-паук",
                    OriginalTitle = "Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2002, 4, 30),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238f4e456424d944fb",
                    Title = "Новый Человек-паук",
                    OriginalTitle = "The Amazing Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2012, 6, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238b1875ba2516138e",
                    Title = "Человек-паук: Нет пути домой",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 12, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure, Genre.Fantasy],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                Title = "Strange",
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23abd59fb38cc6f7c9",
                    Title = "Доктор Стрэндж",
                    OriginalTitle = "Doctor Strange",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 10, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb2319dfa109a86bcc7e",
                    Title = "Очень странные дела",
                    OriginalTitle = "Stranger Things",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 7, 11),
                    Genres =
                    [
                        Genre.Horror, Genre.Fantastic, Genre.Fantasy, Genre.Thriller, Genre.Drama, Genre.Detective
                    ],
                    AgeRating = AgeRating.SixteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                Title = "Фильм",
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                Countries = ["Китай"],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb238b98ac1e52d6dbe2",
                    Title = "Операция «Панда»",
                    OriginalTitle = "Xiong mao ji hua",
                    Countries = ["Китай"],
                    ReleaseDate = new DateOnly(2021, 9, 3),
                    Genres = [Genre.Comedy, Genre.ActionMovie],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb235d80b28c59945b15",
                    Title = "Кунг-фу Вин Чунь",
                    OriginalTitle = "Gong fu yong chun",
                    Countries = ["Китай", "Гонконг"],
                    ReleaseDate = new DateOnly(2010, 10, 12),
                    Genres = [Genre.ActionMovie, Genre.Melodrama, Genre.Comedy],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Countries = ["Великобритания", "СССР", "Польша"],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb235b83ee0d81498e07",
                    Title = "Гарри Поттер и Принц-полукровка",
                    OriginalTitle = "Harry Potter and the Half-Blood Prince",
                    Countries = ["Великобритания", "США"],
                    ReleaseDate = new DateOnly(2009, 7, 6),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Family],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentalGuidanceSuggested,
                    IsSerial = false,
                    Platforms = null,
                },
                new()
                {
                    Id = "68fbdb23edd26052617d2700",
                    Title = "Операция «Ы» и другие приключения Шурика",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1965, 7, 23),
                    Genres = [Genre.Comedy, Genre.Melodrama, Genre.Crime],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new()
                {
                    Id = "68fbdb23c0a252a0ae73e1f5",
                    Title = "Бременские музыканты",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1973, 5, 1),
                    Genres = [Genre.Cartoon, Genre.Children, Genre.Musical, Genre.Fantasy],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23fbda316d99eb8c15",
                    Title = "Ведьмак",
                    OriginalTitle = "The Witcher",
                    Countries = ["США", "Польша"],
                    ReleaseDate = new DateOnly(2019, 12, 20),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Drama, Genre.Horror],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                Countries = ["Турция", "Новая Зеландия", "Австралия"],
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                Genres = [Genre.Melodrama],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23edd26052617d2700",
                    Title = "Операция «Ы» и другие приключения Шурика",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1965, 7, 23),
                    Genres = [Genre.Comedy, Genre.Melodrama, Genre.Crime],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb235d80b28c59945b15",
                    Title = "Кунг-фу Вин Чунь",
                    OriginalTitle = "Gong fu yong chun",
                    Countries = ["Китай", "Гонконг"],
                    ReleaseDate = new DateOnly(2010, 10, 12),
                    Genres = [Genre.ActionMovie, Genre.Melodrama, Genre.Comedy],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23ee49893b43c90958",
                    Title = "Анатомия страсти",
                    OriginalTitle = "Grey's Anatomy",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2005, 3, 27),
                    Genres = [Genre.Drama, Genre.Melodrama],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["АМС"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Genres = [Genre.Detective, Genre.Family],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb2319dfa109a86bcc7e",
                    Title = "Очень странные дела",
                    OriginalTitle = "Stranger Things",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 7, 11),
                    Genres =
                    [
                        Genre.Horror, Genre.Fantastic, Genre.Fantasy, Genre.Thriller, Genre.Drama, Genre.Detective
                    ],
                    AgeRating = AgeRating.SixteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbeb892282f88bfcea5d5b",
                    Title = "Хрустальный",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2021, 4, 20),
                    Genres = [Genre.Detective, Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["KION"],
                },
                new MovieDto
                {
                    Id = "68fbeb89929abb26716afb50",
                    Title = "Фишер",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 2, 8),
                    Genres = [Genre.Detective, Genre.Drama, Genre.Crime, Genre.Thriller],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["more.tv", "Wink"],
                },
                new MovieDto
                {
                    Id = "68fbdb235b83ee0d81498e07",
                    Title = "Гарри Поттер и Принц-полукровка",
                    OriginalTitle = "Harry Potter and the Half-Blood Prince",
                    Countries = ["Великобритания", "США"],
                    ReleaseDate = new DateOnly(2009, 7, 6),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Family],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentalGuidanceSuggested,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbeb89b4bee23480a52ca6",
                    Title = "Время приключений",
                    OriginalTitle = "Adventure Time with Finn & Jake",
                    Countries = ["США", "Гонконг", "Япония", "Южная Корея", "Германия"],
                    ReleaseDate = new DateOnly(2010, 4, 5),
                    Genres =
                    [
                        Genre.Cartoon, Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Comedy, Genre.Adventure,
                        Genre.Family
                    ],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                Genres = [Genre.Documentary, Genre.Military, Genre.Historical, Genre.Sports],
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                Platforms = ["Netflix"],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb2319dfa109a86bcc7e",
                    Title = "Очень странные дела",
                    OriginalTitle = "Stranger Things",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 7, 11),
                    Genres =
                    [
                        Genre.Horror, Genre.Fantastic, Genre.Fantasy, Genre.Thriller, Genre.Drama, Genre.Detective
                    ],
                    AgeRating = AgeRating.SixteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb23fbda316d99eb8c15",
                    Title = "Ведьмак",
                    OriginalTitle = "The Witcher",
                    Countries = ["США", "Польша"],
                    ReleaseDate = new DateOnly(2019, 12, 20),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Drama, Genre.Horror],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb23489bc1028003429d",
                    Title = "Элита",
                    OriginalTitle = "Élite",
                    Countries = ["Испания"],
                    ReleaseDate = new DateOnly(2018, 10, 5),
                    Genres = [Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Platforms = ["KION", "Wink", "Start", "Disney+"],
            },
            [
                new MovieDto
                {
                    Id = "68fbeb892282f88bfcea5d5b",
                    Title = "Хрустальный",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2021, 4, 20),
                    Genres = [Genre.Detective, Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["KION"],
                },
                new MovieDto
                {
                    Id = "68fbeb89ceecaae7efa9902c",
                    Title = "Слово пацана. Кровь на асфальте ",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 11, 9),
                    Genres = [Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Wink", "START"],
                },
                new MovieDto
                {
                    Id = "68fbeb89929abb26716afb50",
                    Title = "Фишер",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 2, 8),
                    Genres = [Genre.Detective, Genre.Drama, Genre.Crime, Genre.Thriller],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["more.tv", "Wink"],
                },
                new MovieDto
                {
                    Id = "68fbdb232ad5e3332c3179ac",
                    Title = "Локи",
                    OriginalTitle = "Loki",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 7, 9),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
                new MovieDto
                {
                    Id = "68fbeb89a47c72e3b919670f",
                    Title = "Мандалорец",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2019, 11, 12),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Platforms = ["Premier, Кинопоиск"],
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                AgeRating = AgeRating.SixPlus,
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23edd26052617d2700",
                    Title = "Операция «Ы» и другие приключения Шурика",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1965, 7, 23),
                    Genres = [Genre.Comedy, Genre.Melodrama, Genre.Crime],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23c0a252a0ae73e1f5",
                    Title = "Бременские музыканты",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1973, 5, 1),
                    Genres = [Genre.Cartoon, Genre.Children, Genre.Musical, Genre.Fantasy],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                AgeRating = AgeRating.ZeroPlus,
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23476323981a7a3f7e",
                    Title = "Человек-паук",
                    OriginalTitle = "Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2002, 4, 30),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238f4e456424d944fb",
                    Title = "Новый Человек-паук",
                    OriginalTitle = "The Amazing Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2012, 6, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238b1875ba2516138e",
                    Title = "Человек-паук: Нет пути домой",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 12, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure, Genre.Fantasy],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23abd59fb38cc6f7c9",
                    Title = "Доктор Стрэндж",
                    OriginalTitle = "Doctor Strange",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 10, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb2388052130a64d83f8",
                    Title = "Дюна",
                    OriginalTitle = "Dune: Part One",
                    Countries = ["США", "Канада", "Венгрия"],
                    ReleaseDate = new DateOnly(2021, 9, 3),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Drama, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                RatingMpaa = RatingMpaa.GeneralAudiences,
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                IsSerial = false,
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23476323981a7a3f7e",
                    Title = "Человек-паук",
                    OriginalTitle = "Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2002, 4, 30),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238f4e456424d944fb",
                    Title = "Новый Человек-паук",
                    OriginalTitle = "The Amazing Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2012, 6, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238b1875ba2516138e",
                    Title = "Человек-паук: Нет пути домой",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 12, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure, Genre.Fantasy],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23abd59fb38cc6f7c9",
                    Title = "Доктор Стрэндж",
                    OriginalTitle = "Doctor Strange",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 10, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb2388052130a64d83f8",
                    Title = "Дюна",
                    OriginalTitle = "Dune: Part One",
                    Countries = ["США", "Канада", "Венгрия"],
                    ReleaseDate = new DateOnly(2021, 9, 3),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Drama, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb236ca5db5246e81476",
                    Title = "Поворот не туда 4: Кровавое начало",
                    OriginalTitle = "Wrong Turn 4: Bloody Beginnings",
                    Countries = ["США", "Германия", "Канада"],
                    ReleaseDate = new DateOnly(2011, 10, 25),
                    Genres = [Genre.Horror, Genre.Adventure],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = RatingMpaa.Restricted,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb238b98ac1e52d6dbe2",
                    Title = "Операция «Панда»",
                    OriginalTitle = "Xiong mao ji hua",
                    Countries = ["Китай"],
                    ReleaseDate = new DateOnly(2021, 9, 3),
                    Genres = [Genre.Comedy, Genre.ActionMovie],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb235b83ee0d81498e07",
                    Title = "Гарри Поттер и Принц-полукровка",
                    OriginalTitle = "Harry Potter and the Half-Blood Prince",
                    Countries = ["Великобритания", "США"],
                    ReleaseDate = new DateOnly(2009, 7, 6),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Family],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentalGuidanceSuggested,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23edd26052617d2700",
                    Title = "Операция «Ы» и другие приключения Шурика",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1965, 7, 23),
                    Genres = [Genre.Comedy, Genre.Melodrama, Genre.Crime],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23c0a252a0ae73e1f5",
                    Title = "Бременские музыканты",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1973, 5, 1),
                    Genres = [Genre.Cartoon, Genre.Children, Genre.Musical, Genre.Fantasy],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb235d80b28c59945b15",
                    Title = "Кунг-фу Вин Чунь",
                    OriginalTitle = "Gong fu yong chun",
                    Countries = ["Китай", "Гонконг"],
                    ReleaseDate = new DateOnly(2010, 10, 12),
                    Genres = [Genre.ActionMovie, Genre.Melodrama, Genre.Comedy],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                IsSerial = true,
            },
            [
                new MovieDto
                {
                    Id = "68fbdb2319dfa109a86bcc7e",
                    Title = "Очень странные дела",
                    OriginalTitle = "Stranger Things",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2016, 7, 11),
                    Genres =
                    [
                        Genre.Horror, Genre.Fantastic, Genre.Fantasy, Genre.Thriller, Genre.Drama, Genre.Detective
                    ],
                    AgeRating = AgeRating.SixteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb2381b22fd920945711",
                    Title = "Мажор",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2014, 12, 15),
                    Genres = [Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23fbda316d99eb8c15",
                    Title = "Ведьмак",
                    OriginalTitle = "The Witcher",
                    Countries = ["США", "Польша"],
                    ReleaseDate = new DateOnly(2019, 12, 20),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Drama, Genre.Horror],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb23e99f47f725ec7a7f",
                    Title = "Реальные пацаны",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2010, 11, 8),
                    Genres = [Genre.Comedy],
                    AgeRating = AgeRating.SixteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23c7390b85b903db82",
                    Title = "Киберсталкер",
                    OriginalTitle = "Stalk",
                    Countries = ["Франция"],
                    ReleaseDate = new DateOnly(2020, 3, 13),
                    Genres = [Genre.Thriller, Genre.Drama],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb232ad5e3332c3179ac",
                    Title = "Локи",
                    OriginalTitle = "Loki",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 7, 9),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
                new MovieDto
                {
                    Id = "68fbdb23489bc1028003429d",
                    Title = "Элита",
                    OriginalTitle = "Élite",
                    Countries = ["Испания"],
                    ReleaseDate = new DateOnly(2018, 10, 5),
                    Genres = [Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb23c13d1b15c8b2d528",
                    Title = "Могучая девятка",
                    OriginalTitle = "The Mighty Nein",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2025, 11, 19),
                    Genres = [Genre.Cartoon, Genre.Fantasy, Genre.ActionMovie, Genre.Comedy, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Amazon Prime Video"],
                },
                new MovieDto
                {
                    Id = "68fbdb23ee49893b43c90958",
                    Title = "Анатомия страсти",
                    OriginalTitle = "Grey's Anatomy",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2005, 3, 27),
                    Genres = [Genre.Drama, Genre.Melodrama],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["АМС"],
                },
                new MovieDto
                {
                    Id = "68fbeb89a47c72e3b919670f",
                    Title = "Мандалорец",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2019, 11, 12),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
                new MovieDto
                {
                    Id = "68fbeb89ceecaae7efa9902c",
                    Title = "Слово пацана. Кровь на асфальте ",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 11, 9),
                    Genres = [Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Wink", "START"],
                },
                new MovieDto
                {
                    Id = "68fbeb892282f88bfcea5d5b",
                    Title = "Хрустальный",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2021, 4, 20),
                    Genres = [Genre.Detective, Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["KION"],
                },
                new MovieDto
                {
                    Id = "68fbeb89929abb26716afb50",
                    Title = "Фишер",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 2, 8),
                    Genres = [Genre.Detective, Genre.Drama, Genre.Crime, Genre.Thriller],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["more.tv", "Wink"],
                },
                new MovieDto
                {
                    Id = "68fbeb89b4bee23480a52ca6",
                    Title = "Время приключений",
                    OriginalTitle = "Adventure Time with Finn & Jake",
                    Countries = ["США", "Гонконг", "Япония", "Южная Корея", "Германия"],
                    ReleaseDate = new DateOnly(2010, 4, 5),
                    Genres =
                    [
                        Genre.Cartoon, Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Comedy, Genre.Adventure,
                        Genre.Family
                    ],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateFrom = new DateOnly(2023, 1, 1),
            },
            [
                new MovieDto
                {
                    Id = "68fbeb89ceecaae7efa9902c",
                    Title = "Слово пацана. Кровь на асфальте ",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 11, 9),
                    Genres = [Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Wink", "START"],
                },
                new MovieDto
                {
                    Id = "68fbeb89929abb26716afb50",
                    Title = "Фишер",
                    OriginalTitle = null,
                    Countries = ["Россия"],
                    ReleaseDate = new DateOnly(2023, 2, 8),
                    Genres = [Genre.Detective, Genre.Drama, Genre.Crime, Genre.Thriller],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["more.tv", "Wink"],
                },
                new MovieDto
                {
                    Id = "68fbdb23c13d1b15c8b2d528",
                    Title = "Могучая девятка",
                    OriginalTitle = "The Mighty Nein",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2025, 11, 19),
                    Genres = [Genre.Cartoon, Genre.Fantasy, Genre.ActionMovie, Genre.Comedy, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Amazon Prime Video"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateTo = new DateOnly(2005, 1, 1),
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23476323981a7a3f7e",
                    Title = "Человек-паук",
                    OriginalTitle = "Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2002, 4, 30),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23edd26052617d2700",
                    Title = "Операция «Ы» и другие приключения Шурика",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1965, 7, 23),
                    Genres = [Genre.Comedy, Genre.Melodrama, Genre.Crime],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb23c0a252a0ae73e1f5",
                    Title = "Бременские музыканты",
                    OriginalTitle = null,
                    Countries = ["СССР"],
                    ReleaseDate = new DateOnly(1973, 5, 1),
                    Genres = [Genre.Cartoon, Genre.Children, Genre.Musical, Genre.Fantasy],
                    AgeRating = AgeRating.SixPlus,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateFrom = new DateOnly(2002, 5, 1),
                ReleaseDateTo = new DateOnly(2010, 10, 12),
            },
            [
                new()
                {
                    Id = "68fbdb23ee49893b43c90958",
                    Title = "Анатомия страсти",
                    OriginalTitle = "Grey's Anatomy",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2005, 3, 27),
                    Genres = [Genre.Drama, Genre.Melodrama],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["АМС"],
                },
                new MovieDto
                {
                    Id = "68fbdb235b83ee0d81498e07",
                    Title = "Гарри Поттер и Принц-полукровка",
                    OriginalTitle = "Harry Potter and the Half-Blood Prince",
                    Countries = ["Великобритания", "США"],
                    ReleaseDate = new DateOnly(2009, 7, 6),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Family],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentalGuidanceSuggested,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbdb235d80b28c59945b15",
                    Title = "Кунг-фу Вин Чунь",
                    OriginalTitle = "Gong fu yong chun",
                    Countries = ["Китай", "Гонконг"],
                    ReleaseDate = new DateOnly(2010, 10, 12),
                    Genres = [Genre.ActionMovie, Genre.Melodrama, Genre.Comedy],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = false,
                    Platforms = null,
                },
                new MovieDto
                {
                    Id = "68fbeb89b4bee23480a52ca6",
                    Title = "Время приключений",
                    OriginalTitle = "Adventure Time with Finn & Jake",
                    Countries = ["США", "Гонконг", "Япония", "Южная Корея", "Германия"],
                    ReleaseDate = new DateOnly(2010, 4, 5),
                    Genres =
                    [
                        Genre.Cartoon, Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Comedy, Genre.Adventure,
                        Genre.Family
                    ],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateFrom = new DateOnly(2026, 1, 1),
            },
            []
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateTo = new DateOnly(1950, 1, 1),
            },
            []
        },
        {
            new GetMoviesByFilterRequest()
            {
                ReleaseDateFrom = new DateOnly(2013, 1, 1),
                ReleaseDateTo = new DateOnly(2014, 1, 1),
            },
            []
        },
        {
            new GetMoviesByFilterRequest
            {
                Title = "Spider",
                ReleaseDateFrom = new DateOnly(2010, 1, 1),
            },
            [
                new MovieDto
                {
                    Id = "68fbdb238f4e456424d944fb",
                    Title = "Новый Человек-паук",
                    OriginalTitle = "The Amazing Spider-Man",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2012, 6, 13),
                    Genres = [Genre.Fantastic, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = AgeRating.TwelvePlus,
                    RatingMpaa = RatingMpaa.ParentsStronglyCautioned,
                    IsSerial = false,
                    Platforms = null,
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Countries = ["США"],
                Genres = [Genre.Horror, Genre.Adventure],
                Platforms = ["Disney+"],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb232ad5e3332c3179ac",
                    Title = "Локи",
                    OriginalTitle = "Loki",
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2021, 7, 9),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
                new MovieDto
                {
                    Id = "68fbeb89a47c72e3b919670f",
                    Title = "Мандалорец",
                    OriginalTitle = null,
                    Countries = ["США"],
                    ReleaseDate = new DateOnly(2019, 11, 12),
                    Genres = [Genre.Fantastic, Genre.Fantasy, Genre.ActionMovie, Genre.Adventure],
                    AgeRating = null,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Disney+"],
                },
            ]
        },
        {
            new GetMoviesByFilterRequest
            {
                Title = "а",
                Countries = ["США", "Испания"],
                ReleaseDateFrom = new DateOnly(2000, 1, 1),
                ReleaseDateTo = new DateOnly(2026, 1, 1),
                Genres = [Genre.Drama],
                AgeRating = AgeRating.EighteenPlus,
                IsSerial = true,
                Platforms = ["Netflix"],
            },
            [
                new MovieDto
                {
                    Id = "68fbdb23fbda316d99eb8c15",
                    Title = "Ведьмак",
                    OriginalTitle = "The Witcher",
                    Countries = ["США", "Польша"],
                    ReleaseDate = new DateOnly(2019, 12, 20),
                    Genres = [Genre.Fantasy, Genre.Adventure, Genre.Drama, Genre.Horror],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
                new MovieDto
                {
                    Id = "68fbdb23489bc1028003429d",
                    Title = "Элита",
                    OriginalTitle = "Élite",
                    Countries = ["Испания"],
                    ReleaseDate = new DateOnly(2018, 10, 5),
                    Genres = [Genre.Thriller, Genre.Drama, Genre.Crime],
                    AgeRating = AgeRating.EighteenPlus,
                    RatingMpaa = null,
                    IsSerial = true,
                    Platforms = ["Netflix"],
                },
            ]
        },
    };
}