using UnityEngine;

namespace EC2019.Entity
{
    public class Worm : MonoBehaviour
    {
        private int Id { get; set; }
        private int Health { get; set; }
        private Vector2 Position { get; set; }
        private Weapon Weapon { get; set; }
        private int DiggingRange { get; set; }
        private int MovementRange { get; set; }
        private string Profession { get; set; }
    }
}
