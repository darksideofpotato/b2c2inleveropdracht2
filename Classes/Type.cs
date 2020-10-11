using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Type
    {
        private int typeId;
        private string typeName;

        public Type(int _typeId, string _typeName)
        {
            this.typeId = _typeId;
            this.typeName = _typeName;
        }
    }
}