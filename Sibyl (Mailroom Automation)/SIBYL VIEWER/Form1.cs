using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WindowsInput;
using WindowsInput.Native;
using System.Media;

namespace SIBYL_VIEWER
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Current number determined by numberBox.
        /// </summary>
        public string currentNum { get; private set; }
        
        /// <summary>
        /// Current loop (box || env).
        /// True if boxes, false if envelopes. 
        /// Because fuck whoever gets to do envelopes.
        /// </summary>
        public bool loopProtocol { get; private set; }

        /// <summary>
        /// If the setup completes, turn to true. Else, it's false. 
        /// If it's false, you're an idiot.
        /// </summary>
        public bool setupComplete { get; set; }

        /// <summary>
        /// If you're at MHC, then good for you. 
        /// Have fun doing two packages. 
        /// </summary>
        public bool MHC { get; set; }

        /// <summary>
        /// If you are at Lassonde, 
        /// then innovation courses through you!
        /// </summary>
        public bool LSND { get; set; }

        /// <summary>
        /// The type of parcel being issued. 
        /// Possible: 
        /// Envelopes: 1 down
        /// Large box: 2
        /// OS: 3
        /// Small: 4
        /// Tube: 5
        /// </summary>
        public Dictionary<string, int> maria;
        public string typeKey = "small";

        /// <summary>
        /// The carrier. 
        /// Possible: 
        /// AMZL 1
        /// DHL 3
        /// FedEx 4
        /// OnTrac 5
        /// UPS 8
        /// USPS 9
        /// </summary>
        public Dictionary<string, int> draco;
        public string carrierKey = "usps";

        public InputSimulator hachi;

        public int sleepInterval = 25;

        SoundPlayer masterpiece001;
        /// <summary>
        /// Sets up the overarching dictionaries.
        /// </summary>
        public Form1()
        {

            masterpiece001 = new SoundPlayer("masterpiece001.wav");

            hachi = new InputSimulator();

            draco = new Dictionary<string, int>();
            draco["amazon"] = 1;
            draco["dhl"] = 3;
            draco["fedex"] = 4;
            draco["ontrac"] = 5;
            draco["ups"] = 8;
            draco["usps"] = 9;

            maria = new Dictionary<string, int>();
            maria["envelope"] = 1;
            maria["large"] = 2;
            maria["os"] = 3;
            maria["small"] = 4;
            maria["tube"] = 5;

            MHC = false;
            LSND = false;

            InitializeComponent();
        }

        /// <summary>
        /// When boxButton clicked, invokes initial setup. 
        /// Changes current loop protocol to be boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxButton_Click(object sender, EventArgs e)
        {
            initialNumSetup();
            loopProtocol = true;
            if (setupComplete) majorUxUpdate();
        }

        /// <summary>
        /// When boxButton clicked, invokes initial setup. 
        /// Changes current loop protocol to be envelopes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void envButton_Click(object sender, EventArgs e)
        {
            initialNumSetup();
            loopProtocol = false;
            if (setupComplete) majorUxUpdate();
        }

        /// <summary>
        /// Sets current number, unblits all unnecessary UI elements. 
        /// Sets up for next event loop~~!
        /// </summary>
        private void initialNumSetup()
        {
            int boxNumber;
            if (Int32.TryParse(numberBox.Text, out boxNumber)) // If numberBox can be parsed as an int. 
            {
                currentNum = numberBox.Text; // Current num is a string, unfortunately. 
                                             // It's because of the mail room's policy 'pro-leading zeroes.'
                setupComplete = true;

            }
            else
            { // Seriously, everyone should watch "Plastic Memories." It's a masterpiece. 
                // Either way, if it can't be an int, repeat. 
                // Think of this as a boss battle. 
                MessageBox.Show("'Error. I didn't quite get that.\n " +
                    "Please repeat the question.'", "Error!");
                setupComplete = false;
            }
        }

        /// <summary>
        /// Remember how Frieza transforms eight times? 
        /// It's like that, but only one time. 
        /// </summary>
        private void majorUxUpdate()
        {
            boxButton.Hide(); // "Darkness will prevail and the light expire!"
            envButton.Hide();
            numberBox.Hide();
            button1.Hide();
            button2.Hide();
            t1.Hide();
            t2.Hide();
            t3.Hide();
            t4.Hide();
            if (loopProtocol)
            {
                label1.Text = "sibyl: " + currentNum; // Displays the current num so confusion doesn't reign.
                                                            // Also, Sibyl is a cool name.
                label2.Text = "~BOXES~";

                enableCarrierButtons();

                smallBoxButton.Enabled = true;
                osBoxButton.Enabled = true;
                largeBoxButton.Enabled = true;
                tubeBoxButton.Enabled = true;
                masterpieceButton.Enabled = true;

            }
            else
            {
                label1.Text = "sibyl: " + currentNum;
                typeKey = "envelope";
                label2.Text = "~ENVELOPES~";
                enableCarrierButtons();
                masterpieceButton.Enabled = true;


            }
        }

        private void enableCarrierButtons()
        {
            dhlButton.Enabled = true;
            amzlButton.Enabled = true;
            fedexButton.Enabled = true;
            ontracButton.Enabled = true;
            upsButton.Enabled = true;
            uspsButton.Enabled = true;
            executeButton.Enabled = true;
        }

        /// <summary>
        /// BUTTON OPERATIONS
        /// </summary>
        private void largeBoxButton_Click(object sender, EventArgs e)
        {
            typeKey = "large";
            buttonColorChangerTypes();
            largeBoxButton.BackColor = Color.Orange;
            largeBoxButton.ForeColor = Color.Black;
        }

        private void osBoxButton_Click(object sender, EventArgs e)
        {
            typeKey = "os";
            buttonColorChangerTypes();
            osBoxButton.BackColor = Color.Orange;
            osBoxButton.ForeColor = Color.Black;
        }

        private void smallBoxButton_Click(object sender, EventArgs e)
        {
            typeKey = "small";
            buttonColorChangerTypes();
            smallBoxButton.BackColor = Color.Orange;
            smallBoxButton.ForeColor = Color.Black;
        }

        private void tubeBoxButton_Click(object sender, EventArgs e)
        {
            typeKey = "tube";
            buttonColorChangerTypes();
            tubeBoxButton.BackColor = Color.Orange;
            tubeBoxButton.ForeColor = Color.Black;
        }

        private void amzlButton_Click(object sender, EventArgs e)
        {
            carrierKey = "amazon";
            buttonColorChangerCarriers();
            amzlButton.BackColor = Color.Orange;
            amzlButton.ForeColor = Color.Black;
        }

        private void dhlButton_Click(object sender, EventArgs e)
        {
            carrierKey = "dhl";
            buttonColorChangerCarriers();
            dhlButton.BackColor = Color.Orange;
            dhlButton.ForeColor = Color.Black;
        }

        private void fedexButton_Click(object sender, EventArgs e)
        {
            carrierKey = "fedex";
            buttonColorChangerCarriers();
            fedexButton.BackColor = Color.Orange;
            fedexButton.ForeColor = Color.Black;
        }

        private void ontracButton_Click(object sender, EventArgs e)
        {
            carrierKey = "ontrac";
            buttonColorChangerCarriers();
            ontracButton.BackColor = Color.Orange;
            ontracButton.ForeColor = Color.Black;
        }

        private void upsButton_Click(object sender, EventArgs e)
        {
            carrierKey = "ups";
            buttonColorChangerCarriers();
            upsButton.BackColor = Color.Orange;
            upsButton.ForeColor = Color.Black;
        }

        private void uspsButton_Click(object sender, EventArgs e)
        {
            carrierKey = "usps";
            buttonColorChangerCarriers();
            uspsButton.BackColor = Color.Orange;
            uspsButton.ForeColor = Color.Black;
        }

        /// <summary>
        /// "Elohim, Essaim... I implore you."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void executeButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now.Date; // NTP is 'da bomb. System clock won't fail, presumably.
            //Clipboard.SetText(currentdate.ToString("M-d-") + currentNum);

            string boarder = currentdate.ToString("M-d-") + currentNum; // format: 6-7-000

            if (MHC == true)
            {
                //boarder preappend M.
                boarder = boarder.Insert(0, "M");
            }
            if (LSND == true)
            {
                //boarder preappend L. 
                boarder = boarder.Insert(0, "L");
            }

            Clipboard.SetText(boarder);

            hachi.Keyboard.KeyDown(VirtualKeyCode.MENU);
            System.Threading.Thread.Sleep(sleepInterval);
            hachi.Keyboard.KeyPress(VirtualKeyCode.TAB); // Switches back to the StarRez window.
            System.Threading.Thread.Sleep(sleepInterval);
            hachi.Keyboard.KeyUp(VirtualKeyCode.MENU);

            System.Threading.Thread.Sleep(sleepInterval);

            hachi.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                hachi.Keyboard.KeyPress(VirtualKeyCode.TAB); // Gets the cursor in the starting position.
                System.Threading.Thread.Sleep(sleepInterval);
            }
            hachi.Keyboard.KeyUp(VirtualKeyCode.SHIFT);

            System.Threading.Thread.Sleep(sleepInterval);

            hachi.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            System.Threading.Thread.Sleep(sleepInterval);
            hachi.Keyboard.KeyPress(VirtualKeyCode.VK_V); // Pastes the clipboard.
            System.Threading.Thread.Sleep(sleepInterval);
            hachi.Keyboard.KeyUp(VirtualKeyCode.CONTROL);

            System.Threading.Thread.Sleep(sleepInterval);

            hachi.Keyboard.KeyPress(VirtualKeyCode.TAB);
            System.Threading.Thread.Sleep(sleepInterval);

            for (int i = 0; i < maria[typeKey]; i++)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                hachi.Keyboard.KeyPress(VirtualKeyCode.DOWN); // Selects type of parcel.
                System.Threading.Thread.Sleep(sleepInterval);
            }

            System.Threading.Thread.Sleep(sleepInterval);
            hachi.Keyboard.KeyPress(VirtualKeyCode.TAB);
            System.Threading.Thread.Sleep(sleepInterval);

            for (int i = 0; i < draco[carrierKey]; i++)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                hachi.Keyboard.KeyPress(VirtualKeyCode.DOWN); // Selects type of parcel.
                System.Threading.Thread.Sleep(sleepInterval);
            }

            System.Threading.Thread.Sleep(sleepInterval);

            hachi.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            System.Threading.Thread.Sleep(sleepInterval);

            currentNumIterator();

            label1.Text = "sibyl: " + currentNum;


        }
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

            currentNum = currentstring;

        }
        private void buttonColorChangerTypes()
        {
            largeBoxButton.BackColor = Color.Black;
            smallBoxButton.BackColor = Color.Black;
            tubeBoxButton.BackColor = Color.Black;
            osBoxButton.BackColor = Color.Black;

            largeBoxButton.ForeColor = Color.White;
            smallBoxButton.ForeColor = Color.White;
            tubeBoxButton.ForeColor = Color.White;
            osBoxButton.ForeColor = Color.White;
        }

        private void buttonColorChangerCarriers()
        {
            amzlButton.BackColor = Color.Black;
            upsButton.BackColor = Color.Black;
            uspsButton.BackColor = Color.Black;
            ontracButton.BackColor = Color.Black;
            dhlButton.BackColor = Color.Black;
            fedexButton.BackColor = Color.Black;

            amzlButton.ForeColor = Color.White;
            upsButton.ForeColor = Color.White;
            uspsButton.ForeColor = Color.White;
            ontracButton.ForeColor = Color.White;
            fedexButton.ForeColor = Color.White;
            dhlButton.ForeColor = Color.White;

        }

        private void masterpiece001wavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                masterpiece001.Play();
            }
            catch (Exception)
            {

                MessageBox.Show("I hate whoever removed the audio file.");
            }
        }

        private void masterpieceButton_Click(object sender, EventArgs e)
        {
            masterpiece001.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LSND = false;
            MHC = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LSND = true;
            MHC = false;
        }

        ///
        /// END BUTTON OPERATIONS
        /// 
    }
}
