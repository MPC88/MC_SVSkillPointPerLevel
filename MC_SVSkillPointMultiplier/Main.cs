using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace MC_SVSkillPointPerLevel
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "mc.starvalor.skillpointperlevel";
        public const string pluginName = "SV Skill Point Per Level";
        public const string pluginVersion = "1.0.0";

        public static ConfigEntry<float> pointsPerLevel;
        public static ConfigEntry<float> remainder;

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Main));

            pointsPerLevel = Config.Bind<float>("1. Settings",
                "Points per level: ",
                2.0f,
                "Skill points per level (can be decimal).");

            remainder = Config.Bind<float>("2. Memory",
                "Remainder",
                0.0f,
                "Do not edit manually.  Records partial skill points from decimal results after multiplication.");
        }

        [HarmonyPatch(typeof(PlayerCharacter), nameof(PlayerCharacter.LevelUP))]
        [HarmonyPostfix]
        private static void PlayerCharacterLevelUp_Post(PlayerCharacter __instance)
        {
            int pointsToAdd = Mathf.FloorToInt(pointsPerLevel.Value);
            float curRemainder = remainder.Value + (pointsPerLevel.Value - pointsToAdd);
            int remainderPoints = 0;

            if (curRemainder > 1)
                remainderPoints = Mathf.FloorToInt(curRemainder);

            pointsToAdd += remainderPoints;
            remainder.Value = curRemainder - remainderPoints;

            __instance.skillPoints += pointsToAdd - 1;
        }
    }
}
