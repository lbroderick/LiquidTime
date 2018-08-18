using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlSwirl : MonoBehaviour {
	public float speed;
	public float size;
	private float timer;
	public bool allowTimer;
	public int value;
	public GameObject Swirl3d;
	//public GameObject[] shapes;
	public Image FillCircle;

	public float ColorTimer;
	public bool allowColor;
	public Color TargetColor;

	public bool allowSize;
	public bool allowSpeed;
	public bool allowScale3dSwirl;
	public bool allowScale3dSwirl2;
	//public bool allowScaleShapes; //3.698387

	//public GameObject ShapesParent;
	public GameObject SwirlMorph;
	public GameObject[] SwirlMorphParts;
	public GameObject[] swrls;
	public GameObject[] shps;
	public int RandomShape;

	public GameObject plane1;
	public GameObject plane2;
	// Use this for initialization
	void Start () {
		
		value = -1;
		RandomShape = Random.Range (0, SwirlMorphParts.Length);
		SwirlMorphParts [RandomShape].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (allowTimer) {
			FillCircle.fillAmount = timer / 2;
			timer += Time.deltaTime;
			if (timer > 2) {
				FillCircle.fillAmount = 0;
				timer = 0;
				allowTimer = false;
				ArrowController ();
			}

		}
		if (allowColor) {
			GetComponent<Renderer> ().material.color = Color.Lerp (GetComponent<Renderer> ().material.color, TargetColor, Time.deltaTime/3);
		}
		if (allowSize) {
			
			transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (size, size, size), Time.deltaTime/5);
		}
		if (allowSpeed) {
			while(GetComponent<Animator> ().speed<speed)
				GetComponent<Animator> ().speed += Time.deltaTime/10; 
		}
		if (allowScale3dSwirl) {
			Swirl3d.transform.localScale = Vector3.Lerp (Swirl3d.transform.localScale, Vector3.zero, Time.deltaTime);
			if (Swirl3d.transform.localScale.x < 0.5f) {
			//	ShapesParent.transform.localScale = Vector3.zero;
			//	shapes[Random.Range(0,shapes.Length)].SetActive (true);
			//	allowScaleShapes = true;
				allowScale3dSwirl = false;
				Swirl3d.SetActive (false);
			}
		}
	//	if(allowScaleShapes)
	//	{
	//		ShapesParent.transform.localScale = Vector3.Lerp (ShapesParent.transform.localScale, new Vector3(3.5f,3.5f,3.5f), Time.deltaTime);
	//	}
		if (allowScale3dSwirl2) {
			if(!allowScale3dSwirl)
				Swirl3d.transform.localScale = Vector3.Lerp (Swirl3d.transform.localScale, new Vector3(2.082638f,2.082638f,2.082638f), Time.deltaTime);
		}

	}
	//NEWWWWW
	public void FillShapes(Color neededColor)
	{
		swrls = GameObject.FindGameObjectsWithTag ("swrl");
		foreach (GameObject swrl in swrls) {
			swrl.GetComponent<Renderer> ().material.color = neededColor;
		}
		if (RandomShape == 0) {
			shps = GameObject.FindGameObjectsWithTag ("cube");
			foreach (GameObject sh in shps) {
				sh.GetComponent<Renderer> ().material.color = neededColor;
			}
		}
		if (RandomShape == 1) {
			shps = GameObject.FindGameObjectsWithTag ("geosphere");
			foreach (GameObject sh in shps) {
				sh.GetComponent<Renderer> ().material.color = neededColor;
			}
		}
		if (RandomShape == 2) {
			shps = GameObject.FindGameObjectsWithTag ("pyramid");
			foreach (GameObject sh in shps) {
				sh.GetComponent<Renderer> ().material.color = neededColor;
			}
		}
		if (RandomShape == 3) {
			shps = GameObject.FindGameObjectsWithTag ("romb");
			foreach (GameObject sh in shps) {
				sh.GetComponent<Renderer> ().material.color = neededColor;
			}
		}
	}
	//NEWWWW
	public void AllowTimerYes()
	{
		allowTimer = true;
	}
	public void AllowTimerNo()
	{
		timer = 0;
		allowTimer = false;
		FillCircle.fillAmount = 0;
	}
	public void ArrowController()
	{
		value++;
		if (value == 0) {
			ChangeOpacity ();
		}
		if (value == 1) {
			ChangeColor (Random.Range(0,7));
		}
		if (value == 2) {
			ChangeSize (0.5f);
		}
		if (value == 3) {
			ChangeSpeed (2f);
		}
		if (value == 4) {
			Swirl3d.SetActive (true);
			allowScale3dSwirl2 = true;
			GetComponent<MeshRenderer> ().enabled = false;
		}
		if (value == 5) {
			Swirl3d.SetActive (false);
			SwirlMorph.SetActive (true);
			FillShapes (TargetColor);
		}
		if (value == 6) {
			SwirlMorph.SetActive (false);
			plane1.SetActive (true);
			plane2.SetActive (false);
		}
	}
	public void ChangeSpeed(float val)
	{
		allowSpeed=true;
		//speed = val;

	}
	public void ChangeSize(float val)
	{
		size = val;
		allowSize = true;
		//transform.localScale = new Vector3(size,size,size);

	}
	public void ChangeOpacity()
	{
		GetComponent<Renderer> ().material.color = new Color(GetComponent<Renderer> ().material.color.r,GetComponent<Renderer> ().material.color.g,GetComponent<Renderer> ().material.color.b,1);
	}
	public void ChangeColor(int rand)
	{
		
		if (rand == 0) {
			TargetColor = Color.green;
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = Color.green;
			FillShapes (Color.green);
		}
		if (rand == 1) {
			TargetColor = Color.blue;
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = Color.blue;
			FillShapes (Color.blue);

		}
		if (rand == 2) {
			TargetColor = Color.red;
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = Color.red;
			FillShapes (Color.red);

		}
		if (rand == 3) {
			TargetColor = Color.yellow;
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = Color.yellow;
			FillShapes (Color.yellow);

		}
		if (rand == 4) {
			TargetColor = Color.cyan;
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = Color.cyan;
			FillShapes (Color.cyan);

		}
		if (rand == 5) {
			TargetColor = new Color(255,140,0);
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = new Color(255f,140f,0f);
			FillShapes (new Color (255f, 140f, 0f));

		}
		if (rand == 6) {
			TargetColor = new Color(75,0,130);
			allowColor = true;
			Swirl3d.GetComponent<Renderer> ().material.color = new Color(75f,0f,130f);
			FillShapes (new Color (75f, 0f, 130f));

		}

	}
}
