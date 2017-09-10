using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProjetoAcessoDados.Base
{
    public abstract class StringEnum<T> where T : class
    {
        //protected StringEnum() { }
        //protected StringEnum(string value)
        //{
        //    if (value == null)
        //        throw new ArgumentException("Valor NULL não é possível para enumeradores StringEnum", typeof(T).Name + ".value");

        //    var values = Enumerate();
        //    if (!values.Any(k => k.Key == value))
        //        throw new DomainRuleException(typeof(T).Name, string.Format("Não encontrado valor de enumeração '{0}'", value));
        //}

        public string Value { get; set; }

        public static implicit operator string(StringEnum<T> obj)
        {
            if (obj != null)
                return obj.Value;
            else
                return null;
        }
        public override String ToString()
        {
            return Value;
        }

        public static T GetByValue(string value)
        {
            if (value == null)
                throw new ArgumentException("Valor NULL não é possível para enumeradores StringEnum", typeof(T).Name + ".value");
            if (!Enumerate().Any(k => k.Key == value))
                throw new DomainRuleException(typeof(T).Name, string.Format("Não encontrado valor de enumeração '{0}'", value));

            var constructor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(String) }, null);
            T instance = constructor.Invoke(new object[] { value }) as T;
            return (T)instance;
        }
        public static List<KeyValuePair<string, string>> Enumerate()
        {
            List<KeyValuePair<string, string>> enumerator = new List<KeyValuePair<string, string>>();
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                KeyValuePair<string, string> enumItem;

                Attribute attr = field.GetCustomAttribute(typeof(StringEnumDescription));
                if (attr != null)
                {
                    enumItem = new KeyValuePair<string, string>(field.GetValue(null).ToString(), ((StringEnumDescription)attr)._description);
                }
                else
                {
                    enumItem = new KeyValuePair<string, string>(field.GetValue(null).ToString(), field.Name);
                }

                enumerator.Add(enumItem);
            }

            return enumerator;
        }

        public static KeyValuePair<string, string> GetDescriptionWithColor(string enumValue)
        {
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            FieldInfo field = fields.ToList().Find(f => f.GetValue(null).ToString() == enumValue);
            if (field != null)
            {
                Attribute attr = field.GetCustomAttribute(typeof(StringEnumDescription));
                if (attr != null)
                {
                    return new KeyValuePair<string, string>(((StringEnumDescription)attr)._description, ((StringEnumDescription)attr)._color.ToString());
                }
                else
                    throw new Exception(string.Format("Falta o atributo [StringEnumDescription] para o enum de valor '{0}'", enumValue));
            }
            else
                throw new Exception(string.Format("Não foi encontrada a variável para o enum value '{0}'", enumValue));
        }

        public static string GetDescription(string enumValue)
        {
            string enumDescription = null;
            var enumerator = Enumerate();
            var enumItem = enumerator.Find(e => e.Key == enumValue);
            enumDescription = enumItem.Value;

            return enumDescription;
        }
    }
}