using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine.UI;
using UnityEngine;
class BadgeView : UnityGuiView<BadgeViewModel>{

    //===================================
    // 以下是该View管理的ugui控件
    //==================================
    public Image iconImage;
    public Image elementColorIamge;
    

    protected override void OnInitialize() {
        base.OnInitialize();
        binder.Add<string>("ElementColor", OnElementColorPropertyValueChanged);
        // 图片略过
    }

    private void OnElementColorPropertyValueChanged(string oldValue,string newValue) {
        switch (newValue) {
            case "Red":
                elementColorIamge.color = Color.red;
                break;
            case "Green":
                elementColorIamge.color = Color.green;
                break;
            case "Blue":
                elementColorIamge.color = Color.blue;
                break;
        }
    }


}
