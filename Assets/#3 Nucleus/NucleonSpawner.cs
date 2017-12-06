using UnityEngine;

public class NucleonSpawner : MonoBehaviour {
	public float timeBetweenSpawns;
	public float spawnDistance;
	public Nucleon[] nucleonPrefabs;

	private float timeSinceLastSpawn;

	private void Awake() {
		timeSinceLastSpawn = 0;
	}

	private void FixedUpdate() {
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			SpawnNucleon();
			timeSinceLastSpawn = 0;
		} else {
			timeSinceLastSpawn += Time.deltaTime;
		}
	}

	private void SpawnNucleon() {
		Nucleon randomNucleon = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
		Nucleon spawn = Instantiate(randomNucleon);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}
}
