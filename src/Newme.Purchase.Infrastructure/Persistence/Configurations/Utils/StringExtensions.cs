using Newme.Purchase.Domain.Models.Enums;
using System.Reflection;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations.Utils
{
    // public static class StringExtensions
    // {
    //     /// <summary>
    //     /// Return a instance of purchase state enumName
    //     /// </summary>
    //     /// <param name="enumName"></param>
    //     /// <returns></returns>
    //     public static EPurchaseOrderStatus GetState(this string enumName)
    //     {
    //         Assembly assembly = Assembly.Load("Newme.Purchase.Domain");
    //         string fullEnumName = $"Newme.Purchase.Domain.Models.Enums.{enumName}";
    //         Type type = assembly.GetType(fullEnumName);
    //         EPurchaseOrderStatus state = (EPurchaseOrderStatus)Activator.CreateInstance(type);
    //         return state;
    //     }
    // }
}