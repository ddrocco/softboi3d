using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GeneReader {
    [System.Serializable]
    public struct PolyGenome
    {
        public BinomialTrait[] binomial;
    }

    [System.Serializable]
    public struct BinomialTrait
    {
        public string name;
        public string aa;
        public string ab;
        public string bb;
    }

    public enum BinomialAlleles {
        UNKNOWN,
        AA,
        AB,
        BB,
    }

    public enum Allele {
        UNKNOWN,
        A,
        B,
    }

    private static PolyGenome polyGenome = new PolyGenome();
    private static Dictionary<string, BinomialTrait> binomialTraitDict = new Dictionary<string, BinomialTrait>();
    private static List<string> binomialTraitNames = new List<string>();

    public GeneReader() {
        string binomial_genes_path = "Assets/Resources/BinomialGenes.json";
        StreamReader reader = new StreamReader(binomial_genes_path);
        string binomial_genes_json_dump = reader.ReadToEnd();
        reader.Close();
        polyGenome = JsonUtility.FromJson<PolyGenome>(binomial_genes_json_dump);
        foreach (BinomialTrait binomialTrait in polyGenome.binomial) {
            binomialTraitDict[binomialTrait.name] = binomialTrait;
            binomialTraitNames.Add(binomialTrait.name);
        }
    }

	public static string GetBinomialTrait(string traitName, BinomialAlleles alleles) {
        if (!binomialTraitDict.ContainsKey(traitName)) {
            return "N/A";
        }
        switch (alleles) {
            case (BinomialAlleles.AA):
                return binomialTraitDict[traitName].aa;
            case (BinomialAlleles.AB):
                return binomialTraitDict[traitName].ab;
            case (BinomialAlleles.BB):
                return binomialTraitDict[traitName].bb;
            default:
                return "N/A";
        }
    }

    public static string[] GetBinomialTraitNames() {
        if (binomialTraitNames.Count == 0) {
            GeneReader gene_reader = new GeneReader();
        }
        return binomialTraitNames.ToArray();
    }

    public static BinomialAlleles Punnet(BinomialAlleles a, BinomialAlleles b) {
        Allele aInherit = FromBinomial(a);
        Allele bInherit = FromBinomial(b);
        if (aInherit == bInherit) {
            if (aInherit == Allele.A) {
                return BinomialAlleles.AA;
            } else {
                return BinomialAlleles.BB;
            }
        } else {
            return BinomialAlleles.AB;
        }
    }

    public static Allele FromBinomial(BinomialAlleles alleles) {
        switch (alleles) {
            case (BinomialAlleles.AA):
                return Allele.A;
            case (BinomialAlleles.AB):
                return (Random.Range(0.0f, 1.0f) < 0.5f) ? Allele.A : Allele.B;
            case (BinomialAlleles.BB):
                return Allele.B;
            default:
                return Allele.UNKNOWN;
        }
    }
}
