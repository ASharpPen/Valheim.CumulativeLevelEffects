using BepInEx;
using HarmonyLib;

namespace Valheim.CumulativeLevelEffects;

[BepInPlugin("cumulative_level_effects", "Cumulative Level Effects", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    // Awake is called once when both the game and the plug-in are loaded
    void Awake()
    {
        Log.Logger = Logger;

        new Harmony("mod.cumulative_level_effects").PatchAll();
    }
}


