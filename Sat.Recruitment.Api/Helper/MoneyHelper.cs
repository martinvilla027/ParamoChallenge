using System;
using Sat.Recruitment.Api.Contract.Request;

namespace Sat.Recruitment.Api.Helper
{
    public class MoneyHelper
    {
        public static decimal MoneyFromUserType(UserRequest request)
        {
            var decimalMoney = decimal.Parse(request.Money);

            switch (request.UserType)
            {
                case "Normal":
                    if (decimalMoney > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        var gif = decimalMoney * percentage;
                        decimalMoney += gif;
                    }

                    if (decimalMoney < 100 && decimalMoney > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = decimalMoney * percentage;
                        decimalMoney = +gif;
                    }
                    break;
                case "SuperUser":
                    if (decimalMoney > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = decimalMoney * percentage;
                        decimalMoney = +gif;
                    }
                    break;
                case "Premium":
                    if (decimalMoney > 100)
                    {
                        var gif = decimalMoney * 2;
                        decimalMoney = +gif;
                    }
                    break;
                default:
                    decimalMoney = 0;
                    break;
            }

            return decimalMoney;
        }
    }
}
