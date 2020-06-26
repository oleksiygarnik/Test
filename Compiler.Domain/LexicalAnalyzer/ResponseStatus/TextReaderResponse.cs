using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.ResponseStatus
{
    public class TextReaderResponse
    {
        private readonly TextReaderStatus _status;

        private readonly Token _token;

        public TextReaderResponse(TextReaderStatus status)
        {
            _status = status ?? throw new ArgumentNullException(nameof(status));
        }

        public TextReaderResponse(TextReaderStatus status, Token token)
        {
            _status = status ?? throw new ArgumentNullException(nameof(status));
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public override string ToString()
            => $"Status: {_status}, Token: {_token ?? "None"}";

    }
}
