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
        _texture = new Texture2D(rowSize, imageData.Count / rowSize);
        _texture.Apply(true);
        for (int i = 0; i < imageData.Count; i += rowSize)
        {
            for (int j = 0; j < rowSize; ++j)
            {
                float color = ((float)imageData[j + i]);
                Color c = new Color(color, color, color);
                _texture.SetPixel(j, i / rowSize, c);
                _texture.Apply(true);
            }
        }
        _texture.Apply();
        _go.GetComponent<Renderer>().material.mainTexture = _texture;
    }

    public void ShowTrueValue() {
    }
    #endregion
}
