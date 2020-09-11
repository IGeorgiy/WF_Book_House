using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Book_House
{
    class Room : Location
    {
        public Room(string name, string decoration) : base(name)
        {
            Decoration = decoration;
        }
        public string Decoration { get; private set; }
        public override string Description => base.Description + " Здесь вы видите "+Decoration;
    }
}
