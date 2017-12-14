using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	private PooledObject prefab;
	private List<PooledObject> availableObjects = new List<PooledObject>();

	public static ObjectPool GetPool(PooledObject prefab) {
		GameObject obj = new GameObject(prefab.name + " Pool");
		DontDestroyOnLoad(obj);
		ObjectPool pool = obj.AddComponent<ObjectPool>();
		pool.prefab = prefab;
		return pool;
	}

	public PooledObject GetObject() {
		PooledObject obj;
		int lastAvailableIndex = availableObjects.Count - 1;

		if (lastAvailableIndex >= 0) {
			obj = availableObjects[lastAvailableIndex];
			availableObjects.RemoveAt(lastAvailableIndex);
			obj.gameObject.SetActive(true);
		} else {
			obj = Instantiate<PooledObject>(prefab);
			obj.transform.SetParent(transform, false);
			obj.Pool = this;
		}

		return obj;
	}

	public void AddObject(PooledObject obj) {
		obj.gameObject.SetActive(false);
		availableObjects.Add(obj);
	}
}
