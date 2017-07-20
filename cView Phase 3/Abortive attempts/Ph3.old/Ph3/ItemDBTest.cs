using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
   
    class ItemDBTest
    {

        static void Main(string[] args)
        {
            ItemDB myItemDB = new ItemDB();

            Park myPark = new Park();
            myPark.Name = "Marshall Park";

            myItemDB.Add(myPark);
            myItemDB.PrintAll();
        }
    }
}
