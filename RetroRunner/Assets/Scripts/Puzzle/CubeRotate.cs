using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private List<GameObject> cubeSet;
    [SerializeField]
    private GameObject cubeManager;

    private void Start()
    {
        cubeSet = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                GameObject gameObject = hit.transform.gameObject;
                Debug.Log(gameObject.name);
            }

            if (gameObject.name == hit.transform.gameObject.name)
            {
                RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, 1, Vector3.one, 1f);
                foreach (var h in hits)
                {
                    if (h.collider.tag == "Cube")
                    {
                        cubeSet.Add(h.transform.gameObject);
                    }
                }

                foreach (var i in cubeSet)
                {
                    if (Vector3.Distance(this.transform.position, i.transform.position) < 1f)
                    {
                        i.transform.SetParent(this.gameObject.transform);
                    }
                }

                if (gameObject.name == "UR" || gameObject.name == "DR")
                {
                    this.transform.Rotate(new Vector3(0, 90, 0));
                }
                else if (gameObject.name == "FR" || gameObject.name == "BR")
                {
                    this.transform.Rotate(new Vector3(0, 0, 90));
                }
                else if (gameObject.name == "LR" || gameObject.name == "RR")
                {
                    this.transform.Rotate(new Vector3(90, 0, 0));
                }

                foreach (var i in cubeSet)
                {
                    if (Vector3.Distance(this.transform.position, i.transform.position) < 1f)
                    {
                        i.transform.SetParent(cube.transform);
                    }
                }
                cubeSet.Clear();
            }
            StartCoroutine(cubeManager.GetComponent<CubeManager>().ChkCube());
        }
    }
}
