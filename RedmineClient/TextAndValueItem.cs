using System;

namespace RedmineClient
{
    public class TextAndValueItem
    {
        public string Text { set; get; }
        public object Value { set; get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
