using System.Collections.Generic;

namespace DesignPatterns.Patterns.Behavioural.Interpreter
{
    /* 
     * permite interpretar sentencias en un lenguaje
     * dada una representacion para su gramatica
     */

    public interface IExpression
    {
        City Interpret();
    }

    public class CityExpression : IExpression
    {
        private readonly City _city;

        public CityExpression(City city)
        {
            _city = city;
        }

        public virtual City Interpret()
        {
            return _city;
        }
    }

    public class MostNortherlyExpression : IExpression
    {
        private readonly IList<IExpression> _expressions;

        public MostNortherlyExpression(
            IList<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public virtual City Interpret()
        {
            var resultingCity = new City(@"Nowhere",
                -999.9, -999.9);
            foreach (var currentExpression in _expressions)
            {
                var currentCity = currentExpression.Interpret();
                if (currentCity.Latitude > resultingCity.Latitude)
                {
                    resultingCity = currentCity;
                }
            }
            return resultingCity;
        }
    }
    public class MostSoutherlyExpression : IExpression
    {
        private readonly IList<IExpression> _expressions;

        public MostSoutherlyExpression(
            IList<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public virtual City Interpret()
        {
            var resultingCity = new City(@"Nowhere",
                999.9, 999.9);
            foreach (var currentExpression in _expressions)
            {
                var currentCity = currentExpression.Interpret();
                if (currentCity.Latitude < resultingCity.Latitude)
                {
                    resultingCity = currentCity;
                }
            }
            return resultingCity;
        }
    }
    public class MostWesterlyExpression : IExpression
    {
        private readonly IList<IExpression> _expressions;

        public MostWesterlyExpression(
            IList<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public virtual City Interpret()
        {
            var resultingCity = new City(@"Nowhere",
                999.9, 999.9);
            foreach (var currentExpression in _expressions)
            {
                var currentCity = currentExpression.Interpret();
                if (currentCity.Longitude < resultingCity.Longitude)
                {
                    resultingCity = currentCity;
                }
            }
            return resultingCity;
        }
    }
    public class MostEasterlyExpression : IExpression
    {
        private readonly IList<IExpression> _expressions;

        public MostEasterlyExpression(
            IList<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public virtual City Interpret()
        {
            var resultingCity = new City(@"Nowhere",
                -999.9, -999.9);
            foreach (var currentExpression in _expressions)
            {
                var currentCity = currentExpression.Interpret();
                if (currentCity.Longitude > resultingCity.Longitude)
                {
                    resultingCity = currentCity;
                }
            }
            return resultingCity;
        }
    }

    public class DirectionalEvaluator
    {
        private readonly IDictionary<string, City> _cities;

        public DirectionalEvaluator()
        {
            _cities = new Dictionary<string, City>();

            _cities[@"aberdeen"] = new City(@"Aberdeen", 57.15, -2.15);
            _cities[@"belfast"] = new City(@"Belfast", 54.62, -5.93);
            _cities[@"birmingham"] = new City(@"Birmingham", 52.42, -1.92);
            _cities[@"dublin"] = new City(@"Dublin", 53.33, -6.25);
            _cities[@"edinburgh"] = new City(@"Edinburgh", 55.92, -3.02);
            _cities[@"glasgow"] = new City(@"Glasgow", 55.83, -4.25);
            _cities[@"london"] = new City(@"London", 51.53, -0.08);
            _cities[@"liverpool"] = new City(@"Liverpool", 53.42, -3.0);
            _cities[@"manchester"] = new City(@"Manchester", 53.5, -2.25);
            _cities[@"southampton"] = new City(@"Southampton", 50.9, -1.38);
        }

        public virtual City Evaluate(string route)
        {
            var expresssionStack = new Stack<IExpression>();
            var tokens = new List<string>();
            var fromIndex = 0;
            var finished = false;
            while (!finished)
            {
                var spaceLocation = route.IndexOf(@" ", fromIndex, System.StringComparison.Ordinal);
                if (spaceLocation >= 0)
                {
                    tokens.Add(route.Substring(fromIndex,
                        spaceLocation - fromIndex));
                    fromIndex = spaceLocation + 1;
                }
                else
                {
                    tokens.Add(route.Substring(fromIndex));
                    finished = true;
                }

                //parse tokens
                foreach (var token in SplitTokens(route))
                {
                    //tokken in city?
                    if (_cities.ContainsKey(token))
                    {
                        var city = _cities[token];
                        expresssionStack.Push(new CityExpression(city));

                    }
                    else if (token.Equals(@"northerly"))
                    {
                        expresssionStack.Push(
                            new MostNortherlyExpression(
                                LoadExpressions(expresssionStack)));
                    }
                    else if (token.Equals(@"southerly"))
                    {
                        expresssionStack.Push(
                            new MostSoutherlyExpression(
                                LoadExpressions(expresssionStack)));
                    }
                    else if (token.Equals(@"westerly"))
                    {
                        expresssionStack.Push(
                            new MostWesterlyExpression(
                                LoadExpressions(expresssionStack)));
                    }
                    else if (token.Equals(@"easterly"))
                    {
                        expresssionStack.Push(
                            new MostEasterlyExpression(
                                LoadExpressions(expresssionStack)));
                    }
                }
            }
            return expresssionStack.Pop().Interpret();
        }
        private static IList<string> SplitTokens(string str)
        {
            var tokens = new List<string>();
            var fromIndex = 0;
            var finished = false;
            while (!finished)
            {
                var spaceLocation = str.IndexOf(@" ", fromIndex, System.StringComparison.Ordinal);
                if (spaceLocation >= 0)
                {
                    tokens.Add(str.Substring(fromIndex,
                        spaceLocation - fromIndex));
                    fromIndex = spaceLocation + 1;
                }
                else
                {
                    tokens.Add(str.Substring(fromIndex));
                    finished = true;
                }
            }
            return tokens;
        }
        private static IList<IExpression> LoadExpressions(
            Stack<IExpression> expressionStack )
        {
            IList<IExpression> expressions = 
                new List<IExpression>();
            while (expressionStack.Count>0)
            {
                expressions.Add(expressionStack.Pop());
            }
            return expressions;
        }
    }
    #region Clases para el ejemplo
    public sealed class City
    {
        private readonly string _name;
        private readonly double _latitude, _longitude;

        public City(string name, double latitude, double longitude)
        {
            _name = name;
            _latitude = latitude;
            _longitude = longitude;
        }

        public string Name
        {
            get { return _name; }
        }
        /*
         * en el ejemplo lat y long 
         * se guardan como doubles, se consideran 
         * valores positivos y negativos como norte, sur
         * este, oeste como corresponda
         */
        public double Latitude
        {
            get { return _latitude; }
        }
        public double Longitude
        {
            get { return _longitude; }
        }
        public override bool Equals(object otherObject)
        {
            if (this == otherObject)
            {
                return true;
            }
            if (!(otherObject is City))
            {
                return false;
            }
            var otherCity = (City)otherObject;
            return Name.Equals(otherCity.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    } 
    #endregion
}
