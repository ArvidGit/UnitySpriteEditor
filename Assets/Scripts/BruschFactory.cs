using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Simple factory class
    public class BruschFactory
    {
        public static IBrusch GetBrusch(int index)
        {
            Brusches b = (Brusches)index;
            switch (b)
            {
                case Brusches.Standard:
                    return new StandardBrusch();
                case Brusches.Double:
                    return new DoubleBrusch(1);
                case Brusches.Triple:
                    return new DoubleBrusch(2);
                case Brusches.Fill:
                    return new FillBrusch();
                default:
                    return new StandardBrusch();
            }
        }
    }

