using System;
using System.Collections.Generic;
using UnityEngine;

public static class ViewsManager
{
    private static Dictionary<Type, UIView> _viewsByType = new();
    public static void Register(UIView view)
    {
        _viewsByType.Add(view.GetType(), view);
    }

    public static void UnRegister(UIView view)
    {
        if (_viewsByType.ContainsKey(view.GetType()))
        {
            _viewsByType.Remove(view.GetType());
        }
    }

    public static T GetView<T>() where T:UIView
    {
        if (_viewsByType.TryGetValue(typeof(T), out var view)) {
            return (T)view;
        }
        else
        {
            Debug.LogError("View not found!");
            return null;
        }
    }

    public static void Show <T>() where T: UIView
    {
        var view = GetView<T>();
        view.Show();
    }

    public static void HideAll()
    {
        foreach (var view in _viewsByType.Values)
        {
            view.Hide();
        }
    }
}
