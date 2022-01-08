using HarmonyLib;

namespace Valheim.CumulativeLevelEffects;

[HarmonyPatch]
internal static class LevelEffects_SetupVisualization_Patch
{
    [HarmonyPatch(typeof(LevelEffects), nameof(LevelEffects.SetupLevelVisualization))]
    [HarmonyPostfix]
    private static void AddCumulativeLoop(LevelEffects __instance, int level)
    {
        if (level <= 1)
        {
            return;
        }

        for (int lvl = 2; lvl < level - 1; ++lvl)
        {
            int index = lvl - 2;

            if (index >= __instance.m_levelSetups?.Count)
            {
                break;
            }

            var levelSetup = __instance.m_levelSetups[index];

            if (levelSetup.m_enableObject)
            {
                Log.LogTrace($"Enabling {(level - 1)} star equipment: '{levelSetup.m_enableObject?.name}'");

                levelSetup.m_enableObject.SetActive(true);
            }
        }
    }
}
