using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using System.IO;

public class DigitsScript : MonoBehaviour {


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

    List<PictureScript> examples = new List<PictureScript>();
    List<PictureScript> tests= new List<PictureScript>();

    public void LoadFiles() {
        // Lecture des exemples pour l'entrainement
        DateTime start = DateTime.Now;
        StreamReader reader = new StreamReader(File.OpenRead(@"Assets\Data\train_light.csv"));

        // On lit la 1ère avec les labels pour s'en débarasser
        string headerLine = reader.ReadLine();

        // Liste des digits
        List<int> digits = new List<int>();
        // Liste des couleurs de pixel
        List<List<double>> pixelColors = new List<List<double>>();

        int examplesCount = 0;

        while(!reader.EndOfStream) {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            // Le digit est le 1er caractère
            digits.Add(int.Parse(values[0]));

            // On remplit une liste de double avec les valeurs du pixel
            List<double> datas = new List<double>();
            for(int i = 1; i < values.Length; ++i) {
                datas.Add(double.Parse(values[i]));
            }
            pixelColors.Add(datas);

            ++examplesCount;
        }
        DateTime end = DateTime.Now;
        Debug.Log("La lecture du fichier train_light.csv a pris : " + ((end - start).TotalMilliseconds) / 1000 + " s");
        start = DateTime.Now;

        for(int i = 0; i < 1000; ++i) {
            examples.Add(new PictureScript(pixelColors[i], 28, digits[i], true, new Vector3((i % 100) - 10, 0, 5 - (int)(i / 100))));
        }

        for(int i = 1000; i < 2000; ++i) {
            tests.Add(new PictureScript(pixelColors[i], 28, digits[i], true, new Vector3((i % 100) - 10, 0, (5 - (int)(i / 100)) - 1)));
        }
        end = DateTime.Now;
        Debug.Log("La création des scripts a pris : " + ((end - start).TotalMilliseconds) / 1000 + " s");

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Lecture des test pour la verification
        //start = DateTime.Now;
        //reader = new StreamReader(File.OpenRead(@"Assets\Data\test_light.csv"));

        //// On lit la 1ère avec les labels pour s'en débarasser
        //headerLine = reader.ReadLine();

        //// Liste des digits
        //digits = new List<int>();
        //// Liste des couleurs de pixel
        //pixelColors = new List<List<double>>();

        //int testsCount = 0;

        //while(!reader.EndOfStream) {
        //    string line = reader.ReadLine();
        //    string[] values = line.Split(',');

        //    // On remplit une liste de double avec les valeurs du pixel
        //    List<double> datas = new List<double>();
        //    for(int i = 0; i < values.Length; ++i) {
        //        datas.Add(double.Parse(values[i]));
        //    }
        //    pixelColors.Add(datas);

        //    ++testsCount;
        //}
        //end = DateTime.Now;
        //Debug.Log("La lecture du fichier test_light.csv a pris : " + ((end - start).TotalMilliseconds) / 1000 + " s");

        //start = DateTime.Now;
        //for(int i = 0; i < 1000; ++i) {
        //    tests.Add(new PictureScript(pixelColors[i], 28, 0, true, new Vector3((i % 100) - 10, -10, 5 - (int)(i / 100))));
        //}
        //end = DateTime.Now;
        //Debug.Log("La création des scripts a pris : " + ((end - start).TotalMilliseconds) / 1000 + " s");
    }

