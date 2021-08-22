/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextInputText.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Text-Input-Text.
    /// </summary>
    public class UITextInputText : UIPanel
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Text txt_Tittle;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected InputField ipt_Content;
        /// <summary>
        /// 
        /// </summary>
        protected Text txt_Caption;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Text txt_Stamp;

        /// <summary>
        /// 
        /// </summary>
        public string Tittle
        {
            set { txt_Tittle.text = value; }
            get { return txt_Tittle.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { ipt_Content.text = value; }
            get { return ipt_Content.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { txt_Caption.text = value; }
            get { return txt_Caption.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public InputField.ContentType ContentType
        {
            set { ipt_Content.contentType = value; }
            get { return ipt_Content.contentType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CharacterLimit
        {
            set { ipt_Content.characterLimit = value; }
            get { return ipt_Content.characterLimit; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Stamp
        {
            set { txt_Stamp.text = value; }
            get { return txt_Stamp.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public event Action<string> OnValueChangedEvent
        {
            add { onValueChangedEvent += value; }
            remove { onValueChangedEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<string> onValueChangedEvent;
        /// <summary>
        /// 
        /// </summary>
        protected Func<string, string> beforeValueChange;

        /// <summary>
        /// 
        /// </summary>
        public event Action<string> OnEndEditEvent
        {
            add { onEndEditEvent += value; }
            remove { onEndEditEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<string> onEndEditEvent;
        /// <summary>
        /// 
        /// </summary>
        protected Func<string, string> beforeEndEdit;

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            txt_Caption = ipt_Content.GetComponentInChildren<Text>();
            ipt_Content.onValueChanged.AddListener(Ipt_Content_OnValueChanged);
            ipt_Content.onEndEdit.AddListener(Ipt_Content_OnEndEdit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="default"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void InitForInteger(int @default, int min, int max)
        {
            ContentType = InputField.ContentType.IntegerNumber;
            beforeEndEdit = (value) =>
            {
                var number = 0;
                if (int.TryParse(value, out number))
                {
                    if (number < min || number > max)
                    {
                        number = Mathf.Clamp(number, min, max);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        number = @default;
                    }
                    else if (value.StartsWith("-"))
                    {
                        number = min;
                    }
                    else
                    {
                        number = max;
                    }
                }

                value = number.ToString();
                Content = value;
                return value;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tittle"></param>
        /// <param name="content"></param>
        /// <param name="caption"></param>
        /// <param name="stamp"></param>
        public void Refresh(string tittle = null, string content = null, string caption = null, string stamp = null)
        {
            Tittle = tittle;
            Content = content;
            Caption = caption;
            Stamp = stamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Ipt_Content_OnValueChanged(string value)
        {
            value = beforeValueChange?.Invoke(value);
            onValueChangedEvent?.Invoke(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Ipt_Content_OnEndEdit(string value)
        {
            value = beforeEndEdit?.Invoke(value);
            onEndEditEvent?.Invoke(value);
        }
    }
}