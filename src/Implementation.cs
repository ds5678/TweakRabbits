using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Harmony;

namespace TweakRabbits
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }

    [HarmonyPatch(typeof(BaseAi), "Stun")]
    public class TweakRabbitsStunDuration
    {
        public static void Prefix(BaseAi __instance)
        {
            if (__instance.m_AiRabbit != null && Settings.options.stunDuration >= 0f)
            {
                //MelonLogger.Log("TweakRabbits: stun duration {0}", __instance.m_StunSeconds);
                __instance.m_StunSeconds = Settings.options.stunDuration;
            }
        }

        public static void Postfix(BaseAi __instance)
        {
            if (__instance.m_AiRabbit != null && Settings.options.killOnHit)
            {
                __instance.EnterDead();
            }
        }
    }
}
