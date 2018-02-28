using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
	class IdName
	{
		public IdName() { }
		public IdName(int? id)
		{
			Id = id;
		}

		public IdName(int? id, string name) : this(id)
		{
			Name = name;
		}

		public int? Id { get; set; }
		public string Name { get; set; }
		public string DisplayName
		{
			get {
				return Name;
			}
		}
	}
}
