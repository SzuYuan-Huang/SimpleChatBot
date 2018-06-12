using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatBotResponse.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "lu3bjI19f3tWdY/9wFj9Nh7gyKp5ztm71ynDGffoD2ub1gkLdGR4eHvmdZaSn0F4ZwcB4TjEacY1Ebz5HBbSOCy7ytKn3VxUg/XIqvE0HFiA6rS3IAIQo7erIEzowK2hMHM47Zmny/bJZf+YtC/GawdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U1283329d6502dd9bbd6d5845de3d996c";
        const string GoogleApi = "AIzaSyDDqJDqsBjIa6u7iFeNP_IdbNWXvc4v0cU";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text")//收到文字
                    {
                        if (LineEvent.message.text.Contains("Hello"))
                        {
                            this.ReplyMessage(LineEvent.replyToken, this.GetUserInfo(LineEvent.source.userId).displayName + "你好");                           
                        }
                        else
                        {
                            this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                        }
                    }
                    if (LineEvent.message.type == "sticker")//收到貼圖
                    {
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    }
                        
                    if (LineEvent.message.type == "location")
                    {
                        int i = 0;
                        var client = new WebClient();
                        byte[] bResult = client.DownloadData("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + LineEvent.message.latitude + "," + LineEvent.message.longitude + "&radius=500&types=food&key=" + GoogleApi + "&language=zh-TW");
                        string result = Encoding.UTF8.GetString(bResult);
                        dynamic json = JValue.Parse(result);
                        string data = "";
                        foreach (var item in json.results)
                        {
                            string name = item.name;
                            string vicinity = item.vicinity;
                            data += name + Environment.NewLine + vicinity + Environment.NewLine + Environment.NewLine;
                        }
                        this.ReplyMessage(LineEvent.replyToken, data);
                    }
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
