using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Book_House
{
    abstract class Location
    {
        public Location(string name)
        {
            Name = name;
        }
        public Location[] Exits;
        public string Name;
        public virtual string Description
        {
            get
            {
                string description = "Вы находитесь в " + Name + ". Вы видите двери, ведущие в: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}
