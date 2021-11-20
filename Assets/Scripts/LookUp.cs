using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public static class LookUp
    {
        public static PlayerInput PlayerInput { get; set; }
        public static DialogController DialogController { get; set; }
        public static MessageHub MessageHub { get; set; }
        public static InventorySystem InventorySystem { get; set; }
    }
}