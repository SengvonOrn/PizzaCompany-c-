using Guna.UI2.WinForms;
using System.Web.UI.WebControls;

namespace PizzaCompany.ultill
{
    public class formatMoney
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



        public static void GenerateMoney(
        decimal total,
        Guna2TextBox rielInput,
        Guna2TextBox dollarInput,
        Guna2TextBox dollarResult,
        Guna2TextBox rielResult)
        {
            const decimal ExchangeRate = 4150m;

            bool dollarParsed = decimal.TryParse(dollarInput.Text, out decimal dollarValue);
            bool rielParsed = decimal.TryParse(rielInput.Text, out decimal khmerValue);

            if (dollarParsed)
            {
                if (dollarValue > total)
                {
                    decimal getChange = dollarValue - total;
                    dollarResult.Text = getChange.ToString("0.00") + " $";
                    decimal getToKhmer = getChange * ExchangeRate;
                    rielResult.Text = getToKhmer.ToString("0.00") + " ៛";
                }
                else
                {
                    dollarResult.Text = "";
                    rielResult.Text = "";
                }
            }

            else if (rielParsed)
            {
                decimal totalInRiel = total * ExchangeRate;

                if (khmerValue > totalInRiel)
                {
                    decimal changeInRiel = khmerValue - totalInRiel;
                    rielResult.Text = changeInRiel.ToString("0.00") + " ៛";

                    decimal changeInDollar = changeInRiel / ExchangeRate;
                    dollarResult.Text = changeInDollar.ToString("0.00") + " $";
                }
                else
                {
                    rielResult.Text = "";
                    dollarResult.Text = "";
                }
            }
        }
    }
}
