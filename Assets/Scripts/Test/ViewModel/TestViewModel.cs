using System;
using System.Collections.Generic;
using MVVMLerning;
using UnityEngine;

class TestViewModel : ViewModelBase{
    public BindableProperty<string> Text = new BindableProperty<string>();

    // 发布颜色改变的消息
    public void PublishColorChange() {
        MessageAggregator<object>.Instance.Publish("ChangeColor",this,new MessageArgs<object>(Text.Value));

        Debug.Log("颜色改变了,颜色变为:"+Text.Value);
    }
}
