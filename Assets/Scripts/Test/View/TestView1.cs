using System;
using System.Collections.Generic;
using MVVMLerning;
using UnityEngine;
using UnityEngine.UI;

class TestView1 : UnityGuiView<TestViewModel>{

    //==============================
    // 此视图管理的控件
    //==============================
    public Text textComponent;      // Text控件

    public TestView1() : base() {
        BindingContext = new TestViewModel();
    }

    protected override void OnInitialize() {
        base.OnInitialize();
        binder.Add<string>("Text", TextValueChanged);
    }

    public TestViewModel ViewModel {
        get {
            return BindingContext;
        }
    }

    /// <summary>
    /// 当没有使用属性绑定器的时候,需要覆写OnBindingContextChanged方法
    /// 来对委托进行替换操作(旧的删掉,新的增加),使用属性绑定器之后,
    /// 就不用做这么麻烦的操作了,在根类UnityGUIView中该方法已经使用
    /// bind,unbind方法对这些委托进行操作了
    /// </summary>
    /// <param name="oldViewModel"></param>
    /// <param name="newViewModel"></param>
    //protected override void OnBindingContextChanged(TestViewModel oldViewModel, TestViewModel newViewModel) {
    //    TestViewModel testViewModel = oldViewModel;

    //    // 去掉旧的ViewModel上的所有委托函数
    //    if (testViewModel != null) {
    //        testViewModel.Text.OnValueChange -= TextValueChanged;
    //    }

    //    TestViewModel newTestViewModel = newViewModel;
    //    if (newTestViewModel != null) {
    //        newTestViewModel.Text.OnValueChange += TextValueChanged;
    //    }
    //}

    /// <summary>
    /// ViewModel属性中Text属性绑定的方法
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private void TextValueChanged(string oldValue,string newValue) {
        textComponent.text = newValue;
    }

}
