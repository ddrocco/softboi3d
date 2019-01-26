using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitDict {
    public delegate string Trait();

    public static string Null() {
        return null;
    }

    public static string Overweight() {
        return "Overweight.";
    }

    public static string Thin() {
        return "Average weight.";
    }

    public static string GreenAccent() {
        return "Green accent around neck.";
    }

    public static string BlueColor() {
        return "Blue body.";
    }

    public static string RedColor() {
        return "Red body.";
    }

    public static string PurpleColor() {
        return "Purple body.";
    }

    public static string WhiteColor() {
        return "White body.";
    }

    public static string BigTeeth() {
        return "Big teeth.";
    }

    public static string SmallTeeth() {
        return "Small teeth.";
    }

    public static string Intelligent() {
        return "Smarter than most Softbois.";
    }

    public static string Aggressive() {
        return "An aggressive nature.";
    }

    public static string Docile() {
        return "A calm, docile nature.";
    }

    public static string ElephantFeet() {
        return "Bigass feet that look like elephant feet.";
    }

    public static string ToedFeet() {
        return "Tiny feet with tiny toes.";
    }

    public static string WebbedFeet() {
        return "Webbed feet.";
    }

    public static string LongTail() {
        return "Long tail.";
    }

    public static string ShortTail() {
        return "Short tail.";
    }

    public static string NoTail() {
        return "No tail.";
    }
    
    public static readonly Dictionary<string, Trait> traitsMap
            = new Dictionary<string, Trait>
    {
        {"Null", new Trait(Null)},
        //Weight
        {"Overweight", new Trait(Overweight)},
        {"Thin", new Trait(Thin)},
        //Teeth
        {"BigTeeth", new Trait(BigTeeth)},
        {"SmallTeeth", new Trait(SmallTeeth)},
        //Personality
        {"Aggressive", new Trait(Aggressive)},
        {"Docile", new Trait(Docile)},
        {"Intelligent", new Trait(Intelligent)},
        //Feet
        {"ElephantFeet", new Trait(ElephantFeet)},
        {"ToedFeet", new Trait(ToedFeet)},
        {"WebbedFeet", new Trait(WebbedFeet)},
        //Tail
        {"LongTail", new Trait(LongTail)},
        {"ShortTail", new Trait(ShortTail)},
        {"NoTail", new Trait(NoTail)},
        //Color
        {"BlueColor", new Trait(BlueColor)},
        {"PurpleColor", new Trait(PurpleColor)},
        {"RedColor", new Trait(RedColor)},
        {"WhiteColor", new Trait(WhiteColor)},
        {"GreenAccent", new Trait(GreenAccent)},
    };
}