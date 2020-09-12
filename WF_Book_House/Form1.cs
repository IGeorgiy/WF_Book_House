using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Book_House
{
    public partial class Form1 : Form
    {

        private RoomWithDoor livingRoom = new RoomWithDoor("Гостиная", "старинный ковер", "дубовая дверь с латунной ручкой");
        private Room dinningRoom = new Room("Столовая", "хрустальная люстра");
        private RoomWithDoor kitchen = new RoomWithDoor("Кухня", "плита из нержавеющей стали", "сетчатая дверь, ведущая на задний двор");
        private OutsideWithDoor frontYard = new OutsideWithDoor("Лужайка", false, "дубовая дверь с латунной ручкой");
        private Outside garden = new Outside("Сад", false);
        private OutsideWithDoor backYard = new OutsideWithDoor("Задний двор", true, "сетчатая дверь, ведущая на кухню");

        private Location currentLocation;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToNewLocation(livingRoom);
        }

        public void CreateObjects()
        {
            livingRoom.Exits = new Location[] { dinningRoom };
            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { dinningRoom };
            frontYard.Exits = new Location[] { garden, backYard };
            garden.Exits = new Location[] { frontYard, backYard };
            backYard.Exits = new Location[] { frontYard, garden };

            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToNewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            goThroughTheDoor.Visible = currentLocation is IHasExteriorDoor;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToNewLocation(exits.Items[exits.SelectedIndex] as Location);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor locationWithDoor = currentLocation as IHasExteriorDoor;
            MoveToNewLocation(locationWithDoor.DoorLocation);
        }
    }
}
