using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Book_House
{
    class Outside : Location
    {
        public Outside(string name, bool hot) : base (name)
        {
            Hot = hot;
        }
        public bool Hot { get; private set; }

        public override string Description
        {
            get
            {
                string NewDescription = base.Description;
                if (Hot)
                    NewDescription += " Очень жарко.";
                return NewDescription;
            }
        }

    }
}
