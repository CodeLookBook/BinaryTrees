using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BSTree<int>();

            tree.Insert(10);

            tree.Insert(08);
            tree.Insert(07);
            tree.Insert(09);
            tree.Insert(05);
            tree.Insert(06);
            tree.Insert(04);

            tree.Insert(18);
            tree.Insert(17);
            tree.Insert(19);
            tree.Insert(15);
            tree.Insert(16);
            tree.Insert(14);

            tree.InOrderTraverse(i => System.Console.WriteLine(i));           

            System.Console.ReadKey();
        }
    }
}
