using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeAnalyzer
{
    public static class CSharpExtensions
    {
        public static ITypeSymbol GetTypeSymbol(
           this SemanticModel semanticModel,
           ExpressionSyntax expression,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            return semanticModel
                .GetTypeInfo(expression, cancellationToken)
                .Type;
        }

        public static ISymbol GetSymbol(
          this SemanticModel semanticModel,
          ExpressionSyntax expression,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            return semanticModel
                .GetSymbolInfo(expression, cancellationToken)
                .Symbol;
        }

        public static ISymbol GetSymbol(
            this SemanticModel semanticModel,
            AttributeSyntax attribute,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return semanticModel
                .GetSymbolInfo(attribute, cancellationToken)
                .Symbol;
        }

        public static IMethodSymbol GetExtensionMethodSymbol(
           this SemanticModel semanticModel,
           ExpressionSyntax expression)
        {
            if (GetSymbol(semanticModel, expression) is IMethodSymbol methodSymbol
                && methodSymbol.IsExtensionMethod)
            {
                IMethodSymbol reducedFrom = methodSymbol.ReducedFrom;

                if (reducedFrom != null)
                    return reducedFrom;

                return methodSymbol;
            }

            return null;
        }

        public static bool TryGetNameParts(this ExpressionSyntax expression, out IList<string> parts)
        {
            var partsList = new List<string>();
            if (!TryGetNameParts(expression, partsList))
            {
                parts = null;
                return false;
            }

            parts = partsList;
            return true;
        }

        public static bool TryGetNameParts(this ExpressionSyntax expression, List<string> parts)
        {
            if (expression.IsKind(SyntaxKind.SimpleMemberAccessExpression))
            {
                var memberAccess = (MemberAccessExpressionSyntax)expression;
                if (!TryGetNameParts(memberAccess.Expression, parts))
                {
                    return false;
                }

                return AddSimpleName(memberAccess.Name, parts);
            }
            else if (expression.IsKind(SyntaxKind.QualifiedName))
            {
                var qualifiedName = (QualifiedNameSyntax)expression;
                if (!TryGetNameParts(qualifiedName.Left, parts))
                {
                    return false;
                }

                return AddSimpleName(qualifiedName.Right, parts);
            }
            else if (expression is SimpleNameSyntax simpleName)
            {
                return AddSimpleName(simpleName, parts);
            }
            else
            {
                return false;
            }
        }

        private static bool AddSimpleName(SimpleNameSyntax simpleName, List<string> parts)
        {
            if (!simpleName.IsKind(SyntaxKind.IdentifierName))
            {
                return false;
            }

            parts.Add(simpleName.Identifier.ValueText);
            return true;
        }
    }
}
