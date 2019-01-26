using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome {
    private List<TraitDict.Trait> traits = new List<TraitDict.Trait>();
    private Dictionary<string, GeneReader.BinomialAlleles> genome = new Dictionary<string, GeneReader.BinomialAlleles>();

    public void AddTrait(string traitSetName, GeneReader.BinomialAlleles alleles) {
        genome[traitSetName] = alleles;
        string traitName = GeneReader.GetBinomialTrait(traitSetName, alleles);
        TraitDict.Trait trait = TraitDict.traitsMap[traitName];
        traits.Add(trait);
    }

    public void Clear() {
        traits.Clear();
    }
    
    public void PrintGenome() {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.AppendLine("This softboi has the following genes:");
        foreach (KeyValuePair<string, GeneReader.BinomialAlleles> gene in genome) {
            stringBuilder.Append("\t-");
            stringBuilder.Append(gene.Key);
            stringBuilder.Append(": ");
            stringBuilder.Append(gene.Value.ToString());
        }
        Debug.Log(stringBuilder.ToString());
    }

    public void PrintTraits() {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.AppendLine("This softboi has the following genetic traits:");
        foreach (TraitDict.Trait trait in traits) {
            if (trait() == null) {
                continue;
            }
            stringBuilder.Append("\t-");
            stringBuilder.AppendLine(trait());
        }
        Debug.Log(stringBuilder.ToString());
    }

    public Genome BreedWith(Genome mate) {
        Genome child = new Genome();
        foreach (string traitSetName in GeneReader.GetBinomialTraitNames()) {
            GeneReader.BinomialAlleles thisAlleles = genome[traitSetName];
            GeneReader.BinomialAlleles otherAlleles = mate.genome[traitSetName];
            GeneReader.BinomialAlleles childAlleles = GeneReader.Punnet(thisAlleles, otherAlleles);
            child.AddTrait(traitSetName, childAlleles);
        }
        return child;
    }
}