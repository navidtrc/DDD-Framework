using System.Collections;

namespace Utilities.Extensions;

public static class Assert
{
    public static void NotNull<T>(T obj, string name, string message = null)
        where T : class
    {
        if (obj is null)
            throw new ArgumentNullException($"{name} : {typeof(T)}", message);
    }

    public static void NotNull<T>(T? obj, string name, string message = null)
        where T : struct
    {
        if (!obj.HasValue)
            throw new ArgumentNullException($"{name} : {typeof(T)}", message);

    }

    public static void NotEmpty<T>(T obj, string name, string message = null, T defaultValue = null)
        where T : class
    {
        if (obj == defaultValue
            || (obj is string str && string.IsNullOrWhiteSpace(str))
            || (obj is IEnumerable list && !list.Cast<object>().Any()))
        {
            throw new ArgumentException("Argument is empty : " + message, $"{name} : {typeof(T)}");
        }
    }

    private static Dictionary<string, string> _bankCards;
    public static Dictionary<string, string> BankCards
    {
        get
        {
            if (_bankCards != null)
                return _bankCards;
            return new Dictionary<string, string>
            {
                {"504172","بانک قرض الحسنه رسالت" },
                {"627412","بانک اقتصاد نوین" },
                {"627381","بانک انصار" },
                {"505785","بانک ایران زمین" },
                {"622106","بانک پارسیان" },
                {"639194","بانک پارسیان" },
                {"627884","بانک پارسیان" },
                {"639347","بانک پاسارگاد" },
                {"502229","بانک پاسارگاد" },
                {"636214","بانک آینده" },
                {"627353","بانک تجارت" },
                {"585983","بانک تجارت" },
                {"502908","بانک توسعه تعاون" },
                {"627648","بانک توسعه صادرات ایران" },
                {"207177","بانک توسعه صادرات ایران" },
                {"636949","بانک حکمت ایرانیان" },
                {"502938","بانک دی" },
                {"589463","بانک رفاه کارگران" },
                {"621986","بانک سامان" },
                {"62198619","بلو" },
                {"62198618","بلو" },
                {"589210","بانک سپه" },
                {"639607","بانک سرمایه" },
                {"639346","بانک سینا" },
                {"502806","بانک شهر" },
                {"603769","بانک صادرات ایران" },
                {"627961","بانک صنعت و معدن" },
                {"606373","بانک قرض الحسنه مهر ایران" },
                {"639599","بانک قوامین" },
                {"627488","بانک کارآفرین" },
                {"502910","بانک کارآفرین" },
                {"603770","بانک کشاورزی" },
                {"639217","بانک کشاورزی" },
                {"505416","بانک گردشگری" },
                {"636795","بانک مرکزی" },
                {"628023","بانک مسکن" },
                {"610433","بانک ملت" },
                {"991975","بانک ملت" },
                {"603799","بانک ملی ایران" },
                {"639370","بانک مهر اقتصاد" },
                {"627760","پست بانک ایران" },
                {"628157","موسسه اعتباری توسعه" },
                {"505801","موسسه اعتباری کوثر" }
            };
        }
    }

    public static bool IsBankCardValid(string cardNumber)
    {
        return BankCards.Keys.Any(cardNumber.StartsWith) && IsLuhnValid(cardNumber);
    }
    public static string GetBankName(string cardNumber)
    {
        return BankCards.FirstOrDefault(kvp => cardNumber.StartsWith(kvp.Key)).Value;
    }
    public static bool IsLuhnValid(string cardNumber)
    {
        int sum = 0;
        bool alternate = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(cardNumber[i].ToString());

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            alternate = !alternate;
        }

        return (sum % 10 == 0);
    }
}