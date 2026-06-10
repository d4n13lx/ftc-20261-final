using ftc_20261_final.Parte3.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3.Infrastructure
{
    public static class ConfiguradorMt
    {
        public static MaquinaTuring CriarMtL4()
        {
            var delta = new Dictionary<(string, char), (string, char, char)>();

            return new MaquinaTuring(delta, "q0", "qaccept", "qreject", 1000);
        }

        public static MaquinaTuring CriarMtFuncaoUnaria()
        {
            var delta = new Dictionary<(string, char), (string, char, char)>();

            return new MaquinaTuring(delta, "q0", "qaccept", "qreject", 500);
        }
    }
}
