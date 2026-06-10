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

            delta[("q0", 'a')] = ("q1", 'X', 'R');
            delta[("q0", 'Y')] = ("q4", 'Y', 'R');

            delta[("q1", 'a')] = ("q1", 'a', 'R');
            delta[("q1", 'Y')] = ("q1", 'Y', 'R');

            delta[("q1", 'b')] = ("q2", 'Y', 'R');

            delta[("q2", 'b')] = ("q2", 'b', 'R');
            delta[("q2", 'Z')] = ("q2", 'Z', 'R');

            delta[("q2", 'c')] = ("q3", 'Z', 'L');

            delta[("q3", 'Z')] = ("q3", 'Z', 'L');
            delta[("q3", 'Y')] = ("q3", 'Y', 'L');
            delta[("q3", 'b')] = ("q3", 'b', 'L');
            delta[("q3", 'a')] = ("q3", 'a', 'L');

            delta[("q3", 'X')] = ("q0", 'X', 'R');

            delta[("q4", 'Y')] = ("q4", 'Y', 'R');
            delta[("q4", 'Z')] = ("q4", 'Z', 'R');

            delta[("q4", '_')] = ("qaccept", '_', 'R');

            return new MaquinaTuring(delta, "q0", "qaccept", "qreject", 1000);
        }

        public static MaquinaTuring CriarMtFuncaoUnaria()
        {
            var delta = new Dictionary<(string, char), (string, char, char)>();

            delta[("q0", '1')] = ("q0", '1', 'R');
            delta[("q0", '_')] = ("qaccept", '1', 'R');

            return new MaquinaTuring(delta, "q0", "qaccept", "qreject", 500);
        }
    }
}
