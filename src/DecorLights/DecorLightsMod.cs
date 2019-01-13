﻿using Database;
using Harmony;
using System.Collections.Generic;

namespace DecorLights
{
	public class DecorLightsMod
	{
		[HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
		public class DecorLightsBuildingsPatch
		{
			private static void Prefix()
			{
				Strings.Add("STRINGS.BUILDINGS.PREFABS.LAVALAMP.NAME", "Lava Lamp");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.LAVALAMP.DESC", "More light, more heat.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.LAVALAMP.EFFECT", STRINGS.BUILDINGS.PREFABS.CEILINGLIGHT.DESC);

				Strings.Add("STRINGS.BUILDINGS.PREFABS.SALTLAMP.NAME", "Salt Lamp");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.SALTLAMP.DESC", "Fake salt. Not edible. Do not lick.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.SALTLAMP.EFFECT", STRINGS.BUILDINGS.PREFABS.CEILINGLIGHT.DESC);

				Strings.Add("STRINGS.BUILDINGS.PREFABS.CEILINGLAMP.NAME", "Ceiling Lamp");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.CEILINGLAMP.DESC", "Like a normal ceiling light, but prettier.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.CEILINGLAMP.EFFECT", STRINGS.BUILDINGS.PREFABS.CEILINGLIGHT.DESC);

				ModUtil.AddBuildingToPlanScreen("Furniture", LavaLampConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Furniture", SaltLampConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Furniture", CeilingLampConfig.ID);
			}
		}

		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DecorLightsDbPatch
		{
			private static void Prefix()
			{
				List<string> ls = new List<string>(Techs.TECH_GROUPING["Luxury"]) { LavaLampConfig.ID, SaltLampConfig.ID, CeilingLampConfig.ID };
				Techs.TECH_GROUPING["Luxury"] = ls.ToArray();
			}
		}
	}
}