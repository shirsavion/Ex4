using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public abstract class MenuItem  // MAYBE INTERNAL?
    {
        protected const int k_break = 0;
        protected int            m_level;
        protected string         m_title;
        protected List<MenuItem> m_children;
        protected MenuItem       m_parent;

        public MenuItem(string i_title, int i_level, MenuItem i_parent)
        {
            m_title = i_title;
            m_level = i_level;
            m_parent = i_parent;
        }

        public int Level
        {
            get
            {
                return m_level;
            }
        }

        public string Title
        {
            get
            {
                return m_title;
            }
        }

        // Menu type successor will run their menu,
        // Action type successor will do their job.
        public abstract void Work();

    }
}
