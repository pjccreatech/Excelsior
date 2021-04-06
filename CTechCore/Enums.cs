using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Enums
{

    public static class StockItem
    {
        public enum StockItemStatus
        {
            [Description("Active")]
            Active = 0,
            [Description("Inactive")]
            Inactive = 1,
            [Description("Does Not Exist")]
            DoesNotExist = 2,
        }

        public static class StockRollItem
        {
            public enum GRVType
            {
                Each = 'e',
                Length = 'm'
            }
        }
    }

    public static class Document
    {
        public enum Type
        {
            Quote = 0,
            [Description("Sales Order")]
            SalesOrder = 1,
            Invoice = 2,
            [Description("Purchase Order")]
            PurchaseOrder = 3,
            [Description("Goods Receiving Voucher")]
            GoodsReceivingVoucher = 4,
            [Description("Return To Supplier")]
            ReturnToSupplier = 5,
            [Description("Commodity Check-In")]
            CommodityCheckIn = 6,
            [Description("Stock Movement")]
            StockMovement = 7
        }

        public enum State
        {
            New = 0,
            Saved = 1,
            Processed = 2,
            Completed = 3,
            Cancelled = 4,
        }
        
        public enum PaymentStatus
        {
            [Description("CASH ON DELIVERY")]
            COD = 0,
            [Description("PAID CARD")]
            PaidCard = 1,
            [Description("PAID CASH")]
            PaidCash = 2,
            [Description("PAID DEPOSIT")]
            PaidDeposit = 3,
            [Description("PAID EFT")]
            PaidEFT= 4,
            [Description("PAID IN ADVAMNCE")]
            PIA = 5,
            [Description("To Pay At Showroom")]
            PayAtShowroom = 6,
            [Description("To Pay On Delivery")]
            POD = 7,
            [Description("POD - 30 Days")]
            POD30 = 8
        }

        public enum Tax
        {
            TaxExclusive,
            TaxInclusive
        }

        public enum AccountType
        {
            Customer = 0,
            Supplier = 1,
        }

        public enum AccountingOperation
        {
            NoChange = 0,
            Increase = 1,
            Decrease = -1,
        }


        public enum Processable
        {
            [Display(Name = "Confirmed")]
            [Description("Cancelled")]
            Cancelled,
            [Display(Name = "Confirmed")]
            [Description("Confirmed")]
            Confirmed,
            [Display(Name = "Not Released")]
            [Description("Not Released")]
            NotReleased
        }        
    }

    public static class Helpers
    {

        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static string GetDisplayText(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
            if (attribs.Length > 0)
            {
                return ((System.ComponentModel.DescriptionAttribute)attribs[0]).Description;
            }
            return string.Empty;
        }

        //public static IList<string> GetDisplayValues(Enum value)
        //{
        //    return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        //}


        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        //public static string GetDisplayValue(T value)
        //{
        //    var fieldInfo = value.GetType().GetField(value.ToString());

        //    var descriptionAttributes = fieldInfo.GetCustomAttributes(
        //        typeof(DisplayAttribute), false) as DisplayAttribute[];

        //    if (descriptionAttributes[0].ResourceType != null)
        //        return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

        //    if (descriptionAttributes == null) return string.Empty;
        //    return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        //}

        public static string RemoveInvalidChars(string s)
        {
            System.Text.RegularExpressions.Regex illegalInFileName = new System.Text.RegularExpressions.Regex(string.Format("[{0}]", System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()))), System.Text.RegularExpressions.RegexOptions.Compiled);
            //s.ToList<char>().Take(c => char.IsLetter(c));
            s = string.Concat(s.Where(char.IsLetterOrDigit));
            return illegalInFileName.Replace(s, "");
        }
    }
}
