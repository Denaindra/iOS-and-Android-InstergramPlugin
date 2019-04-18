using System;
using Xamarin.Forms;

namespace XamarinKit.Utilityies
{
    public class PropertiesDictionary: Application
    {
        private static PropertiesDictionary propertyInstants;

        public PropertiesDictionary()
        {
           
        }

        public static PropertiesDictionary PropertyInstants
        {
            get
            {
                if (propertyInstants == null)
                {
                    propertyInstants = new PropertiesDictionary();
                }
                return propertyInstants;
            }
        }

        public void SetData(string id,string data)
        {
            Application.Current.Properties[id] = data;
        }

        public string Getvalue(string id)
        {
            if (CheckpropertyKeyAvaialableOrNot(id))
            {
              return Application.Current.Properties[id]  as string;
            }
            return string.Empty;
        }


        private bool CheckpropertyKeyAvaialableOrNot(string id)
        {
            return Application.Current.Properties.ContainsKey(id);
        }

        public void Removeproperty(string id) 
        {
            Application.Current.Properties.Remove(id);
        }
    }
}