    public void Train_Digit() {

        Dictionary<int, System.IntPtr> models = new Dictionary<int, System.IntPtr>();
        Dictionary<int, List<double>> listInputResult = new Dictionary<int, List<double>>();
        for(int i = 0; i < 10; ++i) {
            // TODO: Changer le nom de la fonction
            models.Add(i, LinearPerceptronClassification_Creation(28 * 28));
            listInputResult.Add(i, new List<double>());
        }

        List<double> listInputInput = new List<Double>();

        // Pour chaque exemple (image)
        foreach(PictureScript ps in examples) {

            // Pour chaque parametre (pixel)
            foreach(double pixelColor in ps.GetPixelsColor) {
                listInputInput.Add(pixelColor);
            }

            // Pour chaque modele
            for(int i = 0; i < 10; ++i) {
                // Si c'est le bon caractère dans le gameObject
                if(i == ps.GetDigit) {
                    listInputResult[i].Add(1);
                } else {
                    listInputResult[i].Add(-1);
                }
            }
        }

        double[] inputInput = listInputInput.ToArray();

        // Pour chaque modèle
        for(int i = 0; i < 10; ++i) {
            double[] inputResult = listInputResult[i].ToArray();
            // TODO: nombre de paramètres ok ?
            LinearPerceptronClassification_Training(models[i], 10000, inputResult.Length, 28 * 28, inputInput, inputResult);
        }

        Dictionary<int, double> results = new Dictionary<int, double>();

        // Calcul de Ein (predict sur le jeu d'entrainement)
        double Ein;
        int numberOfSuccessExamples = 0;
        // Pour chaque image
        foreach(PictureScript ps in examples) {

            double[] inputs = ps.GetPixelsColor.ToArray();

            // Pour chaque model
            for(int i = 0; i < 10; ++i) {
                results.Add(i, LinearPerceptronClassification_Predict(models[i], 28 * 28, inputs));
            }

            // on affiche ce qu'on a décidé
            for(int i = 0; i < 10; ++i) {
                //Debug.Log(" i = " + i + ": " + results[i]);
                if(results[i] == 1) {
                    ps.SetPredictedValue(i);
                    if(i == ps.GetDigit) {
                        numberOfSuccessExamples++;
                    }
                    break;
                }
            }
        }

        Ein = numberOfSuccessExamples / examples.Count;
        Debug.Log("Ein : " + Ein);

        // Calcul de Eout (predict sur le jeu de test)
        double Eout;
        int numberOfSuccessTests = 0;
        // Pour chaque image
        foreach(PictureScript ps in tests) {

            double[] inputs = ps.GetPixelsColor.ToArray();

            // Pour chaque model
            for(int i = 0; i < 10; ++i) {
                results.Add(i, LinearPerceptronClassification_Predict(models[i], 28 * 28, inputs));
            }

            // on affiche ce qu'on a décidé
            for(int i = 0; i < 10; ++i) {
                //Debug.Log(" i = " + i + ": " + results[i]);
                if(results[i] == 1) {
                    ps.SetPredictedValue(i);
                    if(i == ps.GetDigit) {
                        numberOfSuccessTests++;
                    }
                    break;
                }
            }
        }

        Eout = numberOfSuccessTests / tests.Count;
        Debug.Log("Eout : " + Eout);

        //// Suppression
        //for(int i = 0; i < 10; ++i) {
        //    LinearPerceptronClassification_Deletion(models[i]);
        //}
    }

    bool _isShowingTrueValue = false;
    bool _isShowingPredictedValue = false;

    void Update() {
        if(Input.GetKeyDown(KeyCode.A)) {
            _isShowingTrueValue = !_isShowingTrueValue;
            examples.ForEach(s => s.ShowTrueValue(_isShowingTrueValue));
            tests.ForEach(s => s.ShowTrueValue(_isShowingTrueValue));
        } else if(Input.GetKeyDown(KeyCode.Z)) {
            _isShowingPredictedValue = !_isShowingPredictedValue;
            tests.ForEach(s => s.ShowPredictedValue(_isShowingPredictedValue));
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position -= new Vector3(0.5f, 0, 0);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += new Vector3(0.5f, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow)) {
            gameObject.transform.position += new Vector3(0, 0, 0.5f);
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.position -= new Vector3(0, 0, 0.5f);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0) {
            gameObject.GetComponent<Camera>().orthographicSize += 0.1f;
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0) {
            gameObject.GetComponent<Camera>().orthographicSize -= 0.1f;
        }
    }
}
