using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PictureScript : MonoBehaviour
{


    void Start()
    {
        List<double> a = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a1 = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a2 = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a3 = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a4 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a5 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a6 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a7 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a8 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a9 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a10 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a11 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a12 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a13 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a14 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a15 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a16 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a17 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a18 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a19 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a20 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a21 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a22 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a23 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a24 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a25 = new List<double>() { 0, 100, 200, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a26 = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> a27 = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        List<List<double>> l = new List<List<double>>() { a, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27 };
        PictureScript r = new PictureScript(l, 1, true);
    }

    #region Fields
    List<List<int>> _pixels;
    Dictionary<int, double> _pixelMaterial;
    GameObject _go = null;
    int _digit;
    #endregion

    #region Properties
    public List<double> GetPixelsColor
    {
        get
        {
            List<double> result = new List<double>();
            _pixels.ForEach(line => line.ForEach(pixel => result.Add(_pixelMaterial[pixel])));
            return result;
        }
    }
    public int GetDigit
    {
        get
        {
            return _digit;
        }
    }
    #endregion

    #region Private Methods
    private PictureScript() { }
    #endregion

    #region Public Methods
    public PictureScript(List<List<double>> imageData, int digit, bool isExample)
    {
        _pixelMaterial = new Dictionary<int, double>();
        _pixels = new List<List<int>>();
        _digit = digit;

        _go = new GameObject("Image" + digit);
        _go.tag = "IMAGE_TEST";
        if (isExample)
            _go.tag = "IMAGE_EXAMPLE";

        for (int i = 0; i < imageData.Count; ++i)
        {
            List<double> line = imageData[i];
            GameObject pixelLine = new GameObject("PixelLine");
            List<int> pixelLineV = new List<int>();
            pixelLine.transform.parent = _go.transform;

            for (int j = 0; j < line.Count; ++j)
            {
                double pixelP = line[j];
                GameObject pixel = GameObject.CreatePrimitive(PrimitiveType.Plane);
                int pixelID = pixel.GetInstanceID();
                Debug.Log(pixelID);
                pixelLineV.Add(pixelID);
                pixel.name = "Pixel";
                pixel.transform.parent = pixelLine.transform;
                pixel.transform.localScale = new Vector3(.1f, .1f, .1f);
                pixel.transform.localPosition = new Vector3(i, 0, j);
                Material color = new Material(Shader.Find("Standard"));
                color.color = new Color(255 - (float)imageData[i][j], 255 - (float)imageData[i][j], 255 - (float)imageData[i][j]);
                _pixelMaterial.Add(pixelID, imageData[i][j]);
                pixel.GetComponent<Renderer>().material.color = new Color(255 - (float)imageData[i][j], 255 - (float)imageData[i][j], 255 - (float)imageData[i][j]);
            };
            _pixels.Add(pixelLineV);

        };
    }

    public void SetColorOfPixel(int pixelX, int pixelY, float grayValue)
    {
        Material color = new Material(Shader.Find("Standard"));
        Color newColor = new Color(255 - grayValue, 255 - grayValue, 255 - grayValue);

        

        int id = _pixels[pixelY][pixelX];
        _pixelMaterial[id] = grayValue;

    }
    #endregion
}
