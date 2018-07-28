using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

class BadgeViewModel : ViewModelBase{
    public readonly BindableProperty<string> Icon = new BindableProperty<string>();
    public readonly BindableProperty<string> ElementColor = new BindableProperty<string>();

    // 这个不是OnInitialize那个方法.
    // 该方法等待主ViewModel模型更新的时候调用
    public void Initialization(Badge badge) {
        Icon.Value = badge.Icon;
        ElementColor.Value = badge.ElementColor;
    }

}
