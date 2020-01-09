﻿using PlanningCenter.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PlanningCenter.Api.QueryObjects {
    public class BaseQO {
        public BaseQO() {
            PageNumber = 1;
            PageSize = 25;
        }

        private List<string> _includes = new List<string>();

        public void AddInclude(params string[] include) {
            _includes.AddRange(include);
        }

        [QO("include")]
        public string Include {
            get {
                if (_includes.Count == 0) {
                    return null;
                }

                return string.Join(" ", _includes.ToArray());
            }
        }

        public int? PageNumber { get; set; }

        [QO("per_page")]
        public int? PageSize { get; set; }

        [QO("offset")]
        public int? Offset {
            get {
                if (PageNumber.HasValue && PageSize.HasValue) {
                    return (PageNumber - 1) * PageSize; 
                }

                return 0;
            }
        }

        internal string ToQueryString() { //non-encoded query string
            StringBuilder sb = new StringBuilder();

            var dict = ToDictionary();
            foreach (var key in dict.Keys) {
                sb.Append(key).Append('=').Append(dict[key]).Append('&');
            }

            return sb.ToString().TrimEnd('&');
        }

        internal Dictionary<string, string> ToDictionary() {
            var ret = new Dictionary<string, string>();
            var props = this.GetType().GetProperties();

            foreach (PropertyInfo p in props) {
                if (!IgnoreProperty(p)) {
                    if (IsRightType(p.PropertyType)) {
                        object value = p.GetValue(this, null);
                        if (value != null && value.ToString() != string.Empty) {// null means the property won't be the part of search parameters
                            //ret.Add(GetKey(p), value.ToString());
                            DateTime? d = value as Nullable<DateTime>;
                            if (d != null) { // DateTime need special handling for converting to string.
                                string format = GetFormat(p);
                                ret.Add(GetKey(p), d.Value.ToString(format == null ? "yyyy-MM-ddTHH:mm:ssZ" : format));
                            }
                            else {
                                ret.Add(GetKey(p), value.ToString());
                            }
                        }
                    }
                    else {
                        var message = "All the properties in the DataAccess query object have to be nullable primitive or nullabel datetime or nullable enum or string, property \"" + p.Name + "\" has type : " + p.PropertyType.ToString();
                        throw new Exception(message);
                    }
                }
            }
            return ret;
        }

        private bool IgnoreProperty(PropertyInfo pi) {
            object[] pa = pi.GetCustomAttributes(typeof(QOIgnoreAttribute), false);
            return pa.Length > 0;
        }

        private string GetKey(PropertyInfo pi) {
            object[] pa = pi.GetCustomAttributes(typeof(QOAttribute), false);
            return pa.Length == 0 ? pi.Name : ((QOAttribute)pa[0]).Value;
        }

        private string GetFormat(PropertyInfo pi) {
            object[] pa = pi.GetCustomAttributes(typeof(QOAttribute), false);
            return pa.Length == 0 ? null : ((QOAttribute)pa[0]).Format;
        }

        private bool IsRightType(Type t) {

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                Type[] types = t.GetGenericArguments();
                if (types.Length != 1) // we only take one argument nullable type.
                    return false;
                else
                    t = types[0];
            }

            return AllowedType(t);
        }

        private bool AllowedType(Type t) {
            return t == typeof(string) || t == typeof(DateTime) || t == typeof(TimeSpan) || t == typeof(decimal) || t.IsPrimitive || t.IsEnum;
        }
    }
}
