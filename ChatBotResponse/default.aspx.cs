using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatBotResponse
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "lu3bjI19f3tWdY/9wFj9Nh7gyKp5ztm71ynDGffoD2ub1gkLdGR4eHvmdZaSn0F4ZwcB4TjEacY1Ebz5HBbSOCy7ytKn3VxUg/XIqvE0HFiA6rS3IAIQo7erIEzowK2hMHM47Zmny/bJZf+YtC/GawdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U1283329d6502dd9bbd6d5845de3d996c";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}