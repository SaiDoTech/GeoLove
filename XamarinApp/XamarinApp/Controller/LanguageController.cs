﻿using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.LangResource;
using XamarinApp.Model;

namespace XamarinApp.Controller
{
    class LanguageController
    {
        public static List<AppLanguage> AppLanguages { get; private set; }

        public LanguageController()
        {
            var eng = new AppLanguage("English", "en-us");
            var ru = new AppLanguage("Русский", "ru-ru");
            var by = new AppLanguage("Беларуская", "be-BY");

            AppLanguages = new List<AppLanguage>()
            {
                eng,
                ru,
                by
            };

            Resource.Culture = new System.Globalization.CultureInfo(AppLanguages[0].CI);
        }

        public static void SetNewCulture(int indx)
        {
            Resource.Culture = new System.Globalization.CultureInfo(AppLanguages[indx].CI);
        }
    }
}
