﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Settings
    {
        public static Dictionary<Category, int> AdditionalSortsPersons
        {
            get
            {
                return new Dictionary<Category, int>
                {
                    { Category.hiestSort, 15 },
                    { Category.firstSort, 10 },
                    { Category.secondSort, 5 },
                };
            }
        }
    }
}
