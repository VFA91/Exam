using System.Collections.Generic;
using System.Linq;

namespace ParenthesesBalancing
{
    public class ParenthesesBalancing
    {
        private const char LEFT_PARENTHESIS = '(';
        private const char RIGHT_PARENTHESIS = ')';

        private Stack<char> _parentheses = new Stack<char>();

        public bool IsBalanced(string input)
        {
            IEnumerable<char> parenthesesInInput = input.Where(c => IsLeftParenthesis(c) || IsRightParenthesis(c));

            foreach (char parenthesis in parenthesesInInput)
            {
                if (IsLeftParenthesis(parenthesis))
                    _parentheses.Push(parenthesis);
                else
                    if (!ClearRightParentheses(parenthesis))
                    return false;
            }

            return ParenthesesClosed();
        }

        private bool ClearRightParentheses(char parenthesis)
        {
            if (!IsRightParenthesis(parenthesis))
                return false;

            if (StackIsEmpty())
                return false;

            _parentheses.Pop();

            return true;
        }

        private bool ParenthesesClosed() => StackIsEmpty() ? true : false;
        private static bool IsRightParenthesis(char @char) => @char.Equals(RIGHT_PARENTHESIS);
        private static bool IsLeftParenthesis(char @char) => @char.Equals(LEFT_PARENTHESIS);
        private bool StackIsEmpty() => _parentheses.Count == 0;
    }
}