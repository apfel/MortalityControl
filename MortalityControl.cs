// Copyright (c) 2021 apfel
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute and/or sublicense copies of
// the Software.
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using MelonLoader;
using ModThatIsNotMod.BoneMenu;
using UnityEngine;

public class MortalityControl : MelonMod
{
    private bool beMortal = true;
    private bool preferInstantDeath = true;

    private void performHealthTypeChange()
    {
        GameObject _object = GameObject.Find("[RigManager (Default Brett)]");
        if (_object == null)
        {
            LoggerInstance.Warning("Failed to find the rig manager.");
            return;
        }

        Player_Health health = _object.GetComponent<Player_Health>();
        if (health == null)
        {
            LoggerInstance.Warning("Failed to find the health component.");
            return;
        }

        health.healthMode = !beMortal ? Player_Health.HealthMode.Invincible : preferInstantDeath ? Player_Health.HealthMode.InsantDeath : Player_Health.HealthMode.Mortal;
    }

    private void updateBeMortal(bool yes)
    {
        beMortal = yes;
        performHealthTypeChange();
    }

    private void updatePreferInstantDeath(bool yes)
    {
        preferInstantDeath = yes;
        performHealthTypeChange();
    }

    public override void OnApplicationStart()
    {
        MelonPreferences_Category prefCategory = MelonPreferences.CreateCategory("MortalityControl", "Mortality Control");

        MelonPreferences_Entry<bool> mortalityEntry = prefCategory.CreateEntry<bool>("ToggleMortality", true, "Toggle mortality", "Whether to mortal-ize the player.");
        beMortal                                    = mortalityEntry.Value;
        mortalityEntry.OnValueChanged               += (_, _new) => updateBeMortal(_new);

        MelonPreferences_Entry<bool> instantDeathPreference = prefCategory.CreateEntry<bool>("PreferInstantDeath", preferInstantDeath, "Prefer instant death", "Whether the player should die instantly instead of having time for revenge.");
        preferInstantDeath                                  = instantDeathPreference.Value;
        instantDeathPreference.OnValueChanged               += (_, _new) => updatePreferInstantDeath(_new);

        MenuCategory category = ModThatIsNotMod.BoneMenu.MenuManager.CreateCategory("Mortality Control", Color.white);
        category.CreateBoolElement("Become mortal", Color.white, beMortal, (_new) => updateBeMortal(_new));
        category.CreateBoolElement("Prefer instant death", Color.white, beMortal, (_new) => updatePreferInstantDeath(_new));
    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName) => performHealthTypeChange();
}
