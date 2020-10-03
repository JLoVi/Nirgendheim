﻿using UnityEngine;
using System.Collections;

public class offset : MonoBehaviour {

	public float scrollSpeed = 0.5F;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_NormalMap", new Vector2(offset, 0));
	}
}