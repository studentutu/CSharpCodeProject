/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ListJsonUtility.cs
 *  Description  :  Utility for List json.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Utility for List json.
    /// </summary>
    public sealed class ListJsonUtility
    {
        /// <summary>
        /// Deserialize List from avatar json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="json">Json text of ListAvatar.</param>
        /// <returns>List object.</returns>
        public static List<T> FromJson<T>(string json)
        {
            var avatar = JsonUtility.FromJson<ListAvatar<T>>(json);
            if (avatar == null)
            {
                return null;
            }

            return avatar.source;
        }

        /// <summary>
        /// Serialize List to avatar json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="list">Source list.</param>
        /// <returns>Json text of ListAvatar.</returns>
        public static string ToJson<T>(List<T> list)
        {
            var avatar = new ListAvatar<T>(list);
            return JsonUtility.ToJson(avatar);
        }

        /// <summary>
        /// Avatar for List serialize by JsonUtility.
        /// </summary>
        /// <typeparam name="T">Type of list item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        private class ListAvatar<T>
        {
            /// <summary>
            /// Source list.
            /// </summary>
            public List<T> source;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="source">Source list.</param>
            public ListAvatar(List<T> source)
            {
                this.source = source;
            }
        }
    }
}