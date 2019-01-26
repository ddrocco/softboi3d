using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomeRandomizer {

    public static Genome GenerateRandomGenome() {
        Genome genome = new Genome();
        foreach (string traitSetName in GeneReader.GetBinomialTraitNames()) {
            GeneReader.BinomialAlleles alleles = GetRandomBinomialAllele();
            genome.AddTrait(traitSetName, alleles);
        }
        return genome;
    }

    public static GeneReader.BinomialAlleles GetRandomBinomialAllele() {
        float f = Random.Range(0.0f, 1.0f);
        if (f < 0.25f) {
            return GeneReader.BinomialAlleles.AA;
        }
        else if (f < 0.75f) {
            return GeneReader.BinomialAlleles.AB;
        }
        else {
            return GeneReader.BinomialAlleles.BB;
        }
    }
}