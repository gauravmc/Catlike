using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Cube : MonoBehaviour {
	public int xSize, ySize, zSize;

	private Mesh mesh;
	private Vector3[] vertices;

	private void Awake() {
		Generate();
	}

	private void Generate() {
		GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "Procedural Cube";
		vertices = new Vector3[CalculateNumberOfVertices()];
		StartCoroutine(CreateVertices());
//		CreateTriangles();
	}

	private int CalculateNumberOfVertices() {
		int cornerVertices = 8;
		int edgeVertices = (xSize + ySize + zSize - 3) * 4;
		int faceVertices = ((xSize - 1) * (ySize - 1) +
			(ySize - 1) * (zSize - 1) +
			(zSize - 1) * (xSize - 1)) * 2;

		return cornerVertices + edgeVertices + faceVertices;
	}

	private IEnumerator CreateVertices() {
		WaitForSeconds wait = new WaitForSeconds(0.05f);
		int v = 0;

		for (int y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++) {
				vertices[v++] = new Vector3(x, y, 0);
				yield return wait;
			}

			for (int z = 1; z <= zSize; z++) {
				vertices[v++] = new Vector3(xSize, y, z);
				yield return wait;
			}

			for (int x = xSize - 1; x >= 0; x--) {
				vertices[v++] = new Vector3(x, y, zSize);
				yield return wait;
			}

			for (int z = zSize - 1; z > 0; z--) {
				vertices[v++] = new Vector3(0, y, z);
				yield return wait;
			}
			yield return wait;
		}

		for (int x = 1; x < xSize; x++) {
			for (int z = 1; z < zSize; z++) {
				vertices[v++] = new Vector3(x, 0, z);
			}
		}

		for (int x = 1; x < xSize; x++) {
			for (int z = 1; z < zSize; z++) {
				vertices[v++] = new Vector3(x, ySize, z);
			}
		}

		mesh.vertices = vertices;
	}

//	private void CreateTriangles() {
//		int quads = (xSize * ySize + ySize * zSize + zSize * xSize) * 2;
//		int[] triangles = new int[quads * 6];
//		mesh.triangles = triangles;
//	}

	private void OnDrawGizmos() {
		if (vertices == null) {
			return;
		}

		Gizmos.color = Color.black;
		foreach(Vector3 vertex in vertices) {
			Gizmos.DrawSphere(vertex, 0.1f);
		}
	}
}
