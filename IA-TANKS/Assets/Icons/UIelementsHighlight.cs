using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIelementsHighlight : MonoBehaviour
{
    public Image reloading;
    public Image shooting;
    public Image moving;
    Color normal;
    public bool m;
    public bool s;
    public bool r;
    // Start is called before the first frame update
    void Start()
    {
        m = true;
        s = false;
        r = false;
       normal = reloading.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(m && !s && !r)
        {
            var tempColor = shooting.color;
            tempColor.a = 0.5f;
            moving.color = normal;
            shooting.color = tempColor;
            reloading.color = tempColor;
        }
        if (!m && s && !r)
        {
            var tempColor = shooting.color;
            tempColor.a = 0.5f;
            moving.color = tempColor;
            reloading.color = tempColor;
            shooting.color = normal;
        }
        if (!m && !s && r)
        {
            var tempColor = shooting.color;
            tempColor.a = 0.5f;
            moving.color = tempColor;
            shooting.color = tempColor;
            reloading.color = normal;
        }
    }
}
