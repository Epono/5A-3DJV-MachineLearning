using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PictureScript{
    #region Fields
    Texture2D _texture;
    int _digit;
    GameObject _go;
    #endregion

    #region Properties
    public List<double> GetPixelsColor
    {
        get
        {
            List<double> result = new List<double>();
            for (int i = 0; i < _texture.height; ++i)
            {
                for (int j = 0; j < _texture.width; ++j) {
                    result.Add(_texture.GetPixel(i, j).r);
                }
            }
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
    public PictureScript(List<double> imageData, int rowSize, int digit, bool isExample, Vector3 imapgePosition)
    {
        _go = PlanePoolManager.Instance.GetPlane();
        _go.tag = "IMAGE_TEST";
        _go.transform.position = imapgePosition;
        if (isExample)
            _go.tag = "IMAGE_EXAMPLE";
        string test = "";
        _texture = new Texture2D(rowSize, imageData.Count / rowSize);
        //for (int i = 0; i < 28*28; i+=28) {
        //    for (int j = 0; j < 28; ++j)
        //    {
        //        float color = ((float)imageData[j + i]);
        //        test += color;
        //        Color c = new Color(color, 0, 0);
        //        _texture.SetPixel(i/28, j, c);
        //        _texture.Apply();
        //    }
        //    test += "\n";
        //}
        for (int i = 0; i < imageData.Count; i += rowSize)
        {
            for (int j = 0; j < rowSize; ++j)
            {
                float color = ((float)imageData[j + i]);
                Color c = new Color(color, color, color);
                _texture.SetPixel(j, i / rowSize, c);
                _texture.Apply(true);
            }
            test += "\n";
        }
        Debug.Log(test);
        _texture.Apply();
        Texture testa = new Texture();
        testa = _texture;
        _go.GetComponent<Renderer>().material.mainTexture = testa;
    }
    #endregion
}
