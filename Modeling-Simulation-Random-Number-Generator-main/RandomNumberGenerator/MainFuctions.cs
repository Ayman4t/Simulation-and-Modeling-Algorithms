using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    class MainFuctions
    {

        public bool validateInput(double multiplier, double increment, double modulus, double x0)
        {
            if ((modulus > 0) && (modulus > multiplier) && (modulus > increment) && (x0 < modulus))
                return true;

            return false;
        }


        public List<double> LCG_Generator(double multiplier, double increment, double modulus, double x0, double iteration)
        {
            List<double> lcg = new List<double>();
            double seed_i = 0;

            for (int i = 1; i <= iteration; i++) 
            {
                if(i == 1)
                {
                    lcg.Add(((multiplier * x0) + increment) % modulus);
                    seed_i = ((multiplier * x0) + increment) % modulus;
                }
                else
                {
                    lcg.Add(((multiplier * seed_i) + increment) % modulus);
                    seed_i = ((multiplier * seed_i) + increment) % modulus;  
                }

                
            }
            return lcg;
        }


        public double calculateActualPeriodLenth(double multiplier, double increment, double modulus, double x0)
        {
            double LongestPeriod = -1;
            double k = modulus - 1;
            bool check1 = true, check2 = true, check3 = true;

            if (IsPowerOfTwo(modulus) && (increment != 0))
            {
                if(IsRelativelyPrime(increment, modulus))
                {
                    LongestPeriod = modulus;
                    check1 = false;
                }
            }
            if (IsPowerOfTwo(modulus) && (increment == 0))
            {
                if (IsSeedOdd(x0) && (multiplier == (5 + 8 * k)))
                {
                    LongestPeriod = modulus / 4;
                    check2 = false;
                }     
            }
            if (IsPrime(modulus) && (increment == 0))
            {
                if (IsDivisible((Math.Pow(multiplier, k) - 1), modulus))
                {
                    LongestPeriod = modulus - 1;
                    check3 = false;
                }
            }
            if(check1 && check2 && check3)
                LongestPeriod = calculatePeriodLenth(multiplier, increment, modulus, x0);

            return LongestPeriod;
        }


        public double calculatePeriodLenth(double multiplier, double increment, double modulus, double x0)
        {
            double LongestPeriod = 0;
            double seed_i = 0;
            double first_number = ((multiplier * x0) + increment) % modulus;
            for (int i = 2; i <= modulus; i++)
            {
                if (i == 2)   
                    seed_i = ((multiplier * first_number) + increment) % modulus;
                else   
                    seed_i = ((multiplier * seed_i) + increment) % modulus;

                LongestPeriod++;
                if (seed_i == first_number)
                    return LongestPeriod;
            }
            return 0;
        }


        public bool IsPrime(double modulus)
        {
            if (modulus <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(modulus); i++)
            {
                if (modulus % i == 0)
                    return false;

            }
            return true;
        }


        public bool IsDivisible(double a, double b)
        {
            double cDouble = a / b;
            int cInteger = (int)cDouble;
            if (cInteger == cDouble)
                return true;
            return false;
        }


        public bool IsPowerOfTwo(double num)
        {
            if (num == 0)
                return false;
            while (num != 1)
            {
                if (num % 2 != 0)
                    return false;
                num = num / 2;
            }
            return true;
        }


        public bool IsSeedOdd(double seed)
        {
            if (seed % 2 != 0)
                return true;
            return false;
        }


        public bool IsRelativelyPrime(double increment, double modulus)
        {
            double num = Math.Min(modulus, increment);
            for (int i = 2; i <= num; i++)
            {
                if (IsDivisible(increment, i) && IsDivisible(modulus, i))
                    return false;
            }
            return true;
        }


        public List<double> getPrimeNumbers(double number)
        {
            List<double> primeNumbers = new List<double>();
            bool isPrime = true;

            for (int i = 2; i <= number; i++)
            {
                for (int j = 2; j <= number; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
                isPrime = true;
            }

            return primeNumbers;
        }

    }
}
