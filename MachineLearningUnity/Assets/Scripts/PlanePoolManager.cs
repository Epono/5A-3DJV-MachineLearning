using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanePoolManager {
    #region Fields
    List<GameObject> _aviablePlane;
    List<GameObject> _usedPlane;
    #endregion
    #region Properties
    public static PlanePoolManager Instance = new PlanePoolManager();

    #endregion
    #region Properties
    public List<GameObject> UsedPlane
    {
        get
        {
            return _usedPlane;
        }

        set
        {
            _usedPlane = value;
        }
    }
    #endregion
    #region Private Methods
    private PlanePoolManager()
    {
        _aviablePlane = new List<GameObject>();
        _usedPlane = new List<GameObject>();
        GameObject[] tab = GameObject.FindGameObjectsWithTag("PLANE_FOR_IMAGE");
        foreach (GameObject o in tab)
            _aviablePlane.Add(o);
    }
    #endregion
    #region Public Methods
    public GameObject GetPlane() {
        GameObject result = _aviablePlane[0];
        _usedPlane.Add(result);
        _aviablePlane.Remove(result);
        return result ;
    }
    public void FreePlane(GameObject toReset) {
        if (_usedPlane.Contains(toReset))
        {
            _usedPlane.Remove(toReset);
            toReset.tag = "PLANE_FOR_IMAGE";
            _aviablePlane.Add(toReset);
        }
    }
    #endregion
}
