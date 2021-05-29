using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void ChoiceEventHandler();

    // Each Action Component will be of this type.
    public class MenuActionItem : MenuItem
    {
        public event ChoiceEventHandler Clicked;

        public MenuActionItem(string i_title, MenuItem i_parent):base(i_title, i_parent.Level+1, i_parent)
        { }

        public override void Work()
        {
            Console.Clear();
            OnClicked();
            m_parent.Work();
        }

        private void OnClicked()
        {
            Clicked.Invoke();
        }
    }
}
