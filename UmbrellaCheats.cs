using BepInEx;
using UnityEngine;

namespace UmbrellaCheats
{
    [BepInPlugin("com.yourname.umbrella.cheats", "Umbrella Cheater", "1.0.0")]
    public class UmbrellaCheater : BaseUnityPlugin
    {
        void Update()
        {
            try
            {
                // === Infinite Health ===
                var player = GameObject.FindObjectOfType<PlayerHealth>();
                if (player != null)
                    player.currentHealth = player.maxHealth;

                // === Infinite Ammo ===
                var gun = GameObject.FindObjectOfType<GunController>();
                if (gun != null)
                    gun.currentAmmo = 999;

                // === No Reload ===
                if (gun != null)
                    gun.needsReload = false;

                // === Infinite Money ===
                var money = GameObject.FindObjectOfType<MoneyManager>();
                if (money != null)
                    money.amount = 999999;
            }
            catch { }
        }
    }
}
