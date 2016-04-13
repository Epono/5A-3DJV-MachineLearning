using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

public class MainScript : MonoBehaviour {

    [DllImport("LearningDllForUnity")]
    public extern static System.IntPtr LinearPerceptronClassification_Creation(int inputSize);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronClassification_Training(System.IntPtr index, int iterationsCount, int size, int inputSize, double[] inputInput, double[] inputResult);

    [DllImport("LearningDllForUnity")]
    public extern static double LinearPerceptronClassification_Predict(System.IntPtr index, int inputSize, double[] input);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronClassification_Deletion(System.IntPtr index);

    [SerializeField]
    Material defaultMaterial;

    GameObject[] tab;
    System.IntPtr index;

    void Start() {
        tab = GameObject.FindGameObjectsWithTag("MABITE");
    }

    void Update() {

    }

    public void train() {

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0.5 || go.transform.position.y == -0.5) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronClassification_Creation(2);
        List<double> listInputInput = new List<double>();
        List<double> listInputResult = new List<double>();
        foreach(GameObject go in tab) {
            if(go.transform.position.y != 0) {
                listInputInput.Add(go.transform.position.x);
                listInputInput.Add(go.transform.position.z);
                listInputResult.Add(go.transform.position.y);
            }
        }
        double[] inputInput = listInputInput.ToArray();
        double[] inputResult = listInputResult.ToArray();

        LinearPerceptronClassification_Training(index, 10000, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronClassification_Predict(index, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronClassification_Deletion(index);
    }
}
