using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra
{
    public static class MultiSetAlgebra
    {
        /// <summary>
        /// Skips results from a set
        /// </summary>
        /// <param name="set">set to filter</param>
        /// <param name="count">number of results to filter away</param>
        /// <returns></returns>
        public static IEnumerable<IMultiSetRow> SkipResults(this IEnumerable<IMultiSetRow> set, int count)
        {
            //yield signature
            yield return (SignatureRow)set.First();

            //filter
            foreach (var row in set.Skip(1 + count))
            {
                yield return row;
            }
        }

        /// <summary>
        /// Limits results from a set
        /// </summary>
        /// <param name="set">set to filter</param>
        /// <param name="count">maximum number of results to take</param>
        /// <returns></returns>
        public static IEnumerable<IMultiSetRow> TakeResults(this IEnumerable<IMultiSetRow> set, int count)
        {
            //yield signature
            yield return (SignatureRow)set.First();

            //filter
            foreach (var row in set.Skip(1).Take(count))
            {
                yield return row;
            }
        }

        #region private methods
        /// <summary>
        /// Returns the projection of a row
        /// </summary>
        public static ResultRow ProjectRow(ResultRow row, string[] variableList)
        {
            var result = new ResultRow(new Dictionary<string, object>());
            foreach (var variable in variableList)
            {
                var pair = row.SolutionMapping.Where(p => p.Key == variable).First();
                result.SolutionMapping.Add(pair.Key, pair.Value);
            }
            return result;
        }

        /// <summary>
        /// Binds variables of a result row
        /// </summary>
        public static ResultRow BindRow(ResultRow row, Dictionary<string, object> bindingDictionary)
        {
            foreach (var binding in bindingDictionary)
            {
                object value;
                if (row.SolutionMapping.TryGetValue(binding.Key, out value))
                {
                    row.SolutionMapping[binding.Key] = binding.Value;
                }
                else
                {
                    throw new ArgumentException($"Error binding the variable {binding.Key} to a result row, the solution mapping does not include the variable {binding.Key}");
                }
            }
            return row;
        }

        /// <summary>
        /// Extend a row with null values
        /// </summary>
        public static ResultRow ExtendRow(ResultRow row, string[] extensionSignature)
        {
            foreach (var header in extensionSignature)
            {
                row.SolutionMapping.Add(header, null);
            }
            return row;
        }

        /// <summary>
        /// Joins tow signature rows on a given array of common variables
        /// </summary>
        public static SignatureRow JoinSignatures(SignatureRow row1, SignatureRow row2, string[] commonVariables)
        {
            var resultWidth = row1.VariableList.Length + row2.VariableList.Length - commonVariables.Length;
            var result = new SignatureRow(new string[resultWidth]);
            int i;

            for (i = 0; i < row1.VariableList.Length; i++)
            {
                result.VariableList[i] = row1.VariableList[i];
            }
            foreach (var variable in row2.VariableList)
            {
                if (!commonVariables.Contains(variable))
                {
                    result.VariableList[i++] = variable;
                }
            }

            return result;
        }

        /// <summary>
        /// Joins tow result rows on a given array of common variables
        /// </summary>
        public static ResultRow JoinRows(ResultRow row1, ResultRow row2, string[] commonVariables)
        {
            var result = new ResultRow(new Dictionary<string, object>(row1.SolutionMapping));

            foreach (var pair in row2.SolutionMapping)
            {
                if (!commonVariables.Contains(pair.Key))
                {
                    result.SolutionMapping.Add(pair.Key, pair.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns true if two result rows are compatible on a given array of common variables
        /// </summary>
        public static bool Compatible(ResultRow row1, ResultRow row2, string[] commonVariables)
        {
            return commonVariables.All(v =>
            (row1.SolutionMapping.ContainsKey(v) && row2.SolutionMapping.ContainsKey(v) && row1.SolutionMapping[v].Equals(row2.SolutionMapping[v])) ||
            (!row1.SolutionMapping.ContainsKey(v) && !row2.SolutionMapping.ContainsKey(v)));
        }

        /// <summary>
        /// Returns the shared variables of two signature rows
        /// </summary>
        public static string[] GetCommonVariables(SignatureRow row1, SignatureRow row2)
        {
            return row1.VariableList.Where(v => row2.VariableList.Contains(v)).ToArray();
        }
        #endregion
    }   
}
