using Api1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    public class PlayersDataStore
    {
        public static PlayersDataStore Current { get; } = new PlayersDataStore();
        public List<PlayerDto> Players { get; set; }
        public PlayersDataStore()
        {
            // Dummy Data
            Players = new List<PlayerDto>()
            {
                new PlayerDto()
                {
                    Id = 1,
                    Name = "Mr.Carrot",
                    Level = 22,
                    Item = new List<ItemDto>()
                    {
                        new ItemDto()
                        {
                            Id = 1,
                            Name = "Potato",
                            Value = 15
                        },
                        new ItemDto()
                        {
                            Id = 2,
                            Name = "Seed",
                            Value = 5
                        }
                    }
                },
                new PlayerDto()
                {
                    Id = 2,
                    Name = "Vihrab95",
                    Level = 25,
                    Item = new List<ItemDto>()
                    {
                        new ItemDto()
                        {
                            Id = 1,
                            Name = "Wooden Sword",
                            Value = 250
                        },
                        new ItemDto()
                        {
                            Id = 2,
                            Name = "Rock",
                            Value = 10
                        },
                        new ItemDto()
                        {
                            Id = 3,
                            Name = "Torch",
                            Value = 20
                        }
                    }
                },
                new PlayerDto()
                {
                    Id = 3,
                    Name = "Mdal",
                    Level = 19,
                    Item = new List<ItemDto>()
                    {
                        new ItemDto()
                        {
                            Id = 1,
                            Name = "Stick",
                            Value = 5
                        },
                        new ItemDto()
                        {
                            Id = 2,
                            Name = "Rock",
                            Value = 10
                        },
                        new ItemDto()
                        {
                            Id = 3,
                            Name = "Wood",
                            Value = 20
                        },
                        new ItemDto()
                        {
                            Id = 4,
                            Name = "Wooden Axe",
                            Value = 150
                        },
                        new ItemDto()
                        {
                            Id = 5,
                            Name = "Stone Sword",
                            Value = 350
                        }
                    }
                }
            };
        }
    }
}
