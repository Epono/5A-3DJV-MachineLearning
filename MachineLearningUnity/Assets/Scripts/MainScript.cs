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

    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport("LearningDllForUnity")]
    public extern static System.IntPtr LinearPerceptronRegression_Creation(int inputSize);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronRegression_Training(System.IntPtr index, int size, int inputSize, double[] inputInput, double[] inputResult);

    [DllImport("LearningDllForUnity")]
    public extern static double LinearPerceptronRegression_Predict(System.IntPtr index, int inputSize, double[] input);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronRegression_Deletion(System.IntPtr index);

    [SerializeField]
    Material defaultMaterial;

    GameObject[] tab;
    System.IntPtr index;

    void Start() {
        tab = GameObject.FindGameObjectsWithTag("MABITE");
    }

    void Update() {

    }

    public void Train_SimpleClassification() {

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

    public void Train_SimpleCrossClassification() {

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
                listInputInput.Add(Mathf.Abs(go.transform.position.x) + Mathf.Abs(go.transform.position.z));
                listInputInput.Add(Mathf.Abs(go.transform.position.x * go.transform.position.z));
                listInputResult.Add(go.transform.position.y);
            }
        }
        double[] inputInput = listInputInput.ToArray();
        double[] inputResult = listInputResult.ToArray();

        LinearPerceptronClassification_Training(index, 10000, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronClassification_Predict(index, 2, new double[2] { Mathf.Abs(go.transform.position.x) + Mathf.Abs(go.transform.position.z), Mathf.Abs(go.transform.position.x * go.transform.position.z) });
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronClassification_Deletion(index);
    }

    public void Train_SimpleXORClassification() {

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0.5 || go.transform.position.y == -0.5) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronClassification_Creation(1);
        List<double> listInputInput = new List<double>();
        List<double> listInputResult = new List<double>();
        foreach(GameObject go in tab) {
            if(go.transform.position.y != 0) {
                listInputInput.Add(go.transform.position.x * go.transform.position.z);
                listInputResult.Add(go.transform.position.y);
            }
        }
        double[] inputInput = listInputInput.ToArray();
        double[] inputResult = listInputResult.ToArray();

        LinearPerceptronClassification_Training(index, 10000, inputInput.Length / 2, 1, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronClassification_Predict(index, 1, new double[1] { go.transform.position.x * go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronClassification_Deletion(index);
    }

    public void Train_SimpleSquareClassification() {

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
                listInputInput.Add(go.transform.position.x * go.transform.position.x);
                listInputInput.Add(go.transform.position.z * go.transform.position.z);
                listInputResult.Add(go.transform.position.y);
            }
        }
        double[] inputInput = listInputInput.ToArray();
        double[] inputResult = listInputResult.ToArray();

        LinearPerceptronClassification_Training(index, 10000, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronClassification_Predict(index, 2, new double[2] { go.transform.position.x * go.transform.position.x, go.transform.position.z * go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronClassification_Deletion(index);
    }

    public void Train_SimpleRegression() {

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0.5 || go.transform.position.y == -0.5) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronRegression_Creation(2);
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

        LinearPerceptronRegression_Training(index, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronRegression_Predict(index, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY, go.transform.position.z);
            }
        }

        LinearPerceptronRegression_Deletion(index);
    }

    public void Train_MultiClassification() {

        System.IntPtr indexRed = LinearPerceptronClassification_Creation(2);
        System.IntPtr indexBlue = LinearPerceptronClassification_Creation(2);
        System.IntPtr indexGreen = LinearPerceptronClassification_Creation(2);

        List<double> listInputInputRed = new List<double>();
        List<double> listInputResultRed = new List<double>();
        List<double> listInputInputBlue = new List<double>();
        List<double> listInputResultBlue = new List<double>();
        List<double> listInputInputGreen = new List<double>();
        List<double> listInputResultGreen = new List<double>();

        //foreach(GameObject go in tab) {
        //    if(go.transform.position.y == -1) {
        //        listInputInputBlue.Add(go.transform.position.x);
        //        listInputInputBlue.Add(go.transform.position.z);
        //        listInputResultBlue.Add(go.transform.position.y);
        //    } else if(go.transform.position.y == 1) {
        //        listInputInputRed.Add(go.transform.position.x);
        //        listInputInputRed.Add(go.transform.position.z);
        //        listInputResultRed.Add(go.transform.position.y);
        //    } else if(go.transform.position.y == 2) {
        //        listInputInputGreen.Add(go.transform.position.x);
        //        listInputInputGreen.Add(go.transform.position.z);
        //        listInputResultGreen.Add(go.transform.position.y);
        //    }
        //}

        foreach(GameObject go in tab) {
            if(go.transform.position.y == -1 || go.transform.position.y == 1 || go.transform.position.y == 2) {
                listInputInputBlue.Add(go.transform.position.x);
                listInputInputBlue.Add(go.transform.position.z);
                listInputInputRed.Add(go.transform.position.x);
                listInputInputRed.Add(go.transform.position.z);
                listInputInputGreen.Add(go.transform.position.x);
                listInputInputGreen.Add(go.transform.position.z);

                listInputResultBlue.Add(go.transform.position.y == -1 ? 1 : -1);
                listInputResultRed.Add(go.transform.position.y == 1 ? 1 : -1);
                listInputResultGreen.Add(go.transform.position.y == 2 ? 1 : -1);
            }
        }

        double[] inputInputRed = listInputInputRed.ToArray();
        double[] inputResultRed = listInputResultRed.ToArray();
        double[] inputInputBlue = listInputInputBlue.ToArray();
        double[] inputResultBlue = listInputResultBlue.ToArray();
        double[] inputInputGreen = listInputInputGreen.ToArray();
        double[] inputResultGreen = listInputResultGreen.ToArray();

        LinearPerceptronClassification_Training(indexRed, 10000, inputInputRed.Length / 2, 2, inputInputRed, inputResultRed);
        LinearPerceptronClassification_Training(indexBlue, 10000, inputInputBlue.Length / 2, 2, inputInputBlue, inputResultBlue);
        LinearPerceptronClassification_Training(indexGreen, 10000, inputInputGreen.Length / 2, 2, inputInputGreen, inputResultGreen);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newYRed = (float)LinearPerceptronClassification_Predict(indexRed, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                float newYBlue = (float)LinearPerceptronClassification_Predict(indexBlue, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                float newYGreen = (float)LinearPerceptronClassification_Predict(indexGreen, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                if(newYRed == 1) {
                    go.transform.position = new Vector3(go.transform.position.x, 1, go.transform.position.z);
                } else if(newYBlue == 1) {
                    go.transform.position = new Vector3(go.transform.position.x, -1, go.transform.position.z);
                } else if(newYGreen == 1) {
                    go.transform.position = new Vector3(go.transform.position.x, 2, go.transform.position.z);
                }
                //go.transform.position = new Vector3(go.transform.position.x, Mathf.Max(newYBlue, Mathf.Max(newYGreen, newYRed)) / 2, go.transform.position.z);
            }
        }

        LinearPerceptronClassification_Deletion(indexRed);
        LinearPerceptronClassification_Deletion(indexBlue);
        LinearPerceptronClassification_Deletion(indexGreen);
    }
}
