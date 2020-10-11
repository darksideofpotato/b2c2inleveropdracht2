using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Taste
    {
        private int tasteId;
        private string tasteName;

        public Taste(int _tasteId, string _tasteName)
        {
            this.tasteId = _tasteId;
            this.tasteName = _tasteName;
        }
    }
}