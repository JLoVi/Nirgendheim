using UnityEngine;
using System.Collections;

public class vertices : MonoBehaviour {



		public GameObject model;


		void Start()
		{
			CreateBoundingCube();
		}
		void CreateBoundingCube()
		{
			Bounds bBox = CalculateBoundingBox(model);
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = bBox.center;
			cube.transform.localScale = bBox.size;
		Debug.Log (bBox);

		}
		public static Bounds CalculateBoundingBox(GameObject aObj)
		{
			if (aObj == null)
			{
				Debug.LogError("CalculateBoundingBox: object is null");
				return new Bounds(Vector3.zero, Vector3.one);
			}
			Transform myTransform = aObj.transform;
			Mesh mesh = null;
			MeshFilter mF = aObj.GetComponent<MeshFilter>();
			if (mF != null)
				mesh = mF.mesh;
			else
			{
				SkinnedMeshRenderer sMR = aObj.GetComponent<SkinnedMeshRenderer>();
				if (sMR != null)
					mesh = sMR.sharedMesh;
			}
			if (mesh == null)
			{
				Debug.LogError("CalculateBoundingBox: no mesh found on the given object");
				return new Bounds(aObj.transform.position, Vector3.one);
			}
			Vector3[] vertices = mesh.vertices;
			if (vertices.Length <=0)
			{
				Debug.LogError("CalculateBoundingBox: mesh doesn't have vertices");
				return new Bounds(aObj.transform.position, Vector3.one);
			}
			Vector3 min, max;
			min = max = myTransform.TransformPoint(vertices[0]);
			for (int i = 1; i < vertices.Length; i++)
			{
				Vector3 V = myTransform.TransformPoint(vertices[i]);
				for (int n = 0; n < 3; n++)
				{
					if (V[n] > max[n])
						max[n] = V[n];
					if (V[n] < min[n])
						min[n] = V[n];
				}
			}
			Bounds B = new Bounds();
			B.SetMinMax(min, max);
			return B;

			
		}
	}