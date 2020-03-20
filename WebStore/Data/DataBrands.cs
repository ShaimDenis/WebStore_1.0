using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Data
{
    public class DataBrands
    {
        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand { Id = 1, Name = "Acne", Order = 0 },
            new Brand { Id = 2, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 3, Name = "Albiro", Order = 2 },
            new Brand { Id = 4, Name = "Ronhill", Order = 3 },
            new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };
    }
}
