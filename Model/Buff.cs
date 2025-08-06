using System;
using System.Collections.Generic;
using System.Drawing;
using TriangleAuto.Utils;

namespace TriangleAuto.Model
{
    internal class Buff
    {
        public String name { get; set; }
        public EffectStatusIDs effectStatusID { get; set; }
        public Bitmap icon { get; set; }

        public Buff(string name, EffectStatusIDs effectStatus, Bitmap icon)
        {
            this.name = name;
            this.effectStatusID = effectStatus;
            this.icon = icon;
        }

        //--------------------- SKILLS ------------------------------

        //Archer Skills
        public static List<Buff> GetArcherSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Concentration", EffectStatusIDs.CONCENTRATION, Resources.TriangleAuto.Icons.ac_concentration),
                new Buff("Wind Walk", EffectStatusIDs.WINDWALK, Resources.TriangleAuto.Icons.sn_windwalk),
                new Buff("True Sight", EffectStatusIDs.TRUESIGHT, Resources.TriangleAuto.Icons.sn_sight),
                new Buff("Ilimitar", EffectStatusIDs.UNLIMIT, Resources.TriangleAuto.Icons.Ilimitar),
                new Buff("A Poem of Bragi", EffectStatusIDs.POEMBRAGI, Resources.TriangleAuto.Icons.poem_of_bragi),
                new Buff("Windmill Rush", EffectStatusIDs.RUSH_WINDMILL, Resources.TriangleAuto.Icons.windmill_rush),
                new Buff("Moonlight Serenade", EffectStatusIDs.MOONLIT_SERENADE, Resources.TriangleAuto.Icons.moonlight_serenade),
                new Buff("Frigg's Song", EffectStatusIDs.FRIGG_SONG, Resources.TriangleAuto.Icons.friggs_song)
            };

