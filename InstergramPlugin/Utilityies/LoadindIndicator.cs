using System;
using Acr.UserDialogs;

namespace XamarinKit.Utilityies
{
    public class LoadindIndicator
    {
        private static LoadindIndicator indicator;

        public LoadindIndicator()
        {
        }

        public static LoadindIndicator Indicator
        {
            get
            {
                if (indicator == null)
                {
                    indicator = new LoadindIndicator();
                }

                return indicator;
            }
        }


        public void StartIndicator()
        {
            UserDialogs.Instance.ShowLoading("Loading", MaskType.Clear);
        }

        public void EndIndicator()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
