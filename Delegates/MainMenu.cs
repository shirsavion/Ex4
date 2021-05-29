using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // Only the main menu will be of this type.
    public class MainMenu : SubMenu
    {
        public MainMenu(string i_title) : base(i_title, null)
        {
            m_level = 0;    // Main menu is base level, all other levels derive from it's ancestry.
        }

        public void Show()
        {
            Work();
        }

    }
}
