using UnityEngine;

public class StuffSpawner : MonoBehaviour {
	[SerializeField]
	private FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
	public float particleVelocity;
	public Stuff[] stuffPrefabs;
	public Material stuffMaterial;

	private float timeSinceLastSpawn;
	private float currentSpawnDelay;

	private void Awake() {
		timeSinceLastSpawn = 0;
		currentSpawnDelay = timeBetweenSpawns.RandomInRange;
	}

	private void FixedUpdate() {
		if (timeSinceLastSpawn >= currentSpawnDelay) {
			SpawnStuff();
			timeSinceLastSpawn = 0;
			currentSpawnDelay = timeBetweenSpawns.RandomInRange;
		} else {
			timeSinceLastSpawn += Time.deltaTime;
		}
	}

	private void SpawnStuff() {
		Stuff randomStuff = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
		Stuff spawn = Instantiate(randomStuff);
		spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
		spawn.transform.localPosition = transform.position;
		spawn.transform.localScale = Vector3.one * scale.RandomInRange;
		spawn.transform.localRotation = Random.rotation;

		spawn.Body.velocity = transform.up * particleVelocity + Random.onUnitSphere * randomVelocity.RandomInRange;
		spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
	}

	[System.Serializable]
	private struct FloatRange {
		public float min, max;

		public float RandomInRange {
			get {
				return Random.Range(min, max);
			}
		}
	}
}
