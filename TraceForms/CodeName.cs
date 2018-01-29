using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    class CodeName
    {
        public CodeName() { }
        public CodeName(string code)
        {
            Code = code;
        }

        public CodeName(string code, string name) : this(code)
        {
            Name = name;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Name)) {
                    return Code ?? string.Empty;
                }
                else {
                    return $"{Code} ({Name})";
                }
            }
        }
    }
}
