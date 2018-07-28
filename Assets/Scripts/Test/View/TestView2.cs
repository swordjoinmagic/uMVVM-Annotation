using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

class TestView2 : UnityGuiView<TestViewModel2>{

    public Image images;

    public void Awake() {
        BindingContext = new TestViewModel2();
        print("执行Awake方法");

        Reveal();

    }

    protected override void OnInitialize() {
        base.OnInitialize();

        // 为属性绑定器绑定属性Color的监听方法为OnColoChange
        binder.Add<string>("Color",OnColorChange);

        print("此时的ViewModel是:"+BindingContext);

        // 进入下一生命周期
        //Reveal();
    }

    private void OnColorChange(string oldValue,string newValue) {

        print("images是:"+images);

        switch (newValue) {
            case "Red":
                images.color = Color.red;
                break;
            case "Black":
                images.color = Color.black;
                break;
            case "Blue":
                images.color = Color.blue;
                break;
            case "Green":
                images.color = Color.green;
                break;
            default:
                break;
        }
    }
}
