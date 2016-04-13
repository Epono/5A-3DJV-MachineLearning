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

    public bool isExample = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(!Application.isPlaying) {
            if(gameObject.transform.position.y == 1) {
                gameObject.GetComponent<Renderer>().material = redMaterial;
            } else if(gameObject.transform.position.y == -1) {
                gameObject.GetComponent<Renderer>().material = blueMaterial;
            } else if(gameObject.transform.position.y == 2) {
                gameObject.GetComponent<Renderer>().material = greenMaterial;
            } else {
                gameObject.GetComponent<Renderer>().material = defaultMaterial;
                isExample = false;
            }
        }
    }


}
