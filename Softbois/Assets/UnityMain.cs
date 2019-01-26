using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMain : MonoBehaviour {
	
	public List<Genome> genomes = new List<Genome>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ConstructGenome() {
		Genome genome = GenomeRandomizer.GenerateRandomGenome();
		genome.PrintGenome();
		genomes.Add(genome);
	}

	public void ConstructGenomesAndFuck() {
		Genome genome1 = GenomeRandomizer.GenerateRandomGenome();
		genome1.PrintGenome();
		genomes.Add(genome1);
		Genome genome2 = GenomeRandomizer.GenerateRandomGenome();
		genome2.PrintGenome();
		genomes.Add(genome2);
		Genome genome3 = genome1.BreedWith(genome2);
		genome3.PrintGenome();
		genomes.Add(genome3);
	}
}
