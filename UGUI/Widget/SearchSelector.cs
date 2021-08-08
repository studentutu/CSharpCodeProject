/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SearchSelector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Search selector with InputField-Button-Collector.
    /// </summary>
    public class SearchSelector : UIWidget
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected InputField ipt_Keyword;
        /// <summary>
        /// 
        /// </summary>
        protected Text txt_Caption;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Button btn_Search;
        /// <summary>
        /// 
        /// </summary>
        protected Text txt_Search;
        /// <summary>
        /// 
        /// </summary>
        protected Image img_Search;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected bool isNullMatchAll;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData opn_Search;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData opn_Clear;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected ButtonCollector btnCollector;

        /// <summary>
        /// On select event (Index of the select item, value of the select item).
        /// </summary>
        public event Action<int, string> OnSelectEvent
        {
            add { onSelectEvent += value; }
            remove { onSelectEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<int, string> onSelectEvent;

        /// <summary>
        /// 
        /// </summary>
        public string Keyword
        {
            set { ipt_Keyword.text = value; }
            get { return ipt_Keyword.text; }
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
        protected List<string> items = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            txt_Caption = ipt_Keyword.GetComponentInChildren<Text>();
            txt_Search = btn_Search.GetComponentInChildren<Text>();
            img_Search = btn_Search.GetComponent<Image>();

            ipt_Keyword.onValueChanged.AddListener(Ipt_Keyword_OnValueChanged);
            btn_Search.onClick.AddListener(Btn_Search_OnClick);
            btnCollector.OnItemClickEvent += BtnCollector_OnItemClickEvent;
        }

        /// <summary>
        /// Refresh data items and select.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="select"></param>
        /// <param name="caption"></param>
        public void Refresh(string[] items, int select = -1, string caption = null)
        {
            this.items.Clear();
            var keyword = string.Empty;
            if (items != null)
            {
                this.items.AddRange(items);
                if (select >= 0 && select < items.Length)
                {
                    keyword = items[select];
                }
            }
            Keyword = keyword;
            Caption = caption;
            btnCollector.SetGOActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        private void Ipt_Keyword_OnValueChanged(string keyword)
        {
            ShowSearchResults(keyword);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Btn_Search_OnClick()
        {
            if (string.IsNullOrEmpty(Keyword))
            {
                if (isNullMatchAll)
                {
                    if (btnCollector.IsGOActive)
                    {
                        btnCollector.SetGOActive(false);
                    }
                    else
                    {
                        ShowSearchResults(null);
                    }
                }
            }
            else
            {
                Keyword = string.Empty;
            }
            ipt_Keyword.OnSelect(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void BtnCollector_OnItemClickEvent(int index, string value)
        {
            Keyword = value;
            btnCollector.SetGOActive(false);
            onSelectEvent?.Invoke(index, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        protected void ShowSearchResults(string keyword)
        {
            SetSearchBtnOption(keyword);

            var selects = SearchDataItems(keyword);
            RefreshSearchItems(selects.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        protected void SetSearchBtnOption(string keyword)
        {
            var text = opn_Search.text;
            var image = opn_Search.image;
            if (!string.IsNullOrEmpty(keyword))
            {
                text = opn_Clear.text;
                image = opn_Clear.image;
            }
            txt_Search.text = text;
            img_Search.sprite = image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected List<string> SearchDataItems(string keyword)
        {
            var matches = new List<string>();
            if (string.IsNullOrEmpty(keyword))
            {
                if (isNullMatchAll)
                {
                    matches.AddRange(items);
                }
                return matches;
            }

            var key = keyword.ToLower();
            foreach (var item in items)
            {
                if (item.ToLower().Contains(key))
                {
                    matches.Add(item);
                }
            }
            return matches;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void RefreshSearchItems(string[] items)
        {
            btnCollector.Refresh(items);
            btnCollector.SetGOActive(items.Length > 0);
        }
    }
}