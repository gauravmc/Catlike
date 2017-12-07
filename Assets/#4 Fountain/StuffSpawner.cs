using UnityEngine;

public class StuffSpawner : MonoBehaviour {
	public float timeBetweenSpawns;
	public Stuff[] stuffPrefabs;
	public float particleVelocity;

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
		Stuff randomNucleon = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
		Stuff spawn = Instantiate(randomNucleon);
		spawn.transform.localPosition = transform.position;
		spawn.Body.velocity = transform.up * particleVelocity;
	}
}
