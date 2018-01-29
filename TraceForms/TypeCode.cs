using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    class TypeCode
    {
        public TypeCode() { }

        public TypeCode(string type, string code)
        {
            Code = code;
        }

        public string Type { get; set; }
        public string Code { get; set; }
    }

    class TypeCodeName : CodeName
    {
        public TypeCodeName() { }

        public TypeCodeName(string type, string code) 
        {
            Type = type;
            Code = code;
        }

        public TypeCodeName(string type, string code, string name) : base(code, name)
        {
            Type = type;
        }

        public string Type { get; set; }
    }

}
