using System;
using System.Collections.Generic;


namespace DeBox.Unitoolz.Utils
{
    public class TokenPool
    {
        private readonly string _poolPrefix = "";
        private HashSet<string> _tokens;

        public TokenPool() : this(string.Empty)
        {
        }

        public TokenPool(string poolPrefix)
        {
            _poolPrefix = poolPrefix;
            _tokens = new HashSet<string>();
        }

        public bool IsClean
        {
            get
            {
                return _tokens.Count == 0;
            }
        }

        public void Borrow(out string token, string prefix="")
        {
            Guid guid = Guid.NewGuid();
            token = _poolPrefix + prefix + guid.ToString();
            _tokens.Add(token);
        }

        public void Return(string token)
        {
            if (!TryReturn(token))
            {
                throw new InvalidOperationException("Attempt to return a token that was never borrowed: " + token);
            }
        }

        public bool TryReturn(string token)
        {
            return _tokens.Remove(token);
        }

        public void RevokeAll()
        {
            _tokens.Clear();
        }
    }
}
