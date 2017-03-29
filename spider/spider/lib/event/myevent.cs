using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mywork
{
    public class networkevent : EventArgs
    {

        public networkevent(string jj, object ff)
        {

            this.massage = jj;
            this.mm = ff;

        }
        private string massage;
        private object mm;
        public object getobject()
        {

            return this.mm;

        }
        public string getstring()
        {


            return massage;

        }


    }


    public class handmassageenevt
    {

        public event EventHandler<networkevent> mnetworkevent;
        public handmassageenevt()
        {



        }

        public void sendmassage(object mm)
        {

            EventHandler<networkevent> hmnetworkevent = mnetworkevent;
            if (mm != null)
            {

                hmnetworkevent(this, new networkevent("xiaoxichenggong", mm));

            }






        }






    }
    public class hand_udp_massage_event
    {

        public event EventHandler<networkevent> mnetworkevent;
        public hand_udp_massage_event()
        {



        }

        public void sendmassage(object mm)
        {

            EventHandler<networkevent> hmnetworkevent = mnetworkevent;
            if (mm != null)
            {

                hmnetworkevent(this, new networkevent("xiaoxichenggong", mm));

            }






        }








    }

    //事件订阅
    public class su
    {

        // private EventHandler<networkevent> vv;
        public su(handmassageenevt ff)
        {

            ff.mnetworkevent += HandleCustomEvent;

        }
        public void HandleCustomEvent(object sender, networkevent e)
        {
            Console.WriteLine(" received this message: {0}", e.getstring());
        }



    }



}
