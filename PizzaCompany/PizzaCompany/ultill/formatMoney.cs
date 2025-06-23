namespace PizzaCompany.ultill
{
    internal class formatMoney
    {
        public static string ConvertUsdToShortKhr(decimal usd, decimal exchangeRate = 4100)
        {
            decimal khr = usd * exchangeRate;

            if (khr >= 1_000_000)
                return (khr / 1_000_000M).ToString("0.#") + "M";
            else if (khr >= 1_000)
                return (khr / 1_000M).ToString("0.#") + "K";
            else
                return khr.ToString("0");



        }


        public static string ConvertUsdToKM(decimal usd)
        {
            if (usd >= 1_000_000)
                return (usd / 1_000_000M).ToString("0.#") + "M";
            else if (usd >= 1_000)
                return (usd / 1_000M).ToString("0.#") + "K";
            else if (usd >= 100)
                return (usd / 100M).ToString("0.#") + "H";
            else
                return usd.ToString("0.##" + "$");
        }




        public static string ConvertUsdToRiel(decimal usd, decimal exchange = 4100)
        {
            decimal riel = usd * exchange;
            return riel.ToString("N0") + " ៛"; 
        }



    }
}
