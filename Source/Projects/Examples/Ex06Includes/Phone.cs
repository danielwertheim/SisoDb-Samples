using System;

namespace Examples.Ex06Includes
{
    [Serializable]
    public class Phone
    {
        public string AreaCode { get; private set; }

        public int Number { get; private set; }

        public Phone(string areaCode, int number)
        {
            AreaCode = areaCode;
            Number = number;
        }

        public override string ToString()
        {
            return AreaCode + "-" + Number;
        }
    }
}