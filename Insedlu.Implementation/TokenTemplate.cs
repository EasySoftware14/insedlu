using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Insedlu.Implementation
{
    public class TokenTemplate
    {
        private bool _scancomplete;
        private string _body;
        private readonly List<string> _tokens;
        public TokenTemplate(string tokenFilename)
        {
            _scancomplete = false;
            _body = string.Empty;
            _tokens = new List<string>();
            ReadBody(tokenFilename);
        }
        public string Body
        {
            set
            {
                _body = value;
            }
            get
            {
                return _body;
            }
        }
        private void ReadBody(string tokenFilename)
        {
            using (var streamReader = new StreamReader(tokenFilename))
            {
                var result = string.Empty;

                try
                {
                    string line;

                    do
                    {
                        line = streamReader.ReadLine();
                        result += line;
                    }
                    while (line != null);

                    _body = result;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("File {0} could not be read. <br><br>" + ex.StackTrace, tokenFilename));
                }
            }

        }
        public void SetTokenValue(string token, string value)
        {
            if (_scancomplete == false)
            {
                ScanDocument();
            }
            string searchToken = "%" + token + "%";
            if (_body.IndexOf(searchToken, StringComparison.Ordinal) <= 0)
                throw new ETokenNotFound(token);
            _body = _body.Replace(searchToken, value);
        }
        public void ScanDocument()
        {
            var re = new Regex("%.*?%", RegexOptions.IgnoreCase);
            var matchList = re.Matches(Body);
            foreach (Match d in matchList)
            {
                if (!_tokens.Contains(d.Value))
                {
                    _tokens.Add(d.Value);
                }
            }
            _scancomplete = true;
        }
    }

    public class ETokenNotFound : Exception
    {
        public ETokenNotFound(string token): base("Token '" + token + "' not found.") { }
        
    }
}
