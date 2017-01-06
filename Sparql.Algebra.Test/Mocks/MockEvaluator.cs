using System;
using System.Collections.Generic;
using Sparql.Algebra.Filters;
using Sparql.Algebra.GraphEvaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Test.Constants;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Test.Mocks
{
    public class MockEvaluator:IEvaluator
    {
        public IEnumerable<LabelledTreeNode<object, Term>> Evaluate(LabelledTreeNode<object, Term> queryModel, int? offset, int? limit, IFilter filter, IGraphSource source)
        {
            if (source.EndPoint.Equals(TestUris.MathematiciansRepoUri)) //8 mathematicians
            {
                var archimedes = new LabelledTreeNode<object, Term>("archimedes");
                var gauss = new LabelledTreeNode<object, Term>("gauss");
                var descartes = new LabelledTreeNode<object, Term>("descartes");
                var euclid = new LabelledTreeNode<object, Term>("euclid");
                var newton = new LabelledTreeNode<object, Term>("newton");
                var pythagoras = new LabelledTreeNode<object, Term>("pythagoras");
                var euler = new LabelledTreeNode<object, Term>("euler");
                var leibniz = new LabelledTreeNode<object, Term>("leibniz");

                archimedes.AddChild(Biografy.Name, "Archimedes")
                    .AddChild(Biografy.YearOfBirth, -287)
                    .AddChild(Biografy.YearOfDeath, -212)
                    .AddChild(Biografy.Nationality, "greece");

                gauss.AddChild(Biografy.Name, "Carl Friedrich Gauss")
                    .AddChild(Biografy.YearOfBirth, 1777)
                    .AddChild(Biografy.YearOfDeath, 1855)
                    .AddChild(Biografy.Nationality, "germany");

                descartes.AddChild(Biografy.Name, "René Descartes")
                    .AddChild(Biografy.YearOfBirth, 1596)
                    .AddChild(Biografy.YearOfDeath, 1650)
                    .AddChild(Biografy.Nationality, "france");

                euclid.AddChild(Biografy.Name, "Euclid")
                    .AddChild(Biografy.YearOfBirth, -325)
                    .AddChild(Biografy.YearOfDeath, -265)
                    .AddChild(Biografy.Nationality, "greece");

                newton.AddChild(Biografy.Name, "Isaac Newton")
                    .AddChild(Biografy.YearOfBirth, 1643)
                    .AddChild(Biografy.YearOfDeath, 1727)
                    .AddChild(Biografy.Nationality, "england");

                pythagoras.AddChild(Biografy.Name, "Pythagoras")
                    .AddChild(Biografy.YearOfBirth, -569)
                    .AddChild(Biografy.YearOfDeath, -475)
                    .AddChild(Biografy.Nationality, "greece");

                euler.AddChild(Biografy.Name, "Leonhard Euler")
                    .AddChild(Biografy.YearOfBirth, 1707)
                    .AddChild(Biografy.YearOfDeath, 1783)
                    .AddChild(Biografy.Nationality, "switzerland");

                leibniz.AddChild(Biografy.Name, "Gottfried Wilhelm Leibniz")
                    .AddChild(Biografy.YearOfBirth, 1646)
                    .AddChild(Biografy.YearOfDeath, 1716)
                    .AddChild(Biografy.Nationality, "germany");

                yield return archimedes;
                yield return gauss;
                yield return descartes;
                yield return euclid;
                yield return newton;
                yield return pythagoras;
                yield return euler;
                yield return leibniz;
            }
            else if (source.EndPoint.Equals(TestUris.PhysicistRepoUri)) //7 physiscists
            {
                var einstein = new LabelledTreeNode<object, Term>("einstein");
                var curie = new LabelledTreeNode<object, Term>("curie");
                var bohr = new LabelledTreeNode<object, Term>("bohr");
                var feynman = new LabelledTreeNode<object, Term>("feynman");
                var newton = new LabelledTreeNode<object, Term>("newton");
                var galilei = new LabelledTreeNode<object, Term>("galilei");
                var maxwell = new LabelledTreeNode<object, Term>("maxwell");

                einstein.AddChild(Biografy.Name, "Albert Einstein")
                    .AddChild(Biografy.YearOfBirth, 1879)
                    .AddChild(Biografy.YearOfDeath, 1955)
                    .AddChild(Biografy.Nationality, "germany");

                curie.AddChild(Biografy.Name, "Marie Curie")
                    .AddChild(Biografy.YearOfBirth, 1867)
                    .AddChild(Biografy.YearOfDeath, 1934)
                    .AddChild(Biografy.Nationality, "france");

                bohr.AddChild(Biografy.Name, "Niels Bohr")
                    .AddChild(Biografy.YearOfBirth, 1885)
                    .AddChild(Biografy.YearOfDeath, 1962)
                    .AddChild(Biografy.Nationality, "denmark");

                feynman.AddChild(Biografy.Name, "Richard Feynman")
                    .AddChild(Biografy.YearOfBirth, 1918)
                    .AddChild(Biografy.YearOfDeath, 1988)
                    .AddChild(Biografy.Nationality, "usa");

                newton.AddChild(Biografy.Name, "Isaac Newton")
                    .AddChild(Biografy.YearOfBirth, 1643)
                    .AddChild(Biografy.YearOfDeath, 1727)
                    .AddChild(Biografy.Nationality, "england");

                galilei.AddChild(Biografy.Name, "Galileo Galilei")
                    .AddChild(Biografy.YearOfBirth, 1564)
                    .AddChild(Biografy.YearOfDeath, 1642)
                    .AddChild(Biografy.Nationality, "italy");

                maxwell.AddChild(Biografy.Name, "James Clerk Maxwell")
                    .AddChild(Biografy.YearOfBirth, 1831)
                    .AddChild(Biografy.YearOfDeath, 1879)
                    .AddChild(Biografy.Nationality, "scottland");

                yield return einstein;
                yield return curie;
                yield return bohr;
                yield return feynman;
                yield return newton;
                yield return galilei;
                yield return maxwell;
            }
            else if (source.EndPoint.Equals(TestUris.NationsRepouri)) //7 nations
            {
                var germany = new LabelledTreeNode<object, Term>("germany");
                var france = new LabelledTreeNode<object, Term>("france");
                var denmark = new LabelledTreeNode<object, Term>("denmark");
                var greece = new LabelledTreeNode<object, Term>("greece");
                var italy = new LabelledTreeNode<object, Term>("italy");
                var england = new LabelledTreeNode<object, Term>("england");
                var scottland = new LabelledTreeNode<object, Term>("scottland");
                var usa = new LabelledTreeNode<object, Term>("usa");
                var switzerland = new LabelledTreeNode<object, Term>("switzerland");

                germany.AddChild(Geografy.Name, "Germany")
                    .AddChild(Geografy.Capital, "Berlin")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 80620000);

                france.AddChild(Geografy.Name, "France")
                    .AddChild(Geografy.Capital, "Paris")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 66030000);

                denmark.AddChild(Geografy.Name, "Denmark")
                    .AddChild(Geografy.Capital, "Berlin")
                    .AddChild(Geografy.Continent, "Europe");

                greece.AddChild(Geografy.Name, "Greece")
                    .AddChild(Geografy.Capital, "Athens")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 11030000);

                italy.AddChild(Geografy.Name, "Italy")
                    .AddChild(Geografy.Capital, "Rome")
                    .AddChild(Geografy.Continent, "Europe");

                england.AddChild(Geografy.Name, "England")
                    .AddChild(Geografy.Capital, "Berlin")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 53010000);

                scottland.AddChild(Geografy.Name, "Scottland")
                    .AddChild(Geografy.Capital, "Berlin")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 5295000);

                usa.AddChild(Geografy.Name, "United States Of America")
                    .AddChild(Geografy.Capital, "Washington")
                    .AddChild(Geografy.Continent, "America")
                    .AddChild(Geografy.Population, 318900000);

                switzerland.AddChild(Geografy.Name, "Switzerland")
                    .AddChild(Geografy.Capital, "Bern")
                    .AddChild(Geografy.Continent, "Europe")
                    .AddChild(Geografy.Population, 8081000);

                yield return germany;
                yield return france;
                yield return denmark;
                yield return greece;
                yield return england;
                yield return scottland;
                yield return usa;
                yield return switzerland;
            }
            else
            {
                yield return new LabelledTreeNode<object, Term>(null);
            }
        }
    }
}
