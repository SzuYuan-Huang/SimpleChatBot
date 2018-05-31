using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatBot
{
    public partial class ChatBotWebForm : System.Web.UI.Page
    {
        string ChannelAccessToken = "cErP0hwiBxTszWiiREgYUOxonU9JqahDJ/303eCMRwILDObOtwl0PAgirVrB510YZwcB4TjEacY1Ebz5HBbSOCy7ytKn3VxUg/XIqvE0HFhnDh4btEUwH6Z01+9HWUfJPnTQIIZCRtDeXUQxPKBwKQdB04t89/1O/w1cDnyilFU=";
        string AdminUserId = "U1283329d6502dd9bbd6d5845de3d996c";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);

            bot.PushMessage(AdminUserId, "test");
            bot.PushMessage(AdminUserId,1,1);
            bot.PushMessage(AdminUserId, new Uri("https://cdn0.iconfinder.com/data/icons/black-logistics-icons/256/Robotics.png"));
            
        }
    }
}