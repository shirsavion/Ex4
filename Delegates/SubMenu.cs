using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // Each Menu Item that is not the main one neither an action, will be of this type.
    public class SubMenu : MenuItem
    {
        public SubMenu(string i_title, MenuItem i_parent):base(i_title, i_parent.Level+1, i_parent)
        {
        }

        public List<MenuItem> Children
        {
            get
            {
                return m_children;
            }
        }

        public override void Work()
        {
            int inputChoice, idxForPrint;
            string finish = this is MainMenu ? "Exit" : "Back";
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu: {0} , Current level: {1}", m_title, m_level);
                Console.WriteLine("Please choose:");
                idxForPrint = 1;
                foreach (MenuItem item in m_children)
                {
                    Console.WriteLine("{0}. {1}", idxForPrint++, item);
                }

                Console.WriteLine("{0}. {1}", k_break, finish);
                inputChoice = getInputFromUser();
                if (inputChoice == k_break) // back to parent or exit
                {
                    if(!(this is MainMenu))
                    {
                        m_parent.Work();
                    }

                    keepRunning = false;
                }
                else // forward to child
                {
                    m_children[--inputChoice].Work();
                }
            }
            
        }

        private int getInputFromUser()
        {
            string genuineInput;
            int numericInputVal;
            bool inputValidity = true;

            do
            {
                genuineInput = Console.ReadLine();
                inputValidity = int.TryParse(genuineInput, out numericInputVal);
                if (inputValidity)
                {
                    inputValidity = numericInputVal > 0 && numericInputVal <= m_children.Count;
                }

                if(!inputValidity)
                {
                    Console.WriteLine("Please choose a valid index,{0}between 1 and {1}:", Environment.NewLine, m_children.Count);
                }

            } while (!inputValidity);

            return numericInputVal;
        }


    }
}
