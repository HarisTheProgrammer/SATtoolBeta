using System.Collections.Immutable;
using CodeAnalyzer.Entities.Helpers;
using Microsoft.CodeAnalysis;

namespace CodeAnalyzer.Utilities
{
    public static class SymbolUtility
    {
        public static bool IsLinqIEnumerableWithPredicate(
            IMethodSymbol methodSymbol,
            string name,
            int parameterCount)
        {
            if (methodSymbol.DeclaredAccessibility != Accessibility.Public)
                return false;

            if (methodSymbol.Name is null || !methodSymbol.Name.Equals(name))
                return false;

            INamedTypeSymbol containingType = methodSymbol.ContainingType;

            if (containingType == null)
                return false;

            if (containingType.Equals(MetaDataNames.System_Linq_Enumerable))
            {
                ImmutableArray<IParameterSymbol> parameters = methodSymbol.Parameters;

                return parameters.Length == parameterCount
                    && parameters[0].Type.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                    && IsPredicateFunc(parameters[1].Type, methodSymbol.TypeArguments[0]);
            }

            return false;
        }

        public static bool IsLinqIEnumerableWithPredicate(IMethodSymbol methodSymbol, string name)
        {
            if (methodSymbol.DeclaredAccessibility != Accessibility.Public)
                return false;

            if (methodSymbol.Name is null || !methodSymbol.Name.Equals(name))
                return false;

            INamedTypeSymbol containingType = methodSymbol.ContainingType;

            if (containingType == null)
                return false;

            if (MetaDataNames.System_Linq_Enumerable.Equals(containingType))
            {
                ImmutableArray<IParameterSymbol> parameters = methodSymbol.Parameters;

                if (parameters.Length > 1)
                {
                    return parameters[0].Type.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                        && IsPredicateFunc(parameters[1].Type, methodSymbol.TypeArguments[0]);
                }
            }

            return false;
        }

        public static bool IsPredicateFunc(ISymbol symbol, ITypeSymbol parameter)
        {
            if (!MetaDataNames.System_Func_T2.Equals(symbol))
                return false;

            ImmutableArray<ITypeSymbol> typeArguments = ((INamedTypeSymbol)symbol).TypeArguments;

            return typeArguments.Length == 2
                && typeArguments[0].Equals(parameter)
                && typeArguments[1].SpecialType == SpecialType.System_Boolean;
        }
    }
}
