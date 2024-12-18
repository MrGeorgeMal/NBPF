﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NBPF.Blueprint
{
    public class BPObject
    {
        #region Event
        protected delegate void BPObjectChangedHandler();
        event BPObjectChangedHandler? BPObjectChanged;
        #endregion



        #region Protected Member
        protected float _x = 0.0f;
        protected float _y = 0.0f;
        protected float _actualX = 0.0f;
        protected float _actualY = 0.0f;
        protected Canvas _drawLayer = new Canvas();
        protected List<UIElement> _drawElements = new List<UIElement>();
        #endregion



        #region Public Mebmer
        public float X
        {
            get { return _x; }
            set { _x = value; Update(); }
        }
        public float Y
        {
            get { return -1 * _y; }
            set { _y = -1 * value; Update(); }
        }
        public float ActualX
        {
            get { return _actualX; }
            set { _actualX = value; }
        }
        public float ActualY
        {
            get { return _actualY; }
            set { _actualY = value; }
        }
        public Canvas DrawLayer { get { return _drawLayer; } }
        #endregion



        #region Constructor
        public BPObject()
        {
            this.BPObjectChanged += new BPObjectChangedHandler(BPObject_Changed);
            SetupObject();
            Update();
        }
        #endregion



        #region Protected Member
        protected virtual void SetupObject() { }
        protected virtual void Update()
        {
            if (BPObjectChanged != null)
            {
                BPObjectChanged();
            }
        }
        #endregion



        #region Private Member
        private void BPObject_Changed()
        {
            _drawLayer.Children.Clear();
            _drawElements.Clear();

            SetupObject();

            foreach(UIElement element in _drawElements)
            {
                _drawLayer.Children.Add(element);
            }
        }
        #endregion
    }
}
