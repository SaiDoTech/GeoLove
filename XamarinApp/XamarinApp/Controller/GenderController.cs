using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Model;

namespace XamarinApp.Controller
{
    class GenderController
    {
        public static List<Gender> AppGenders { get; private set; }

        public GenderController()
        {
            var male = new Gender("Male");
            var female = new Gender("Female");

            AppGenders = new List<Gender>()
            {
                male,
                female
            };

        }
    }
}
