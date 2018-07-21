using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMLerning;
using UnityEngine.UI;
using UnityEngine;

class TestView2 : UnityGuiView<TestViewModel2>{

    public Image images;

    //public TestView2() : base() {
    //    //
    //    print("TestViewModel2是:" + BindingContext);
    //    print("构造方法");
    //}

    public void Awake() {
        BindingContext = new TestViewModel2();
    }

    protected override void OnInitialize() {
        base.OnInitialize();

        // 为属性绑定器绑定属性Color的监听方法为OnColoChange
        binder.Add<string>("Color",OnColorChange);
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
