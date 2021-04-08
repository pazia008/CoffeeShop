using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.Repositories
{
    public interface ICoffeeRepo
    {

        List<Coffee> GetAllCoffees();
        void AddCoffee(Coffee coffee);

    }
}
