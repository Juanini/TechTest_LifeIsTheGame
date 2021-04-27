using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GameConstants
    {
        // * =====================================================================================================================================
        // * WEAPONS

        public const int GUN_PARABOL    = 1;
        public const int GUN_BLACKHOLE  = 2;
        public const int GUN_EXTRA      = 3;

        // * =====================================================================================================================================
        // * DANCE TYPES

        public const int DANCE_TYPE_UNKOWN   = 0;
        public const int DANCE_TYPE_HOUSE    = 1;
        public const int DANCE_TYPE_MACARENA = 2;
        public const int DANCE_TYPE_HIP_HOP  = 3;

        public const string DANCE_NAME_HOUSE    = "Dance House";
        public const string DANCE_NAME_MACARENA = "Dance Macarena";
        public const string DANCE_NAME_HIP_HOP  = "Dance Hip Hop";

        // * =====================================================================================================================================
        // * TAG

        public const string TAG_WEAPON_DROP = "WeaponDrop";
        public const string TAG_VFX_GRAVITY_GLOW = "VFXGravityGlow";
        public const string TAG_VFX_EXPLOSION = "VFXExplosion";
        public const string TAG_FLOOR = "Floor";

        // * =====================================================================================================================================
        // * SCENES

        public static string SCENE_GAME = "Game";
        public static string SCENE_MAIN_MENU = "MainMenu";
        public static string SCENE_SPLASH = "SplashScreen";
    }
}