            return skills;
        }

        //Swordsman Skills
        public static List<Buff> GetSwordmanSkill()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Endure", EffectStatusIDs.ENDURE, Resources.TriangleAuto.Icons.sm_endure),
                new Buff("Auto Beserk", EffectStatusIDs.AUTOBERSERK, Resources.TriangleAuto.Icons.sm_autoberserk),
                new Buff("Guard", EffectStatusIDs.AUTOGUARD, Resources.TriangleAuto.Icons.cr_autoguard),
                new Buff("Shield Reflection", EffectStatusIDs.REFLECTSHIELD, Resources.TriangleAuto.Icons.cr_reflectshield),
                new Buff("Spear Quicken", EffectStatusIDs.SPEARQUICKEN, Resources.TriangleAuto.Icons.cr_spearquicken),
                new Buff("Defending Aura", EffectStatusIDs.DEFENDER, Resources.TriangleAuto.Icons.cr_defender),
                new Buff("Dedication", EffectStatusIDs.LKCONCENTRATION, Resources.TriangleAuto.Icons.lk_concentration),
                new Buff("Frenzy", EffectStatusIDs.BERSERK, Resources.TriangleAuto.Icons.lk_berserk),
                new Buff("Twohand Quicken", EffectStatusIDs.TWOHANDQUICKEN, Resources.TriangleAuto.Icons.mer_quicken),
                new Buff("Parry", EffectStatusIDs.PARRYING, Resources.TriangleAuto.Icons.ms_parrying),
                new Buff("Aura Blade", EffectStatusIDs.AURABLADE, Resources.TriangleAuto.Icons.lk_aurablade),
                new Buff("Enchant Blade", EffectStatusIDs.ENCHANT_BLADE, Resources.TriangleAuto.Icons.enchant_blade),
                new Buff("Shrink", EffectStatusIDs.CR_SHRINK, Resources.TriangleAuto.Icons.cr_shrink),
                new Buff("Inspiration", EffectStatusIDs.INSPIRATION, Resources.TriangleAuto.Icons.lg_inspiration),
                new Buff("Prestige", EffectStatusIDs.PRESTIGE, Resources.TriangleAuto.Icons.lg_prestige),
                new Buff("Shield Spell", EffectStatusIDs.SHIELDSPELL, Resources.TriangleAuto.Icons.lg_shieldspell),
                new Buff("Vanguard Force", EffectStatusIDs.FORCEOFVANGUARD, Resources.TriangleAuto.Icons.vanguard_force),
                new Buff("Servant Weapon", EffectStatusIDs.SERVANTWEAPON, Resources.TriangleAuto.Icons.servant_weapon),
                new Buff("Reflect Damage", EffectStatusIDs.REFLECTDAMAGE, Resources.TriangleAuto.Icons.reflect_damage),
            };

            return skills;
        }

        //Mage Skills
        public static List<Buff> GetMageSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Energy Coat", EffectStatusIDs.ENERGYCOAT, Resources.TriangleAuto.Icons.mg_energycoat),
                new Buff("Sight Blaster", EffectStatusIDs.SIGHTBLASTER, Resources.TriangleAuto.Icons.wz_sightblaster),
                new Buff("Autospell", EffectStatusIDs.AUTOSPELL, Resources.TriangleAuto.Icons.sa_autospell),
                new Buff("Double Casting", EffectStatusIDs.DOUBLECASTING, Resources.TriangleAuto.Icons.pf_doublecasting),
                new Buff("Memorize", EffectStatusIDs.MEMORIZE, Resources.TriangleAuto.Icons.pf_memorize),
                new Buff("Telekinesis Intense", EffectStatusIDs.TELEKINESIS_INTENSE, Resources.TriangleAuto.Icons.telecinese),
                new Buff("Amplification", EffectStatusIDs.MYST_AMPLIFY, Resources.TriangleAuto.Icons.amplify),
                new Buff("Recognized Spell", EffectStatusIDs.RECOGNIZEDSPELL, Resources.TriangleAuto.Icons.recognized_spell)
            };

            return skills;
        }

        //Merchant Skills
        public static List<Buff> GetMerchantSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Crazy Uproar", EffectStatusIDs.CRAZY_UPROAR, Resources.TriangleAuto.Icons.mc_loud),
                new Buff("Power-Thrust", EffectStatusIDs.OVERTHRUST, Resources.TriangleAuto.Icons.bs_overthrust),
                new Buff("Adrenaline Rush", EffectStatusIDs.ADRENALINE, Resources.TriangleAuto.Icons.bs_adrenaline),
                new Buff("Advanced Adrenaline Rush", EffectStatusIDs.ADRENALINE2, Resources.TriangleAuto.Icons.bs_adrenaline2),
                new Buff("Maximum Power-Thrust", EffectStatusIDs.OVERTHRUSTMAX, Resources.TriangleAuto.Icons.ws_overthrustmax),
                new Buff("Weapon Perfection", EffectStatusIDs.WEAPONPERFECT, Resources.TriangleAuto.Icons.bs_weaponperfect),
                new Buff("Power Maximize", EffectStatusIDs.MAXIMIZE, Resources.TriangleAuto.Icons.bs_maximize),
                new Buff("Cart Boost", EffectStatusIDs.CARTBOOST, Resources.TriangleAuto.Icons.ws_cartboost),
                new Buff("Meltdown", EffectStatusIDs.MELTDOWN, Resources.TriangleAuto.Icons.ws_meltdown),
                new Buff("Acceleration", EffectStatusIDs.ACCELERATION, Resources.TriangleAuto.Icons.mec_acceleration),
                new Buff("Cart Boost", EffectStatusIDs.GN_CARTBOOST, Resources.TriangleAuto.Icons.cart_boost),
                new Buff("Research Report", EffectStatusIDs.RESEARCHREPORT, Resources.TriangleAuto.Icons.researchreport)
            };

            return skills;
        }

        //Thief Skills
        public static List<Buff> GetThiefSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Poison React", EffectStatusIDs.POISONREACT, Resources.TriangleAuto.Icons.as_poisonreact),
                new Buff("Reject Sword", EffectStatusIDs.SWORDREJECT, Resources.TriangleAuto.Icons.st_rejectsword),
                new Buff("Preserve", EffectStatusIDs.PRESERVE, Resources.TriangleAuto.Icons.st_preserve),
                new Buff("Enchant Deadly Poison", EffectStatusIDs.EDP, Resources.TriangleAuto.Icons.asc_edp),
                new Buff("Weapon Blocking", EffectStatusIDs.WEAPONBLOCKING, Resources.TriangleAuto.Icons.weapon_blocking)
            };

            return skills;
        }

        //Acolyte Skills
        public static List<Buff> GetAcolyteSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Gloria", EffectStatusIDs.GLORIA, Resources.TriangleAuto.Icons.pr_gloria),
                new Buff("Magnificat", EffectStatusIDs.MAGNIFICAT, Resources.TriangleAuto.Icons.pr_magnificat),
                new Buff("Angelus", EffectStatusIDs.ANGELUS, Resources.TriangleAuto.Icons.al_angelus),
                new Buff("Rising Dragon", EffectStatusIDs.RAISINGDRAGON, Resources.TriangleAuto.Icons.rising_dragon),
                new Buff("Firm Faith", EffectStatusIDs.FIRM_FAITH, Resources.TriangleAuto.Icons.firm_faith),
                new Buff("Powerful Faith", EffectStatusIDs.POWERFUL_FAITH, Resources.TriangleAuto.Icons.powerful_faith),
                new Buff("Gentle Touch-Revitalize", EffectStatusIDs.GENTLETOUCH_REVITALIZE, Resources.TriangleAuto.Icons.gentle_touch_revitalize),
                new Buff("Gentle Touch-Convert", EffectStatusIDs.GENTLETOUCH_CHANGE, Resources.TriangleAuto.Icons.gentle_touch_convert),
                new Buff("Fury ", EffectStatusIDs.FURY, Resources.TriangleAuto.Icons.fury),
                new Buff("Impositio Manus",  EffectStatusIDs.IMPOSITIO, Resources.TriangleAuto.Icons.impositio_manus),
            };

            return skills;
        }

        //Ninja Skills
        public static List<Buff> GetNinjaSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Cicada Skin Shed", EffectStatusIDs.PEEL_CHANGE, Resources.TriangleAuto.Icons.nj_utsusemi),
                new Buff("Ninja Aura", EffectStatusIDs.AURA_NINJA, Resources.TriangleAuto.Icons.nj_nen),
                new Buff("Izayoi", EffectStatusIDs.IZAYOI, Resources.TriangleAuto.Icons.izayoi)
            };

            return skills;
        }

        //Taekwon Skills
        public static List<Buff> GetTaekwonSkills()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Mild Wind (Earth)", EffectStatusIDs.PROPERTYGROUND, Resources.TriangleAuto.Icons.tk_mild_earth),
                new Buff("Mild Wind (Fire)", EffectStatusIDs.PROPERTYFIRE, Resources.TriangleAuto.Icons.tk_mild_fire),
                new Buff("Mild Wind (Water)", EffectStatusIDs.PROPERTYWATER, Resources.TriangleAuto.Icons.tk_mild_water),
                new Buff("Mild Wind (Wind)", EffectStatusIDs.PROPERTYWIND, Resources.TriangleAuto.Icons.tk_mild_wind),
                new Buff("Mild Wind (Ghost)", EffectStatusIDs.PROPERTYTELEKINESIS, Resources.TriangleAuto.Icons.tk_mild_ghost),
                new Buff("Mild Wind (Holy)", EffectStatusIDs.ASPERSIO, Resources.TriangleAuto.Icons.tk_mild_holy),
                new Buff("Mild Wind (Shadow)", EffectStatusIDs.PROPERTYDARK, Resources.TriangleAuto.Icons.tk_mild_shadow),
                new Buff("Tumbling", EffectStatusIDs.DODGE_ON, Resources.TriangleAuto.Icons.tumbling)
            };

            return skills;
        }


        public static List<Buff> GetGunsSkills()
        {
            List<Buff> skills = new List<Buff>();

            skills.Add(new Buff("Gatling Fever", EffectStatusIDs.GATLINGFEVER, Resources.TriangleAuto.Icons.gatling_fever));
            skills.Add(new Buff("Madness Canceller", EffectStatusIDs.MADNESSCANCEL, Resources.TriangleAuto.Icons.madnesscancel));
            skills.Add(new Buff("Adjustment", EffectStatusIDs.ADJUSTMENT, Resources.TriangleAuto.Icons.adjustment));
            skills.Add(new Buff("Increase Accuracy", EffectStatusIDs.ACCURACY, Resources.TriangleAuto.Icons.increase_accuracy));

            return skills;
        }


        //--------------------- STUFFS ------------------------------
        //--------------------- Potions ------------------------------
        public static List<Buff> GetPotionsBuffs()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Concentration Potion", EffectStatusIDs.CONCENTRATION_POTION, Resources.TriangleAuto.Icons.concentration_potiongif),
                new Buff("Awakening Potion", EffectStatusIDs.AWAKENING_POTION, Resources.TriangleAuto.Icons.awakening_potion),
                new Buff("Berserk Potion", EffectStatusIDs.BERSERK_POTION, Resources.TriangleAuto.Icons.berserk_potion),
                new Buff("Regeneration Potion", EffectStatusIDs.REGENERATION_POTION, Resources.TriangleAuto.Icons.regeneration),
                new Buff("HP Increase Potion", EffectStatusIDs.HP_INCREASE_POTION_LARGE, Resources.TriangleAuto.Icons.ghp),
                new Buff("SP Increase Potion", EffectStatusIDs.SP_INCREASE_POTION_LARGE, Resources.TriangleAuto.Icons.gsp),
                new Buff("Red Herb Activator", EffectStatusIDs.RED_HERB_ACTIVATOR, Resources.TriangleAuto.Icons.red_herb_activator),
                new Buff("Blue Herb Activator", EffectStatusIDs.BLUE_HERB_ACTIVATOR, Resources.TriangleAuto.Icons.blue_herb_activator),
                new Buff("Golden X", EffectStatusIDs.REF_T_POTION, Resources.TriangleAuto.Icons.Golden_X), 
                new Buff("Energy Drink", EffectStatusIDs.ENERGY_DRINK_RESERCH, Resources.TriangleAuto.Icons.energetic_drink),
                new Buff("Mega Resist Potion", EffectStatusIDs.TARGET_BLOOD, Resources.TriangleAuto.Icons.mega_resist_potion),
                new Buff("Full SwingK Potion", EffectStatusIDs.FULL_SWINGK, Resources.TriangleAuto.Icons.swing_k),
                new Buff("Mana Plus Potion", EffectStatusIDs.MANA_PLUS, Resources.TriangleAuto.Icons.mana_plus),
                new Buff("Blessing Of Tyr", EffectStatusIDs.BASICHIT, Resources.TriangleAuto.Icons.blessing_of_tyr)
            };

            return skills;
        }

        public static List<Buff> GetElementalsBuffs()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Fire Conversor", EffectStatusIDs.PROPERTYFIRE, Resources.TriangleAuto.Icons.ele_fire_converter),
                new Buff("Wind Conversor", EffectStatusIDs.PROPERTYWIND, Resources.TriangleAuto.Icons.ele_wind_converter),
                new Buff("Earth Conversor", EffectStatusIDs.PROPERTYGROUND, Resources.TriangleAuto.Icons.ele_earth_converter),
                new Buff("Water Conversor", EffectStatusIDs.PROPERTYWATER, Resources.TriangleAuto.Icons.ele_water_converter),
                new Buff("Cursed Water", EffectStatusIDs.PROPERTYDARK, Resources.TriangleAuto.Icons.cursed_water),
                new Buff("Fireproof Potion", EffectStatusIDs.RESIST_PROPERTY_FIRE, Resources.TriangleAuto.Icons.fireproof),
                new Buff("Waterproof Potion", EffectStatusIDs.RESIST_PROPERTY_WATER, Resources.TriangleAuto.Icons.coldproof),
                new Buff("Windproof Potion", EffectStatusIDs.RESIST_PROPERTY_WIND, Resources.TriangleAuto.Icons.thunderproof),
                new Buff("Earthproof Potion", EffectStatusIDs.RESIST_PROPERTY_GROUND, Resources.TriangleAuto.Icons.earhproof)
            };

            return skills;
        }

        public static List<Buff> GetFoodBuffs()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("STR Food", EffectStatusIDs.FOOD_STR, Resources.TriangleAuto.Icons.strfood),
                new Buff("AGI Food", EffectStatusIDs.FOOD_AGI, Resources.TriangleAuto.Icons.agi_food),
                new Buff("VIT Food", EffectStatusIDs.FOOD_VIT, Resources.TriangleAuto.Icons.vit_food),
                new Buff("INT Food", EffectStatusIDs.FOOD_INT, Resources.TriangleAuto.Icons.int_food),
                new Buff("DEX Food", EffectStatusIDs.FOOD_DEX, Resources.TriangleAuto.Icons.dex_food),
                new Buff("LUK Food", EffectStatusIDs.FOOD_LUK, Resources.TriangleAuto.Icons.luk_food),

                new Buff("3RD STR Food", EffectStatusIDs.STR_3RD_FOOD, Resources.TriangleAuto.Icons.str_3rd_food),
                new Buff("3RD AGI Food", EffectStatusIDs.AGI_3RD_FOOD, Resources.TriangleAuto.Icons.agi_3rd_food),
                new Buff("3RD VIT Food", EffectStatusIDs.VIT_3RD_FOOD, Resources.TriangleAuto.Icons.vit_3rd_food),
                new Buff("3RD INT Food", EffectStatusIDs.INT_3RD_FOOD, Resources.TriangleAuto.Icons.int_3rd_food),
                new Buff("3RD DEX Food", EffectStatusIDs.DEX_3RD_FOOD, Resources.TriangleAuto.Icons.dex_3rd_food),
                new Buff("3RD LUK Food", EffectStatusIDs.LUK_3RD_FOOD, Resources.TriangleAuto.Icons.luk_3rd_food),
                new Buff("Almighty", EffectStatusIDs.RWC_2011_SCROLL, Resources.TriangleAuto.Icons.almighty),
                new Buff("CASH Food", EffectStatusIDs.FOOD_VIT_CASH, Resources.TriangleAuto.Icons.cash_food),
            };


            return skills;
        }

        public static List<Buff> GetBoxesBuffs()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("Drowsiness Box", EffectStatusIDs.DROWSINESS_BOX, Resources.TriangleAuto.Icons.drowsiness),
                new Buff("Resentment Box", EffectStatusIDs.RESENTMENT_BOX, Resources.TriangleAuto.Icons.resentment),
                new Buff("Sunlight Box", EffectStatusIDs.SUNLIGHT_BOX, Resources.TriangleAuto.Icons.sunbox),
                new Buff("Box of Gloom", EffectStatusIDs.CONCENTRATION, Resources.TriangleAuto.Icons.gloom),
                new Buff("Box of Thunder", EffectStatusIDs.BOX_OF_THUNDER, Resources.TriangleAuto.Icons.speed),
                new Buff("Speed Potion / Guyak", EffectStatusIDs.SPEED_POT, Resources.TriangleAuto.Icons.speedpotion),
                new Buff("Anodyne", EffectStatusIDs.ENDURE, Resources.TriangleAuto.Icons.anodyne),
                new Buff("Aloevera", EffectStatusIDs.PROVOKE, Resources.TriangleAuto.Icons.aloevera),
                new Buff("Abrasivo", EffectStatusIDs.CRITICALPERCENT, Resources.TriangleAuto.Icons.abrasive),
                new Buff("Combat Pill", EffectStatusIDs.COMBAT_PILL, Resources.TriangleAuto.Icons.combat_pill),
                new Buff("Celermine Juice", EffectStatusIDs.ENRICH_CELERMINE_JUICE, Resources.TriangleAuto.Icons.celermine)
            };

            return skills;
        }

        public static List<Buff> GetScrollBuffs()
        {
            List<Buff> skills = new List<Buff>
            {

                new Buff("Increase Agility Scroll", EffectStatusIDs.INC_AGI, Resources.TriangleAuto.Icons.al_incagi1),
                new Buff("Bless Scroll", EffectStatusIDs.BLESSING, Resources.TriangleAuto.Icons.al_blessing1),
                new Buff("Full Chemical Protection (Scroll)", EffectStatusIDs.PROTECTARMOR, Resources.TriangleAuto.Icons.cr_fullprotection),
                new Buff("Link Scroll", EffectStatusIDs.SOULLINK, Resources.TriangleAuto.Icons.sl_soullinker),
                new Buff("Monster Transform",  EffectStatusIDs.MONSTER_TRANSFORM, Resources.TriangleAuto.Icons.mob_transform),
                new Buff("Assumptio",  EffectStatusIDs.ASSUMPTIO, Resources.TriangleAuto.Icons.assumptio),

            };

            return skills;
        }

        public static List<Buff> GetETCBuffs()
        {
            List<Buff> skills = new List<Buff>
            {
                new Buff("THURISAZ Rune", EffectStatusIDs.THURISAZ, Resources.TriangleAuto.Icons.THURISAZ),
                new Buff("OTHILA Rune", EffectStatusIDs.OTHILA, Resources.TriangleAuto.Icons.OTHILA),
                new Buff("HAGALAZ Rune", EffectStatusIDs.HAGALAZ, Resources.TriangleAuto.Icons.HAGALAZ),
                new Buff("LUX AMINA Rune", EffectStatusIDs.LUX_AMINA, Resources.TriangleAuto.Icons.LUX_AMINA),
                new Buff("Cat Can", EffectStatusIDs.OVERLAPEXPUP, Resources.TriangleAuto.Icons.cat_can),
                new Buff("Bubble Gum", EffectStatusIDs.CASH_RECEIVEITEM, Resources.TriangleAuto.Icons.he_bubble_gum),
                new Buff("Battle Manual", EffectStatusIDs.CASH_PLUSEXP, Resources.TriangleAuto.Icons.combat_manual)
            };

            return skills;
        }

    }
}
