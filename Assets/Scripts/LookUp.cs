using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public static class LookUp
    {
        public static PlayerInput PlayerInput { get; set; }
        public static DialogController DialogController { get; set; }
        public static MessageHub MessageHub { get; set; }
        public static InventorySystem InventorySystem { get; set; }
        public static EventSystem EventSystem { get; set; }
        public static Transform AbuelaSpawnPoint { get; set; }
        public static GameObject Player { get; set; }
        public static GameObject PauseScreen { get; set; }
        public static DialogOptions DialogOptions { get; set; }
    }
}