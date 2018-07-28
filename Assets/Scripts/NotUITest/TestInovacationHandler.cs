using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using uMVVM;
using UnityEngine;

/// <summary>
/// 用来测试AOP的类
/// </summary>
class TestInovacationHandler : IInvocationHandler {
    public object Invoke(object target, MethodInfo method, object[] args) {
        PreProcess();
        var result = method.Invoke(target,args);
        PostProcess();
        return result;
    }

    public void PostProcess() {
        Debug.Log("执行方法后");
    }

    public void PreProcess() {
        Debug.Log("执行方法前");
    }
}
