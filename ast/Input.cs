using System.Collections.Generic;

namespace first.ast
{
    public class Input
    {
        private List<Statement> _statements;

        public Input(List<Statement> statements)
        {
            _statements = statements;
        }

        public List<Statement> GetStatements()
        {
            return _statements;
        }
    }
}