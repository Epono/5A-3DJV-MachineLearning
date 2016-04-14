using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SphereScript : MonoBehaviour {

    [SerializeField]
    Material defaultMaterial;

    [SerializeField]
    Material redMaterial;

    [SerializeField]
    Material blueMaterial;

    [SerializeField]
    Material greenMaterial;

    public bool isExample;

    // Use this for initialization
    void Start() {
        if (gameObject.transform.position.y == 1)
        {
            gameObject.GetComponent<Renderer>().material = redMaterial;
            gameObject.GetComponent<SphereScript>().isExample = true;
        }
        else if (gameObject.transform.position.y == -1)
        {
            gameObject.GetComponent<Renderer>().material = blueMaterial;
            gameObject.GetComponent<SphereScript>().isExample = true;
        }
        else if (gameObject.transform.position.y == 2)
        {
            gameObject.GetComponent<Renderer>().material = greenMaterial;
            gameObject.GetComponent<SphereScript>().isExample = true;
        }
        else {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
            gameObject.GetComponent<SphereScript>().isExample = false;
        }

    }

    // Update is called once per frame
    void Update() {
        if(!Application.isPlaying) {
            if(gameObject.transform.position.y == 1) {
                gameObject.GetComponent<Renderer>().material = redMaterial;
                gameObject.GetComponent<SphereScript>().isExample = true;
            } else if(gameObject.transform.position.y == -1) {
                gameObject.GetComponent<Renderer>().material = blueMaterial;
                gameObject.GetComponent<SphereScript>().isExample = true;
            } else if(gameObject.transform.position.y == 2) {
                gameObject.GetComponent<Renderer>().material = greenMaterial;
                gameObject.GetComponent<SphereScript>().isExample = true;
            } else {
                gameObject.GetComponent<Renderer>().material = defaultMaterial;
                gameObject.GetComponent<SphereScript>().isExample = false;
            }
        }
    }


}
