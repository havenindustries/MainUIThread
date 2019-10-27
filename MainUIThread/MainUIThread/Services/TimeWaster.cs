using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MainUIThread.Services
{
    class TimeWaster
    {

        public async Task<bool> WasteTime()
        {
            int cnt = 0;
            string mess = string.Empty;
            while (cnt <= 10)
            {
                mess = "Round " + cnt.ToString();
                MessagingCenter.Send<string>(mess, "TestMessage");
                await Task.Delay(5000);
            }

            return true;
        }


    }

}
