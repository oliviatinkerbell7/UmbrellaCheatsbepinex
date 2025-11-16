using BepInEx;
using UnityEngine;

namespace UmbrellaCheats
{
    [BepInPlugin("com.yourname.umbrellacheats", "Umbrella Cheats", "1.0.0")]
    public class UmbrellaCheats : BaseUnityPlugin
    {
        // Toggle keys
        private KeyCode toggleHP = KeyCode.F1;
        private KeyCode toggleAmmo = KeyCode.F2;
        private KeyCode toggleMoney = KeyCode.F3;

        // Cheat states
        private bool infiniteHP = false;
        private bool infiniteAmmo = false;
        private bool infiniteMoney = false;

        void Update()
        {
            // Toggle cheats
            if (Input.GetKeyDown(toggleHP)) infiniteHP = !infiniteHP;
            if (Input.GetKeyDown(toggleAmmo)) infiniteAmmo = !infiniteAmmo;
            if (Input.GetKeyDown(toggleMoney)) infiniteMoney = !infiniteMoney;

            // Apply cheats to player
            var player = GameObject.FindWithTag("Player");
            if (player == null) return;

            if (infiniteHP)
            {
                var health = player.GetComponent<PlayerHealth>();
                if (health != null) health.currentHealth = health.maxHealth;
            }

            if (infiniteAmmo)
            {
                var weapon = player.GetComponent<PlayerWeapons>();
                if (weapon != null) weapon.currentAmmo = weapon.maxAmmo;
            }

            if (infiniteMoney)
            {
                var wallet = player.GetComponent<PlayerWallet>();
                if (wallet != null) wallet.money = 999999;
            }
        }
    }

    // Dummy classes to prevent compile errors if game uses different names
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth = 100;
        public int maxHealth = 100;
    }

    public class PlayerWeapons : MonoBehaviour
    {
        public int currentAmmo = 30;
        public int maxAmmo = 30;
    }

    public class PlayerWallet : MonoBehaviour
    {
        public int money = 0;
    }
}
