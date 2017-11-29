using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace TestCon
{
    class Program
    {

        public static void presser()
        {
            InputSimulator hachi = new InputSimulator();

            hachi.Keyboard.KeyDown(VirtualKeyCode.MENU);
            hachi.Keyboard.KeyPress(VirtualKeyCode.TAB);
            System.Threading.Thread.Sleep(30);
            hachi.Keyboard.KeyPress(VirtualKeyCode.TAB);
            hachi.Keyboard.KeyUp(VirtualKeyCode.MENU);
            System.Threading.Thread.Sleep(30);

            //while (true)
            //{
            //    hachi.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.VK_H);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.VK_O);
            //    hachi.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            //    hachi.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            //}

        }

        public string currentNum = "000";


        private void currentNumIterator()
        {
            int current;
            string currentstring;
            Int32.TryParse(currentNum, out current);
            current += 1;
            currentstring = current.ToString();

            while (currentstring.Length < 3)
            {
                currentstring = currentstring.Insert(0, "0");
            }

            Console.WriteLine(currentstring);
            currentNum = currentstring;

        }

        static void Main(string[] args)
        {
            string current = "000";
            DateTime now = DateTime.UtcNow.Date;
            string currentNum = "000";
            Console.WriteLine(now.ToString("M-d-") + currentNum);

            //for (int i = 0; i < 200; i++)
            //{
            //    currentNumIterator();
            //}
            //System.Threading.Thread.Sleep(50000);
            //presser();
            Console.Read();

        }


    }
}
