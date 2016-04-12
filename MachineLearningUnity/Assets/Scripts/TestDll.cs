using UnityEngine;
using System.Runtime.InteropServices;

public class TestDll : MonoBehaviour {

    [DllImport("LearningDllForUnity")]
    public extern static System.IntPtr LinearPerceptronClassification_Creation(int dimension);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronClassification_Training(System.IntPtr index);

    [DllImport("LearningDllForUnity")]
    public extern static double LinearPerceptronClassification_Result(System.IntPtr index);

    [DllImport("LearningDllForUnity")]
    public extern static void LinearPerceptronClassification_Deletion(System.IntPtr index);

    void Start() {

    }

    void Update() {
        Debug.Log(LinearPerceptronClassification_Creation(12));
    }
}
