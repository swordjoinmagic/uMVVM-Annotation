using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;

class TestViewModel2 : ViewModelBase{
    public BindableProperty<string> Color = new BindableProperty<string>();

    // 在构造方法中订阅消息
    public TestViewModel2() {
        Debug.Log("执行TestViewModel2构造方法");
        MessageAggregator<object>.Instance.Subscribe("ChangeColor",ColorChanged);
    }

    private void ColorChanged(object sender, MessageArgs<object> args) {
        Debug.Log("ColorChanged方法被执行");
        Color.Value = (string)args.Item;
    }
}
