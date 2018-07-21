using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class TestTrigger : MonoBehaviour{

    public InputField InputFieldComponent;  // 输入框控件
    public TestView1 view1;

    /// <summary>
    /// 当输入框改变时触发的方法
    /// </summary>
    public void ChangeInputFiled() {
        print("输入框改变了");
        view1.ViewModel.Text.Value = InputFieldComponent.text;
    }
}

