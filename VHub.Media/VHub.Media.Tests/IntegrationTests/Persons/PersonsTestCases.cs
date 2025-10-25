using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.Contracts.Persons.Requests;
using Xunit;

namespace VHub.Media.Tests.IntegrationTests.Persons;

public static class PersonsTestCases
{
    public static TheoryData<GetPersonsByFilterRequest?, PersonDto[]> TestCases => new()
    {
        {
            null,
            []
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = "68e559933162afba60b1946d"
            },
            [
                new PersonDto
                {
                    Id = "68e559933162afba60b1946d",
                    FullName = "Том Холланд",
                    OriginalFullName = "Tom Holland",
                    BirthDate = new DateOnly(1996, 6, 1),
                    BirthPlace = "Кингстон-апон-Темс, Большой Лондон, Великобритания",
                    Movies = [],
                }
            ]
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = "68e559933162afba60b1946d",
                FullName = "Эмма Стоун",
                OriginalFullName = "Emma Stone",
                BirthDate = new DateOnly(1995, 1, 1),
                BirthPlace = "Аризона",
            },
            [
                new PersonDto
                {
                    Id = "68e559933162afba60b1946d",
                    FullName = "Том Холланд",
                    OriginalFullName = "Tom Holland",
                    BirthDate = new DateOnly(1996, 6, 1),
                    BirthPlace = "Кингстон-апон-Темс, Большой Лондон, Великобритания",
                    Movies = [],
                }
            ]
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = null,
                FullName = null,
                OriginalFullName = null,
                BirthDate = null,
                BirthPlace = null,
            },
            []
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = null,
                FullName = "Сэди",
                OriginalFullName = "Tom",
                BirthDate = null,
                BirthPlace = null,
            },
            [
                new()
                {
                    Id = "68e559937976667bf6608d0f",
                    FullName = "Сэди Синк",
                    OriginalFullName = "Sadie Sink",
                    BirthDate = new DateOnly(2002, 4, 16),
                    BirthPlace = "Бренхем, Техас, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559930a581027464db21e",
                    FullName = "Сэди Фрост",
                    OriginalFullName = "Sadie Frost",
                    BirthDate = new DateOnly(1965, 6, 19),
                    BirthPlace = "Лондон, Англия, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e5599346f2cc0231fc833a",
                    FullName = "Сэди Сэндлер",
                    OriginalFullName = "Sadie Sandler",
                    BirthDate = new DateOnly(2006, 5, 6),
                    BirthPlace = "Лос-Анджелес, Калифорния, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993f66a3a9837595eb0",
                    FullName = "Сэди Стэнли",
                    OriginalFullName = "Sadie Stanley",
                    BirthDate = new DateOnly(2001, 11, 15),
                    BirthPlace = "Колумбия, Южная Каролина, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993650cc39470b6979e",
                    FullName = "Том Харди",
                    OriginalFullName = "Tom Hardy",
                    BirthDate = new DateOnly(1977, 9, 15),
                    BirthPlace = "Лондон, Англия, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993b24832c3a69515b8",
                    FullName = "Том Круз",
                    OriginalFullName = "Tom Cruise",
                    BirthDate = new DateOnly(1962, 7, 3),
                    BirthPlace = "Сиракьюс, Нью-Йорк, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559937d9924b58991cbd4",
                    FullName = "Том Хэнкс",
                    OriginalFullName = "Tom Hanks",
                    BirthDate = new DateOnly(1956, 7, 9),
                    BirthPlace = "Конкорд, Калифорния, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559933162afba60b1946d",
                    FullName = "Том Холланд",
                    OriginalFullName = "Tom Holland",
                    BirthDate = new DateOnly(1996, 6, 1),
                    BirthPlace = "Кингстон-апон-Темс, Большой Лондон, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e5599303ad9306b67d7a8f",
                    FullName = "Том Хиддлстон",
                    OriginalFullName = "Tom Hiddleston",
                    BirthDate = new DateOnly(1981, 2, 9),
                    BirthPlace = "Лондон, Англия, Великобритания",
                    Movies = [],
                }
            ]
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = null,
                FullName = null,
                OriginalFullName = "To",
                BirthDate = null,
                BirthPlace = null,
            },
            [
                new PersonDto
                {
                    Id = "68e55993650cc39470b6979e",
                    FullName = "Том Харди",
                    OriginalFullName = "Tom Hardy",
                    BirthDate = new DateOnly(1977, 9, 15),
                    BirthPlace = "Лондон, Англия, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993b24832c3a69515b8",
                    FullName = "Том Круз",
                    OriginalFullName = "Tom Cruise",
                    BirthDate = new DateOnly(1962, 7, 3),
                    BirthPlace = "Сиракьюс, Нью-Йорк, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559937d9924b58991cbd4",
                    FullName = "Том Хэнкс",
                    OriginalFullName = "Tom Hanks",
                    BirthDate = new DateOnly(1956, 7, 9),
                    BirthPlace = "Конкорд, Калифорния, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559933162afba60b1946d",
                    FullName = "Том Холланд",
                    OriginalFullName = "Tom Holland",
                    BirthDate = new DateOnly(1996, 6, 1),
                    BirthPlace = "Кингстон-апон-Темс, Большой Лондон, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e5599303ad9306b67d7a8f",
                    FullName = "Том Хиддлстон",
                    OriginalFullName = "Tom Hiddleston",
                    BirthDate = new DateOnly(1981, 2, 9),
                    BirthPlace = "Лондон, Англия, Великобритания",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55d24fad0cfb0a9990cef",
                    FullName = "Тоби Магуайр",
                    OriginalFullName = "Tobey Maguire",
                    BirthDate = new DateOnly(1975, 6, 27),
                    BirthPlace = "Санта-Моника, Калифорния, США",
                    Movies = [],
                }
            ]
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = null,
                FullName = "Сэди С",
                OriginalFullName = null,
                BirthDate = null,
                BirthPlace = null,
            },
            [
                new PersonDto
                {
                    Id = "68e559937976667bf6608d0f",
                    FullName = "Сэди Синк",
                    OriginalFullName = "Sadie Sink",
                    BirthDate = new DateOnly(2002, 4, 16),
                    BirthPlace = "Бренхем, Техас, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e5599346f2cc0231fc833a",
                    FullName = "Сэди Сэндлер",
                    OriginalFullName = "Sadie Sandler",
                    BirthDate = new DateOnly(2006, 5, 6),
                    BirthPlace = "Лос-Анджелес, Калифорния, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993f66a3a9837595eb0",
                    FullName = "Сэди Стэнли",
                    OriginalFullName = "Sadie Stanley",
                    BirthDate = new DateOnly(2001, 11, 15),
                    BirthPlace = "Колумбия, Южная Каролина, США",
                    Movies = [],
                }
            ]
        },
        {
            new GetPersonsByFilterRequest()
            {
                Id = null,
                FullName = "Сэди",
                OriginalFullName = "Tom",
                BirthDate = null,
                BirthPlace = "США",
            },
            [
                new PersonDto
                {
                    Id = "68e559937976667bf6608d0f",
                    FullName = "Сэди Синк",
                    OriginalFullName = "Sadie Sink",
                    BirthDate = new DateOnly(2002, 4, 16),
                    BirthPlace = "Бренхем, Техас, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e5599346f2cc0231fc833a",
                    FullName = "Сэди Сэндлер",
                    OriginalFullName = "Sadie Sandler",
                    BirthDate = new DateOnly(2006, 5, 6),
                    BirthPlace = "Лос-Анджелес, Калифорния, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993f66a3a9837595eb0",
                    FullName = "Сэди Стэнли",
                    OriginalFullName = "Sadie Stanley",
                    BirthDate = new DateOnly(2001, 11, 15),
                    BirthPlace = "Колумбия, Южная Каролина, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e55993b24832c3a69515b8",
                    FullName = "Том Круз",
                    OriginalFullName = "Tom Cruise",
                    BirthDate = new DateOnly(1962, 7, 3),
                    BirthPlace = "Сиракьюс, Нью-Йорк, США",
                    Movies = [],
                },
                new PersonDto
                {
                    Id = "68e559937d9924b58991cbd4",
                    FullName = "Том Хэнкс",
                    OriginalFullName = "Tom Hanks",
                    BirthDate = new DateOnly(1956, 7, 9),
                    BirthPlace = "Конкорд, Калифорния, США",
                    Movies = [],
                }
            ]
        },
    };
}