using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Book_House
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;
        private Location doorLocation;
        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }
        public Location DoorLocation
        {
            get
            {
                for (int i = 0; i < base.Exits.Length; i++)
                {
                    if (base.Exits[i] is OutsideWithDoor)
                        return base.Exits[i];
                }
                return doorLocation;
            }
        }
    }
}
