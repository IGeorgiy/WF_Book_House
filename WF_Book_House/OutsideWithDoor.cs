using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Book_House
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot, string doorDescription) : base(name, hot)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;
        private Location doorLocation;
        public string DoorDescription
        {
            get
            {
                if (base.Hot)
                {
                    return "Тут очень жарко";
                }
                return doorDescription;
            }
        }
        public Location DoorLocation
        {
            get
            {
                for(int i = 0; i < base.Exits.Length; i++)
                {
                    if (base.Exits[i] is RoomWithDoor)
                        return base.Exits[i];
                }
                return doorLocation;
            }
        }
    }
}
