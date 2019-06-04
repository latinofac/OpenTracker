using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class Images
    {
        public System.Drawing.Bitmap GetImageResource(string imagePath)
        {
            System.Drawing.Bitmap image = null;
            switch (imagePath)
            {
                case "2h":
                    image = OpenTracker.Properties.Resources._2h;
                    break;
                case "2d":
                    image = OpenTracker.Properties.Resources._2d;
                    break;
                case "2c":
                    image = OpenTracker.Properties.Resources._2c;
                    break;
                case "2s":
                    image = OpenTracker.Properties.Resources._2s;
                    break;
                case "3h":
                    image = OpenTracker.Properties.Resources._3h;
                    break;
                case "3d":
                    image = OpenTracker.Properties.Resources._3d;
                    break;
                case "3c":
                    image = OpenTracker.Properties.Resources._3c;
                    break;
                case "3s":
                    image = OpenTracker.Properties.Resources._3s;
                    break;
                case "4h":
                    image = OpenTracker.Properties.Resources._4h;
                    break;
                case "4d":
                    image = OpenTracker.Properties.Resources._4d;
                    break;
                case "4c":
                    image = OpenTracker.Properties.Resources._4c;
                    break;
                case "4s":
                    image = OpenTracker.Properties.Resources._4s;
                    break;
                case "5h":
                    image = OpenTracker.Properties.Resources._5h;
                    break;
                case "5d":
                    image = OpenTracker.Properties.Resources._5d;
                    break;
                case "5c":
                    image = OpenTracker.Properties.Resources._5c;
                    break;
                case "5s":
                    image = OpenTracker.Properties.Resources._5s;
                    break;
                case "6h":
                    image = OpenTracker.Properties.Resources._6h;
                    break;
                case "6d":
                    image = OpenTracker.Properties.Resources._6d;
                    break;
                case "6c":
                    image = OpenTracker.Properties.Resources._6c;
                    break;
                case "6s":
                    image = OpenTracker.Properties.Resources._6s;
                    break;
                case "7h":
                    image = OpenTracker.Properties.Resources._7h;
                    break;
                case "7d":
                    image = OpenTracker.Properties.Resources._7d;
                    break;
                case "7c":
                    image = OpenTracker.Properties.Resources._7c;
                    break;
                case "7s":
                    image = OpenTracker.Properties.Resources._7s;
                    break;
                case "8h":
                    image = OpenTracker.Properties.Resources._8h;
                    break;
                case "8d":
                    image = OpenTracker.Properties.Resources._8d;
                    break;
                case "8c":
                    image = OpenTracker.Properties.Resources._8c;
                    break;
                case "8s":
                    image = OpenTracker.Properties.Resources._8s;
                    break;
                case "9h":
                    image = OpenTracker.Properties.Resources._9h;
                    break;
                case "9d":
                    image = OpenTracker.Properties.Resources._9d;
                    break;
                case "9c":
                    image = OpenTracker.Properties.Resources._9c;
                    break;
                case "9s":
                    image = OpenTracker.Properties.Resources._9s;
                    break;
                case "Th":
                    image = OpenTracker.Properties.Resources.Th;
                    break;
                case "Td":
                    image = OpenTracker.Properties.Resources.Td;
                    break;
                case "Tc":
                    image = OpenTracker.Properties.Resources.Tc;
                    break;
                case "Ts":
                    image = OpenTracker.Properties.Resources.Ts;
                    break;
                case "Jh":
                    image = OpenTracker.Properties.Resources.Jh;
                    break;
                case "Jd":
                    image = OpenTracker.Properties.Resources.Jd;
                    break;
                case "Jc":
                    image = OpenTracker.Properties.Resources.Jc;
                    break;
                case "Js":
                    image = OpenTracker.Properties.Resources.Js;
                    break;
                case "Qh":
                    image = OpenTracker.Properties.Resources.Qh;
                    break;
                case "Qd":
                    image = OpenTracker.Properties.Resources.Qd;
                    break;
                case "Qc":
                    image = OpenTracker.Properties.Resources.Qc;
                    break;
                case "Qs":
                    image = OpenTracker.Properties.Resources.Qs;
                    break;
                case "Kh":
                    image = OpenTracker.Properties.Resources.Kh;
                    break;
                case "Kd":
                    image = OpenTracker.Properties.Resources.Kd;
                    break;
                case "Kc":
                    image = OpenTracker.Properties.Resources.Kc;
                    break;
                case "Ks":
                    image = OpenTracker.Properties.Resources.Ks;
                    break;
                case "Ah":
                    image = OpenTracker.Properties.Resources.Ah;
                    break;
                case "Ad":
                    image = OpenTracker.Properties.Resources.Ad;
                    break;
                case "Ac":
                    image = OpenTracker.Properties.Resources.Ac;
                    break;
                case "As":
                    image = OpenTracker.Properties.Resources.As;
                    break;
                case "redCard":
                    image = OpenTracker.Properties.Resources.redCard;
                    break;
                default:
                    break;
            }

            return image;
        }
    }
}
