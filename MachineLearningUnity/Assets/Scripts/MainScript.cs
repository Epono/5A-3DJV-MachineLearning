using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;

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

    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport("LearningDllForUnity")]
    public extern static System.IntPtr LinearPerceptronMultiLayersClassification_Creation(int inputSize, int[] layersSize, int size);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronMultiLayersClassification_Training(System.IntPtr index, int iterationsCount, int size, int inputSize, double[] inputInput, double[] inputResult);

    [DllImport("LearningDllForUnity")]
    public extern static double LinearPerceptronMultiLayersClassification_Predict(System.IntPtr index, int layerInd, int modelInd, double[] input, int inputSize, int inputInd);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronMultiLayersClassification_Deletion(System.IntPtr index);

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
            if(!go.GetComponent<SphereScript>().isExample) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronClassification_Creation(2);
        List<double> listInputInput = new List<double>();
        List<double> listInputResult = new List<double>();

        // Pour chaque exemple (boule bleue ou rouge)
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

    public void Train_SimpleRegression() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
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

    public void Train_SimpleCrossClassification() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
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
    public void Train_SimpleCrossRegression() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronRegression_Creation(2);
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

        LinearPerceptronRegression_Training(index, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronRegression_Predict(index, 2, new double[2] { Mathf.Abs(go.transform.position.x) + Mathf.Abs(go.transform.position.z), Mathf.Abs(go.transform.position.x * go.transform.position.z) });
                go.transform.position = new Vector3(go.transform.position.x, newY + 2, go.transform.position.z);
            }
        }

        LinearPerceptronRegression_Deletion(index);
    }

    public void Train_SimpleXORClassification() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
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

    public void Train_SimpleXORRegression() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronRegression_Creation(1);
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

        LinearPerceptronRegression_Training(index, inputInput.Length / 2, 1, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronRegression_Predict(index, 1, new double[1] { go.transform.position.x * go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY, go.transform.position.z);
            }
        }

        LinearPerceptronRegression_Deletion(index);
    }

    public void Train_SimpleSquareClassification() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
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

    public void Train_SimpleSquareRegression() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        index = LinearPerceptronRegression_Creation(2);
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

        LinearPerceptronRegression_Training(index, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronRegression_Predict(index, 2, new double[2] { go.transform.position.x * go.transform.position.x, go.transform.position.z * go.transform.position.z });
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronRegression_Deletion(index);
    }

    public void Train_MultiClassification() {

        System.IntPtr indexRed = LinearPerceptronClassification_Creation(2);
        System.IntPtr indexBlue = LinearPerceptronClassification_Creation(2);
        System.IntPtr indexGreen = LinearPerceptronClassification_Creation(2);

        List<double> listInputInput = new List<double>();

        List<double> listInputResultRed = new List<double>();
        List<double> listInputResultBlue = new List<double>();
        List<double> listInputResultGreen = new List<double>();

        foreach(GameObject go in tab) {
            if(go.transform.position.y == -1 || go.transform.position.y == 1 || go.transform.position.y == 2) {
                listInputInput.Add(go.transform.position.x);
                listInputInput.Add(go.transform.position.z);

                listInputResultBlue.Add(go.transform.position.y == -1 ? 1 : -1);
                listInputResultRed.Add(go.transform.position.y == 1 ? 1 : -1);
                listInputResultGreen.Add(go.transform.position.y == 2 ? 1 : -1);
            }
        }

        double[] inputInput = listInputInput.ToArray();

        double[] inputResultRed = listInputResultRed.ToArray();
        double[] inputResultBlue = listInputResultBlue.ToArray();
        double[] inputResultGreen = listInputResultGreen.ToArray();

        LinearPerceptronClassification_Training(indexRed, 10000, inputInput.Length / 2, 2, inputInput, inputResultRed);
        LinearPerceptronClassification_Training(indexBlue, 10000, inputInput.Length / 2, 2, inputInput, inputResultBlue);
        LinearPerceptronClassification_Training(indexGreen, 10000, inputInput.Length / 2, 2, inputInput, inputResultGreen);

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

    public void Train_MultiRegression() {

        System.IntPtr indexRed = LinearPerceptronRegression_Creation(2);
        System.IntPtr indexBlue = LinearPerceptronRegression_Creation(2);
        System.IntPtr indexGreen = LinearPerceptronRegression_Creation(2);

        List<double> listInputInput = new List<double>();

        List<double> listInputResultRed = new List<double>();
        List<double> listInputResultBlue = new List<double>();
        List<double> listInputResultGreen = new List<double>();

        foreach(GameObject go in tab) {
            if(go.transform.position.y == -1 || go.transform.position.y == 1 || go.transform.position.y == 2) {
                listInputInput.Add(go.transform.position.x);
                listInputInput.Add(go.transform.position.z);

                listInputResultBlue.Add(go.transform.position.y == -1 ? 1 : -1);
                listInputResultRed.Add(go.transform.position.y == 1 ? 1 : -1);
                listInputResultGreen.Add(go.transform.position.y == 2 ? 1 : -1);
            }
        }

        double[] inputInput = listInputInput.ToArray();

        double[] inputResultRed = listInputResultRed.ToArray();
        double[] inputResultBlue = listInputResultBlue.ToArray();
        double[] inputResultGreen = listInputResultGreen.ToArray();

        LinearPerceptronRegression_Training(indexRed, inputInput.Length / 2, 2, inputInput, inputResultRed);
        LinearPerceptronRegression_Training(indexBlue, inputInput.Length / 2, 2, inputInput, inputResultBlue);
        LinearPerceptronRegression_Training(indexGreen, inputInput.Length / 2, 2, inputInput, inputResultGreen);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newYRed = (float)LinearPerceptronRegression_Predict(indexRed, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                float newYBlue = (float)LinearPerceptronRegression_Predict(indexBlue, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                float newYGreen = (float)LinearPerceptronRegression_Predict(indexGreen, 2, new double[2] { go.transform.position.x, go.transform.position.z });
                float average = (newYRed + newYBlue + newYGreen) / 3;
                go.transform.position = new Vector3(go.transform.position.x, average, go.transform.position.z);
            }
        }

        LinearPerceptronRegression_Deletion(indexRed);
        LinearPerceptronRegression_Deletion(indexBlue);
        LinearPerceptronRegression_Deletion(indexGreen);
    }

    public void Train_MultiLayersClassification() {

        foreach(GameObject go in tab) {
            if(!go.GetComponent<SphereScript>().isExample) {
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
            }
        }

        //index = LinearPerceptronClassification_Creation(2);
        index = LinearPerceptronMultiLayersClassification_Creation(2, new int[] { 2, 1 }, 2);
        List<double> listInputInput = new List<double>();
        List<double> listInputResult = new List<double>();

        // Pour chaque exemple (boule bleue ou rouge)
        foreach(GameObject go in tab) {
            if(go.transform.position.y != 0) {
                listInputInput.Add(go.transform.position.x);
                listInputInput.Add(go.transform.position.z);
                listInputResult.Add(go.transform.position.y);
            }
        }
        double[] inputInput = listInputInput.ToArray();
        double[] inputResult = listInputResult.ToArray();

        LinearPerceptronMultiLayersClassification_Training(index, 10000, inputInput.Length / 2, 2, inputInput, inputResult);

        foreach(GameObject go in tab) {
            if(go.transform.position.y == 0) {
                float newY = (float)LinearPerceptronMultiLayersClassification_Predict(index, 1, 0, new double[2] { go.transform.position.x, go.transform.position.z }, 2, 0);
                go.transform.position = new Vector3(go.transform.position.x, newY / 2, go.transform.position.z);
            }
        }

        LinearPerceptronMultiLayersClassification_Deletion(index);
    }
}
