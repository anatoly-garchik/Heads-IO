using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.UI.View
{
    public class ViewManager : MonoBehaviour, IViewManager
    {
        [SerializeField] private View[] _views;

        private Dictionary<Type, IView> _viewsByType;
        private Type _currentView;
        private IView _lastShowView;

        private void Awake()
        {
            CreateViewDictionary();
        }

        public void ShowView<T>() where T : IView
        {
            Type viewType = typeof(T);
            
            if (viewType == _currentView)
                return;

            if (_viewsByType.ContainsKey(viewType))
            {
                if (_lastShowView != null)
                    _lastShowView.Hide();

                _currentView = viewType;
                _viewsByType[_currentView].Show();
                _lastShowView = _viewsByType[_currentView];
            }
        }

        public void HideView<T>() where T : IView
        {
            Type viewType = typeof(T);

            if (_viewsByType.ContainsKey(viewType))
            {
                _viewsByType[viewType].Hide();
            }
        }

        private void CreateViewDictionary()
        {
            _viewsByType = new Dictionary<Type, IView>();

            foreach (var view in _views)
            {
                Type type = view.GetType();
                
                if (!_viewsByType.ContainsKey(type))
                    _viewsByType.Add(type, view);
            }
        }
    }
}
