using System.Collections;

namespace PT
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public void main()
        {
            seller s1 = new seller(1, "tak", "nie");
            seller s2 = new seller(2, "tak", "nie");
            seller s3 = new seller(3, "tak", "nie");

            ArrayList ar = new ArrayList();
            ar.Add(s1);
            ar.Add(s2);
            ar.Add(s3);


        }
    }
}