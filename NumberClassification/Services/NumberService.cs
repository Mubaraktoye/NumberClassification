namespace NumberClassification.Services
{
    public class NumberService : INumberService
    {
        private readonly HttpClient _httpClient;

        public NumberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  object ClassifyNumber(int num)
        {
            return new
            {
                number = num,
                is_prime = IsPrime(num),
                is_perfect = IsPerfect(num),
                properties = GetProperties(num),
                digit_sum = GetDigitSum(num),
                fun_fact =  GetFunFact(num)
            };
        }

        private bool IsPrime(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        private bool IsPerfect(int num)
        {
            int sum = 1;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (i != num / i) sum += num / i;
                }
            }
            return sum == num && num != 1;
        }

        private bool IsArmstrong(int num)
        {
            int sum = 0, temp = num, digits = num.ToString().Length;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }
            return sum == num;
        }

        private string[] GetProperties(int num)
        {
            bool isArmstrong = IsArmstrong(num);
            bool isOdd = num % 2 != 0;

            if (isArmstrong && isOdd) return new[] { "armstrong", "odd" };
            if (isArmstrong) return new[] { "armstrong", "even" };
            if (isOdd) return new[] { "odd" };
            return new[] { "even" };
        }

        private int GetDigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        private string GetFunFact(int num)
        {
            string url = $"http://numbersapi.com/{num}/math";
            try
            {
                return  _httpClient.GetStringAsync(url).Result;
            }
            catch
            {
                return "Fun fact not available";
            }
        }
    }
}

