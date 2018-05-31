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

        protected void Button3_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回復", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriAction() { label = "標題-開啟URL", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postback", data = "abc=aaa&def=111" });

            var ButtonTemplateMsg = new isRock.LineBot.ButtonsTemplate()
            {
                title = "選項",
                text = "請選擇其中之一",
                altText = "請在手機上顯示",
                thumbnailImageUrl = new Uri("https://pics.me.me/which-one-would-you-choose-dream-job-love-of-your-5581703.png"),
                actions = actions
            };
            bot.PushMessage(AdminUserId, ButtonTemplateMsg);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "Yes", text = "Yes" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "NO", text = "NO" });

            var ConfirmTemplate = new isRock.LineBot.ConfirmTemplate()
            {
                text = "請選擇其中之一",
                altText = "請在手機上顯示",
                actions = actions
            };
            bot.PushMessage(AdminUserId, ConfirmTemplate);

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //建立Bot instance
            isRock.LineBot.Bot bot =
                new isRock.LineBot.Bot(channelAccessToken);  //傳入Channel access token

            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageActon() { label = "標題-文字回覆", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriActon() { label = "標題-Google", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackActon() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            //單一Column 
            var Column = new isRock.LineBot.Column
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201706/22-124357-ad3c87d6-b9cc-488a-8150-1c2fe642d237.png"),
                actions = actions //設定回覆動作
            };

            //建立CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

            //這是範例，所以用一組樣板建立三個
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);
            //發送 CarouselTemplate
            bot.PushMessage(AdminUserId, CarouselTemplate);
        }
    }
}