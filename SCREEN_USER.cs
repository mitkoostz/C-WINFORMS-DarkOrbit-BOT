using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOT
{
    public class SCREEN_USER
    {
        //This class saves user's screen size.
        //when program searchs color it uses 10 tasks 
        //every task scan 1/10 from screen height and screen full width
        //example: if screen is 1600width 900height
        //first TASK will scan first 90p height and their all width!


       public static int totalWidth = Screen.PrimaryScreen.Bounds.Width;
       public static int totalHeight = Screen.PrimaryScreen.Bounds.Height;

        public static int heightScanPart = Screen.PrimaryScreen.Bounds.Height / 10;  //my laptop height - 900   so 900/10 = 90 


     }
}
