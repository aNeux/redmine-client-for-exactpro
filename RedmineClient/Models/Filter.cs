using System;

namespace RedmineClient.Models
{
    /// <summary>
    /// Перечисление возможных объектов фильтрации.
    /// </summary>
    public enum FilterObjects { Status, Tracker, Priority, Privacy, StartDate, Subject, EstimatedTime, DoneRatio, Author, Assignee };
    /// <summary>
    /// Перечисление возможных условий фильтрации.
    /// </summary>
    public enum FilterConditions { IS, ISNOT, CONTAINS, DOESNT_CONTAIN, MORE_OR_EQUAL, LESS_OR_EQUAL, BEETWEN };

    /// <summary>
    /// Представление настроек одного объекта фильтрации.
    /// </summary>
    public class Filter
    {
        public FilterObjects Obj { set; get; }
        public FilterConditions Condition { set; get; }
        public object Value { set; get; }

        public Filter(FilterObjects obj, FilterConditions сondition, object value)
        {
            this.Obj = obj;
            this.Condition = сondition;
            this.Value = value;
        }
    }
}
