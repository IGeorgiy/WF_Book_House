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

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        public void CreateObjects()
        {
            livingRoom.Exits = new Location[] { frontYard, dinningRoom };
            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { dinningRoom, backYard };
            frontYard.Exits = new Location[] { backYard, garden };

        }
    }
}
