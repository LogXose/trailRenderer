using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagger : MonoBehaviour {
    GameObject LastTrail;
    public GameObject Prefab;
    bool isDrawing = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (isDrawing)
            {
                Plane ObjPlane = new Plane(Camera.main.transform.forward * -1, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDist;
                if (ObjPlane.Raycast(ray, out rayDist))
                {
                    LastTrail.transform.position = ray.GetPoint(rayDist);
                    isDrawing = true;
                }
            }
            else
            {
                
                Plane ObjPlane = new Plane(Camera.main.transform.forward * -1, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDist;
                if (ObjPlane.Raycast(ray, out rayDist))
                {
                    GameObject gameObject = Instantiate(Prefab, ray.GetPoint(rayDist),Quaternion.identity);
                    LastTrail = gameObject;
                    isDrawing = true;
                }
            }
        }
        else
        {
            isDrawing = false;
        }
	}
}
